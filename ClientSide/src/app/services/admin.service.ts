import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Faculty } from '../admin/models-and-DTO/faculty';
import { AuthService } from './auth.service';
import { CreateDepartmentDTO } from '../admin/models-and-DTO/create-department-dto';

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

  getStudentList() {
    return this.http.get(this.api + "/admin/student-list", this.auth.createHttpOptions())
  }

  getUserList() {
    return this.http.get(this.api + "/admin/user-list", this.auth.createHttpOptions())
  }
  createDepartment(departmentObj : CreateDepartmentDTO){
    return this.http.post(this.api + '/admin/create-program', departmentObj, this.auth.createHttpOptions())
  }

  getDepartmentList(){
    return this.http.get(this.api + '/admin/program-list', this.auth.createHttpOptions())
  }

  viewFacultyDetails(facultyId : string){
    return this.http.get(this.api + `/admin/faculty-details/${facultyId}`, this.auth.createHttpOptions())
  }

  updateFacultyDetails(faculty : Faculty | undefined){
    return this.http.put(this.api + `/update-faculty/${faculty?.facultyId}`, faculty, this.auth.createHttpOptions())
  }
  
}
