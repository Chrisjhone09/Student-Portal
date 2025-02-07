import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UserRegister } from '../models/user-register';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  imports: [RouterLink, CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  errorMessage : string = "";
  userInfo = new UserRegister();
  isPasswordMatched : boolean = false;
  constructor(private service: AuthService, private route : Router) {}
  
  register() {
    if (this.userInfo.password !== this.userInfo.confirmPassword) {
      this.isPasswordMatched = true
      return;
    }
    if(this.userInfo.password === this.userInfo.confirmPassword )
    this.isPasswordMatched = false
    this.service.register(this.userInfo).subscribe({
      next: (response) => {
        this.route.navigate(['/login'])
      },
      error: (error) => {
        
      },
    });

    
  }

  
  
}
