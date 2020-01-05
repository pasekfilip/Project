// import { AbstractControl, ValidatorFn, FormControl } from '@angular/forms';
// import { UserService } from '../Services/user.service';
// import { delay, switchMap, map } from 'rxjs/operators';
// import { User } from '../Models/user';
// import { timer } from 'rxjs';
// // export function ifUserExists(control : AbstractControl) : {[key: string] : any } | null
// // {
// //     var userService: UserService
// //     return userService.getIfUserExists(control.value) ? null : {'this name is not registered': {value : control.value}};
// // }

// export function ifUserExists(userService: UserService): ValidatorFn {
//     return (control: AbstractControl): { [key: string]: any } | null => {
//         return userService.getIfUserExists(control.value) ? null : { 'exists': { value: control.value } };
//     }
// }


// export const loginAsyncValidator =
//     (userService: UserService, time: number = 500) => {
//         return (input: FormControl) => {
//             timer(time).pipe(
//                 map(res => {
//                     return userService.getIfUserExists(input.value) ? null : { 'exists': { value: input.value } }
//                 })
//             )
//         }
//     }