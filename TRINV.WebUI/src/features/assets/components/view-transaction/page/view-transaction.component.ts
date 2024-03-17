import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
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
import { Observable } from 'rxjs';
import { ITransaction } from '../../../../../entities/assets/models/transaction.model';
import {
  DeleteTransactionById,
  GetTransactionById,
  UpdateTransactionById,
} from '../../../../../entities/assets/store/assets.actions';
import { selectTransaction } from '../../../../../entities/assets/store/assets.selectors';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'view-add-transaction-dialog',
  templateUrl: 'view-transaction.component.html',
  styleUrl: 'view-transaction.component.scss',
})
export class ViewTransactionDialogComponent implements OnInit {
  public chart: any;
  public transaction$!: Observable<ITransaction | null>;

  public updateForm = new FormGroup({
    quantity: new FormControl(),
    totalPrice: new FormControl(),
    pricePerUnit: new FormControl(),
  });

  constructor(
    private readonly dialogRef: MatDialogRef<ViewTransactionDialogComponent>,
    private readonly store: Store,
    @Inject(MAT_DIALOG_DATA) public id: number
  ) {
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

  public ngOnInit(): void {
    this.store.dispatch(
      new GetTransactionById({
        id: this.id,
      })
    );

    this.transaction$ = this.store.pipe(select(selectTransaction));

    this.transaction$.subscribe((transaction) => {
      if (transaction) {
        this.updateForm.patchValue(transaction);
      }
    });

    this.createChart();
  }

  public onUpdate(id: number): void {
    this.store.dispatch(
      new UpdateTransactionById({
        transaction: {
          id: id,
          quantity: this.updateForm.controls.quantity.value,
          totalPrice: this.updateForm.controls.totalPrice.value,
          pricePerUnit: this.updateForm.controls.pricePerUnit.value,
        },
      })
    );

    this.closeDialog();
  }

  public ontDelete(id: number): void {
    this.store.dispatch(new DeleteTransactionById({ id }));
    this.closeDialog();
  }

  public closeDialog(): void {
    this.dialogRef.removePanelClass('form-dialog');
    this.dialogRef.close();
  }

  createChart() {
    this.chart = new Chart('chart', {
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
