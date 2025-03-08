import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../../services/admin.service';
import { FacultyListAndCountDTO } from '../../../models-and-DTO/faculty-list-and-count-dto';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AddFacultyComponent } from '../../../add-faculty/add-faculty.component';
import { ViewDetailsComponent } from '../../../view-details/view-details/view-details.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-faculty',
  imports: [CommonModule, FormsModule],
  templateUrl: './faculty.component.html',
  styleUrl: './faculty.component.css'
})
export class FacultyComponent implements OnInit{

  dataObj: FacultyListAndCountDTO | undefined

  constructor(private adminService: AdminService, private matDialog: MatDialog,
              private route: Router){}
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
  addFaculty() {
    const dialogRef = this.matDialog.open(AddFacultyComponent, {
      height: '540px',
      width: '500px'
    })

    dialogRef.afterClosed().subscribe(data => {
      if(data == 'success'){
        this.loadData();
        this.route.navigate(['/admin/faculty-list'])
      }
    })

  }
  loadData() {
    this.adminService.getFacultyList().subscribe(response => {
      this.dataObj = response as FacultyListAndCountDTO
    })
  }

  viewDetails(facultyId : string) {
    this.matDialog.open(ViewDetailsComponent, {
      height: '550px',
      width: '500px',
      data: {facultyId : facultyId}
    })
  }
    

}
