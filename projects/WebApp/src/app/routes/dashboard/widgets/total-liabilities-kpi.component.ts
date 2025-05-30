import {Component, inject, OnInit} from '@angular/core';
import {KpiCardComponent} from '../kpi-card/kpi-card.component';
import {Store} from '@ngxs/store';
import {LoadTotalAssetsKpiAction, LoadTotalLiabilitiesKpiAction} from '../state/dashboard.actions';
import {DashboardState} from '../state/dashboard.state';
import {AsyncPipe} from '@angular/common';

@Component({
  selector: 'app-total-liabilities-kpi',
  imports: [KpiCardComponent, AsyncPipe],
  template: `
    @if(totalAssetsKpi$|async; as kpi){
      <app-kpi-card [value]="kpi.totalValue" [trendValue]="kpi.trendValue" titleKey="dashboard.total-liabilities" />
    }
  `,
})
export class TotalLiabilitiesKpiComponent implements OnInit{
  private readonly store = inject(Store);
  public totalAssetsKpi$ = this.store.select(DashboardState.totalLiabilitiesKpi);
  ngOnInit() {
    this.store.dispatch(new LoadTotalLiabilitiesKpiAction());
  }
}
