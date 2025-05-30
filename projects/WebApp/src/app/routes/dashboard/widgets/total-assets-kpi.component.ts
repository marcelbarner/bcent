import {Component, inject, OnInit} from '@angular/core';
import {KpiCardComponent} from '../kpi-card/kpi-card.component';
import {Store} from '@ngxs/store';
import {LoadTotalAssetsKpiAction} from '../state/dashboard.actions';
import {DashboardState} from '../state/dashboard.state';
import {AsyncPipe} from '@angular/common';

@Component({
  selector: 'app-total-assets-kpi',
  imports: [KpiCardComponent, AsyncPipe],
  template: `
    @if(totalAssetsKpi$|async; as kpi){
      <app-kpi-card [value]="kpi.totalValue" [trendValue]="kpi.trendValue" titleKey="dashboard.total-assets" />
    }
  `,
})
export class TotalAssetsKpiComponent implements OnInit{
  private readonly store = inject(Store);
  public totalAssetsKpi$ = this.store.select(DashboardState.totalAssetsKpi);
  ngOnInit() {
    this.store.dispatch(new LoadTotalAssetsKpiAction());
  }
}
