import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { LeadComponent } from './lead/lead.component'; 
import { LeadAcceptedDetailsComponent } from './shared/details/lead-accepted-details/lead-accepted-details.component';
import { LeadInvitedDetailsComponent } from './shared/details/lead-invited-details/lead-invited-details.component';
import { LeadAcceptedListComponent } from './shared/list/lead-accepted-list/lead-accepted-list.component';
import { LeadInvitedListComponent } from './shared/list/lead-invited-list/lead-invited-list.component';
import { SharedModule } from '../shared/shared.module';
import { LeadListComponent } from './shared/list/lead-list/lead-list.component';
import { Store } from './shared/lead.store';
 
@NgModule({
  declarations: [
    LeadInvitedListComponent,
    LeadAcceptedListComponent,
    LeadComponent,
    LeadAcceptedDetailsComponent,
    LeadInvitedDetailsComponent,
    LeadListComponent, 
  ],
  providers: [Store],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class LeadModule { }
