import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../pages/dashboard/dashboard.component';
import { AssetsListComponent } from '../pages/assets/assets-list.component';
import { MenuComponent } from '../widgets/menu/menu.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
    loadChildren: () =>
      import('../pages/dashboard/dashboard.module').then(
        (m) => m.DashboardModule
      ),
  },
  {
    path: 'assets',
    component: AssetsListComponent,
    loadChildren: () =>
      import('../pages/assets/assets-list.module').then(
        (m) => m.AssetsListModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
