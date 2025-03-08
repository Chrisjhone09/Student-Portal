import { Component } from '@angular/core';
import { Faculty } from '../models-and-DTO/faculty';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AdminService } from '../../services/admin.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-add-faculty',
  imports: [CommonModule, FormsModule],
  templateUrl: './add-faculty.component.html',
  styleUrl: './add-faculty.component.css'
})
export class AddFacultyComponent {

  isRegistrar: boolean = false
  isNotRegistrar: boolean = true;
  constructor(private adminService: AdminService, private route: Router, private mat: MatDialog) { }
  faculty: Faculty = new Faculty()
  onSubmit() {
    this.adminService.addFaculty(this.faculty).subscribe({
      next: (response) => {
        this.mat.closeAll();
        this.route.navigate(["/admin"])
      }, error: (err) => {
        console.log(err);
      }
    });
  }

  checkRegistrar() {
    this.isRegistrar = this.faculty.role === 'Registrar';
    this.isNotRegistrar = !this.isRegistrar; 
  }
  

}
