import { NgModule } from '@angular/core';
import { DashboardInfoModule } from '../../features/dashboard/components/dashboard-info/dashboard-info.module';
import { DashboardComponent } from './dashboard.component';
import { MatTabsModule } from '@angular/material/tabs';
import { DashboardInvestmentPerformanceModule } from '../../features/dashboard/components/dashboard-investment-performance-list/dashboard-investment-performance-list.module';
import { DashboardInvestmentsInPecentModule } from '../../features/dashboard/components/dashboard-investments-in-percent/dashboard-investments-in-percent.module';
import { DashboardLastInvestmentsModule } from '../../features/dashboard/components/dashboard-last-investments/dashboard-last-investments.module';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [DashboardComponent],
  imports: [
    DashboardInfoModule,
    DashboardInvestmentPerformanceModule,
    DashboardInvestmentsInPecentModule,
    DashboardLastInvestmentsModule,
    MatTabsModule,
    SharedModule,
  ],
  exports: [],
  providers: [],
})
export class DashboardModule {}
