import { Component, inject } from '@angular/core';
import { AsyncPipe, CurrencyPipe, DatePipe } from '@angular/common';
import { MtxGridModule, MtxGridColumn } from '@ng-matero/extensions/grid';
import {AccountsService} from '../../api/services';

@Component({
  selector: 'app-transactions-overview',
  imports: [MtxGridModule, AsyncPipe, CurrencyPipe, DatePipe],
  templateUrl: './transactions-overview.component.html',
  styleUrl: './transactions-overview.component.css'
})
export class TransactionsOverviewComponent {
  private readonly apiService = inject(AccountsService);
  columns: MtxGridColumn[] = [
    { header: 'Transaction ID', field: 'id',sortable: true  },
    { header: 'Date', field: 'date',sortable: true, type: 'date'  },
    { header: 'Purpose of use', field: 'purposeOfUse',sortable: true  },
    { header: 'Category', field: 'transactionCategoryId',sortable: true  },
    { header: 'Amount', field: 'amount',sortable: true, type:'currency', typeParameter: {currencyCode:'EUR'}  },
  ]
  data$ = this.apiService.webApi2FeaturesAccountsTransactionsEndpoint();
}
