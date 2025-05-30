import {Component, inject, OnInit} from '@angular/core';
import {KpiCardComponent} from '../kpi-card/kpi-card.component';
import {Store} from '@ngxs/store';
import {LoadIncomesVsExpensesAction, LoadTotalAssetsKpiAction} from '../state/dashboard.actions';
import {DashboardState} from '../state/dashboard.state';
import {AsyncPipe} from '@angular/common';
import { IncomesVsExpensComponent } from '../incomes-vs-expens/incomes-vs-expens.component';

@Component({
  selector: 'app-income-vs-expense-widget',
  imports: [IncomesVsExpensComponent, AsyncPipe],
  template: `
    @if(totalAssetsKpi$|async; as kpi){
      <app-incomes-vs-expens [data]="kpi" titleKey="dashboard.income-vs-expense" />
    }
  `,
})
export class IncomeVsExpenseWidgetComponent implements OnInit{
  private readonly store = inject(Store);
  public totalAssetsKpi$ = this.store.select(DashboardState.incomeVsExpense);
  ngOnInit() {
    this.store.dispatch(new LoadIncomesVsExpensesAction());
  }
}
