import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, ObservedValueOf } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { loginUser } from '../Models/loginUser';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient,private cookie:CookieService) { }
  private url: string = "http://localhost:49497/api/Token";
  private headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}
  logUser(loginData:loginUser) : Observable<any>
  {
    return this.http.post(this.url,loginData,this.headers);
  }
  loggedIn() : Observable<boolean>
  {
     let result:boolean;
     return this.http.post<boolean>(`${this.url}/Validate`,JSON.stringify(this.cookie.get('token')),this.headers);
  }
  ifTokenExists()
  {
    return !!this.cookie.get('token');
  }
  logOut()
  {
    this.cookie.delete("token");
  }
}
