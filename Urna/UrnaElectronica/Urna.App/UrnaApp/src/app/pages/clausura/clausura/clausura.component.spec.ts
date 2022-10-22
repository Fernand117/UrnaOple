import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClausuraComponent } from './clausura.component';

describe('ClausuraComponent', () => {
  let component: ClausuraComponent;
  let fixture: ComponentFixture<ClausuraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClausuraComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClausuraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
