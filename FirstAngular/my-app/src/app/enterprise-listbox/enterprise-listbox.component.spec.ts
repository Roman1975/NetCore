import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnterpriseListboxComponent } from './enterprise-listbox.component';

describe('EnterpriseListboxComponent', () => {
  let component: EnterpriseListboxComponent;
  let fixture: ComponentFixture<EnterpriseListboxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnterpriseListboxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnterpriseListboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
