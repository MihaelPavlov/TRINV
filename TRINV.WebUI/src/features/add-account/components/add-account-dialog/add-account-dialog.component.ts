import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-account-dialog',
  templateUrl: 'add-account-dialog.component.html',
  styleUrl: 'add-account-dialog.component.scss'
})
export class AddAccountDialogComponent {
  constructor(
    private readonly dialogRef: MatDialogRef<AddAccountDialogComponent>
  ) {}

  public closeDialog(): void {
    this.dialogRef.removePanelClass('form-dialog');
    this.dialogRef.close();
  }
}
