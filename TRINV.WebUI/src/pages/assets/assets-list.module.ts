import { NgModule } from '@angular/core';
import { AssetsListComponent } from './assets-list.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { SharedModule } from '../../shared/shared.module';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';

@NgModule({
  declarations: [AssetsListComponent],
  imports: [MatExpansionModule,MatTableModule,MatIconModule,MatMenuModule,MatListModule,MatSelectModule,SharedModule],
  exports: [],
  providers: [],
})
export class AssetsListModule {}
