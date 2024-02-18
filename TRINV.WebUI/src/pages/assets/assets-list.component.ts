import {
  Component,
} from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import {
  CategoryScale,
  Chart,
  Filler,
  LineController,
  LineElement,
  LinearScale,
  PointElement,
  Tooltip,
} from 'chart.js';
import { Observable, of } from 'rxjs';
import { AddTransactionDialogComponent } from '../../features/add-transaction/add-transaction.component';
import { ViewTransactionDialogComponent } from '../../features/view-transaction/view-transaction.component';

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
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
  },
  {
    assetId: 'tth',
    name: 'Tether',
    totalQuantity: 495,
    totalPrice: 500,
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
  value = 'Clear me';

  displayedColumns: string[] = ['dateAdded', 'quantity', 'price', 'actions'];
  public chartData: any | null = null;

  dataSource = ELEMENT_DATA;
  public chart: any;

  constructor(public dialog: MatDialog) {
    Chart.register(
      LinearScale,
      LineController,
      CategoryScale,
      PointElement,
      LineElement,
      Tooltip,
      Filler
    );
  }

  openViewTransactionDialog() {
    const dialogRef = this.dialog.open(ViewTransactionDialogComponent, {

    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openAddTransactionDialog() {
    const dialogRef = this.dialog.open(AddTransactionDialogComponent, {

    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  ngOnInit() {
    const rows$ = of(exampleShips);
    this.displayedRows$ = rows$;

    this.createChart();
  }

  public testChart() {
    let options: { label: string; value: string }[] = [
      {
        label: 'Today',
        value: 'today',
      },
      {
        label: 'Last 7 Days',
        value: '7days',
      },
      {
        label: 'Last 30 Days',
        value: '30days',
      },
      {
        label: 'Last 6 Months',
        value: '6months',
      },
      {
        label: 'This Year',
        value: 'year',
      },
    ];

    this.chart = new Chart('MyChart', {
      type: 'line',
      data: {
        labels: [
          'Jan',
          'Feb',
          'Mar',
          'Apr',
          'May',
          'Jun',
          'Jul',
          'Aug',
          'Sep',
          'Oct',
          'Nov',
          'Dec',
        ],
        datasets: [
          {
            label: 'Income',
            backgroundColor: 'rgba(102, 126, 234, 0.25)',
            borderColor: 'rgba(102, 126, 234, 1)',
            pointBackgroundColor: 'rgba(102, 126, 234, 1)',
            data: [13, 16, 21, 28, 32, 34, 32, 31, 30, 26, 20, 100],
          },
          {
            label: 'Expenses',
            backgroundColor: 'rgba(237, 100, 166, 0.25)',
            borderColor: 'rgba(237, 100, 166, 1)',
            pointBackgroundColor: 'rgba(237, 100, 166, 1)',
            data: [13, 16, 21, 28, 32, 34, 32, 31, 30, 26, 20, 100],
          },
        ],
      },
      options: {
        scales: {
          y: {
            grid: {
              display: false,
            },
            ticks: {
              callback(tickValue, index, ticks) {
                let value = tickValue as number;
                return value > 1000
                  ? value < 1000000
                    ? value / 1000 + 'K'
                    : value / 1000000 + 'M'
                  : value;
              },
            },
          },
        },
      },
    });
  }

  createChart() {
    this.chart = new Chart('MyChart', {
      type: 'line',
      data: {
        labels: [
          'Jan',
          'Feb',
          'Mar',
          'Apr',
          'May',
          'Jun',
          'Jul',
          'Aug',
          'Sep',
          'Oct',
          'Nov',
          'Dec',
        ],
        datasets: [
          {
            label: 'Temperature(C) in Lahore',
            data: [13, 16, 21, 28, 32, 34, 32, 31, 30, 26, 20, 100],
            backgroundColor: 'rgba(102, 126, 234, 0.25)',
            borderColor: 'rgba(102, 126, 234, 1)',
            pointBackgroundColor: 'rgba(102, 126, 234, 1)',
            borderWidth: 2,
            fill: 'origin',
          },
          {
            label: 'Cloud Coverage(%) in Lahore',
            data: [26, 29, 31, 24, 10, 3, 14, 16, 4, 5, 23, 50],
            backgroundColor: 'rgba(237, 100, 166, 0.25)',
            borderColor: 'rgba(237, 100, 166, 1)',
            pointBackgroundColor: 'rgba(237, 100, 166, 1)',
            borderWidth: 2,
          },
        ],
      },
      options: {
        responsive: true,
        aspectRatio: 2.5,
        scales: {
          y: {
            beginAtZero: true,
            grid: {
              color: 'rgba(225, 255, 255, 0.2)',
              lineWidth: 2,
            },
            border: {
              dash: [1, 10],
            },
            ticks: { color: 'rgb(157,163,175)' },
          },
          x: {
            grid: {
              color: 'rgba(225, 255, 255, 0.02)',
            },
            ticks: { color: 'rgb(157,163,175)' },
          },
        },
        plugins: {
          tooltip: {
            backgroundColor: 'rgba(0, 0, 0, 0.7)',
            bodyFont: {
              size: 14,
            },
            titleFont: {
              size: 16,
              weight: 'bold',
            },
          },
          legend: {
            labels: {
              font: {
                size: 14,
              },
            },
          },
        },
      },
    });
  }
}
