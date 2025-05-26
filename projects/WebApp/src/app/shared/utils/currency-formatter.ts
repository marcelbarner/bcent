import {NumberFormatter, Root} from '@amcharts/amcharts5';
import {CurrencyPipe} from '@angular/common';

export class CurrencyFormatter extends NumberFormatter{
  private pipe: CurrencyPipe;
  constructor(root: Root, pipe:CurrencyPipe) {
    super(root,{}, false);
    this.pipe = pipe;
  }
  override format(value: number | string, format?: string | Intl.NumberFormatOptions, precision?: number): string {
    return this.pipe.transform(value, 'EUR') ?? super.format(value, format, precision);
  }

}
