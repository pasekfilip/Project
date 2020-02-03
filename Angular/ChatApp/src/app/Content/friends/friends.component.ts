import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { friend } from 'src/app/Models/friend';
import { User } from 'src/app/Models/user';
import { ChatService } from 'src/app/Services/chat.service';
import { FriendService } from 'src/app/Services/friend.service';
import { message } from 'src/app/Models/message';
import { MessageService } from 'src/app/Services/message.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit {

  @Input() users: User[];
  @Input() ID_User: number;
  @Input() lastMessage: message;
  @Output() idChat = new EventEmitter<number>();
  idChatForDeletetingFriend: number;
  private idFriend: number;
  constructor(private router: ActivatedRoute, private friendService: FriendService, private chatService: ChatService, private messageService: MessageService) {
    
  }
  ngOnInit() {
  }
  sendIdChat(id: number) {
    this.idFriend = id;
    const Ids = [this.ID_User, this.idFriend];
    this.chatService.GetChatID(Ids).subscribe(x => this.idChat.emit(x));
  }
  deleteFriend(id: number) {
    const friends: friend = { ID_User: this.ID_User, ID_Friend: id };
    this.friendService.deleteFriend(friends).subscribe(() => console.log("ok"));
    this.users = this.users.filter(x => x.ID != id);

    this.idFriend = id;
    const Ids = [this.ID_User, this.idFriend];
    this.chatService.GetChatID(Ids).subscribe(x => {
    this.idChatForDeletetingFriend = x;
      this.chatService.DeleteChatAndAllTheMessages(x).subscribe();
    });
  }
}



