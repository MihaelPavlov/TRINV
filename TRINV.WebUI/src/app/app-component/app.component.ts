import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ExecuteAllExternalIntegrationResources } from '../../shared/store/external-integration-resource/external-integration-resource.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'TRINV.WebUI';

  constructor(private readonly store: Store) {}

  ngOnInit(): void {
    console.log(this.store)
    this.store.dispatch(new ExecuteAllExternalIntegrationResources());
  }
}
