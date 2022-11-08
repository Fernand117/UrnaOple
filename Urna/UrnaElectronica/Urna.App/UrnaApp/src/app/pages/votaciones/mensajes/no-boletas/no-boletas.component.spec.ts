import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoBoletasComponent } from './no-boletas.component';

describe('NoBoletasComponent', () => {
  let component: NoBoletasComponent;
  let fixture: ComponentFixture<NoBoletasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoBoletasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoBoletasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
