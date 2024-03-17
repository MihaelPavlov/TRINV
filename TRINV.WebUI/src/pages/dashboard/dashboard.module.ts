import { NgModule } from '@angular/core';
import { DashboardInfoModule } from '../../features/dashboard/components/dashboard-info/dashboard-info.module';
import { DashboardComponent } from './page/dashboard.component';
import { MatTabsModule } from '@angular/material/tabs';
import { DashboardInvestmentPerformanceModule } from '../../features/dashboard/components/dashboard-investment-performance-list/dashboard-investment-performance-list.module';
import { DashboardInvestmentsInPecentModule } from '../../features/dashboard/components/dashboard-investments-in-percent/dashboard-investments-in-percent.module';
import { DashboardLastInvestmentsModule } from '../../features/dashboard/components/dashboard-last-investments/dashboard-last-investments.module';
import { SharedModule } from '../../shared/shared.module';
import { DashboardSumPriceChartModule } from '../../features/dashboard/components/dashboard-sum-price-chart/dashboard-sum-price-chart.module';
import { dashboardListReducer } from '../../entities/dashboard/store/dashboad.reducer';
import { DashboardEffect } from '../../entities/dashboard/store/dashboard.effects';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

@NgModule({
  declarations: [DashboardComponent],
  imports: [
    DashboardInfoModule,
    DashboardInvestmentPerformanceModule,
    DashboardInvestmentsInPecentModule,
    DashboardLastInvestmentsModule,
    DashboardSumPriceChartModule,
    MatTabsModule,
    SharedModule,
    StoreModule.forFeature('dashboard', dashboardListReducer),
    EffectsModule.forFeature([DashboardEffect]),
  ],
  exports: [],
  providers: [],
})
export class DashboardModule {}
