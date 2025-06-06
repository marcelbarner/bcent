import { Component, Input, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Select } from '@ngxs/store';
import { Observable } from 'rxjs';
import { CategoriesState } from '../../../../states/categories.state';
import { WebApi2FeaturesCategoriesCategory } from '../../../../api/models/web-api-2-features-categories-category';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MtxSelectModule } from '@ng-matero/extensions/select';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-categories-select',
  standalone: true,
  imports: [
    // Angular
    CommonModule,
    // Material
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    // MTX
    MtxSelectModule,
    TranslateModule,
  ],
  templateUrl: './categories-select.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CategoriesSelectComponent),
      multi: true
    }
  ]
})
export class CategoriesSelectComponent implements ControlValueAccessor {
  @Input() multiple = false;
  @Input() label = 'Kategorie';

  @Select(CategoriesState.categories)
  categories$!: Observable<WebApi2FeaturesCategoriesCategory[]>;

  value: number | number[] | null = null;
  disabled = false;

  private onChange: (value: any) => void = () => {};
  private onTouched: () => void = () => {};

  writeValue(obj: any): void {
    this.value = obj;
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  onSelectionChange(event: any) {
    // Fix: mtx-select emits value as array for multi, as single value for single
    let newValue = event.value;
    if (!this.multiple && Array.isArray(newValue)) {
      newValue = newValue.length > 0 ? newValue[0] : null;
    }
    this.value = newValue;
    this.onChange(this.value);
    this.onTouched();
  }
}
