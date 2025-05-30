import {ChangeDetectionStrategy, Component, inject} from '@angular/core';
import {PageHeaderComponent} from '@shared';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {HttpClient} from '@angular/common/http';
import {TotalAssetsKpiComponent} from './widgets/total-assets-kpi.component';
import { DisplayGrid, GridsterComponent, GridsterConfig, GridsterItem, GridsterItemComponent, GridType } from 'angular-gridster2';
import { DynamicComponent } from 'ng-dynamic-component';
import { TotalNetWorthKpiComponent } from './widgets/total-net-worth-kpi.component';
import { TotalLiabilitiesKpiComponent } from './widgets/total-liabilities-kpi.component';
import { ca } from 'date-fns/locale';
import { IncomeVsExpenseWidgetComponent } from './widgets/income-vs-expense-widget.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
  imports: [PageHeaderComponent, MatCardModule, MatIconModule, TotalAssetsKpiComponent, GridsterComponent, GridsterItemComponent,DynamicComponent],
})
export class DashboardComponent {

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
        default:
          return null;
      }
    }
}
