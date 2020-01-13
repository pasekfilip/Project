import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

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
  loggedUser(userName: string) : Observable<any>
  {
    return this.http.post(this.url,JSON.stringify(userName),this.headers);
  }
  loggedIn()
  {
    return !!this.cookie.get('token');
  }
}
