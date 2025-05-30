import {Action, Selector, State, StateContext} from '@ngxs/store';
import {inject} from '@angular/core';
import {DashboardService} from '../../../api/services';
import {LoadTotalAssetsKpiAction} from './dashboard.actions';
import {tap} from 'rxjs';

export interface DashboardStateModel {
  totalAssetsKpi?: {
    totalValue: number,
    trendValue: number,
    isLoaded: boolean
  },
  totalLiabilitiesKpi?: {
    totalValue: number,
    trendValue: number,
    isLoaded: boolean
  },
  totalNetWorthKpi?: {
    totalValue: number,
    trendValue: number,
    isLoaded: boolean
  },
  incomeVsExpense?:{
    income: number,
    expense: number,
    difference: number,
    isLoaded: boolean
  }
}

@State<DashboardStateModel>({
  name: 'dashboard',
})
export class DashboardState {
  private apiService = inject(DashboardService);

  @Selector()
  static totalAssetsKpi(state: DashboardStateModel) {
    return state.totalAssetsKpi;
  }
  @Selector()
  static totalLiabilitiesKpi(state: DashboardStateModel) {
    return state.totalLiabilitiesKpi;
  }
  @Selector()
  static totalNetWothKpi(state: DashboardStateModel) {
    return state.totalNetWorthKpi;
  }
  @Selector()
  static incomeVsExpense(state: DashboardStateModel) {
    return state.incomeVsExpense;
  }

  @Action(LoadTotalAssetsKpiAction)
  loadTotalAssetsKpi(ctx: StateContext<DashboardStateModel>){
    return this.apiService.webApi2FeaturesDashboardKpisTotalAssetsEndpoint().pipe(
      tap(res => ctx.patchState({totalAssetsKpi:{...res, isLoaded: true}}))
    )
  }
  @Action(LoadTotalAssetsKpiAction)
  loadTotalLiabilitiesKpi(ctx: StateContext<DashboardStateModel>){
    return this.apiService.webApi2FeaturesDashboardKpisTotalLiabilitiesEndpoint().pipe(
      tap(res => ctx.patchState({totalLiabilitiesKpi:{...res, isLoaded: true}}))
    )
  }
  @Action(LoadTotalAssetsKpiAction)
  loadTotalNetWorthKpi(ctx: StateContext<DashboardStateModel>){
    return this.apiService.webApi2FeaturesDashboardKpisTotalNetWorthEndpoint().pipe(
      tap(res => ctx.patchState({totalNetWorthKpi:{...res, isLoaded: true}}))
    )
  }
  @Action(LoadTotalAssetsKpiAction)
  loadIncomeVsExpense(ctx: StateContext<DashboardStateModel>){
    return this.apiService.webApi2FeaturesDashboardIncomeVsExpenseIncomeVsExpenseEndpoint().pipe(
      tap(res => ctx.patchState({incomeVsExpense:{...res, isLoaded: true}}))
    )
  }
}
