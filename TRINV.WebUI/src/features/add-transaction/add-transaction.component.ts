import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-transaction-dialog',
  templateUrl: 'add-transaction.component.html',
  styleUrl: 'add-transaction.component.scss'
})
export class AddTransactionDialogComponent {
  constructor(
    private readonly dialogRef: MatDialogRef<AddTransactionDialogComponent>
  ) {}

  public closeDialog(): void {
    this.dialogRef.removePanelClass('form-dialog');
    this.dialogRef.close();
  }
}
