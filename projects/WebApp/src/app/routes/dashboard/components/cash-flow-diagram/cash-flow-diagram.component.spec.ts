import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CashFlowDiagramComponent } from './cash-flow-diagram.component';

describe('CashFlowDiagramComponent', () => {
  let component: CashFlowDiagramComponent;
  let fixture: ComponentFixture<CashFlowDiagramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CashFlowDiagramComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CashFlowDiagramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
