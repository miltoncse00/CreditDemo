export interface SalesModel {
  id: string;
  customer_id: string;
  timestamp: Date;
  location_name: string;
  operator_name: string;
  opening_debt: number;
  currency: string;
  sale_invoice_number: string;
  payments: PaymentModel[];
}

export interface PaymentModel {
  payment_date: Date,
  description: string,
  payment_amount: number;
}
