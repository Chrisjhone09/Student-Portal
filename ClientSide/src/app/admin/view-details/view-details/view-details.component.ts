import { Component, Inject, OnInit } from '@angular/core';
import { AdminService } from '../../../services/admin.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Faculty } from '../../models-and-DTO/faculty';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-view-details',
  imports: [CommonModule, FormsModule],
  templateUrl: './view-details.component.html',
  styleUrl: './view-details.component.css'
})
export class ViewDetailsComponent implements OnInit {


  isEditing : boolean = false;
  facultyId : string = ""

  faculty : Faculty | undefined


  constructor(private adminService : AdminService, @Inject(MAT_DIALOG_DATA) public data: { facultyId: string }){
    this.facultyId = data.facultyId
  }
  ngOnInit(): void {
    this.adminService.viewFacultyDetails(this.facultyId).subscribe(data =>{
      this.faculty = data as Faculty
    })
  }

  toggleEdit() {
    this.isEditing = !this.isEditing;
  }
  
  save() {
    this.adminService.updateFacultyDetails(this.faculty).subscribe()
  }

}
