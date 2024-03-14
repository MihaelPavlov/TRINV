import { createFeatureSelector, createSelector } from '@ngrx/store';
import {
  ExternalIntegrationResourceInitialState,
  adapter,
} from './external-integration-resource.reducer';

export const selectExternalIntegrationResourceState =
  createFeatureSelector<ExternalIntegrationResourceInitialState>(
    'externalIntegrationResource'
  );

export const selectExternalIntegrationResourceResultList = createSelector(
  selectExternalIntegrationResourceState,
  (state) => adapter.getSelectors().selectAll(state)
);

export const selectExternalIntegrationResourceList = createSelector(
  selectExternalIntegrationResourceState,
  (state) => state.externalIntegrationResourceList
);

export const selectIsLoading = createSelector(
  selectExternalIntegrationResourceState,
  (state) => state.isLoading
);
export const selectError = createSelector(
  selectExternalIntegrationResourceState,
  (state) => state.error
);
