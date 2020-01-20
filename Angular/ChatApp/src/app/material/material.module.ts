import { NgModule } from '@angular/core';
import { MatDialogModule, MatFormFieldModule, MatButtonModule, MatInputModule, MatRippleModule } from '@angular/material'

const MaterialComponents = [
  MatDialogModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatRippleModule
];
@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
