import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from 'src/app/Services/auth.service';
// import { ifUserExists, loginAsyncValidator } from 'src/app/Validation/login-validation';
import { loginUser } from '../../Models/loginUser';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
 
  
 
  constructor(private auth:AuthService,private router:Router,private Cookie:CookieService,) {}
  model: loginUser = new loginUser();
  valid:boolean;
  loginData:loginUser = new loginUser();
  
  ngOnInit() : void{
    this.auth.logOut();
  }
  onLogin()
  {
    this.loginData.userName = this.model.userName;
    this.loginData.password = this.model.password;
    this.auth.logUser(this.loginData).pipe(
      map(data => {
        if(data == null)
        {
          this.valid = true;
          return null;
        }
        else
        {
          this.saveTokenAndNavigateHome(data);
          return data;
        }

      })
    ).subscribe();
      

  }
  saveTokenAndNavigateHome(token: string)
  {
    this.Cookie.set('token',token);
    this.router.navigate(['/Home']);
  }
  
}

