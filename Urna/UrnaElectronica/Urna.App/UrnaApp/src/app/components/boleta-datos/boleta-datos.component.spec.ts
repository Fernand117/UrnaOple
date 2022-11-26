import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoletaDatosComponent } from './boleta-datos.component';

describe('BoletaDatosComponent', () => {
  let component: BoletaDatosComponent;
  let fixture: ComponentFixture<BoletaDatosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BoletaDatosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoletaDatosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
