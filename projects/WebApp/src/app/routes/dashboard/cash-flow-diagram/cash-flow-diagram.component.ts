import {AfterViewInit, Component, inject, Input, NgZone, OnDestroy, PLATFORM_ID} from '@angular/core';
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
  private series?: am5flow.Sankey;

  @Input()
  public set data(val: {from:string, to:string, value:number}[]) {
    this.setChartData(val);
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
          valueField: "value",
          paddingRight: 50
        }));
  this.series = series;
      // Define data
      series.nodes.get("colors")!.set("step", 2);


// Set data



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

  setChartData(data:{from:string, to:string, value:number}[]) {
    this.series?.data.clear();
    this.series?.data.setAll(data);
  }
}
