import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { map, publish, delay } from 'rxjs/operators';
import { message } from 'src/app/Models/message';
import { MessageService } from 'src/app/Services/message.service';
import { UserService } from 'src/app/Services/user.service';
import { Observable } from 'rxjs';


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
  constructor(private router: ActivatedRoute, private userService: UserService, private fb: FormBuilder, private messageService: MessageService) {
    this.modelUserName = this.router.snapshot.params['data'];
    this.userService.getUserByUserName(this.modelUserName).pipe(
      map(data => this.ID_User = data.ID)
    ).subscribe(data => console.log(this.ID_User));
    this.messageService.getAllTheMessages()
    .subscribe(data => this.messages = data);
  }

  ngOnInit() {
    this.createForm(); 
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
    this.sendMessage.ID_Chat = 1;
    this.sendMessage.Send_Time = currentDate.toISOString().slice(0, 19).replace("T", " ");
    this.sendMessage.Del_Msg_Time = currentDate.toISOString().slice(0, 19).replace("T", " ");

    this.messageService.sendMessageToDb(this.sendMessage)
      .subscribe(response => console.log('Success', response),
        error => console.log('error', error));
    this.refresh();
  }
  refresh()
  {
   this.messageService.getAllTheMessages().pipe(
     delay(500),
     map(() => this.messages.slice(this.messages.length -1, 1))
   ).subscribe(data => this.messages = data);
  }
}
