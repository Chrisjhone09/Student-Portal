import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddFacultyComponent } from './add-faculty/add-faculty.component';
import { Faculty } from './models-and-DTO/faculty';
import { AdminService } from '../services/admin.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Counts } from './models-and-DTO/counts';
import { FacultyListAndCountDTO } from './models-and-DTO/faculty-list-and-count-dto';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-admin',
  imports: [CommonModule, FormsModule, RouterOutlet, RouterLink],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit {
  counts : {stundentCount: number, facultyCount: number, userCount: number} | undefined;
  dataObj : FacultyListAndCountDTO = new FacultyListAndCountDTO();

  constructor(private adminService : AdminService){}
  ngOnInit(): void {
    this.adminService.getFacultyList().subscribe({
      next: (response) => {
        console.log(response)
        this.dataObj = response  as FacultyListAndCountDTO;
      },
      error : (error) => {
        console.log(error)
      }
    })
  }
  
}
export interface FacultyResponse {
  facultyList: Faculty[];
  counts: Counts;
}