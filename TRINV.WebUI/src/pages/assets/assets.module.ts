import { NgModule } from '@angular/core';
import { AssetsComponent } from './page/assets.component';
import { SharedModule } from '../../shared/shared.module';
import { MatIconModule } from '@angular/material/icon';
import { AddTransactionDialogModule } from '../../features/assets/components/add-transaction/add-transaction.module';
import { StoreModule } from '@ngrx/store';
import { assetsListReducer } from '../../entities/assets/store/assets.reducer';
import { EffectsModule } from '@ngrx/effects';
import { AssetsEffects } from '../../entities/assets/store/assets.effects';
import { AssetsListModule } from '../../features/assets/components/asset-list/asset-list.module';

@NgModule({
  declarations: [AssetsComponent],
  imports: [
    SharedModule,
    AssetsListModule,
    MatIconModule,
    AddTransactionDialogModule,
    StoreModule.forFeature('assets', assetsListReducer),
    EffectsModule.forFeature([AssetsEffects]),
  ],
  exports: [],
  providers: [],
})
export class AssetsModule {}
