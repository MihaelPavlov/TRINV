import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { MatDialogModule } from '@angular/material/dialog';
import { ViewTransactionDialogComponent } from './view-transaction.component';

@NgModule({
  declarations: [ViewTransactionDialogComponent],
  imports: [
    SharedModule,MatDialogModule
  ],
  exports: [ViewTransactionDialogComponent],
  providers: [],
})
export class ViewTransactionModule {}
