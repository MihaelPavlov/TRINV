import { NgModule } from "@angular/core";
import { DashboardInvestmentPerformanceListComponent } from "./page/dashboard-investment-performance-list.component";
import { MatTooltip, MatTooltipModule } from "@angular/material/tooltip";
import { SharedModule } from "../../../../shared/shared.module";

@NgModule({
    declarations: [DashboardInvestmentPerformanceListComponent],
    imports: [MatTooltipModule,SharedModule],
    exports: [DashboardInvestmentPerformanceListComponent],
    providers: [],
  })
  export class DashboardInvestmentPerformanceModule {}
  