import { NgModule } from "@angular/core";
import { SharedModule } from "../../../../shared/shared.module";
import { DashboardGenericTableDialogComponent } from "./page/dashboard-generic-table.component";
import { MatDialogClose, MatDialogModule } from "@angular/material/dialog";

@NgModule({
    declarations: [DashboardGenericTableDialogComponent],
    imports: [
      SharedModule,
      MatDialogModule,
      MatDialogClose
    ],
    exports: [DashboardGenericTableDialogComponent],
    providers: [],
  })
  export class DashboardGenericTableDialogModule {}
  