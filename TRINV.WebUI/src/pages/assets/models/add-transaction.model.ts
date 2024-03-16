import { TransactionType } from "../../../features/assets/components/add-transaction/page/add-transaction.component";

export interface IAddTransaction {
  assetId: string;
  name: string;
  quantity: number;
  purchasePrice: number;
  purchasePricePerUnit: number;
  transactionType: TransactionType;
  isFromOutsideProvider: boolean;
}
