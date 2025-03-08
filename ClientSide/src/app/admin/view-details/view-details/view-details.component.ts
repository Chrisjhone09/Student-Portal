import { Component, Inject, OnInit } from '@angular/core';
import { AdminService } from '../../../services/admin.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Faculty } from '../../models-and-DTO/faculty';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { FacultyComponent } from '../../navigations/faculty-list/faculty/faculty.component';

@Component({
  selector: 'app-view-details',
  imports: [CommonModule, FormsModule],
  templateUrl: './view-details.component.html',
  styleUrl: './view-details.component.css'
})
export class ViewDetailsComponent implements OnInit {


  isEditing : boolean = false;
  facultyId : string = ""

  faculty : Faculty = new Faculty()
  originFacultyDetails = {...this.faculty}

  constructor(private adminService : AdminService, @Inject(MAT_DIALOG_DATA) public data: { facultyId: string },
              private matDialog: MatDialog, private route : Router, private dialogRef: MatDialogRef<FacultyComponent>){
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
    const patchDoc = []

    if(this.faculty.facultyId !== this.originFacultyDetails.facultyId){
      patchDoc.push({'op': 'replace', path: '/facultyId', value: this.faculty.facultyId})
    }
    if(this.faculty.firstName !== this.originFacultyDetails.firstName){
      patchDoc.push({'op': 'replace', path: '/firstName', value: this.faculty.firstName})
    }
    if(this.faculty.middleName !== this.originFacultyDetails.middleName){
      patchDoc.push({'op': 'replace', path: '/middleName', value: this.faculty.middleName})
    }
    if(this.faculty.lastName !== this.originFacultyDetails.lastName){
      patchDoc.push({'op': 'replace', path: '/lastName', value: this.faculty.lastName})
    }
    if(this.faculty.role !== this.originFacultyDetails.role){
      patchDoc.push({'op': 'replace', path: '/role', value: this.faculty.role})
    }


    this.adminService.updateFacultyDetails(this.faculty.facultyId.toString(), patchDoc).subscribe({
      next: (response) => {
        this.dialogRef.close('success')
        
      }
    })
    
  }

}
