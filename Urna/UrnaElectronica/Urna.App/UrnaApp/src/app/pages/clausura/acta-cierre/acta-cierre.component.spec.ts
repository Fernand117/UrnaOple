import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActaCierreComponent } from './acta-cierre.component';

describe('ActaCierreComponent', () => {
  let component: ActaCierreComponent;
  let fixture: ComponentFixture<ActaCierreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActaCierreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActaCierreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
