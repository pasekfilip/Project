import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { friend } from '../Models/friend';

@Injectable({
  providedIn: 'root'
})
export class FriendService {

  constructor(private http:HttpClient) { }
  private url:string = "http://localhost:49497/api/Friends/UserID/"
  getAllTheFriendsByID_User(id:number): Observable<friend[]>
  {
    return this.http.get<friend[]>(`${this.url}`+`${id}`);
  }
}
