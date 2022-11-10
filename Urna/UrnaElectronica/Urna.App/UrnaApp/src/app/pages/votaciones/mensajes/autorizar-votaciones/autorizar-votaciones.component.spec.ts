import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutorizarVotacionesComponent } from './autorizar-votaciones.component';

describe('AutorizarVotacionesComponent', () => {
  let component: AutorizarVotacionesComponent;
  let fixture: ComponentFixture<AutorizarVotacionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AutorizarVotacionesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AutorizarVotacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
