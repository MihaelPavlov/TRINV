import { Injectable } from '@angular/core';
import { RestApiService } from '../../../shared/services/rest-api.service';
import { IAddTransaction } from '../models/add-transaction.model';
import {
  ExtendedOperationResult,
  OperationResult,
} from '../../../shared/models/operation-result.model';
import { Observable } from 'rxjs';
import { IAsset } from '../models/asset.model';
import { IAssetTransaction } from '../models/asset-transaction.model';
import { ITransaction } from '../models/transaction.model';

@Injectable({
  providedIn: 'root',
})
export class AssetsService {
  constructor(private restApiService: RestApiService) {}

  createTransaction(
    transaction: IAddTransaction
  ): Observable<OperationResult | null> {
    return this.restApiService.post<OperationResult>(
      '/transaction',
      transaction
    );
  }

  getAssets(
    searchExpression: string | null
  ): Observable<ExtendedOperationResult<IAsset[]> | null> {
    return this.restApiService.post<ExtendedOperationResult<IAsset[]>>(
      '/transaction/asset-list',
      { searchExpression }
    );
  }

  getAssetTransactions(
    assetId: string
  ): Observable<ExtendedOperationResult<IAssetTransaction[]> | null> {
    return this.restApiService.post<
      ExtendedOperationResult<IAssetTransaction[]>
    >('/transaction/asset-transaction-list', { assetId });
  }

  getTransactionById(
    id: number
  ): Observable<ExtendedOperationResult<ITransaction> | null> {
    return this.restApiService.get<ExtendedOperationResult<ITransaction>>(
      `/transaction/${id}`
    );
  }
}
