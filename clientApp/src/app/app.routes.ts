import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { AnnouncementComponent } from './announcement/announcement.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { GradesComponent } from './grades/grades.component';
import { EvaluationComponent } from './evaluation/evaluation.component';

export const routes: Routes = [
    {path:'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'home', component: HomeComponent, children: [
        { path: 'announcements', component: AnnouncementComponent},
        {path: 'classSchedule', component: ScheduleComponent},
        {path: 'grades', component: GradesComponent},
        {path: 'facultyEvaluation', component: EvaluationComponent},
        {path: '', redirectTo: 'announcements', pathMatch: 'full'}
    ]},
    {path: '', redirectTo: 'login', pathMatch: 'full'}
];
