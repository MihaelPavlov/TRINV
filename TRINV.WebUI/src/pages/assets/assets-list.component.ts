import { Component } from '@angular/core';
import { Observable, of } from 'rxjs';

export interface ShipData {
  assetId: string;
  name: string;
  totalQuantity: number;
  totalPrice: number;
}

export const exampleShips: ShipData[] = [
  {
    assetId: 'btc',
    name: 'Bitcoin',
    totalQuantity: 1,
    totalPrice: 231021,
  },
  {
    assetId: 'eth',
    name: 'Ethreium',
    totalQuantity: 12.313,
    totalPrice: 15003,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
];

export interface PeriodicElement {
  dateAdded: string;
  quantity: number;
  price: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { dateAdded: '2012 02 01', quantity: 1.4, price: 202 },
  { dateAdded: '2023 02 01', quantity: 0.4, price: 321 },
  { dateAdded: '2022 02 01', quantity: 4.331, price: 1.0079 },
  { dateAdded: '2015 02 01', quantity: 5.4, price: 1.0079 },
  { dateAdded: '2017 02 01', quantity: 1, price: 1.0079 },
];

@Component({
  selector: 'app-assets-list',
  templateUrl: 'assets-list.component.html',
  styleUrl: 'assets-list.component.scss',
})
export class AssetsListComponent {
  displayedRows$!: Observable<ShipData[]>;

  displayedColumns: string[] = ['dateAdded', 'quantity', 'price', 'actions'];

  dataSource = ELEMENT_DATA;
  ngOnInit() {
    const rows$ = of(exampleShips);
    this.displayedRows$ = rows$;
  }
}
