import { Injectable } from '@angular/core';
import { RestApiService } from '../../../shared/services/rest-api.service';
import { ExtendedOperationResult } from '../../../shared/models/operation-result.model';
import { IAssetTransaction } from '../../assets/models/asset-transaction.model';
import { Observable } from 'rxjs';
import { IInvestmentPerformance } from '../models/investment-performance';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  constructor(private restApiService: RestApiService) {}

  getAssetInvestmentList(
    assetId: string
  ): Observable<ExtendedOperationResult<IAssetTransaction[]> | null> {
    return this.restApiService.post<
      ExtendedOperationResult<IAssetTransaction[]>
    >('/dashboard/asset-investment-list', { assetId });
  }

  getDashboardInvestmentPerformance(): Observable<ExtendedOperationResult<
    IInvestmentPerformance[]
  > | null> {
    return this.restApiService.get<
      ExtendedOperationResult<IInvestmentPerformance[]>
    >('/dashboard/dashboard-investment-performance');
  }
}
