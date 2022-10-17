import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EleccionesEscolaresComponent } from './elecciones-escolares.component';

describe('EleccionesEscolaresComponent', () => {
  let component: EleccionesEscolaresComponent;
  let fixture: ComponentFixture<EleccionesEscolaresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EleccionesEscolaresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EleccionesEscolaresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
