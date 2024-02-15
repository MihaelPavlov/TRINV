import { Component } from "@angular/core";

@Component({
    selector:"app-dashboard-info",
    templateUrl:"dashboard-info.component.html",
    styles: [
        `
          .index {
            position: relative;
            z-index: 0;
          }
          .text-green {
            color: green;
          }
    
          .text-red {
            color: red;
          }
        `,
      ],
})
export class DashboardInfoComponent {

}