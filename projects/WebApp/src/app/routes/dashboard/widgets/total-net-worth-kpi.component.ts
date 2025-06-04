import {Component, inject, OnInit} from '@angular/core';
import {KpiCardComponent} from '../components/kpi-card/kpi-card.component';
import {Store} from '@ngxs/store';
import {LoadTotalAssetsKpiAction, LoadTotalNetWorthKpiAction} from '../state/dashboard.actions';
import {DashboardState} from '../state/dashboard.state';
import {AsyncPipe} from '@angular/common';

@Component({
  selector: 'app-total-net-worth-kpi',
  imports: [KpiCardComponent, AsyncPipe],
  template: `
    @if(totalAssetsKpi$|async; as kpi){
      <app-kpi-card [value]="kpi.totalValue" [trendValue]="kpi.trendValue" titleKey="dashboard.net-worth" />
    }
  `,
})
export class TotalNetWorthKpiComponent implements OnInit{
  private readonly store = inject(Store);
  public totalAssetsKpi$ = this.store.select(DashboardState.totalNetWothKpi);
  ngOnInit() {
    this.store.dispatch(new LoadTotalNetWorthKpiAction());
  }
}
