import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard-investment-performance-list',
  templateUrl: 'dashboard-investment-performance-list.component.html',
  styles: [
    `
      .index {
        position: relative;
        z-index: 0;
      }
      .text-green {
        color: green;
      }

      .text-red {
        color: red;
      }
    `,
  ],
})
export class DashboardInvestmentPerformanceListComponent {}
