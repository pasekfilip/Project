import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
// import { ifUserExists, loginAsyncValidator } from 'src/app/Validation/login-validation';
import { loginUser } from '../../Models/loginUser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
 
  
 
  constructor(private loginService:UserService,private router:Router) {}
  model: loginUser = new loginUser();
  
  ngOnInit() {
    
  }
  
}

