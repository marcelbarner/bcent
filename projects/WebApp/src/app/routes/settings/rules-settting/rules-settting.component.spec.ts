import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RulesSetttingComponent } from './rules-settting.component';

describe('RulesSetttingComponent', () => {
  let component: RulesSetttingComponent;
  let fixture: ComponentFixture<RulesSetttingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RulesSetttingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RulesSetttingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
