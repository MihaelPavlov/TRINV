import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddAccountDialogComponent } from '../../features/add-account/components/add-account-dialog/add-account-dialog.component';

@Component({
  selector: 'app-menu',
  templateUrl: 'menu.component.html',
  styleUrl: 'menu.component.scss',
})
export class MenuComponent {
  constructor(public dialog: MatDialog) {}

  openAccountDialog() {
    const dialogRef = this.dialog.open(AddAccountDialogComponent, {});

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
