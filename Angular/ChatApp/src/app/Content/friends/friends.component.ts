import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/Models/user';
import { ChatService } from 'src/app/Services/chat.service';
import { FriendService } from 'src/app/Services/friend.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit {

  @Input() users: User[];
  @Input() ID_User: number;
  @Output() idChat = new EventEmitter<number>();
  private idFriend : number;
  constructor(private router: ActivatedRoute, private friendService: FriendService, private chatService: ChatService) {
  }

  ngOnInit() { 
  }
  sendIdChat(id:number)
  {
    this.idFriend = id;
    const Ids = [this.ID_User,this.idFriend];
    this.chatService.GetChatID(Ids).subscribe(x => this.idChat.emit(x));
  }

}



