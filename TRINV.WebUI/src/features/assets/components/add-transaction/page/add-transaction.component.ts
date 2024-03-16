import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import {
  ExecuteExternalIntegrationResourceByCategory,
  ExternalResourceCategory,
  IExternalIntegrationResourceResultModel,
} from '../../../../../shared/store/external-integration-resource/external-integration-resource.actions';
import { Observable } from 'rxjs';
import { selectExternalIntegrationResourceResultList } from '../../../../../shared/store/external-integration-resource/external-integration-resource.selectors';
import { AppState } from '../../../../../app/store/app-store.module';
import { FormControl, FormGroup } from '@angular/forms';
import { CreateTransaction } from '../../../../../pages/assets/store/assets.actions';

@Component({
  selector: 'app-add-transaction-dialog',
  templateUrl: 'add-transaction.component.html',
  styleUrl: 'add-transaction.component.scss',
})
export class AddTransactionDialogComponent implements OnInit {
  public assets$!: Observable<IExternalIntegrationResourceResultModel[]>;
  public filteredAssets!: IExternalIntegrationResourceResultModel[];
  public searchTerm!: string;

  public addUpdateForm = new FormGroup({
    type: new FormControl(),
    assetId: new FormControl(),
    name: new FormControl(),
    quantity: new FormControl(),
    purchasePrice: new FormControl(),
    purchasePricePerUnit: new FormControl(),
  });

  constructor(
    private readonly dialogRef: MatDialogRef<AddTransactionDialogComponent>,
    private readonly store: Store<AppState>
  ) {}

  public ngOnInit(): void {
    this.store.dispatch(
      new ExecuteExternalIntegrationResourceByCategory({
        category: ExternalResourceCategory.Crypto,
      })
    );

    this.assets$ = this.store.pipe(
      select(selectExternalIntegrationResourceResultList)
    );

    this.assets$.subscribe((x) => (this.filteredAssets = x));

    this.addUpdateForm
      .get('assetId')
      ?.valueChanges.subscribe((selectedAssetId) => {
        this.assets$.subscribe((assetList) => {
          const selectedAsset = assetList.find(
            (asset) => asset.assetId === selectedAssetId
          );

          if (selectedAsset) {
            this.addUpdateForm.get('name')?.setValue(selectedAsset.name);
          }
        });
      });
  }

  public filterAssets(): void {
    if (!this.searchTerm || this.searchTerm === '') {
      this.assets$.subscribe((assets) => {
        this.filteredAssets = assets;
      });
      return;
    }

    // Filter assets based on the search term
    this.assets$.subscribe((assets) => {
      this.filteredAssets = assets.filter(
        (asset) =>
          asset.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
          asset.assetId.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    });
  }

  onSubmit() {
    this.store.dispatch(
      new CreateTransaction({
        transaction: {
          assetId: this.addUpdateForm.controls.assetId.value,
          name: this.addUpdateForm.controls.name.value,
          quantity: this.addUpdateForm.controls.quantity.value,
          purchasePrice: this.addUpdateForm.controls.purchasePrice.value,
          purchasePricePerUnit: this.addUpdateForm.controls.purchasePricePerUnit.value,
          transactionType: this.addUpdateForm.controls.type.value as TransactionType,
          isFromOutsideProvider: true
        },
      })
    );

    this.closeDialog();
  }

  public closeDialog(): void {
    this.dialogRef.removePanelClass('form-dialog');
    this.dialogRef.close();
  }
}

export enum TransactionType{
  Bought = 0,
  Sold = 1,
}