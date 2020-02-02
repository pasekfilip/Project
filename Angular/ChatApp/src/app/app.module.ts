import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule, routingComponenets } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms'
import { FormsModule } from '@angular/forms';
import { } from './app-routing.module'
import { UserService } from './Services/user.service';
import { HomePageComponent } from './Pages/home-page/home-page.component';
import { MessagesComponent } from './Content/messages/messages.component';
import { MessageService } from './Services/message.service';
import { FriendService } from './Services/friend.service';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from './Services/auth.service';
import { AuthGuard } from './Validation/auth.guard';
import { FriendsComponent } from './Content/friends/friends.component';
import { ChatService } from './Services/chat.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { FriendDialogComponent } from './friend-dialog/friend-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    routingComponenets,
    HomePageComponent,
    MessagesComponent,
    FriendsComponent,
    FriendDialogComponent
  ],
  entryComponents:[FriendDialogComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [UserService, MessageService, FriendService, CookieService,AuthService,ChatService,
  AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
