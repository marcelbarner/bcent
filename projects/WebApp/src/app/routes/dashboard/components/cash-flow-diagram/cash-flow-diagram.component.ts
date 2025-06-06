import {AfterViewInit, Component, inject, Input, NgZone, OnDestroy, PLATFORM_ID, OnChanges} from '@angular/core';
import * as am5 from '@amcharts/amcharts5';
import am5themes_Animated from '@amcharts/amcharts5/themes/Dark';
import * as am5flow from '@amcharts/amcharts5/flow';
import {isPlatformBrowser} from '@angular/common';
import { MatCard, MatCardContent, MatCardHeader, MatCardTitle } from '@angular/material/card';
import { TranslatePipe } from '@ngx-translate/core';
import {WebApi2FeaturesCategoriesCategory} from '../../../../api/models/web-api-2-features-categories-category';
import {
  WebApi2FeaturesDashboardCashflowCashFlowItem
} from '../../../../api/models/web-api-2-features-dashboard-cashflow-cash-flow-item';

@Component({
  selector: 'app-cash-flow-diagram',
  imports: [MatCard, MatCardHeader, MatCardTitle, MatCardContent, TranslatePipe],
  templateUrl: './cash-flow-diagram.component.html',
  styleUrl: './cash-flow-diagram.component.css'
})
export class CashFlowDiagramComponent implements AfterViewInit, OnDestroy, OnChanges {
  private readonly zone = inject(NgZone);
  private readonly platformId = inject(PLATFORM_ID);

  private root!: am5.Root;
  private series?: am5flow.Sankey;
  @Input() titleKey: string = '';
  @Input() categories: WebApi2FeaturesCategoriesCategory[] = [];
  @Input()
  public data: WebApi2FeaturesDashboardCashflowCashFlowItem[]= []

  ngOnChanges(){
    this.setChartData();
  }
  ngAfterViewInit() {
    // Chart code goes in here
    this.browserOnly(() => {
      let root = am5.Root.new("cashflowchart");

      root.setThemes([am5themes_Animated.new(root)]);

      let series = root.container.children.push(
        am5flow.Sankey.new(root, {
          sourceIdField: "from",
          targetIdField: "to",
          valueField: "amount",
          paddingRight: 50
        }));
  this.series = series;
      // Define data
      series.nodes.get("colors")!.set("step", 2);
      series.nodes.setAll({
        idField: "id",
        nameField: "name"
      });


// Set data



// Make stuff animate on load
      series.appear(1000, 100);
      this.root = root;
      this.setChartData()
    });
  }

  ngOnDestroy() {
    // Clean up chart when the component is removed
    this.browserOnly(() => {
      if (this.root) {
        this.root.dispose();
      }
    });
  }

  browserOnly(f: () => void) {
    if (isPlatformBrowser(this.platformId)) {
      this.zone.runOutsideAngular(() => {
        f();
      });
    }
  }

  setChartData() {
    this.series?.data.clear();
    this.series?.nodes.data.clear();
    this.series?.nodes.data.setAll(this.categories.filter(c => this.data.some(f => f.from === c.id?.toString() || f.to === c.id?.toString())));
    this.series?.data.setAll(this.data);
  }
}
