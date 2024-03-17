import { TransactionType } from '../../../features/assets/components/add-transaction/page/add-transaction.component';

export interface ITransaction {
  id: number;
  assetId: string;
  name: string;
  quantity: number;
  totalPrice: number;
  pricePerUnit: number;
  createdOn: Date;
  transactionType: TransactionType;
  transactionProfit: number;
  transactionProfitPercents: number;
}
