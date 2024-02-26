import { NgModule } from '@angular/core';
import { AssetsListComponent } from './assets-list.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { SharedModule } from '../../shared/shared.module';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule } from '@angular/material/card';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatPaginatorModule } from '@angular/material/paginator';
import { AddAccountDialogModule } from '../../features/add-account/components/add-account-dialog.module';
import { AddTransactionDialogModule } from '../../features/add-transaction/add-transaction.module';
import { ViewTransactionModule } from '../../features/view-transaction/view-transaction.module';

@NgModule({
  declarations: [AssetsListComponent],
  imports: [
    MatPaginatorModule,
    MatTooltipModule,
    MatCardModule,
    MatExpansionModule,
    MatTableModule,
    MatIconModule,
    MatMenuModule,
    MatListModule,
    MatSelectModule,
    SharedModule,
    AddAccountDialogModule,
    AddTransactionDialogModule,
    ViewTransactionModule
  ],
  exports: [],
  providers: [],
})
export class AssetsListModule {}
