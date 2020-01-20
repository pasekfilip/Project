import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { friend } from '../Models/friend';
import { searchFriend } from '../Models/searchFriend';

@Injectable({
  providedIn: 'root'
})
export class FriendService {

  constructor(private http:HttpClient) { }
  private url:string = "http://localhost:49497/api/Friends/"
  getAllTheFriendsByID_User(id:number): Observable<friend[]>
  {
    return this.http.get<friend[]>(`${this.url}/UserID/`+`${id}`);
  }
  searchForFriends(friend:searchFriend) : Observable<any>
  {
    return this.http.post<any>(`${this.url}SearchForFriend`,friend);
  }
  createFriend(friend:searchFriend)
  {
    return this.http.post(`${this.url}CreateFriend`,friend).subscribe();
  }
}
