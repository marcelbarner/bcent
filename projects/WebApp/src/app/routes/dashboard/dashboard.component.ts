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
  constructor() {
    this.kpis$ = this.http.get<{ totalAssets: number,
      totalLiabilities: number,
      netWorth: number
    }>("api/dashboard/kpis");
    this.netWorthHistories$ = this.http.get<Record<string,number>>("api/dashboard/history/net-worth");
  }
}
