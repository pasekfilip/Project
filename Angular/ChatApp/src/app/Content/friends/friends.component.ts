import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/Models/user';
import { FriendService } from 'src/app/Services/friend.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit {

  @Input() users: User[];
  @Output() idChat = new EventEmitter<number>();
  constructor(private router: ActivatedRoute, private friendService: FriendService, private userService: UserService) {
  }

  ngOnInit() { 
  }
  sendidChat()
  {
    this.idChat.emit()
  }

}



