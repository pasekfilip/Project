import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routingComponenets } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms'
import { FormsModule } from '@angular/forms';
import { } from './app-routing.module'
import { UserService } from './Services/user.service';
import { UniqueUserNameValidatorDirective } from './Validation/unique-user-name-validator.directive';
import { HomePageComponent } from './Pages/home-page/home-page.component';
import { MessagesComponent } from './Content/messages/messages.component';
import { NavComponent } from './Content/nav/nav.component';
import { MessageService } from './Services/message.service';
import { FriendsPageComponent } from './Pages/friends-page/friends-page.component';
import { FriendService } from './Services/friend.service';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from './Services/auth.service';
import { AuthGuard } from './auth.guard';
@NgModule({
  declarations: [
    AppComponent,
    routingComponenets,
    UniqueUserNameValidatorDirective,
    HomePageComponent,
    MessagesComponent,
    NavComponent,
    FriendsPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [UserService, MessageService, FriendService, CookieService,AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
