import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-registrar-dashboard',
  imports: [RouterOutlet, RouterLink, CommonModule, FormsModule],
  templateUrl: './registrar-dashboard.component.html',
  styleUrl: './registrar-dashboard.component.css'
})
export class RegistrarDashboardComponent {

}
