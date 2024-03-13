import { Action } from '@ngrx/store';
import { OperationResult } from '../../models/operation-result.model';

export const GET_EXTERNAL_INTEGRATION_RESOURCE_LIST =
  '[External Integration Resource] List';
export const GET_EXTERNAL_INTEGRATION_RESOURCE_LIST_SUCCESS =
  '[External Integration Resource] List Success';
export const GET_EXTERNAL_INTEGRATION_RESOURCE_LIST_ERROR =
  '[External Integration Resource] List Error';

export const EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES =
  '[External Integration Resource] Execute All';
export const EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES_SUCCESS =
  '[External Integration Resource] Execute All Success';
export const EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES_ERROR =
  '[External Integration Resource] Execute All Error';

export const EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY =
  '[External Integration Resource] Execute By Category';
export const EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY_SUCCESS =
  '[External Integration Resource] Execute By Category Success';
export const EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY_ERROR =
  '[External Integration Resource] Execute By Category Error';

// without the readonly on the type the reducers doesn't work correctly
export class GetExternalIntegrationResourceList implements Action {
  readonly type = GET_EXTERNAL_INTEGRATION_RESOURCE_LIST;
}

export class GetExternalIntegrationResourceListSuccess implements Action {
  readonly type = GET_EXTERNAL_INTEGRATION_RESOURCE_LIST_SUCCESS;

  constructor(
    public payload: {
      externalIntegrationResources: IExternalIntegrationResourceList[];
    }
  ) {}
}

export class GetExternalIntegrationResourceListError implements Action {
  readonly type = GET_EXTERNAL_INTEGRATION_RESOURCE_LIST_ERROR;

  constructor(public payload: { operationResult: OperationResult | null }) {}
}

export class ExecuteAllExternalIntegrationResources implements Action {
  readonly type = EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES;
}

export class ExecuteAllExternalIntegrationResourcesSuccess implements Action {
  readonly type = EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES_SUCCESS;
}

export class ExecuteAllExternalIntegrationResourcesError implements Action {
  readonly type = EXECUTE_ALL_EXTERNAL_INTEGRATION_RESOURCES_ERROR;

  constructor(public payload: { operationResult: OperationResult | null }) {}
}

export class ExecuteExternalIntegrationResourceByCategory implements Action {
  readonly type = EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY;

  constructor(public payload: {category: ExternalResourceCategory}) {}
}

export class ExecuteExternalIntegrationResourceByCategorySuccess
  implements Action
{
  readonly type = EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY_SUCCESS;

  constructor(
    public payload: {
      externalResources: IExternalIntegrationResourceResultModel[];
    }
  ) {}
}

export class ExecuteExternalIntegrationResourceByCategoryError
  implements Action
{
  readonly type = EXECUTE_EXTERNAL_INTEGRATION_RESOURCE_BY_CATEGORY_ERROR;

  constructor(public payload: { operationResult: OperationResult | null }) {}
}

export type ExternalIntegrationResourcesActions =
  | GetExternalIntegrationResourceList
  | GetExternalIntegrationResourceListSuccess
  | GetExternalIntegrationResourceListError
  | ExecuteAllExternalIntegrationResources
  | ExecuteAllExternalIntegrationResourcesSuccess
  | ExecuteAllExternalIntegrationResourcesError
  | ExecuteExternalIntegrationResourceByCategory
  | ExecuteExternalIntegrationResourceByCategorySuccess
  | ExecuteExternalIntegrationResourceByCategoryError;

export interface Pagination {
  pageSize: number;
  pageNumber: number;
}

export interface IExternalIntegrationResourceResultModel {
  assetId: string;
  name: string;
  price: number;
}

export interface IExternalIntegrationResourceList {
  id: number;
  name: string;
  category: ExternalResourceCategory;
}

export enum ExternalResourceCategory {
  Crypto = 0,
  Stock = 1,
}
