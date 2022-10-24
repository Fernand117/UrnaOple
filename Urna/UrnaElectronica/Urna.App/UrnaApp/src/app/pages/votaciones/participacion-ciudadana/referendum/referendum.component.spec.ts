import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferendumComponent } from './referendum.component';

describe('ReferendumComponent', () => {
  let component: ReferendumComponent;
  let fixture: ComponentFixture<ReferendumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReferendumComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferendumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
