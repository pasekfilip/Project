import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FriendsComponent } from '../Content/friends/friends.component';
import { searchFriend } from '../Models/searchFriend';
import { FriendService } from '../Services/friend.service';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-friend-dialog',
  templateUrl: './friend-dialog.component.html',
  styleUrls: ['./friend-dialog.component.scss']
})
export class FriendDialogComponent implements OnInit{

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,public dialogRef:MatDialogRef<FriendsComponent>,private fb:FormBuilder,private friendService:FriendService) { }
  addFriendForm:FormGroup;
  friend:searchFriend = new searchFriend;
  display:boolean;
  displayText:string;

  ngOnInit() {
    this.friend.ID_User = this.data.data.ID_User;
    this.createForm();
    console.log(this.friend.ID_User);
  }
  createForm()
  {
    this.addFriendForm = this.fb.group(
      {
        FriendName: ['', Validators.required]
      }
    );
  }
  onSubmit()
  {
    this.friend.FriendName = this.addFriendForm.value.FriendName;
    this.friendService.searchForFriends(this.friend).pipe(
      map(result => {
        
        if(result == true)
        {
          this.friendService.createFriend(this.friend);
          this.dialogRef.close("Success");
          return result;
        }
        else if(result.data == "User dosen't exist")
        {
          this.display = true;
          this.displayText = result.data;
          this.addFriendForm.controls['FriendName'].setErrors({'incorrect': true});
        }
        else if(result.data == "You have this User added already")
        {
          this.display = true;
          this.displayText = result.data;
          this.addFriendForm.controls['FriendName'].setErrors({'incorrect': true});
        }
      })
    ).subscribe();
  }
}
