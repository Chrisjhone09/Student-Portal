import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserRegister } from './models/user-register';
import { LoginModel } from './models/login-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
isLoggedin = false;
  private api = "https://localhost:7095/api"
  constructor(private http : HttpClient) { }
  register(user : UserRegister) {
    return this.http.post<any>(this.api + '/register', user);
  }
  login(user : LoginModel) : Observable<any> {
    this.isLoggedin = true;
    return this.http.post<any>(this.api +"/login", user)
  }
  logout() {
    this.isLoggedin =false;
    return this.http.post(this.api+'/logout', {}, {
      withCredentials: true,
      observe: 'response',
      responseType: 'text',
    })
  }

}
