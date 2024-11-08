import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventFormComponent } from './components/event-form/event-form.component';
import { EventListComponent } from './components/event-list/event-list.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'create', component: RegisterComponent },
  { path: 'register', component: EventFormComponent, canActivate: [AuthGuard] },
  { path: 'events', component: EventListComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: '/events', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
