import { EntityState, createEntityAdapter } from '@ngrx/entity';

import { OperationResult } from '../../models/operation-result.model';
import * as actions from './external-integration-resource.actions';
import {
  IExternalIntegrationResourceList,
  IExternalIntegrationResourceResultModel,
} from './external-integration-resource.actions';

const customSelectId = (entity: IExternalIntegrationResourceResultModel) =>
  entity.assetId;

export const adapter =
  createEntityAdapter<IExternalIntegrationResourceResultModel>({
     selectId: customSelectId,
  });

export const initialState: ExternalIntegrationResourceInitialState =
  adapter.getInitialState({
    externalIntegrationResourceList: [],
    isLoading: false,
    error: null,
  });

export interface ExternalIntegrationResourceInitialState
  extends EntityState<IExternalIntegrationResourceResultModel> {
  externalIntegrationResourceList: IExternalIntegrationResourceList[];
  isLoading: boolean;
  error: OperationResult | null;
}

export function externalIntegrationResourceReducer(
  state: ExternalIntegrationResourceInitialState = initialState,
  action: actions.ExternalIntegrationResourcesActions
): ExternalIntegrationResourceInitialState {
  switch (action.type) {
    case actions.GET_EXTERNAL_INTEGRATION_RESOURCE_LIST:
      return { ...state, isLoading: true };
    case actions.GET_EXTERNAL_INTEGRATION_RESOURCE_LIST_SUCCESS:
      return {
        ...state,
        externalIntegrationResourceList:
          action.payload.externalIntegrationResources,
        isLoading: false,
      };
    case actions.GET_EXTERNAL_INTEGRATION_RESOURCE_LIST_ERROR:
      return {
        ...state,
        isLoading: false,
        error: action.payload.operationResult,
      };
    case actions.EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES:
      return { ...state };
    case actions.EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES_SUCCESS:
      return { ...state };
    case actions.EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES_ERROR:
      return {
        ...state,
        error: action.payload.operationResult,
      };
    case actions.EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY:
      return { ...state, isLoading: true };
    case actions.EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY_SUCCESS:
      console.log("reducer -> " , action.payload)
      return adapter.addMany(action.payload.externalResources, {
        ...state,
        isLoading: false,
      });
    case actions.EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY_ERROR:
      return {
        ...state,
        isLoading: false,
        error: action.payload.operationResult,
      };
    default:
      return state;
  }
}
