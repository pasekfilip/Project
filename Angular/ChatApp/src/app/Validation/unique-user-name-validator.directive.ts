import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { Observable } from 'rxjs';
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
