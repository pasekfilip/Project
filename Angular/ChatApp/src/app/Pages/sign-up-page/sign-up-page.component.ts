import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UniqueUserNameValidator } from 'src/app/Validation/unique-user-name-validator.directive';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.scss']
})
export class SignUpPageComponent implements OnInit {

  registrationForm: FormGroup;

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
        password: ['', Validators.required]
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
  onSubmit() {
    this.registrationService.registr(this.registrationForm.value)
      .subscribe(response => console.log('Success', response),
        error => console.log('error', error));
  }

}



