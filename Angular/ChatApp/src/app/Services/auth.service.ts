import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }
  private url: string = "http://localhost:49497/api/Token";
  private headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}
  loggedIn(userName: string) : Observable<any>
  {
    return this.http.post(this.url,JSON.stringify(userName),this.headers);
  }

}
