import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiputacionesComponent } from './diputaciones.component';

describe('DiputacionesComponent', () => {
  let component: DiputacionesComponent;
  let fixture: ComponentFixture<DiputacionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiputacionesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiputacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
