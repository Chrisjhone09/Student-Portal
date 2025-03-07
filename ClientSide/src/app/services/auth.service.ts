import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserRegister } from '../models/user-register';
import { LoginModel } from '../models/login-model';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedin = false;
  private userSubject = new BehaviorSubject<any>(null);
  user$ = this.userSubject.asObservable();
  errorMessage: string | undefined;
  invalidStudentIdErrorMessage: string | undefined;


  private api = "https://localhost:7095/api"

  constructor(private http: HttpClient, private route: Router) {
    const savedUser = localStorage.getItem('student');
    if (savedUser) {
      try {
        const parsedUser = JSON.parse(savedUser);
        this.userSubject.next(parsedUser);
      } catch (error) {
        console.error('Failed to parse saved user:', error);
        localStorage.removeItem('student');
      }
    }
  }


  register(user: UserRegister) {
    return this.http.post<any>(this.api + '/account/register', user);
  }
  login(user: LoginModel) {
    this.http.post<any>(this.api + "/account/login", user).subscribe({
      next: (response) => {
        console.log("API Response:", response);
        if (response && response.token) {
          localStorage.setItem('token', response.token);
          localStorage.setItem('student', JSON.stringify(response));
          this.userSubject.next(response);
          this.isLoggedin = true;
          if (response.firstname == "Chris Jhone") {
            this.route.navigate(["/portal"])
          }
          this.route.navigate(['/portal']);
        } else {
          console.error("Invalid response format from API");
        }
      },
      error: (err) => {
        console.error("Login failed:", err.message);
        this.errorMessage = "Invalid password or email"
      }
    });
  }
  logout() {
    this.isLoggedin = false;
    this.http.post(this.api + '/account/logout', {}, {
      withCredentials: true,
      observe: 'response',
      responseType: 'text',
    }).subscribe({
      next: (success) => {
        localStorage.removeItem('token');
        localStorage.removeItem('student');
        console.log("User has logged out");
        this.route.navigate(['/login']);
      }, error: (error) => { console.log(error) }
    })
  }

  getToken(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('token') || ''}`
    });
  }

  getTokenPatchMethod(){
    return new HttpHeaders({
      'Content-Type': 'application/json-patch+json',
      'Authorization': `Bearer ${localStorage.getItem('token') || ''}`
    });
  }

  createHttpOptions() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      })
    };
  }
}
