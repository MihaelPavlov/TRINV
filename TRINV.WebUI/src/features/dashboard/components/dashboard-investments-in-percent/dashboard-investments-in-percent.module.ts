import { NgModule } from "@angular/core";
import { DashboardInvestmentsInPecentComponent } from "./page/dashboard-investments-in-percent.component";
import { DashboardGenericTableDialogModule } from "../dashboard-generic-table/dashboard-generic-table.module";

@NgModule({
    declarations: [DashboardInvestmentsInPecentComponent],
    imports: [DashboardGenericTableDialogModule],
    exports: [DashboardInvestmentsInPecentComponent],
    providers: [],
  })
  export class DashboardInvestmentsInPecentModule {}
  