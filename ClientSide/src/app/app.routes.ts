import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { EnrollComponent } from './enroll/enroll.component';
import { PortalComponent } from './portal/portal.component';

export const routes: Routes = [
    {path: 'register', component: RegisterComponent},
    {path: 'login', component : LoginComponent},
    {path:'', redirectTo: 'login', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'portal', component: PortalComponent}
];
