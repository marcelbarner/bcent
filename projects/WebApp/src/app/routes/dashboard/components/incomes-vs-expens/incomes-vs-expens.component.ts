import { isPlatformBrowser } from '@angular/common';
import {AfterViewInit, Component, inject, Input, NgZone, OnDestroy, PLATFORM_ID, SimpleChanges} from '@angular/core';

import * as am5 from '@amcharts/amcharts5';
import * as am5xy from '@amcharts/amcharts5/xy';
import am5themes_Animated from '@amcharts/amcharts5/themes/Dark';
import {AxisRenderer} from '@amcharts/amcharts5/xy';
import { MatCard, MatCardContent, MatCardHeader, MatCardTitle } from '@angular/material/card';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-incomes-vs-expens',
  imports: [MatCard, MatCardHeader, MatCardTitle, MatCardContent, TranslatePipe],
  templateUrl: './incomes-vs-expens.component.html',
  styleUrl: './incomes-vs-expens.component.css'
})
export class IncomesVsExpensComponent implements AfterViewInit, OnDestroy{
  private readonly zone = inject(NgZone);
  private readonly platformId = inject(PLATFORM_ID);

  private root!: am5.Root;
  private series?: am5xy.ColumnSeries;
  private xAxis?: am5xy.CategoryAxis<AxisRenderer>;

  @Input() titleKey: string = '';

  @Input()
  public set data(value: {income?:number, expense?:number, difference?:number}) {
    console.log(value);
    this.setChartData(value);
  }

  ngAfterViewInit() {
    // Chart code goes in here
    this.browserOnly(() => {
      let root = am5.Root.new("chartdiv");
      root.setThemes([
        am5themes_Animated.new(root)
      ]);
      let chart = root.container.children.push(am5xy.XYChart.new(root, {
        panX: true,
        panY: true,
        wheelX: "panX",
        wheelY: "zoomX",
        pinchZoomX: true,
        paddingLeft:0,
        paddingRight:1
      }));

// Add cursor
// https://www.amcharts.com/docs/v5/charts/xy-chart/cursor/
      let cursor = chart.set("cursor", am5xy.XYCursor.new(root, {}));
      cursor.lineY.set("visible", false);


// Create axes
// https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
      let xRenderer = am5xy.AxisRendererX.new(root, {
        minGridDistance: 30,
        minorGridEnabled: true
      });

      xRenderer.labels.template.setAll({
        rotation: -90,
        centerY: am5.p50,
        centerX: am5.p100,
        paddingRight: 15
      });

      xRenderer.grid.template.setAll({
        location: 1
      })

      let xAxis = chart.xAxes.push(am5xy.CategoryAxis.new(root, {
        maxDeviation: 0.3,
        categoryField: "country",
        renderer: xRenderer,
        tooltip: am5.Tooltip.new(root, {})
      }));

      this.xAxis = xAxis;
      let yRenderer = am5xy.AxisRendererY.new(root, {
        strokeOpacity: 0.1
      })

      let yAxis = chart.yAxes.push(am5xy.ValueAxis.new(root, {
        maxDeviation: 0.3,
        renderer: yRenderer
      }));

// Create series
// https://www.amcharts.com/docs/v5/charts/xy-chart/series/
      let series = chart.series.push(am5xy.ColumnSeries.new(root, {
        name: "Series 1",
        xAxis: xAxis,
        yAxis: yAxis,
        valueYField: "value",
        sequencedInterpolation: true,
        categoryXField: "country",
        tooltip: am5.Tooltip.new(root, {
          labelText: "{valueY}"
        })
      }));
      this.series = series;

      series.columns.template.setAll({ cornerRadiusTL: 5, cornerRadiusTR: 5, strokeOpacity: 0 });
      series.columns.template.adapters.add("fill", function (fill, target) {
        return chart.get("colors")!.getIndex(series.columns.indexOf(target));
      });

      series.columns.template.adapters.add("stroke", function (stroke, target) {
        return chart.get("colors")!.getIndex(series.columns.indexOf(target));
      });


// Set data





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

  setChartData(data: {income?:number, expense?:number, difference?:number}){
    const chartData = [{
      country: "Income",
      value: data.income,
    }, {
      country: "Expense",
      value: data.expense,
    }, {
      country: "Difference",
      value: data.difference,
    }];
    this.xAxis?.data.clear();
    this.xAxis?.data.setAll(chartData);
    this.series?.data.clear();
    this.series?.data.setAll(chartData);
  }
}
