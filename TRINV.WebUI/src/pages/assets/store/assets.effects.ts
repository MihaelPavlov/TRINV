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
      switchMap((_) =>
        this.assetsService.getAssets(null)
      ),
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
      switchMap((data:actions.GetAssetList) =>{
       return this.assetsService.getAssets(data.payload.searchExpression)
    }
      ),
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
      switchMap((data:actions.GetAssetTransactionList) =>
        this.assetsService.getAssetTransactions(data.payload.assetId)
      ),
      map(
        (
          operationResult: ExtendedOperationResult<IAssetTransaction[]> | null
        ) => {
            console.log("result ->", operationResult?.relatedObject);
            
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
      switchMap((data:actions.GetTransactionById) => this.assetsService.getTransactionById(data.payload.id)),
      map((operationResult: ExtendedOperationResult<ITransaction> | null) => {
        return new actions.GetTransactionByIdSuccess({
          transaction: operationResult?.relatedObject ?? null,
        });
      })
    )
  );

  //
  constructor(
    private readonly actions$: Actions,
    private readonly assetsService: AssetsService
  ) {}
}
