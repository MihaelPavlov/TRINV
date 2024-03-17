import { OperationResult } from '../../../shared/models/operation-result.model';
import { IAssetTransaction } from '../models/asset-transaction.model';
import { IAsset } from '../models/asset.model';
import { ITransaction } from '../models/transaction.model';
import * as actions from './assets.actions';

const initialState: AssetsInitialState = {
  assets: [],
  isLoading: false,
  transactions: [],
  transaction: null,
  error: null,
};

export interface AssetsInitialState {
  assets: IAsset[];
  isLoading: boolean;
  transactions: IAssetTransaction[];
  transaction: ITransaction | null;
  error: OperationResult | null;
}

export function assetsListReducer(
  state: AssetsInitialState = initialState,
  action: actions.AssetsActions
): AssetsInitialState {
  switch (action.type) {
    case actions.CREATE_TRANSACTION:
      return {
        ...state,
        isLoading: true,
      };
    case actions.CREATE_TRANSACTION_SUCCESS:
      return {
        ...state,
        isLoading: false,
      };
    case actions.CREATE_TRANSACTION_ERROR:
    case actions.GET_ASSET_LIST:
      return {
        ...state,
        isLoading: true,
      };
    case actions.GET_ASSET_LIST_SUCCESS:
      return {
        ...state,
        assets: action.payload.assets,
        isLoading: false,
      };
    case actions.GET_ASSET_LIST_ERROR:
    case actions.GET_ASSET_TRANSACTION_LIST:
      return {
        ...state,
        isLoading: true,
      };
    case actions.GET_ASSET_TRANSACTION_LIST_SUCCESS:
      return {
        ...state,
        transactions: action.payload.assetTransactions,
        isLoading: false,
      };
    case actions.GET_ASSET_TRANSACTION_LIST_ERROR:
    case actions.GET_TRANSACTION_BY_ID:
      return {
        ...state,
        isLoading: true,
      };
    case actions.GET_TRANSACTION_BY_ID_SUCCESS:
      return {
        ...state,
        transaction: action.payload.transaction,
        isLoading: false,
      };
    case actions.GET_TRANSACTION_BY_ID_ERROR:
      return {
        ...state,
        isLoading: false,
        error: action.payload.operationResult,
      };
      case actions.UPDATE_TRANSACTION_BY_ID:
        return {
          ...state,
          isLoading: true,
        };
      case actions.UPDATE_TRANSACTION_BY_ID_SUCCESS:
        return {
          ...state,
          isLoading: false,
        };
      case actions.UPDATE_TRANSACTION_BY_ID_ERROR:
        return {
          ...state,
          isLoading: false,
          error: action.payload.operationResult,
        };
        case actions.DELETE_TRANSACTION_BY_ID:
        return {
          ...state,
          isLoading: true,
        };
      case actions.DELETE_TRANSACTION_BY_ID_SUCCESS:
        return {
          ...state,
          isLoading: false,
        };
      case actions.DELETE_TRANSACTION_BY_ID_ERROR:
        return {
          ...state,
          isLoading: false,
          error: action.payload.operationResult,
        };
    default:
      return state;
  }
}
