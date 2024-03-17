import { Component } from '@angular/core';
import { GetDashboardInvestmentPerformanceList } from '../../../../../entities/dashboard/store/dashboard.actions';
import {
  selectInvestmentsPerformanceList,
  selectIsLoadingInvestmentsPerformanceList,
} from '../../../../../entities/dashboard/store/dashboard.selectors';
import { Observable } from 'rxjs';
import { IInvestmentPerformance } from '../../../../../entities/dashboard/models/investment-performance';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-dashboard-investment-performance-list',
  templateUrl: 'dashboard-investment-performance-list.component.html',
  styleUrl: 'dashboard-investment-performance-list.component.scss',
})
export class DashboardInvestmentPerformanceListComponent {
  public isLoadingInvestmentPerformanceList$!: Observable<boolean>;
  public investmentPerformanceList: IInvestmentPerformance[] = [];

  constructor(private readonly store: Store, private readonly dialog: MatDialog) {}

  public ngOnInit(): void {
    this.isLoadingInvestmentPerformanceList$ = this.store.select(
      selectIsLoadingInvestmentsPerformanceList
    );

    this.store
      .select(selectInvestmentsPerformanceList)
      .subscribe((x) => (this.investmentPerformanceList = x));

    this.store.dispatch(new GetDashboardInvestmentPerformanceList());
  }

  openDialog() {
    // this.dialog.open(HistoryLogComponent, {
    //   data: {
    //     data: this.investmentPerformanceList,
    //     allAvailableHeadings: [
    //       'Asset Id',
    //       'Name',
    //       'Total Investment Amount',
    //       'Total Current Amount',
    //       'Rate',
    //     ],
    //     displayedColumns: [
    //       'assetId',
    //       'name',
    //       'totalInitialInvestment',
    //       'totalCurrentInvestment',
    //       'rate',
    //     ],
    //   },
    // });
  }
}
