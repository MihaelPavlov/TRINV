import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as actions from './external-integration-resource.actions';
import { ExternalIntegrationResourceService } from '../../services/external-integration-resource.service';
import { catchError, concatMap, map, of, switchMap } from 'rxjs';
import {
  ExtendedOperationResult,
  OperationResult,
} from '../../models/operation-result.model';
import { IExternalIntegrationResourceResultModel } from './external-integration-resource.actions';

@Injectable()
export class ExternalIntegrationResourceEffects {
  executeAllExternalIntegrationResource$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES),
      switchMap(() =>
        this.externalIntegrationResourceService
          .executeAllExternalIntegrationResource()
          .pipe(
            map((operationResult: OperationResult | null) => {
              console.log(
                'executeAllExternalIntegrationResource',
                operationResult
              );
              if (operationResult != null) {
                return new actions.ExecuteAllExternalIntegrationResourcesSuccess();
              }
              return new actions.ExecuteAllExternalIntegrationResourcesError({
                operationResult,
              });
            })
          )
      )
    )
  );

  executeExternalIntegrationResourceByCategory$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY),
      switchMap((category: any) =>
        this.externalIntegrationResourceService
          .executeExternalIntegrationResourceByCategory(
            category.payload.category
          )
          .pipe(
            map(
              (
                operationResult: ExtendedOperationResult<
                  IExternalIntegrationResourceResultModel[]
                > | null
              ) => {
                console.log(
                  'executeExternalIntegrationResourceByCategory',
                  operationResult
                );

                if (operationResult != null) {
                  return new actions.ExecuteExternalIntegrationResourceByCategorySuccess(
                    { externalResources: operationResult.relatedObject }
                  );
                }
                return new actions.ExecuteExternalIntegrationResourceByCategoryError(
                  {
                    operationResult,
                  }
                );
              }
            ),
            catchError((error) => {
              console.log('------------------------- error ', error);
              return of({ type: 'Failed', payload: error });
            })
          )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private externalIntegrationResourceService: ExternalIntegrationResourceService
  ) {}
}
