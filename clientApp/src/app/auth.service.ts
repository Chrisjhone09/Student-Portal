import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RegisterModel } from './models/register-model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user = [];
  isLoggedIn : boolean = false;

  private apiUrl = "https://localhost:7095/api/";
  constructor(private http: HttpClient) {}

  login(cdkEmail: string, password: string): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { cdkEmail, password };
    this.isLoggedIn = true
    return this.http.post(this.apiUrl + 'login', body, { headers });
  }
  register(userInfo: RegisterModel): Observable<any> {
    return this.http.post<any>(this.apiUrl + 'register', userInfo); 
  }
  logout() {
    this.isLoggedIn =false;
    return this.http.post(this.apiUrl+'logout', {}, {
      withCredentials: true,
      observe: 'response',
      responseType: 'text',
    })
  }
}
