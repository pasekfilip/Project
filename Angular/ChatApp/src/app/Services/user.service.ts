import { Injectable } from '@angular/core';
import { User } from '../Models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  
  
  private url: string = 'http://localhost:49497/api/Users';
  constructor(private http: HttpClient) { }
  private headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })}

  findAll(): Observable<User[]> {
    return this.http.get<User[]>(this.url);
  }
  registr(userData) {
    return this.http.post<any>(this.url, userData);
  }
  getUserByUserName(uName: string): Observable<User> | null {
    return this.http.post<User>(`${this.url}/FindByUserName`,JSON.stringify(uName),this.headers);
  }
  getUsersByIDs(UsersIDs: number[]): Observable<User[] | null>
  {
    return this.http.post<User[]>(`${this.url}/FindUsersByIDs`,UsersIDs,this.headers);
  }
}
