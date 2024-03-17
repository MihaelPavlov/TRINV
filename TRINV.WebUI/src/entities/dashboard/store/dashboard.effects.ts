import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { DashboardService } from '../api/dashboard.service';
import * as actions from './dashboard.actions';
import { map, switchMap } from 'rxjs';
import { ExtendedOperationResult } from '../../../shared/models/operation-result.model';
import { IInvestmentPerformance } from '../models/investment-performance';

@Injectable()
export class DashboardEffect {
  getInvestmentPerformanceList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.GET_DASHBOARD_INVESTMENT_PERFORMANCE_LIST),
      switchMap((_) =>
        this.dashboardService.getDashboardInvestmentPerformance().pipe(
          map(
            (
              operationResult: ExtendedOperationResult<
                IInvestmentPerformance[]
              > | null
            ) => {
              if (operationResult == null) {
                return new actions.GetDashboardInvestmentPerformanceListError({
                  operationResult,
                });
              } else if (!operationResult.success) {
                return new actions.GetDashboardInvestmentPerformanceListError({
                  operationResult,
                });
              }

              return new actions.GetDashboardInvestmentPerformanceListSuccess({
                invesmentPerformanceList: operationResult.relatedObject,
              });
            }
          )
        )
      )
    )
  );

  constructor(
    private readonly actions$: Actions,
    private readonly dashboardService: DashboardService
  ) {}
}
