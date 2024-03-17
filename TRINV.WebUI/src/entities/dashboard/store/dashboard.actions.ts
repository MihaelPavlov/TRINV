import { Action } from '@ngrx/store';
import { IInvestmentPerformance } from '../models/investment-performance';
import { OperationResult } from '../../../shared/models/operation-result.model';

export const GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST =
  '[Dashboard] Investment Performance List';
export const GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST_SUCCESS =
  '[Dashboard] Investment Performance List Success';
export const GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST_ERROR =
  '[Dashboard] Investment Performance List Error';

export class GetDashboardInvestmentPerformanceList implements Action {
  readonly type = GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST;

  constructor() {}
}

export class GetDashboardInvestmentPerformanceListSuccess implements Action {
  readonly type = GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST_SUCCESS;

  constructor(
    public payload: {
      invesmentPerformanceList: IInvestmentPerformance[];
    }
  ) {}
}

export class GetDashboardInvestmentPerformanceListError implements Action {
  readonly type = GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST_ERROR;

  constructor(public payload: { operationResult: OperationResult | null }) {}
}

export type DashboardActions =
  | GetDashboardInvestmentPerformanceList
  | GetDashboardInvestmentPerformanceListSuccess
  | GetDashboardInvestmentPerformanceListError;
