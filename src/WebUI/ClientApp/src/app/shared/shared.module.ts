import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactAvatarComponent } from './components/contact-avatar/contact-avatar.component';

@NgModule({
  declarations: [
    ContactAvatarComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [ContactAvatarComponent]
})
export class SharedModule { }
