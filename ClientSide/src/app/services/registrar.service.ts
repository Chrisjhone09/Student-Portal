import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class RegistrarService {

  private api = "https://localhost:7095/api"

  constructor(private http: HttpClient, private authService : AuthService) { }

  getStudentList(){
    return this.http.get(this.api + "/admin/student-list", this.authService.createHttpOptions());
  }
}
