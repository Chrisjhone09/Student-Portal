import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddFacultyComponent } from './add-faculty/add-faculty.component';
import { Faculty } from './add-faculty/faculty';
import { AdminService } from '../services/admin.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin',
  imports: [CommonModule, FormsModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit {

  faculty: Faculty[] = []

  constructor(private matDialog: MatDialog, private adminService : AdminService){}
  ngOnInit(): void {
    this.adminService.getFacultyList().subscribe({
      next: (response) => {
        this.faculty = response as Faculty[]
      },
      error : (error) => {
        console.log(error)
      }
    })
  }
  addFaculty() {
    this.matDialog.open(AddFacultyComponent, {
      height: '600px',
      width: '500px'
    })
  }
}
