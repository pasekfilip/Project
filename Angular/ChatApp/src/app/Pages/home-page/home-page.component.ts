import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { message } from 'src/app/Models/message';
import { MessageService } from 'src/app/Services/message.service';
import { UserService } from 'src/app/Services/user.service';


@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  messageForm: FormGroup;
  modelUserName: string;
  ID_User: number;
  theMessage: message = new message();
  constructor(private router: ActivatedRoute, private userService: UserService, private fb: FormBuilder, private messageService: MessageService) {
    this.modelUserName = this.router.snapshot.params['data'];
    this.userService.getUserByUserName(this.modelUserName).pipe(
      map(data => this.ID_User = data.ID)
    ).subscribe(data => console.log(this.ID_User));
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
    this.theMessage.ID_User = this.ID_User;
    this.theMessage.TheMessage = this.messageForm.controls['message'].value;
    this.theMessage.ID_Chat = 1;
    this.theMessage.Send_Time = currentDate.toISOString().slice(0,19).replace("T"," ");
    this.theMessage.Del_Msg_Time = currentDate.toISOString().slice(0,19).replace("T"," ");
   
    console.log(this.theMessage);
    this.messageService.sendMessageToDb(this.theMessage)
    .subscribe(response => console.log('Success', response),
    error => console.log('error', error))
  }
  // async gettingAllTheIforamtionAboutUser() : Promise<User>
  // {
  //   return await this.userService.getUserByUserName(this.modelUserName).toPromise();
  // }
}
