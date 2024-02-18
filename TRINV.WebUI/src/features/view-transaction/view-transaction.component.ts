import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CategoryScale, Chart, Filler, LineController, LineElement, LinearScale, PointElement, Tooltip } from 'chart.js';

@Component({
  selector: 'view-add-transaction-dialog',
  templateUrl: 'view-transaction.component.html',
  styleUrl: 'view-transaction.component.scss',
})
export class ViewTransactionDialogComponent implements OnInit {
  public chart: any;

  constructor(
    private readonly dialogRef: MatDialogRef<ViewTransactionDialogComponent>
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

  public closeDialog(): void {
    this.dialogRef.removePanelClass('form-dialog');
    this.dialogRef.close();
  }
  ngOnInit() {
    this.createChart();
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
