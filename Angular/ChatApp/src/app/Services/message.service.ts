import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { message } from '../Models/message';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private url:string = 'http://localhost:49497/api/Message';
  constructor(private http:HttpClient) { }

  sendMessageToDb(message:message) : Observable<message>
  {
    return this.http.post<message>(this.url,message);
  }
}
