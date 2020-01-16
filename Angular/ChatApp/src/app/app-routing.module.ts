import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './Pages/home-page/home-page.component';
import { LoginPageComponent } from './Pages/login-page/login-page.component';
import { SignUpPageComponent } from './Pages/sign-up-page/sign-up-page.component';
import { AuthGuard } from './Validation/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: "/Login", pathMatch: 'full' },
  { path: 'Login', component: LoginPageComponent },
  { path: 'SignUp', component: SignUpPageComponent },
  { path: 'Home', component: HomePageComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponenets = [LoginPageComponent, SignUpPageComponent, HomePageComponent];