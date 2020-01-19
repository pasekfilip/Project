import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private http:HttpClient) { }

  private url:string = "http://localhost:49497/api/Chat_Members/";
  private headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })}
  GetChatID(Ids:number[]) : Observable<number>
  {
    return this.http.post<number>(`${this.url}/ChatID`,Ids,this.headers);
  }

}
