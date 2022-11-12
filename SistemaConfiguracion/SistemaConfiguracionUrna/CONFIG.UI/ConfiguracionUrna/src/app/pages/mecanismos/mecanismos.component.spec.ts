import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MecanismosComponent } from './mecanismos.component';

describe('MecanismosComponent', () => {
  let component: MecanismosComponent;
  let fixture: ComponentFixture<MecanismosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MecanismosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MecanismosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
