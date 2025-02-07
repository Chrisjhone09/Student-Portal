import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-home',
  imports: [RouterLink, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  constructor(public service : AuthService) {}
  student : any;
  ngOnInit () {
    const studentData = localStorage.getItem('student'); // Retrieve the data from localStorage

    if (studentData) {
      this.student = JSON.parse(studentData); // Parse the data if it's not null
      console.log('Student:', this.student); // Access and use the parsed data
    } else {
      console.error('No student data found in localStorage'); // Handle the null case
    }
  }
}
