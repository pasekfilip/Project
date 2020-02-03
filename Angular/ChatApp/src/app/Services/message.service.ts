import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { message } from '../Models/message';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private url:string = 'http://localhost:49497/api/';
  constructor(private http:HttpClient) { }
  private headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })}
  sendMessageToDb(message:message) : Observable<message>
  {
    return this.http.post<message>(`${this.url}`+`Message`,message);
  }
  getAllTheMessages(idChat:number) : Observable<message[]>
  {
    return this.http.get<message[]>(`${this.url}`+`Message`+`/${idChat}`);
  }
  getLastMessage(ids:number[]) :Observable<message>
  {
    return this.http.post<message>(`${this.url}Message/Last`,ids,this.headers);
  }
}
