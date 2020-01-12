import { Directive } from '@angular/core';
import { AbstractControl, AsyncValidator, NG_ASYNC_VALIDATORS, ValidationErrors, AsyncValidatorFn } from '@angular/forms';
import { Observable, observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserService } from '../Services/user.service';


export function UniqueUserNameValidator(userService: UserService): AsyncValidatorFn {
  return (input: AbstractControl): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> => {
    return userService.getUserByUserName(input.value).pipe(
      map(result => {
        return result != null && result.UserName == input.value ? { 'UniqueUserName': true } : null;
      })

    )
  }
}




@Directive({
  selector: '[UniqueUserName]',
  providers: [{ provide: NG_ASYNC_VALIDATORS, useExisting: UniqueUserNameValidatorDirective, multi: true }]
})
export class UniqueUserNameValidatorDirective implements AsyncValidator {

  constructor(private userService: UserService) { }
  validate(input: AbstractControl): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    return this.userService.getUserByUserName(input.value).pipe(
      map(result => {
        return result != null && result.UserName == input.value ? null : { 'UniqueUserName': true };
      })
    )
  }
}
