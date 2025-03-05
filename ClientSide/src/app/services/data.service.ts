import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  apiUrl = "https://localhost:7095/api/"

  constructor(private http: HttpClient, private auth : AuthService) { }

  getHomeData(): Observable<any> {
    return this.http.get(this.apiUrl + "portal", this.auth.createHttpOptions());
  }
  getInstructorsList(): Observable<any> {
    return this.http.get(this.apiUrl + "evaluation/instructors", this.auth.createHttpOptions());
  }

  getInstructorEvaluationForm(id: number) {
    return this.http.get(this.apiUrl + "evaluation/" + id, this.auth.createHttpOptions());
  }


  submitEvaluation(data: EvaluationData) {
    return this.http.post(this.apiUrl + "evaluation/submit", data, this.auth.createHttpOptions())
  }

}

export interface EvaluationData {
  instructorId: number;
  rating: number;
  feedback: string;
}
