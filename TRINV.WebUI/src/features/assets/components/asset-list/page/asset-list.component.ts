import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import {
  GetAssetList,
  GetAssetTransactionList,
} from '../../../../../entities/assets/store/assets.actions';
import {
  selectAssetTransactions,
  selectAssetsList,
} from '../../../../../entities/assets/store/assets.selectors';
import { IAsset } from '../../../../../entities/assets/models/asset.model';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ViewTransactionDialogComponent } from '../../view-transaction/page/view-transaction.component';
import { IAssetTransaction } from '../../../../../entities/assets/models/asset-transaction.model';

@Component({
  selector: 'app-asset-list',
  templateUrl: 'asset-list.component.html',
  styleUrl: 'asset-list.component.scss',
})
export class AssetListComponent implements OnInit {
  public assets$!: Observable<IAsset[]>;
  public assetTransactions$!: Observable<IAssetTransaction[]>;

  constructor(
    private readonly store: Store,
    private readonly dialog: MatDialog
  ) {}

  public ngOnInit(): void {
    this.store.dispatch(new GetAssetList({ searchExpression: null }));
    this.assets$ = this.store.pipe(select(selectAssetsList));
  }

  public openViewTransactionDialog(id: number): void {
    const dialogRef = this.dialog.open(ViewTransactionDialogComponent, {
      data: id,
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  public convertToPositive(num: number): number {
    return Math.abs(num);
  }

  public onOpenAssetPanel(assetId: string): void {
    this.store.dispatch(new GetAssetTransactionList({ assetId }));
    this.assetTransactions$ = this.store.pipe(select(selectAssetTransactions));
  }
}
