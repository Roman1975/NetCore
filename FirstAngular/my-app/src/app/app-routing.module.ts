import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContractsComponent } from './contracts/contracts.component';
import { ContactsComponent } from './contacts/contacts.component';
import { ContractSearchComponent } from './contract-search/contract-search.component';
import { ContractDetailComponent } from './contract-detail/contract-detail.component';
import { ContractJoinComponent } from './contract-join/contract-join.component';

const routes: Routes = [
  { path: 'contracts', component: ContractsComponent },
  { path: 'search/join/:id', component: ContractJoinComponent },
  { path: 'contracts/:id', component: ContractDetailComponent },
  { path: 'contacts', component: ContactsComponent },
  { path: 'search', component: ContractSearchComponent },
  { path: '', redirectTo: '/contracts', pathMatch: 'full' },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}