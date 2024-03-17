import { OperationResult } from '../../../shared/models/operation-result.model';
import { IInvestmentPerformance } from '../models/investment-performance';
import * as actions from './dashboard.actions';

export interface DashboardInitialState {
  investmentPerformanceList: IInvestmentPerformance[];
  isinvestmentPerformanceListLoading: boolean;
  error: OperationResult | null;
}

const initialState: DashboardInitialState = {
  investmentPerformanceList: [],
  isinvestmentPerformanceListLoading: false,
  error: null,
};

export function dashboardListReducer(
  state: DashboardInitialState = initialState,
  action: actions.DashboardActions
): DashboardInitialState {
  switch (action.type) {
    case actions.GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST:
      return {
        ...state,
        isinvestmentPerformanceListLoading: true,
      };
    case actions.GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST_SUCCESS:
      return {
        ...state,
        isinvestmentPerformanceListLoading: false,
        investmentPerformanceList: action.payload.invesmentPerformanceList,
      };
    case actions.GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST_ERROR:
      return {
        ...state,
        isinvestmentPerformanceListLoading: false,
        error: action.payload.operationResult,
      };
    default:
      return state;
  }
}
