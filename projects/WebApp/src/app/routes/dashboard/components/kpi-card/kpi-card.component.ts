import {Component, Input} from '@angular/core';
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from "@angular/material/card";
import {MatIcon} from '@angular/material/icon';
import {CurrencyPipe, NgClass} from '@angular/common';
import {TranslatePipe} from '@ngx-translate/core';

@Component({
  selector: 'app-kpi-card',
  imports: [
    MatCard,
    MatCardContent,
    MatCardHeader,
    MatCardTitle,
    MatIcon,
    NgClass,
    CurrencyPipe,
    TranslatePipe
  ],
  templateUrl: './kpi-card.component.html',
  styleUrl: './kpi-card.component.css'
})
export class KpiCardComponent {
  @Input()
  reverse = false;
  @Input()
  trendValue?: number
  @Input()
  titleKey: string = '';
  @Input()
  value:number = 0;

  getTrendIcon(){
    if(this.trendValue){
      if(this.trendValue > 0){
        return 'trending_up'
      } else if(this.trendValue < 0){
        return 'trending_down'
      }
    }
    return '';
  }
  getTrendTextColorClass(){
    if(this.trendValue){
      if(this.reverse){
        if(this.trendValue < 0){
          return 'text-green-70'
        } else {
          return 'text-red-70'
        }
      } else {
        if(this.trendValue > 0){
          return 'text-green-70'
        } else {
          return 'text-red-70'
        }
      }
    }
    return '';
  }
}
