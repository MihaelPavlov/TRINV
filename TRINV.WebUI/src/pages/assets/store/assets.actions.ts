import { Action } from '@ngrx/store';
import { OperationResult } from '../../../shared/models/operation-result.model';
import { IAddTransaction } from '../models/add-transaction.model';
import { IAsset } from '../models/asset.model';
import { IAssetTransaction } from '../models/asset-transaction.model';
import { ITransaction } from '../models/transaction.model';

export const CREATE_TRANSACTION = '[Assets] Create Transaction';
export const CREATE_TRANSACTION_SUCCESS = '[Assets] Create Transaction Success';
export const CREATE_TRANSACTION_ERROR = '[Assets] Create Transaction Error';

export const GET_ASSET_LIST = '[Assets] Get Asset List';
export const GET_ASSET_LIST_SUCCESS = '[Assets] Get Asset List Success';
export const GET_ASSET_LIST_ERROR = '[Assets] Get Asset List Error';

export const GET_ASSET_TRANSACTION_LIST = '[Assets] Get Asset Transaction List';
export const GET_ASSET_TRANSACTION_LIST_SUCCESS =
  '[Assets] Get Asset Transaction List Success';
export const GET_ASSET_TRANSACTION_LIST_ERROR =
  '[Assets] Get Asset Transaction List Error';

export const GET_TRANSACTION_BY_ID = '[Assets] Get Transaction By Id';
export const GET_TRANSACTION_BY_ID_SUCCESS =
  '[Assets] Get Transaction By Id Success';
export const GET_TRANSACTION_BY_ID_ERROR =
  '[Assets] Get Transaction By Id Error';

export class CreateTransaction implements Action {
  readonly type = CREATE_TRANSACTION;

  constructor(public payload: { transaction: IAddTransaction | null }) {}
}

export class CreateTransactionSuccess implements Action {
  readonly type = CREATE_TRANSACTION_SUCCESS;

  constructor() {}
}

export class CreateTransactionError implements Action {
  readonly type = CREATE_TRANSACTION_ERROR;

  constructor(public payload: { operationResult: OperationResult | null }) {}
}

export class GetAssetList implements Action {
  readonly type = GET_ASSET_LIST;

  constructor(public payload: { searchExpression: string | null }) {}
}

export class GetAssetListSuccess implements Action {
  readonly type = GET_ASSET_LIST_SUCCESS;

  constructor(public payload: { assets: IAsset[] }) {}
}

export class GetAssetListError implements Action {
  readonly type = GET_ASSET_LIST_ERROR;

  constructor(public payload: { operationResult: OperationResult | null }) {}
}

export class GetAssetTransactionList implements Action {
  readonly type = GET_ASSET_TRANSACTION_LIST;

  constructor(public payload: { assetId: string }) {}
}

export class GetAssetTransactionListSuccess implements Action {
  readonly type = GET_ASSET_TRANSACTION_LIST_SUCCESS;

  constructor(
    public payload: {
      assetTransactions: IAssetTransaction[];
    }
  ) {}
}

export class GetAssetTransactionListError implements Action {
  readonly type = GET_ASSET_TRANSACTION_LIST_ERROR;

  constructor(public payload: { operationResult: OperationResult | null }) {}
}

export class GetTransactionById implements Action {
  readonly type = GET_TRANSACTION_BY_ID;

  constructor(public payload: { id: number }) {}
}

export class GetTransactionByIdSuccess implements Action {
  readonly type = GET_TRANSACTION_BY_ID_SUCCESS;

  constructor(
    public payload: {
      transaction: ITransaction | null;
    }
  ) {}
}

export class GetTransactionByIdError implements Action {
  readonly type = GET_TRANSACTION_BY_ID_ERROR;

  constructor(public payload: { operationResult: OperationResult | null }) {}
}

export type AssetsActions =
  | CreateTransaction
  | CreateTransactionSuccess
  | CreateTransactionError
  | GetAssetList
  | GetAssetListSuccess
  | GetAssetListError
  | GetAssetTransactionList
  | GetAssetTransactionListSuccess
  | GetAssetTransactionListError
  | GetTransactionById
  | GetTransactionByIdSuccess
  | GetTransactionByIdError;
