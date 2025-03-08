import { Component, OnInit } from '@angular/core';
import { FooterComponent } from "../../footer/footer.component";
import { AuthService } from '../../services/auth.service';
import { Schedule } from '../../models/schedule';
import { DataService } from '../../services/data.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-portal',
  imports: [CommonModule, RouterLink],
  templateUrl: './portal.component.html',
  styleUrl: './portal.component.css'
})
export class PortalComponent implements OnInit {
  schedule : Schedule[] = []
  student : any;
constructor(private service : AuthService, private data : DataService) {}
  ngOnInit(): void {
    this.service.user$.subscribe({
      next: (user) => {
        console.log('Fetched student data:', user); // Add this log
        this.student = user;
      },
      error: (err) => {
        console.error('Error fetching user data:', err);
      }
    });
    this.data.getHomeData().subscribe({
      next : (reponse) => {
        this.schedule = reponse as Schedule[]
      },
      error : (error) => 
        console.log(error)
    })
  }
 
}
