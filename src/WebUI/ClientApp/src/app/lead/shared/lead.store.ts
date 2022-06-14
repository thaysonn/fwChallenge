import { BehaviorSubject, Observable } from "rxjs";
import { map } from "rxjs/operators";
import { LeadDto } from "../../web-api-client";

export interface State {
  invitedLeads: LeadDto[],
  acceptedLeads: LeadDto[]
}
 
export class Store {
  private subject = new BehaviorSubject<State>({
    acceptedLeads: [],
    invitedLeads: []
  });
  private store = this.subject.asObservable();

  get value() { return this.subject.value; };

  set(name: string, state: any) {
    this.subject.next({
      ...this.value, [name]: state
    });
  };

  public getInvitedLeads(): Observable<LeadDto[]>{
    return this.store.pipe(map(store => store.invitedLeads));
  }

  public getAcceptedLeads(): Observable<LeadDto[]> {
    return this.store.pipe(map(store => store.acceptedLeads));
  }
}
