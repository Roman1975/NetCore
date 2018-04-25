import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here

import { AppComponent } from './app.component';
import { ContractsComponent } from './contracts/contracts.component';
import { ContractService } from './contract.service';
import { MessagesComponent } from './messages/messages.component';
import { MessageService } from './message.service';
import { AppRoutingModule } from './/app-routing.module';
import { ContactsComponent } from './contacts/contacts.component';
import { ContractDetailComponent } from './contract-detail/contract-detail.component';
import { ContractSearchComponent } from './contract-search/contract-search.component';
import { EnterpriseListboxComponent } from './enterprise-listbox/enterprise-listbox.component';
import { ContractListComponent } from './contract-list/contract-list.component';
import { EnterpriseService } from './enterprise.service';
import { ContractJoinComponent } from './contract-join/contract-join.component';


@NgModule({
  declarations: [
    AppComponent,
    ContractsComponent,
    MessagesComponent,
    ContactsComponent,
    ContractDetailComponent,
    ContractSearchComponent,
    EnterpriseListboxComponent,
    ContractListComponent,
    ContractJoinComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
    ContractService,
    MessageService,
    EnterpriseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
