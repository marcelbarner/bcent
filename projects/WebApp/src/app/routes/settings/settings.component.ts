import {Component} from '@angular/core';
import {PageHeaderComponent} from '@shared';
import {CategoriesSettingComponent} from './categories-setting/categories-setting.component';
import {RulesSetttingComponent} from './rules-settting/rules-settting.component';

@Component({
  selector: 'app-settings',
  imports: [
    PageHeaderComponent,
    CategoriesSettingComponent,
    RulesSetttingComponent
  ],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {

}



