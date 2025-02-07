import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {  Router, RouterLink } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-navigation',
  imports: [RouterLink, CommonModule],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.css'
})
export class NavigationComponent {
  isClicked = false;
  constructor(public service : AuthService, private route : Router){}

  MenuClicked() {
    if(this.isClicked == false) {
      this.isClicked = true
    } else this.isClicked = false
  }
  logout() {
    this.service.logout().subscribe({
      next: (success) => {
        localStorage.removeItem('token');
        console.log("User has logged out");
        this.route.navigate(['/login']);
      }, error: (error) => { console.log(error) }
    })
  }

}
