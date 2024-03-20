import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AssetsService } from '../api/assets.service';
import * as actions from './assets.actions';
import {
  ExtendedOperationResult,
  OperationResult,
} from '../../../shared/models/operation-result.model';
import { IAddTransaction } from '../models/add-transaction.model';
import { catchError, map, of, switchMap, tap } from 'rxjs';
import { IAsset } from '../models/asset.model';
import { IAssetTransaction } from '../models/asset-transaction.model';
import { ITransaction } from '../models/transaction.model';
import { DashboardService } from '../../dashboard/api/dashboard.service';

@Injectable()
export class AssetsEffects {
  addTransaction$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.CREATE_TRANSACTION),
      switchMap((data: actions.CreateTransaction) => {
        console.log('transaction -> ', data.payload.transaction);
        return this.assetsService
          .createTransaction(data.payload.transaction as IAddTransaction)
          .pipe(
            map((operationResult: OperationResult | null) => {
              if (!operationResult?.success) {
                return new actions.CreateTransactionError({
                  operationResult,
                });
              }
              return new actions.CreateTransactionSuccess();
            }),
            tap(() => console.log('transaction tracked')),
            catchError((error) => {
              console.log('------------------------- error ', error);

              return of({ type: 'Failed', payload: error });
            })
          );
      })
    )
  );

  addTransactionSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.CREATE_TRANSACTION_SUCCESS),
      switchMap((_) => this.assetsService.getAssets(null)),
      map((operationResult: ExtendedOperationResult<IAsset[]> | null) => {
        return new actions.GetAssetListSuccess({
          assets: operationResult?.relatedObject ?? [],
        });
      })
    )
  );

  getAssets$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.GET_ASSET_LIST),
      switchMap((data: actions.GetAssetList) => {
        return this.assetsService.getAssets(data.payload.searchExpression);
      }),
      map((operationResult: ExtendedOperationResult<IAsset[]> | null) => {
        return new actions.GetAssetListSuccess({
          assets: operationResult?.relatedObject ?? [],
        });
      })
    )
  );

  getAssetTransactionList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.GET_ASSET_TRANSACTION_LIST),
      switchMap((data: actions.GetAssetTransactionList) =>
        this.dashboardService.getAssetInvestmentList(data.payload.assetId)
      ),
      map(
        (
          operationResult: ExtendedOperationResult<IAssetTransaction[]> | null
        ) => {
          return new actions.GetAssetTransactionListSuccess({
            assetTransactions: operationResult?.relatedObject ?? [],
          });
        }
      )
    )
  );

  getTransactionById$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.GET_TRANSACTION_BY_ID),
      switchMap((data: actions.GetTransactionById) =>
        this.assetsService.getTransactionById(data.payload.id)
      ),
      map((operationResult: ExtendedOperationResult<ITransaction> | null) => {
        console.log('transaction-> ', operationResult?.relatedObject);

        return new actions.GetTransactionByIdSuccess({
          transaction: operationResult?.relatedObject ?? null,
        });
      })
    )
  );

  updateTransactionById$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.UPDATE_TRANSACTION_BY_ID),
      switchMap((data: actions.UpdateTransactionById) =>
        this.assetsService.updateTransactionById(data.payload.transaction)
      ),
      map((operationResult: ExtendedOperationResult<string> | null) => {
        if (operationResult?.success) {
          return new actions.UpdateTransactionByIdSuccess();
        }

        return new actions.UpdateTransactionByIdError({ operationResult });
      })
    )
  );

  updateTransactionByIdSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.UPDATE_TRANSACTION_BY_ID_SUCCESS),
      switchMap((_) => this.assetsService.getAssets(null)),
      map((operationResult: ExtendedOperationResult<IAsset[]> | null) => {
        return new actions.GetAssetListSuccess({
          assets: operationResult?.relatedObject ?? [],
        });
      })
    )
  );

  deleteTransactionById$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.DELETE_TRANSACTION_BY_ID),
      switchMap((data: actions.DeleteTransactionById) =>
        this.assetsService.deleteTransactionById(data.payload.id)
      ),
      map((operationResult: ExtendedOperationResult<string> | null) => {
        if (operationResult?.success) {
          return new actions.DeleteTransactionByIdSuccess();
        }

        return new actions.UpdateTransactionByIdError({ operationResult });
      })
    )
  );

  deleteTransactionByIdSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.DELETE_TRANSACTION_BY_ID_SUCCESS),
      switchMap((data: actions.DeleteTransactionByIdSuccess) =>
        this.assetsService.getAssets(null)
      ),
      map((operationResult: ExtendedOperationResult<IAsset[]> | null) => {
        return new actions.GetAssetListSuccess({
          assets: operationResult?.relatedObject ?? [],
        });
      })
    )
  );

  constructor(
    private readonly actions$: Actions,
    private readonly assetsService: AssetsService,
    private readonly dashboardService: DashboardService
  ) {}
}
