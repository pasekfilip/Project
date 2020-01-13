import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from 'src/app/Services/auth.service';
// import { ifUserExists, loginAsyncValidator } from 'src/app/Validation/login-validation';
import { loginUser } from '../../Models/loginUser';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
 
  
 
  constructor(private auth:AuthService,private router:Router,private Cookie:CookieService,) {}
  model: loginUser = new loginUser();
  
  ngOnInit() : void{
    
  }
  onLogin()
  {
    this.auth.loggedUser(this.model.userName).subscribe(res =>{
      this.Cookie.set('token',res)
      this.router.navigate(['/Home'])});
  }
}

