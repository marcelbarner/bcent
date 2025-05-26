import {AfterViewInit, Component, inject, NgZone, OnDestroy, PLATFORM_ID} from '@angular/core';
import * as am5 from '@amcharts/amcharts5';
import am5themes_Animated from '@amcharts/amcharts5/themes/Dark';
import * as am5flow from '@amcharts/amcharts5/flow';
import {isPlatformBrowser} from '@angular/common';

@Component({
  selector: 'app-cash-flow-diagram',
  imports: [],
  templateUrl: './cash-flow-diagram.component.html',
  styleUrl: './cash-flow-diagram.component.css'
})
export class CashFlowDiagramComponent implements AfterViewInit, OnDestroy {
  private readonly zone = inject(NgZone);
  private readonly platformId = inject(PLATFORM_ID);

  private root!: am5.Root;

  ngAfterViewInit() {
    // Chart code goes in here
    this.browserOnly(() => {
      let root = am5.Root.new("cashflowchart");

      root.setThemes([am5themes_Animated.new(root)]);

      let series = root.container.children.push(
        am5flow.Sankey.new(root, {
          sourceIdField: "from",
          targetIdField: "to",
          valueField: "value",
          paddingRight: 50
        }));

      // Define data
      series.nodes.get("colors")!.set("step", 2);


// Set data
// https://www.amcharts.com/docs/v5/charts/flow-charts/#Setting_data
      series.data.setAll([
        { from: "Gehalt", to: "Einnahmen", value: 4000 },
        { from: "Dividende", to: "Einnahmen", value: 200 },
        { from: "Einnahmen", to: "Ausgaben", value: 3500 },
        { from: "Ausgaben", to: "Sparen & Investieren", value: 2000 },
        { from: "Ausgaben", to: "Wohnen", value: 5500 },
      ]);


// Make stuff animate on load
      series.appear(1000, 100);
      this.root = root;
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
}
