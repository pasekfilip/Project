import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../Services/auth.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private authService:AuthService,private router:Router){}

  canActivate():Observable<boolean |boolean>
  {
    return this.authService.loggedIn().pipe(
      map(auth => {
        if(auth)
          return true
        else
        {
          this.router.navigate(['/Login']);
          return false
        }
      })
     
    )
  }
}
