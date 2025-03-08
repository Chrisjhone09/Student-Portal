import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { EnrollComponent } from './enroll/enroll.component';
import { PortalComponent } from './student/portal/portal.component';
import { AuthGuardService } from './services/auth-guard.service';
import { EvaluationHomeComponent } from './student/portal/evaluation/evaluation-history/evaluation-home/evaluation-home.component';
import { InstructorEvaluationComponent } from './student/portal/evaluation/evaluation-history/instructor-evaluation/instructor-evaluation.component';
import { GradesComponent } from './student/portal/grades/grades.component';
import { EvaluationHistoryComponent } from './student/portal/evaluation/evaluation-history/evaluation-history.component';
import { AdminComponent } from './admin/admin.component';
import { FacultyComponent } from './admin/navigations/faculty-list/faculty/faculty.component';
import { UserComponent } from './admin/navigations/user-list/user/user.component';
import { RegistrarDashboardComponent } from './registrar/registrar-dashboard/registrar-dashboard.component';
import { StudentListComponent } from './registrar/student-list/student-list/student-list.component';
import { DepartmentComponent } from './admin/navigations/department/department.component';
import { ViewDetailsComponent } from './admin/view-details/view-details/view-details.component';

export const routes: Routes = [
    {path: 'register', component: RegisterComponent},
    {path: 'login', component : LoginComponent},
    {path:'', redirectTo: 'login', pathMatch: 'full'},
    {path: 'home', component: HomeComponent, },
    {path: 'portal', component: PortalComponent, },
    {path: 'evaluation/instructors', component: EvaluationHomeComponent},
    {path: 'evaluation/:instructorId', component: InstructorEvaluationComponent},
    {path: 'gradesView', component: GradesComponent},
    {path: 'evaluation-history', component: EvaluationHistoryComponent},
    {path: 'admin', component: AdminComponent, children: [
        {path: 'faculty-list',component: FacultyComponent},
        {path: '', redirectTo: "faculty-list", pathMatch: 'full'},
        {path: 'users', component: UserComponent},
        {path: 'department-list', component: DepartmentComponent},
        {path: 'faculty-details/:facultyId', component: ViewDetailsComponent}
    ]},
    {path: 'registrar-dashboard', component: RegistrarDashboardComponent, children: [
        {path:'student-list', component: StudentListComponent},
        {path: '', redirectTo: 'student-list', pathMatch: 'full'},
        
    ]}
];
