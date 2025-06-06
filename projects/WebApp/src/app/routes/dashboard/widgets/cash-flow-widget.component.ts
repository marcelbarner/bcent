import {Component, inject, OnInit} from '@angular/core';
import {Store} from '@ngxs/store';
import {LoadCashFlowAction, LoadIncomesVsExpensesAction, LoadTotalAssetsKpiAction} from '../state/dashboard.actions';
import {DashboardState} from '../state/dashboard.state';
import {AsyncPipe} from '@angular/common';
import {map} from 'rxjs';
import {CashFlowDiagramComponent} from '../components/cash-flow-diagram/cash-flow-diagram.component';
import {CategoriesState} from '../../../states/categories.state';

@Component({
  selector: 'app-cash-flow-widget',
  imports: [CashFlowDiagramComponent, AsyncPipe],
  template: `
    @if (totalAssetsKpi$|async; as kpi) {
      @if (categories$|async; as categories) {
        <app-cash-flow-diagram [data]="kpi" [categories]="categories" titleKey="dashboard.cash-flow"/>
      }
    }
  `,
})
export class CashFlowWidgetComponent implements OnInit {
  private readonly store = inject(Store);
  public totalAssetsKpi$ = this.store.select(DashboardState.cashflow);
  public readonly categories$ = this.store.select(CategoriesState.categories);

  ngOnInit() {
    this.store.dispatch(new LoadCashFlowAction());
  }
}
