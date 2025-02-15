import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AuthService } from '../auth.service';
import { DataService } from '../data.service';
import { Schedule } from '../models/schedule';

@Component({
  selector: 'app-home',
  imports: [RouterLink, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  schedule = new Schedule()
  student : any;
  constructor(private authService: AuthService, private data : DataService) {
  }
  ngOnInit(): void {
    this.authService.user$.subscribe({
      next: (user) => {
        console.log('Fetched student data:', user); // Add this log
        this.student = user;
      },
      error: (err) => {
        console.error('Error fetching user data:', err);
      }
    });

    this.data.getHomeData().subscribe ( {
      next : (response) => {
        this.schedule = response as Schedule
      }
    })
  }
  
}
