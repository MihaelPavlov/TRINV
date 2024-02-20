import { Component, ViewEncapsulation } from "@angular/core";

@Component({
    selector:"app-dashboard",
    templateUrl:"dashboard.component.html",
    styleUrl:"dashboard.component.scss",
    encapsulation: ViewEncapsulation.None // This is turned off because we are using 
    //it to change the color and background color of mat-tab-group

})
export class DashboardComponent{

}