import { Component, OnInit, Output, EventEmitter  } from '@angular/core';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  pageTitle = 'Контакти';

  @Output() notify: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
    this.sendMessage();
  }

  sendMessage() {
    this.notify.emit(this.pageTitle)
  }
  

}
