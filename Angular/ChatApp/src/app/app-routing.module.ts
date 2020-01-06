import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginPageComponent} from './Pages/login-page/login-page.component';
import {SignUpPageComponent} from './Pages/sign-up-page/sign-up-page.component';
import {HomePageComponent} from './Pages/home-page/home-page.component'
import { FriendsPageComponent } from './Pages/friends-page/friends-page.component';

const routes: Routes = [
  {path: '', redirectTo: "/Login", pathMatch: 'full'},
  {path: 'Login', component: LoginPageComponent},
  {path: 'SignUp', component: SignUpPageComponent},
  {path: 'Home', component: HomePageComponent},
  {path: 'Friends', component: FriendsPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponenets = [LoginPageComponent,SignUpPageComponent,HomePageComponent];