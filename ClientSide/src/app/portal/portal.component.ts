import { Component, OnInit } from '@angular/core';
import { FooterComponent } from "../footer/footer.component";
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-portal',
  imports: [FooterComponent],
  templateUrl: './portal.component.html',
  styleUrl: './portal.component.css'
})
export class PortalComponent implements OnInit {

  student : any;
constructor(private service : AuthService) {}
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
  }
 
}
