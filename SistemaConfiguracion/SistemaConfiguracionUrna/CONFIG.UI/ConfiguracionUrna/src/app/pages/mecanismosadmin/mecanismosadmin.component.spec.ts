import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MecanismosadminComponent } from './mecanismosadmin.component';

describe('MecanismosadminComponent', () => {
  let component: MecanismosadminComponent;
  let fixture: ComponentFixture<MecanismosadminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MecanismosadminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MecanismosadminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
