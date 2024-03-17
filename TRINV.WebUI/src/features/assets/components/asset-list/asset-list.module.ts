import { MatExpansionModule } from "@angular/material/expansion";
import { SharedModule } from "../../../../shared/shared.module";
import { ViewTransactionModule } from "../view-transaction/view-transaction.module";
import { AssetListComponent } from "./page/asset-list.component";
import { NgModule } from "@angular/core";
import { MatIconModule } from "@angular/material/icon";
import { MatSelectModule } from "@angular/material/select";
import { MatListModule } from "@angular/material/list";
import { MatMenuModule } from "@angular/material/menu";
import { MatTableModule } from "@angular/material/table";
import { MatCardModule } from "@angular/material/card";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatPaginatorModule } from "@angular/material/paginator";

@NgModule({
    declarations: [AssetListComponent],
    imports: [
      MatExpansionModule,
      MatIconModule,
      SharedModule,
      MatPaginatorModule,
      MatTooltipModule,
      MatCardModule,
      MatTableModule,
      MatIconModule,
      MatMenuModule,
      MatListModule,
      MatSelectModule,
      ViewTransactionModule,
    ],
    exports: [AssetListComponent],
    providers: [],
  })
  export class AssetsListModule {}