import {Action, Selector, State, StateContext} from '@ngxs/store';
import {CategoriesService} from '../api/services';
import { inject } from '@angular/core';
import {LoadCategoriesAction} from './categories.actions';
import {LoadTotalAssetsKpiAction} from '../routes/dashboard/state/dashboard.actions';
import {DashboardStateModel} from '../routes/dashboard/state/dashboard.state';
import { tap } from 'rxjs';
import {WebApi2FeaturesCategoriesCategory} from '../api/models/web-api-2-features-categories-category';

export interface CategoriesStateModel {
  isLoaded: boolean;
  categories: WebApi2FeaturesCategoriesCategory[];
}

@State<CategoriesStateModel>({
  name: 'categories',
  defaults: {
    categories: [],
    isLoaded: false,
  }
})
export class CategoriesState {

  private apiService = inject(CategoriesService);

  @Selector()
  static incomeCategories(ctx: CategoriesStateModel) {
    return ctx.categories.filter(x => x.type === 0);
  }
  @Selector()
  static expenseCategories(ctx: CategoriesStateModel) {
    return ctx.categories.filter(x => x.type === 1);
  }
  @Selector()
  static categories(ctx: CategoriesStateModel) {
    return ctx.categories;
  }

  @Selector()
  static isLoaded(ctx: CategoriesStateModel) {
    return ctx.isLoaded;
  }

  @Action(LoadCategoriesAction)
  loadTotalAssetsKpi(ctx: StateContext<CategoriesStateModel>){
    return this.apiService.webApi2FeaturesCategoriesAccountsEndpoint().pipe(
      tap(res => ctx.patchState({categories:res, isLoaded: true}))
    )
  }

}
