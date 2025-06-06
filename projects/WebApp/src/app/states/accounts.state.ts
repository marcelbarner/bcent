import {Action, Selector, State, StateContext} from '@ngxs/store';
import {AccountsService, CategoriesService} from '../api/services';
import { inject } from '@angular/core';
import {LoadCategoriesAction} from './categories.actions';
import {LoadTotalAssetsKpiAction} from '../routes/dashboard/state/dashboard.actions';
import {DashboardStateModel} from '../routes/dashboard/state/dashboard.state';
import { tap } from 'rxjs';
import {WebApi2FeaturesCategoriesCategory} from '../api/models/web-api-2-features-categories-category';
import {LoadAccountsAction} from './accounts.actions';
import {WebApi2FeaturesAccountsAccount} from '../api/models/web-api-2-features-accounts-account';

export interface AccountsStateModel {
  isLoaded: boolean;
  categories: WebApi2FeaturesAccountsAccount[];
}

@State<AccountsStateModel>({
  name: 'accounts',
  defaults: {
    categories: [],
    isLoaded: false,
  }
})
export class AccountsState {

  private apiService = inject(AccountsService);

  @Selector()
  static accounts(ctx: AccountsStateModel) {
    return ctx.categories;
  }

  @Selector()
  static isLoaded(ctx: AccountsStateModel) {
    return ctx.isLoaded;
  }

  @Action(LoadAccountsAction)
  loadTotalAssetsKpi(ctx: StateContext<AccountsStateModel>){
    return this.apiService.webApi2FeaturesAccountsAccountsEndpoint().pipe(
      tap(res => ctx.patchState({categories:res, isLoaded: true}))
    )
  }

}
