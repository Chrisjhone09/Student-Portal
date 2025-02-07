import { Component } from '@angular/core';
import { Route, Router, RouterLink, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { RegisterModel } from '../models/register-model';
import { CommonModule, NgFor } from '@angular/common';
@Component({
  selector: 'app-register',
  imports: [RouterOutlet, FormsModule, CommonModule, NgFor],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  userInfo : RegisterModel = new RegisterModel;

    errorMessage = "";
    options : string[] = ["Information Technology / CPE", "Criminology", "Nursing", "Hospitality Management", "Education"]
  constructor(private auth: AuthService, private route : Router) {}
  register() {
    if (this.userInfo.password !== this.userInfo.confirmPassword) {
      this.errorMessage = 'Your password does not match';
      return;
    }
    if(this.userInfo.password === this.userInfo.confirmPassword )
    this.errorMessage = "";
    this.auth.register(this.userInfo).subscribe({
      next: (response) => {
        this.route.navigate(['/login'])
      },
      error: (error) => {
        this.errorMessage = 'Registration failed: ' + error.message;
      },
    });

    
  }
}
