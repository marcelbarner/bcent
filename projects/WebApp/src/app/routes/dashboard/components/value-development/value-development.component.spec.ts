import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValueDevelopmentComponent } from './value-development.component';

describe('ValueDevelopmentComponent', () => {
  let component: ValueDevelopmentComponent;
  let fixture: ComponentFixture<ValueDevelopmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ValueDevelopmentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ValueDevelopmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
