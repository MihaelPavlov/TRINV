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
import { IUpdateTransaction } from '../models/update-transaction.mode';

@Injectable({
  providedIn: 'root',
})
export class AssetsService {
  constructor(private restApiService: RestApiService) {}

  UpSertTransaction(
    combineTransactions(
    transaction: IAddTransaction
  ): Observable<OperationResult | null> {
    return this.restApiService.post<OperationResult>(
      '/transaction',
      transaction
    );
  }
  
  combineTransactions(
    transaction: IAddTransaction
  ): Observable<OperationResult | null> {
    return this.restApiService.post<OperationResult>(
      '/transaction',
      transaction
    );
  }

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

  getTransactionById(
    id: number
  ): Observable<ExtendedOperationResult<ITransaction> | null> {
    return this.restApiService.get<ExtendedOperationResult<ITransaction>>(
      `/transaction/${id}`
    );
  }

  updateTransactionById(
    transaction: IUpdateTransaction
  ): Observable<ExtendedOperationResult<string> | null> {
    return this.restApiService.put<ExtendedOperationResult<string>>(
      `/transaction`,
      transaction
    );
  }

  deleteTransactionById(
    id: number
  ): Observable<ExtendedOperationResult<string> | null> {
    return this.restApiService.delete<ExtendedOperationResult<string>>(
      `/transaction/${id}`
    );
  }
}
