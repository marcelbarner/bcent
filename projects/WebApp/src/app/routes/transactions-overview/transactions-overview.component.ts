import {Component, inject} from '@angular/core';
import {AsyncPipe, CurrencyPipe, DatePipe} from '@angular/common';
import {MtxGridModule, MtxGridColumn} from '@ng-matero/extensions/grid';
import {AccountsService} from '../../api/services';
import {Store} from '@ngxs/store';
import {CategoriesState} from '../../states/categories.state';
import {filter, startWith, map, switchMap, tap, combineLatest} from 'rxjs';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {AccountsState} from '../../states/accounts.state';
import {MatDialog} from '@angular/material/dialog';
import {
  TransactionOverlayComponent
} from '@shared/components/transactions/transaction-overlay/transaction-overlay.component';
import { MAT_DIALOG_RIGHT_OVERLAY_CONFIG } from '@shared/utils/dialog-configs';
import { CategoriesSelectComponent } from "../../shared/components/forms/categories-select/categories-select.component";
import { MtxOption, MtxSelect } from '@ng-matero/extensions/select';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-transactions-overview',
  imports: [MtxGridModule, AsyncPipe, TranslatePipe, DatePipe, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatIconModule, CategoriesSelectComponent, MtxSelect, MtxOption],
  templateUrl: './transactions-overview.component.html',
  styleUrl: './transactions-overview.component.css'
})
export class TransactionsOverviewComponent {
  private readonly apiService = inject(AccountsService);
  private readonly store = inject(Store);
  private readonly fb = inject(FormBuilder)
  private readonly dialogService = inject(MatDialog)
  public categorie$ = this.store.select(CategoriesState.isLoaded)
    .pipe(
      filter(isLoaded => isLoaded),
      switchMap(() => this.store.select(CategoriesState.categories)),
    );
  private account$ = this.store.select(AccountsState.isLoaded)
    .pipe(
      filter(isLoaded => isLoaded),
      switchMap(() => this.store.select(AccountsState.accounts)),
    );
  columns: MtxGridColumn[] = [
    {header: 'Transaction ID', field: 'id', sortable: true, hide: true},
    {header: 'Date', field: 'date', sortable: true, type: 'date'},
    {header: 'Purpose of use', field: 'purposeOfUse', sortable: true},
    {header: 'Category', field: 'category', sortable: true},
    {header: 'Account', field: 'account', sortable: true},
    {header: 'Amount', field: 'amount', sortable: true, type: 'currency', typeParameter: {currencyCode: 'EUR'}},
  ]

  filterForm = this.fb.group({
    search: this.fb.control<string|null>(null),
    categoryId: this.fb.control<number|null>(null)
  })

  data$ = combineLatest({
    categories: this.categorie$,
    accounts: this.account$,
    filter: this.filterForm.valueChanges.pipe(startWith(this.filterForm.value))
  })
  .pipe(
    switchMap(a => {
      return this.apiService.webApi2FeaturesAccountsTransactionsEndpoint(a.filter)
      .pipe(map(t => t.map(x => (
        {...x,
          category: a.categories.find(c => c.id === x.transactionCategoryId)?.name,
          account: a.accounts.find(c => c.id === x.accountId)?.name,
        }))))
  }));

  openTransactionOverlay(event: {id: number}){
    this.dialogService.open(TransactionOverlayComponent, MAT_DIALOG_RIGHT_OVERLAY_CONFIG);
  }
}
