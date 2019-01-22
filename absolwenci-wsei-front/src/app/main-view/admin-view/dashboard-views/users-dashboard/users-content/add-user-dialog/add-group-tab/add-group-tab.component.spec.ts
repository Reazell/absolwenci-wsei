import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGroupTabComponent } from './add-group-tab.component';

describe('AddGroupTabComponent', () => {
  let component: AddGroupTabComponent;
  let fixture: ComponentFixture<AddGroupTabComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddGroupTabComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGroupTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
