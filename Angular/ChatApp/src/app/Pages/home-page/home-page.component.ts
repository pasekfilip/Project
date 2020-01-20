import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { interval } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { message } from 'src/app/Models/message';
import { User } from 'src/app/Models/user';
import { FriendService } from 'src/app/Services/friend.service';
import { MessageService } from 'src/app/Services/message.service';
import { UserService } from 'src/app/Services/user.service';
import { MatDialog , MatDialogConfig} from '@angular/material'
import { FriendDialogComponent } from 'src/app/friend-dialog/friend-dialog.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  messageForm: FormGroup;
  modelUserName: string;
  ID_User: number;
  sendMessage: message = new message();
  messages: message[];
  users: User[];
  ID_Chat: number = 1;

  constructor(private router: ActivatedRoute, private userService: UserService, private fb: FormBuilder,
    private messageService: MessageService, private Cookie: CookieService, private friendService: FriendService,public dialog:MatDialog) {

    const token = this.Cookie.get('token');
    const decodedToken = jwt_decode(token);
    this.modelUserName = decodedToken['name'];
    this.messageService.getAllTheMessages(this.ID_Chat).subscribe(data => this.messages = data);
    this.userService.getUserByUserName(this.modelUserName).pipe(
      map(data => {
        this.ID_User = data.ID
      })).subscribe(data => {
        console.log(this.ID_User)
        this.getFriends();
      });

  }

  ngOnInit() {
    this.createForm();
    this.refresh();
  }
  createForm() {
    this.messageForm = this.fb.group(
      {
        message: ['']
      }
    )
  }

  onSend(): void {
    var currentDate = new Date();
    this.sendMessage.ID_User = this.ID_User;
    this.sendMessage.TheMessage = this.messageForm.controls['message'].value;
    this.sendMessage.ID_Chat = this.ID_Chat;
    this.sendMessage.Send_Time = currentDate.toISOString().slice(0, 19).replace("T", " ");
    this.sendMessage.Del_Msg_Time = currentDate.toISOString().slice(0, 19).replace("T", " ");

    this.messageService.sendMessageToDb(this.sendMessage)
      .subscribe(() => { this.refresh() },
        error => console.log('error', error));
    this.messageForm.reset();

  }
  refresh() {
    const source = interval(5000);
    source.pipe(
      map(data => {
        this.messageService.getAllTheMessages(this.ID_Chat).subscribe(data => this.messages = data);
      })
    ).subscribe();
  }
  getFriends() {
    this.friendService.getAllTheFriendsByID_User(this.ID_User).
    pipe(map(data => data.map(f => f.ID_Friend))).subscribe(data => this.userService.getUsersByIDs(data).pipe(
      tap(data => console.log(data))
    ).subscribe(_users => this.users = _users));
  }
  receiveChatID($event)
  {
    console.log($event);
    this.ID_Chat = $event;
    this.refresh();
  }
  openDialog()
  {
    let dialogConfig = new MatDialogConfig(); 
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = {data: {ID_User: this.ID_User}}
    let dialogRef = this.dialog.open(FriendDialogComponent,dialogConfig);
      
    dialogRef.afterClosed().subscribe((data) => {console.log(data); setTimeout(() => this.getFriends(),2000)});
  }
}
