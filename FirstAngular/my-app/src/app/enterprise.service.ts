import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { MessageService } from './message.service';

import { KeyValue } from './keyValue';
import { ENTERPRISES } from './mock-enterprises';

@Injectable()
export class EnterpriseService {

  constructor(private messageService: MessageService) { }

  getEnterpriseList(): Observable<KeyValue[]> {
    var items = of(ENTERPRISES);
    this.messageService.add('EnterpriseService: fetched list of enterprises');
    return items;
  } 

}