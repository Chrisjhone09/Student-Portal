import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { EnrollComponent } from './enroll/enroll.component';
import { PortalComponent } from './portal/portal.component';
import { AuthGuardService } from './services/auth-guard.service';
import { EvaluationHomeComponent } from './evaluation-home/evaluation-home.component';
import { InstructorEvaluationComponent } from './instructor-evaluation/instructor-evaluation.component';
import { GradesComponent } from './grades/grades.component';

export const routes: Routes = [
    {path: 'register', component: RegisterComponent},
    {path: 'login', component : LoginComponent},
    {path:'', redirectTo: 'login', pathMatch: 'full'},
    {path: 'home', component: HomeComponent, },
    {path: 'portal', component: PortalComponent, },
    {path: 'portal/evaluation', component: EvaluationHomeComponent},
    {path: 'evaluation/:instructorId', component: InstructorEvaluationComponent},
    {path: 'gradesView', component: GradesComponent},
    {path: 'evaluation/testPage', component: InstructorEvaluationComponent}
];
