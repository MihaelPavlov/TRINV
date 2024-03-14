import { NgModule } from '@angular/core';
import { AddTransactionDialogComponent } from './page/add-transaction.component';
import { SharedModule } from '../../../../shared/shared.module';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { AppStoreModule } from '../../../../app/store/app-store.module';

@NgModule({
  declarations: [AddTransactionDialogComponent],
  imports: [
    SharedModule,
    MatDialogModule,
    MatButtonToggleModule,
    MatSlideToggleModule,
  ],
  exports: [AddTransactionDialogComponent],
  providers: [],
})
export class AddTransactionDialogModule {}
