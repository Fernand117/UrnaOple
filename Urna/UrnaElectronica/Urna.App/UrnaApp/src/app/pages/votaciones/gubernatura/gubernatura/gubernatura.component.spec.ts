import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GubernaturaComponent } from './gubernatura.component';

describe('GubernaturaComponent', () => {
  let component: GubernaturaComponent;
  let fixture: ComponentFixture<GubernaturaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GubernaturaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GubernaturaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
