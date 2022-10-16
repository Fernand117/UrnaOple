import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EsperaElectorComponent } from './espera-elector.component';

describe('EsperaElectorComponent', () => {
  let component: EsperaElectorComponent;
  let fixture: ComponentFixture<EsperaElectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EsperaElectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EsperaElectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
