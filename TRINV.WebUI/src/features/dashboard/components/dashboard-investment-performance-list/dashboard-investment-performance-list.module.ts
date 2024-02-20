import { NgModule } from "@angular/core";
import { DashboardInvestmentPerformanceListComponent } from "./page/dashboard-investment-performance-list.component";
import { MatTooltip, MatTooltipModule } from "@angular/material/tooltip";

@NgModule({
    declarations: [DashboardInvestmentPerformanceListComponent],
    imports: [MatTooltipModule],
    exports: [DashboardInvestmentPerformanceListComponent],
    providers: [],
  })
  export class DashboardInvestmentPerformanceModule {}
  