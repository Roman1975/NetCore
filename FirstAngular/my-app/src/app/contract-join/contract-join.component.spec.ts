import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractJoinComponent } from './contract-join.component';

describe('ContractJoinComponent', () => {
  let component: ContractJoinComponent;
  let fixture: ComponentFixture<ContractJoinComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContractJoinComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContractJoinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
