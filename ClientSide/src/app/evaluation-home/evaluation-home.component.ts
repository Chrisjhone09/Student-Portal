import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { DataService } from '../services/data.service';
import { Instructor } from '../models/instructor';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-evaluation-home',
  imports: [RouterLink, CommonModule],
  templateUrl: './evaluation-home.component.html',
  styleUrl: './evaluation-home.component.css'
})
export class EvaluationHomeComponent implements OnInit {


  instructors: Instructor[] = [];

  constructor(private data : DataService, private route : Router){}
  ngOnInit(): void {
    this.data.getInstructorsList().subscribe({
      next: (reponse) => {
        this.instructors = reponse as Instructor[]
      }
    })
  }
  
}
