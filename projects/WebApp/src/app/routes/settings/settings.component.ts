import {Component} from '@angular/core';
import {PageHeaderComponent} from '@shared';
import {CategoriesSettingComponent} from './categories-setting/categories-setting.component';

@Component({
  selector: 'app-settings',
  imports: [
    PageHeaderComponent,
    CategoriesSettingComponent
  ],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {

}



