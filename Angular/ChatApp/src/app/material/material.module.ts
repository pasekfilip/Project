import { NgModule } from '@angular/core';
import { MatDialogModule, MatFormFieldModule, MatButtonModule, MatInputModule, MatRippleModule, MatToolbarModule, MatCardModule, MatTableModule, MatMenuModule, MatIconModule, MatProgressSpinnerModule } from '@angular/material'
import { CommonModule } from '@angular/common';

const MaterialComponents = [
  CommonModule,
  MatButtonModule, 
  MatCardModule,
  MatInputModule,
  MatDialogModule,
  MatTableModule,
  MatMenuModule,
  MatIconModule,
  MatProgressSpinnerModule,
  MatRippleModule
];
@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
