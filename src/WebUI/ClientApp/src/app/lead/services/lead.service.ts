import { Injectable } from '@angular/core'; 
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { BaseService } from '../../services/base.service';
import { NotificationService } from '../../services/notification.service';
import { AcceptCommand, DeclineCommand, LeadDto, LeadsClient, LeadStatusDto } from '../../web-api-client';
import { Store } from '../shared/lead.store';

@Injectable({
  providedIn: 'root'
})
export class LeadService extends BaseService {
  constructor(private client: LeadsClient, private notificationService: NotificationService, private store: Store) { super(); }

  public getOptions(): Observable<LeadStatusDto[]> { return this.client.getOptions(); }

  getInvited$: Observable<LeadDto[]> =
    this.client.getInvited()
      .pipe(tap(next => this.store.set('invitedLeads', next)));

  getAccepted$: Observable<LeadDto[]> =
    this.client.getAccepted()
    .pipe(tap(next => this.store.set('acceptedLeads', next)));
   
  public accept(id: number): void {
    this.client.accept(id, { id: id } as AcceptCommand)
      .subscribe(result => {
        this.notificationService.success('Lead has been Accepted!', 'Success!');
        this.updateStore(id); 
      }, error => this.erro(error));
  }

  public decline(id: number): void {
    this.client.decline(id, { id: id } as DeclineCommand)
      .subscribe(result => {
        this.notificationService.success('Lead has been Declined!', 'Success');
        this.updateStore(id); 
      }, error => this.erro(error));
  }

  private erro(err: any) {
    console.log(err);
    this.notificationService.warning('Help us improve your experience by sending an error report', 'Oops! Something went wrong!')
  }

  private updateStore(id: number) { 
    const temp = this.store.value.invitedLeads.filter((lead: LeadDto) => {
      return lead.id != id;
    })
    this.store.set("invitedLeads", temp);
  }
}
