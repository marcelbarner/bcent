import {ChangeDetectionStrategy, Component, inject} from '@angular/core';
import {PageHeaderComponent} from '@shared';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {CashFlowDiagramComponent} from './cash-flow-diagram/cash-flow-diagram.component';
import {IncomesVsExpensComponent} from './incomes-vs-expens/incomes-vs-expens.component';
import {ValueDevelopmentComponent} from './value-development/value-development.component';
import {KpiCardComponent} from './kpi-card/kpi-card.component';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AsyncPipe} from '@angular/common';
import {map} from 'rxjs/operators';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
  imports: [PageHeaderComponent, MatCardModule, MatIconModule, CashFlowDiagramComponent, IncomesVsExpensComponent, ValueDevelopmentComponent, KpiCardComponent, AsyncPipe],
})
export class DashboardComponent {
  private readonly http = inject(HttpClient);
  public kpis$: Observable<{
    totalAssets: number,
    totalLiabilities: number,
    netWorth: number
  }>;

  public netWorthHistories$: Observable<Record<string, number>>;
  public incomeVsExpenses$:Observable<{income:number, expenses:number, difference:number}>
  public cashFows$: Observable<{ from:string, to:string, value:number }[]>;
  constructor() {
    this.kpis$ = this.http.get<{ totalAssets: number,
      totalLiabilities: number,
      netWorth: number
    }>("api/dashboard/kpis");
    this.netWorthHistories$ = this.http.get<Record<string,number>>("api/dashboard/history/net-worth");
    this.incomeVsExpenses$ = this.http.get<{income:number, expenses:number, difference:number}>("api/dashboard/income-vs-expenses");
    this.cashFows$ = this.http
      .get<{id:number, parentId?:number, name:string, parentName:string, value:number, type: 0|1}[]>("api/dashboard/categories")
      .pipe(
        map(res => {
          const cashflow = res.filter(c => c.value !== 0).map(c => (c.type == 0 ?{
            from: c.id + c.name,
            to: c.parentName ? c.parentId + c.parentName : 'Income',
            value: c.value
          }:
            {
              to: c.id + c.name,
              from: c.parentName ? c.parentId + c.parentName : 'Expense',
              value: c.value * -1
            }));
            const income = res.filter(c => c.type === 0 && c.value != 0 && !c.parentId).reduce((acc, c) => acc + c.value, 0);
            const expense = -1 * res.filter(c => c.type === 1 && c.value != 0 && !c.parentId).reduce((acc, c) => acc + c.value, 0);
          cashflow.push({
            from: 'Income',
            to: 'Expense',
            value: income > expense ? expense : income
          })
          console.log(income);
          console.log(expense);
          console.table(cashflow);
          return cashflow;
        })
      );

  }
}
