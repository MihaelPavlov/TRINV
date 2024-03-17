import { TransactionType } from "../../../features/assets/components/add-transaction/page/add-transaction.component";

export interface IAddTransaction {
  assetId: string;
  name: string;
  quantity: number;
  totalPrice: number;
  pricePerUnit: number;
  transactionType: TransactionType;
  isFromOutsideProvider: boolean;
}
