import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { friend } from 'src/app/Models/friend';
import { User } from 'src/app/Models/user';
import { FriendService } from 'src/app/Services/friend.service';
import { UserService } from 'src/app/Services/user.service';
import { map, filter } from 'rxjs/operators';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit {

  @Input() friends: friend[];
  users: User[];
  constructor(private router: ActivatedRoute, private friendService: FriendService, private userService: UserService) {

  }

  ngOnInit() {
    // this.dataService.currentID_User.subscribe(ID => this.ID_User = ID);
    // this.friendService.getAllTheFriendsByID_User(this.ID_User).pipe(
    //   tap(data => console.log(data))
    // ).subscribe(data => this.Friends = data);
    this.userService.findAll().pipe().subscribe(data => {this.users = data,console.log(data)});
    
      
   
     
        

  }

}



