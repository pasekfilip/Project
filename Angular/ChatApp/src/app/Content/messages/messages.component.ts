import { Component, OnInit, Input } from '@angular/core';
import { message } from 'src/app/Models/message';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  constructor(private userService:UserService) { }
  @Input() message: message;
 
  ngOnInit() {
  }
}
