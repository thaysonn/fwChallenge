import { Component, OnInit } from '@angular/core';
import { LeadStatusDto } from '../../web-api-client';
import { LeadService } from '../services/lead.service';

@Component({
  selector: 'app-lead',
  templateUrl: './lead.component.html',
  styleUrls: ['./lead.component.scss']
})
export class LeadComponent implements OnInit {
  public selectedOption: LeadStatusDto = new LeadStatusDto();
  public tabOptions: LeadStatusDto[] = [];

  constructor(private service: LeadService) {
    service.getOptions().subscribe(result => {
      this.tabOptions = result;
      this.selectTab(this.tabOptions[0]);
    }, error => console.error(error));
  }

  ngOnInit(): void { }

  selectTab(opt: LeadStatusDto): void {
    this.selectedOption = opt;
  }
}
