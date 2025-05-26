import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomesVsExpensComponent } from './incomes-vs-expens.component';

describe('IncomesVsExpensComponent', () => {
  let component: IncomesVsExpensComponent;
  let fixture: ComponentFixture<IncomesVsExpensComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IncomesVsExpensComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IncomesVsExpensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
