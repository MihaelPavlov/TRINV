import { Component, OnInit, ViewChild } from '@angular/core';
import {
  ArcElement,
  Chart,
  DoughnutController,
  Legend,
  Title,
  Tooltip,
} from 'chart.js';

@Component({
  selector: 'app-dashboard-sum-price-chart',
  templateUrl: 'dashboard-sum-price-chart.component.html',
  styleUrl: 'dashboard-sum-price-chart.component.scss',
})
export class DashboardSumPriceChartComponent implements OnInit {
  @ViewChild(`canvas`) canvasElement!: HTMLCanvasElement;
  public chart: any;

  constructor() {
    Chart.register(Tooltip, Title, DoughnutController, ArcElement, Legend);
  }

  ngOnInit(): void {
    this.chart = new Chart('chart', {
      type: 'doughnut',
      data: {
        labels: ['A', 'B', 'C'],
        datasets: [
          {
            data: [150, 50, 100],
            backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56'],
          },
        ],
      },
      options: {
        animation: { duration: 1000 },
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          tooltip: {
            yAlign: 'top',
            xAlign: 'center',
            position: 'nearest',
            displayColors: false,
            axis: 'x',
          },
          legend: {
            display: true,
            position: 'bottom',
            align: 'center',
            labels: {
              boxWidth: 20,
              padding: 15.0,
            },
          },
          title: {
            display: true,
            text: 'Price Chart',
          },
        },
      },
    });
  }
}
