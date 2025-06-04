import { Component, OnInit, AfterViewInit, inject } from '@angular/core';
import { PreloaderService, SettingsService } from '@core';
import { RouterOutlet } from '@angular/router';
import { Store } from '@ngxs/store';
import {LoadCategoriesAction} from './states/categories.actions';
import {LoadAccountsAction} from './states/accounts.actions';

@Component({
  selector: 'app-root',
  template: `<router-outlet />`,
  imports: [RouterOutlet],
})
export class AppComponent implements OnInit, AfterViewInit {
  private readonly preloader = inject(PreloaderService);
  private readonly settings = inject(SettingsService);
  private readonly store = inject(Store)

  ngOnInit() {
    this.settings.setDirection();
    this.settings.setTheme();
    this.store.dispatch([new LoadCategoriesAction(), new LoadAccountsAction()]);
  }

  ngAfterViewInit() {
    this.preloader.hide();
  }
}
