import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AssetsInitialState } from "./assets.reducer";

export const selectAssetState = createFeatureSelector<AssetsInitialState>('assets');
export const selectAssetsList = createSelector(selectAssetState, (state) => state.assets);
export const selectIsLoading = createSelector(selectAssetState, (state) => state.isLoading);
export const selectAssetTransactions = createSelector(selectAssetState, (state) => state.transactions);
export const selectTransaction = createSelector(selectAssetState, (state) => state.transaction);
