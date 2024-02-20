import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DashboardGenericTableDialogComponent } from '../../dashboard-generic-table/page/dashboard-generic-table.component';

@Component({
  selector: 'app-dashboard-investments-in-percent',
  templateUrl: 'dashboard-investments-in-percent.component.html',
  styleUrl: 'dashboard-investments-in-percent.component.scss',
})
export class DashboardInvestmentsInPecentComponent {

  constructor(public dialog: MatDialog) {
  }

  openDialog() {
    const dialogRef = this.dialog.open(DashboardGenericTableDialogComponent, {

    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
