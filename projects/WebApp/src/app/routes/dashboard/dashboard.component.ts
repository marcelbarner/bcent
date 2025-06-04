import {ChangeDetectionStrategy, Component, inject} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {AsyncPipe} from '@angular/common';
import {PageHeaderComponent} from '@shared';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {TotalAssetsKpiComponent} from './widgets/total-assets-kpi.component';
import { DisplayGrid, GridsterComponent, GridsterConfig, GridsterItem, GridsterItemComponent, GridType } from 'angular-gridster2';
import { DynamicComponent } from 'ng-dynamic-component';
import { TotalNetWorthKpiComponent } from './widgets/total-net-worth-kpi.component';
import { TotalLiabilitiesKpiComponent } from './widgets/total-liabilities-kpi.component';
import { IncomeVsExpenseWidgetComponent } from './widgets/income-vs-expense-widget.component';
import {MatFormField, MatLabel} from '@angular/material/form-field'
import {MatInputModule } from '@angular/material/input';
import {  MtxDatetimepickerModule } from '@ng-matero/extensions/datetimepicker';
import {DashboardState} from './state/dashboard.state';
import {Store} from '@ngxs/store';
import {SetFromDateAction} from './state/dashboard.actions';
import {CashFlowWidgetComponent} from './widgets/cash-flow-widget.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
  imports: [PageHeaderComponent, FormsModule, MatFormField, MatLabel, MtxDatetimepickerModule, MatInputModule , MatCardModule, MatIconModule, TotalAssetsKpiComponent, GridsterComponent, GridsterItemComponent,DynamicComponent, AsyncPipe],
})
export class DashboardComponent {
  private readonly store = inject(Store);

  from$ = this.store.select(DashboardState.from);
  setfrom(val: Date){
    this.store.dispatch(new SetFromDateAction(val));
  }

  options: GridsterConfig = {
      gridType: GridType.Fit,
      displayGrid: DisplayGrid.None,
      disableWindowResize: false,
      scrollToNewItems: false,
      disableWarnings: false,
      ignoreMarginInRow: false,
      minCols: 3,
      minRows:8,
      outerMargin: false
      // itemResizeCallback: item => {
      //   // update DB with new size
      //   // send the update to widgets
      //   this.resizeEvent.emit(item);
      // }
    };

     dashboard: GridsterItem[]= [
      { cols: 2, rows: 1, y: 0, x: 0, type: 'widgetA' },
      { cols: 2, rows: 1, y: 0, x: 2, type: 'widgetB' },
      { cols: 2, rows: 1, y: 0, x: 4, type: 'widgetC' },
      { cols: 3, rows:3, y:1, x: 0, type: 'widgetD' },
       { cols: 6, rows:3, y:4, x: 0, type: 'widgetE' },

     ];

    getWidgetComponent(item: GridsterItem): any {
      switch (item.type) {
        case 'widgetA':
          return TotalAssetsKpiComponent;
        case 'widgetB':
          return TotalLiabilitiesKpiComponent; // Replace with actual component
        case 'widgetC':
          return TotalNetWorthKpiComponent; // Replace with actual component
        case 'widgetD':
          return IncomeVsExpenseWidgetComponent; // Replace with actual component
          case 'widgetE':
            return CashFlowWidgetComponent;
        default:
          return null;
      }
    }
}
