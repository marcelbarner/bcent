import {Action, Selector, State, StateContext} from '@ngxs/store';
import {inject} from '@angular/core';
import {DashboardService} from '../../../api/services';
import {
  LoadCashFlowAction,
  LoadIncomesVsExpensesAction,
  LoadTotalAssetsKpiAction,
  LoadTotalLiabilitiesKpiAction, LoadTotalNetWorthKpiAction,
  ReloadDashboardAction,
  SetFromDateAction
} from './dashboard.actions';
import {tap} from 'rxjs';
import { startOfToday } from 'date-fns';
import {
  WebApi2FeaturesDashboardCashflowCashFlowItem
} from '../../../api/models/web-api-2-features-dashboard-cashflow-cash-flow-item';

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
  },
  cashflow?:{
    items: WebApi2FeaturesDashboardCashflowCashFlowItem[],
    isLoaded: boolean
  }
  from: Date
}

@State<DashboardStateModel>({
  name: 'dashboard',
  defaults: {
    from: new Date(Date.parse("2025-05-01"))
  }
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
  @Selector()
  static cashflow(state: DashboardStateModel) {
    return state.cashflow?.items;
  }
  @Selector()
  static from(state: DashboardStateModel) {
    return state.from;
  }

  @Action(LoadTotalAssetsKpiAction)
  loadTotalAssetsKpi(ctx: StateContext<DashboardStateModel>){
    const from = ctx.getState().from;
    const fromIsoString = from.toISOString().slice(0, 10);
    return this.apiService.webApi2FeaturesDashboardKpisTotalAssetsEndpoint({from: fromIsoString}).pipe(
      tap(res => ctx.patchState({totalAssetsKpi:{...res, isLoaded: true}}))
    )
  }
  @Action(LoadTotalLiabilitiesKpiAction)
  loadTotalLiabilitiesKpi(ctx: StateContext<DashboardStateModel>){
    const from = ctx.getState().from;
    const fromIsoString = from.toISOString().slice(0, 10);
    return this.apiService.webApi2FeaturesDashboardKpisTotalLiabilitiesEndpoint({from: fromIsoString}).pipe(
      tap(res => ctx.patchState({totalLiabilitiesKpi:{...res, isLoaded: true}}))
    )
  }
  @Action(LoadTotalNetWorthKpiAction)
  loadTotalNetWorthKpi(ctx: StateContext<DashboardStateModel>){
    const from = ctx.getState().from;
    const fromIsoString = from.toISOString().slice(0, 10);
    return this.apiService.webApi2FeaturesDashboardKpisTotalNetWorthEndpoint({from: fromIsoString}).pipe(
      tap(res => ctx.patchState({totalNetWorthKpi:{...res, isLoaded: true}}))
    )
  }
  @Action(LoadIncomesVsExpensesAction)
  loadIncomeVsExpense(ctx: StateContext<DashboardStateModel>){
    const from = ctx.getState().from;
    const fromIsoString = from.toISOString().slice(0, 10);
    return this.apiService.webApi2FeaturesDashboardIncomeVsExpenseIncomeVsExpenseEndpoint({from: fromIsoString}).pipe(
      tap(res => ctx.patchState({incomeVsExpense:{...res, isLoaded: true}}))
    )
  }

  @Action(LoadCashFlowAction)
  loadCashflow(ctx: StateContext<DashboardStateModel>){
    const from = ctx.getState().from;
    const fromIsoString = from.toISOString().slice(0, 10);
    return this.apiService.webApi2FeaturesDashboardCashflowCashflowEndpoint({from: fromIsoString}).pipe(
      tap(res => ctx.patchState({cashflow:{items: res, isLoaded: true}}))
    )
  }
  @Action(SetFromDateAction)
  setFromDate(ctx: StateContext<DashboardStateModel>, {date}: SetFromDateAction) {
    ctx.patchState({from: date});
    return ctx.dispatch(new ReloadDashboardAction())
  }
  @Action(ReloadDashboardAction)
  reloadDashboardAction(ctx: StateContext<DashboardStateModel>) {
    const state = ctx.getState();
    const actions = [];
    if(state.totalAssetsKpi?.isLoaded){
      actions.push(new LoadTotalAssetsKpiAction());
    }
    if(state.totalLiabilitiesKpi?.isLoaded){
      actions.push(new LoadTotalLiabilitiesKpiAction());
    }
    if(state.totalNetWorthKpi?.isLoaded){
      actions.push(new LoadTotalNetWorthKpiAction());
    }
    if(state.incomeVsExpense?.isLoaded){
      actions.push(new LoadIncomesVsExpensesAction());
    }
    if(state.cashflow?.isLoaded){
      actions.push(new LoadCashFlowAction());
    }
    return ctx.dispatch(actions);
  }
}
