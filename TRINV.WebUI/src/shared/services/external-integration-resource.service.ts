import { Injectable } from '@angular/core';
import { RestApiService } from './rest-api.service';
import {
  ExtendedOperationResult,
  OperationResult,
} from '../models/operation-result.model';
import { Observable } from 'rxjs';
import {
  ExternalResourceCategory,
  IExternalIntegrationResourceResultModel,
} from '../store/external-integration-resource/external-integration-resource.actions';

@Injectable({
  providedIn: 'root',
})
export class ExternalIntegrationResourceService {
  constructor(private restApiService: RestApiService) {}

  executeAllExternalIntegrationResource(): Observable<OperationResult | null> {
    return this.restApiService.get<OperationResult>(
      '/externalIntegrationResource/execute-all'
    );
  }

  executeExternalIntegrationResourceByCategory(
    category: number
  ): Observable<ExtendedOperationResult<IExternalIntegrationResourceResultModel[]> | null> {
    console.log("by category " , category)
    return this.restApiService.get<
      ExtendedOperationResult<IExternalIntegrationResourceResultModel[]>
    >(`/externalIntegrationResource/execute-by-category/${category}`);
  }
}
