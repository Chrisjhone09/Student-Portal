import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Faculty } from '../admin/add-faculty/faculty';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
 private api = "https://localhost:7095/api"

  constructor(private http: HttpClient, private auth : AuthService) { }

  addFaculty(faculty : Faculty) : Observable<any> {
    return this.http.post(this.api+"/admin/add-faculty", faculty, this.auth.createHttpOptions());
  }

  getFacultyList() {
    return this.http.get(this.api + "/admin/faculty-list", this.auth.createHttpOptions())
  }
}
