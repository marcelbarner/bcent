import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionOverlayComponent } from './transaction-overlay.component';

describe('TransactionOverlayComponent', () => {
  let component: TransactionOverlayComponent;
  let fixture: ComponentFixture<TransactionOverlayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransactionOverlayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionOverlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
