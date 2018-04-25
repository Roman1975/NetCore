import { ContractCharge } from "./contractCharge";

export class ContractDetail {
    id: number;
    title: string;
    contractType: string;
    contractSupplier: string;
    number: string;
    address: string;
    charges: ContractCharge[];
    dateFrom: Date;
    DateTo: Date;
    DueDate: Date;
    DueDebt: number;
}