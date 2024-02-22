import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dashboard-generic-table',
  templateUrl: 'dashboard-generic-table.component.html',
  styleUrl: 'dashboard-generic-table.component.scss'
})
export class DashboardGenericTableDialogComponent {
  constructor(
    private readonly dialogRef: MatDialogRef<DashboardGenericTableDialogComponent>
  ) {}

  public closeDialog(): void {
    this.dialogRef.removePanelClass('form-dialog');
    this.dialogRef.close();
  }
}
