import {
  AfterViewInit,
  Component,
  inject,
  Input,
  NgZone,
  OnChanges,
  OnDestroy,
  PLATFORM_ID,
  SimpleChanges
} from '@angular/core';
import * as am5 from '@amcharts/amcharts5';
import am5themes_Animated from '@amcharts/amcharts5/themes/Dark';
import * as am5xy from '@amcharts/amcharts5/xy';
import {CurrencyPipe, isPlatformBrowser} from '@angular/common';

@Component({
  selector: 'app-value-development',
  templateUrl: './value-development.component.html',
  styleUrl: './value-development.component.css'
})
export class ValueDevelopmentComponent implements AfterViewInit, OnDestroy, OnChanges{
  private readonly zone = inject(NgZone);
  private readonly platformId = inject(PLATFORM_ID);
  private series!: am5xy.LineSeries;

  @Input()
  public set data(value: Record<string, number>){
    this.historyData = Object.entries(value).map(
      ([dateString, value]) => ({
        date: (new Date(dateString)).getTime(),
        value,
      })
    );
  }
  private historyData: {date:number, value:number}[] = [];
  private root!: am5.Root;
  private chart!: am5xy.XYChart;
  private xAxis!: am5xy.DateAxis<am5xy.AxisRenderer>
  private yAxis!: am5xy.ValueAxis<am5xy.AxisRenderer>

  ngOnChanges(changes: SimpleChanges) {
    if(changes.data && !changes.data.firstChange){
      this.setChartData(this.historyData);
    }
  }

  ngAfterViewInit() {
    // Chart code goes in here
    this.browserOnly(() => {
      let root = am5.Root.new("developmentchart");
      root.setThemes([
        am5themes_Animated.new(root)
      ]);
      let chart = root.container.children.push(am5xy.XYChart.new(root, {
        panX: true,
        panY: true,
        wheelX: "panX",
        wheelY: "zoomX",
        pinchZoomX:true,
        paddingLeft: 0
      }));
      this.chart = chart;


// Add cursor
// https://www.amcharts.com/docs/v5/charts/xy-chart/cursor/
      let cursor = chart.set("cursor", am5xy.XYCursor.new(root, {
        behavior: "none"
      }));
      cursor.lineY.set("visible", false);


// Generate random data
      let date = new Date();
      date.setHours(0, 0, 0, 0);
      let value = 100;

      function generateData() {
        value = Math.round((Math.random() * 10 - 5) + value);
        am5.time.add(date, "day", 1);
        return {
          date: date.getTime(),
          value: value
        };
      }

      function generateDatas(count:number) {
        let data = [];
        for (var i = 0; i < count; ++i) {
          data.push(generateData());
        }
        return data;
      }


// Create axes
// https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
      let xAxis = chart.xAxes.push(am5xy.DateAxis.new(root, {
        maxDeviation: 0.2,
        baseInterval: {
          timeUnit: "day",
          count: 1
        },
        renderer: am5xy.AxisRendererX.new(root, {
          minorGridEnabled:true
        }),
        tooltip: am5.Tooltip.new(root, {})
      }));
      this.xAxis = xAxis;

      let yAxis = chart.yAxes.push(am5xy.ValueAxis.new(root, {
        renderer: am5xy.AxisRendererY.new(root, {
          pan:"zoom"
        })
      }));
      this.yAxis = yAxis;


// Add series
// https://www.amcharts.com/docs/v5/charts/xy-chart/series/



// Add scrollbar
// https://www.amcharts.com/docs/v5/charts/xy-chart/scrollbars/



// Set data
      let data = generateDatas(1200);



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

  setChartData(data:{date:number,value:number}[]){
    this.series = this.chart.series.push(am5xy.LineSeries.new(this.root, {
      name: "Series",
      xAxis: this.xAxis,
      yAxis: this.yAxis,
      valueYField: "value",
      valueXField: "date",
      tooltip: am5.Tooltip.new(this.root, {
        labelText: "{valueY}"
      })
    }));
    this.series.data.setAll(data);
  }
}
