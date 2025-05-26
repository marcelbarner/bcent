import {Component} from '@angular/core';
import {CategoriesTreeComponent} from './categories-tree/categories-tree.component';
import {TranslatePipe} from '@ngx-translate/core';

@Component({
  selector: 'app-categories-setting',
  imports: [
    CategoriesTreeComponent,
    TranslatePipe
  ],
  templateUrl: './categories-setting.component.html',
  styleUrl: './categories-setting.component.css'
})
export class CategoriesSettingComponent {
  public incomeCategories = CATEGORIES.income;
  public expensesCategories = CATEGORIES.expenses;
}

const CATEGORIES =
  {
    "income": [
      {
        "name": "Erwerbseinkommen",
        "children": [
          {"name": "Gehalt"},
          {"name": "Nebenjob"}
        ]
      },
      {
        "name": "Selbständige Tätigkeiten",
        "children": [
          {"name": "Nebengewerbe"}
        ]
      },
      {
        "name": "Kapitaleinkünfte",
        "children": [
          {"name": "Zinsen"},
          {"name": "Dividenden"},
          {"name": "Aktienverkäufe"}
        ]
      },
      {
        "name": "Sonstige Einnahmen",
        "children": [
          {"name": "Geschenke"}
        ]
      }
    ],
    "expenses": [
      {
        "name": "Wohnen",
        "children": [
          {"name": "Miete"},
          {"name": "Nebenkosten"},
          {"name": "Strom"},
          {"name": "Internet/Telefon"}
        ]
      },
      {
        "name": "Lebenshaltung",
        "children": [
          {"name": "Lebensmittel"},
          {"name": "Hygiene"},
          {"name": "Haushalt"}
        ]
      },
      {
        "name": "Mobilität",
        "children": [
          {"name": "Öffentliche Verkehrsmittel"},
          {"name": "Auto (Benzin, Versicherung, Wartung)"}
        ]
      },
      {
        "name": "Versicherungen",
        "children": [
          {"name": "Krankenversicherung"},
          {"name": "Haftpflichtversicherung"},
          {"name": "Hausratversicherung"},
          {"name": "Berufsunfähigkeitsversicherung"}
        ]
      },
      {
        "name": "Freizeit & Unterhaltung",
        "children": [
          {"name": "Streamingdienste"},
          {"name": "Hobbys"},
          {"name": "Urlaub & Reisen"},
          {"name": "Sport & Fitness"}
        ]
      },
      {
        "name": "Gesundheit",
        "children": [
          {"name": "Medikamente"},
          {"name": "Arztkosten"},
          {"name": "Zahnbehandlung"}
        ]
      },
      {
        "name": "Bildung & Weiterbildung",
        "children": [
          {"name": "Kurse & Seminare"},
          {"name": "Fachliteratur"},
          {"name": "Schulgebühren"}
        ]
      },
      {
        "name": "Vorsorge & Investitionen",
        "children": [
          {"name": "Rentenversicherung"},
          {"name": "Private Altersvorsorge"},
          {
            "name": "Wertpapiere",
            "children": [
              {"name": "Aktienkäufe"},
              {"name": "ETFs / Fonds"},
              {"name": "Kryptowährungen"}
            ]
          },
          {"name": "P2P-Anlagen"},
          {"name": "Sonstige Investitionen"}
        ]
      },
      {
        "name": "Sonstige Ausgaben",
        "children": [
          {"name": "Geschenke"},
          {"name": "Spenden"},
          {"name": "Unvorhergesehenes"}
        ]
      }
    ]
  };
