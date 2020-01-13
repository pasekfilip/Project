import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  private ID_UserSource = new BehaviorSubject<number>(2);
  currentID_User = this.ID_UserSource.asObservable();
  constructor() { }

  changeID_User(ID:number)
  {
    this.ID_UserSource.next(ID);
  }
}
