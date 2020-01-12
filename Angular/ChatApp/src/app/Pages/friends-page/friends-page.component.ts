import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FriendService } from 'src/app/Services/friend.service';
import { friend } from 'src/app/Models/friend';
import { tap } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-friends-page',
  templateUrl: './friends-page.component.html',
  styleUrls: ['./friends-page.component.scss']
})

export class FriendsPageComponent implements OnInit {

  ID_User: number;
  Friends: friend[];
  constructor(private router: ActivatedRoute, private friendService: FriendService,Cookie:CookieService) {
    
  }

  ngOnInit() {
    this.friendService.getAllTheFriendsByID_User(this.ID_User).pipe(
      tap(data => console.log(data))
    ).subscribe(data => this.Friends = data);
  }

}
