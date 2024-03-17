import { createFeatureSelector, createSelector } from '@ngrx/store';
import { DashboardInitialState } from './dashboad.reducer';

export const selectDashboardState =
  createFeatureSelector<DashboardInitialState>('dashboard');

export const selectIsLoadingInvestmentsPerformanceList = createSelector(
  selectDashboardState,
  (state) => state.isinvestmentPerformanceListLoading
);
export const selectInvestmentsPerformanceList = createSelector(
  selectDashboardState,
  (state) => state.investmentPerformanceList
);
