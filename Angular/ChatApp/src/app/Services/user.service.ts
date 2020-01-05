import { Injectable } from '@angular/core';
import { User } from '../Models/user';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {


  private url: string = 'http://localhost:49497/api/Users';
  constructor(private http: HttpClient) { }

  findAll(): Observable<User[]> {
    return this.http.get<User[]>(this.url);
  }
  registr(userData) {
    return this.http.post<any>(this.url, userData);
  }
  // getIfUserExists(uName: string)
  // {
  //   return this.http.get<boolean>(`${this.url}/${uName}`);
  // }
  getUserByUserName(uName: string): Observable<User> | null {
    return this.http.get<User>(`${this.url}/${uName}`);
  }

}
