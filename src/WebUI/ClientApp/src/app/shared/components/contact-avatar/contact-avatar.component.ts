import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact-avatar',
  templateUrl: './contact-avatar.component.html',
  styleUrls: ['./contact-avatar.component.scss']
})
export class ContactAvatarComponent implements OnInit {
  @Input() name: string = "";
  public colorToName: string = "";
  private alphabetColors: string[] = ["#A2B01F", "#F0B126", "#5C9BBC", "#F5888D", "#9A89B5", "#5A8770", "#407887", "#F5AF29", "#9A89B5", "#5A8770", "#D33F33", "#B2B7BB", "#5A8770", "#EEB424", "#0087BF", "#F18636", "#0087BF", "#72ACAE", "#9C8AB4", "#B2B7BB", "#6FA9AB", "#0088B9", "#F18636", "#D93A37", "#A6B12E", "#407887"];

  constructor() { }

  ngOnInit(): void {
    var index = Math.floor(this.name.charCodeAt(0) - 65) % this.alphabetColors.length;
    this.colorToName = this.alphabetColors[index];
  }
}
