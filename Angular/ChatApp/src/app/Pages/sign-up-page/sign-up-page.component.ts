import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UniqueUserNameValidator } from 'src/app/Validation/unique-user-name-validator.directive';
import { UserService } from '../../Services/user.service';
import { User } from 'src/app/Models/user';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.scss']
})
export class SignUpPageComponent implements OnInit {

  registrationForm: FormGroup;
  user:User = new User;

  constructor(private registrationService: UserService, private fb: FormBuilder) { }

  ngOnInit() {
    this.createForm();
  }
  createForm() {
    this.registrationForm = this.fb.group(
      {
        userName: ['', [Validators.required, Validators.minLength(3)],
          UniqueUserNameValidator(this.registrationService)],
        email: ['', Validators.required],
        password: ['', Validators.required],
        file: ['']
      }
    )
  }

  get userName() {
    return this.registrationForm.get('userName');
  }
  get email() {
    return this.registrationForm.get('email')
  }
  get password() {
    return this.registrationForm.get('password');
  }
  handleUpload(event)
  {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => 
    {
      this.user.Picture = reader.result.toString();
    }
  }
  onSubmit() {
    this.user.UserName = this.userName.value;
    this.user.Password = this.password.value;
    this.user.Email = this.email.value;
    console.log(this.user);
    this.registrationService.registr(this.user)
      .subscribe(response => console.log('Success', response),
        error => console.log('error', error));
  }

}



