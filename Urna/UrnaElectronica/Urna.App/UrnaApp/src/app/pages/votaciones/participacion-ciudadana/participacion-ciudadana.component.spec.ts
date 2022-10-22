import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParticipacionCiudadanaComponent } from './participacion-ciudadana.component';

describe('ParticipacionCiudadanaComponent', () => {
  let component: ParticipacionCiudadanaComponent;
  let fixture: ComponentFixture<ParticipacionCiudadanaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParticipacionCiudadanaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ParticipacionCiudadanaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
