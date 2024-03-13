import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import {
  ActionReducer,
  ActionReducerMap,
  MetaReducer,
  StoreModule,
} from '@ngrx/store';
import { ExternalIntegrationResourceEffects } from '../../shared/store/external-integration-resource/external-integration-resource.effects';
import {
  ExternalIntegrationResourceInitialState,
  externalIntegrationResourceReducer,
} from '../../shared/store/external-integration-resource/external-integration-resource.reducer';

export interface AppState {
  externalIntegrationResource: ExternalIntegrationResourceInitialState;
}

export const reducers: ActionReducerMap<AppState, any> = {
  externalIntegrationResource: externalIntegrationResourceReducer,
};

export function logger(reducer: ActionReducer<any>): ActionReducer<any> {
  return (state, action) => {
    // console.log('state before -> ', state);
    // console.log('action -> ', action);
    return reducer(state, action);
  };
}

export const environment = {
  production: false,
};

export const metaReducers: MetaReducer<AppState, any>[] =
  !environment.production ? [logger] : [];

@NgModule({
  imports: [
    StoreModule.forRoot(reducers, { metaReducers }),
    EffectsModule.forRoot(ExternalIntegrationResourceEffects),
  ],
})
export class AppStoreModule {}
