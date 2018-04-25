import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';


import { Contract } from './contract';
import { ContractSearch } from './contractSearch';
import { ContractSearchResult } from './contractSearchResult';
import { CONTRACTS } from './mock-contracts';
import { CONTRACTS_SEARCH } from './mock-contracts';
import { MessageService } from './message.service';

@Injectable()
export class ContractService {

  constructor(private messageService: MessageService) { }

  getContracts(): Observable<Contract[]> {
    var items = of(CONTRACTS);
    this.messageService.add('ContractService: fetched contracts');
    return items;
  } 

  findContract(id: number): Observable<Contract> {
    // TODO: send the message _after_ fetching the hero
    this.messageService.add(`ContractService: fetched contract id=${id}`);
    return of(CONTRACTS.find(item => item.id === id));
  }

  findContracts(model: ContractSearch): Observable<ContractSearchResult[]> {
    // TODO: send the message _after_ fetching the hero
    // this.messageService.add(`ContractService: searched contracts for number=${model.number} and enterprseId=${model.enterpriseId}`);
    var items = CONTRACTS_SEARCH.filter(x => x.enterpriseId === model.enterpriseId);
    return of(CONTRACTS_SEARCH);
  }

  checkPincode(pinCode: string, id: number): Observable<boolean>
  {
    return of(false);
  }
}
