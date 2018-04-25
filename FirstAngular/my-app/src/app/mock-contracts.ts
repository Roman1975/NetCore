import { Contract } from './contract';
import { ContractSearchResult } from './contractSearchResult';

export const CONTRACTS: Contract[] = [
    { id: 11, title: 'офіс', contractType: 'електрика постачання', contractSupplier: 'ПАТ Київенерго', number: '111', address: 'м. Київ, вул., Смоленска 31/33, оф. 509', enterpriseId: 2},
    { id: 12, title: 'дім', contractType: 'електрика постачання', contractSupplier: 'ПАТ Київенерго', number: '222', address: 'м. Київ, вул., Франко 7, кв. 509', enterpriseId: 2},
    { id: 13, title: 'офіс', contractType: 'електрика постачання', contractSupplier: 'ДТЕК', number: '333', address: 'м. Київ, вул., Смоленска 31/33, оф. 509', enterpriseId: 3},
    { id: 14, title: 'дім', contractType: 'електрика постачання', contractSupplier: 'ДТЕК', number: '444', address: 'м. Київ, вул., Франко 7, кв. 509', enterpriseId: 3},
    { id: 15, title: 'офіс', contractType: 'електрика постачання', contractSupplier: 'ЛОЕ', number: '555', address: 'м. Київ, вул., Смоленска 31/33, оф. 509', enterpriseId: 4},
    { id: 16, title: 'дім', contractType: 'електрика постачання', contractSupplier: 'ЛОЕ', number: '666', address: 'м. Київ, вул., Франко 7, кв. 509', enterpriseId: 4},
    { id: 17, title: 'офіс', contractType: 'електрика постачання', contractSupplier: 'ПрОЕ', number: '777', address: 'м. Київ, вул., Смоленска 31/33, оф. 509', enterpriseId: 5},
    { id: 18, title: 'дім', contractType: 'електрика постачання', contractSupplier: 'ПрОЕ', number: '888', address: 'м. Київ, вул., Франко 7, кв. 509', enterpriseId: 5},
];


export const CONTRACTS_SEARCH: ContractSearchResult[] = [
    { id: 11, number: '111', address: 'м. Київ, вул., Смоленска 31/33, оф. 509', enterpriseId: 2, email: 'info@com.ua', phone: '(044)-538-10-21'},
    { id: 12, number: '222', address: 'м. Київ, вул., Франко 7, кв. 509', enterpriseId: 2, email: 'info@com.ua', phone: '(044)-538-10-21'},
    { id: 13, number: '333', address: 'м. Київ, вул., Смоленска 31/33, оф. 509', enterpriseId: 3, email: 'info@com.ua', phone: '(044)-538-10-21'},
    { id: 14, number: '444', address: 'м. Київ, вул., Франко 7, кв. 509', enterpriseId: 3, email: 'info@com.ua', phone: '(044)-538-10-21'},
    { id: 15, number: '555', address: 'м. Київ, вул., Смоленска 31/33, оф. 509', enterpriseId: 4, email: 'info@com.ua', phone: '(044)-538-10-21'},
    { id: 16, number: '666', address: 'м. Київ, вул., Франко 7, кв. 509', enterpriseId: 4, email: 'info@com.ua', phone: '(044)-538-10-21'},
    { id: 17, number: '777', address: 'м. Київ, вул., Смоленска 31/33, оф. 509', enterpriseId: 5, email: 'info@com.ua', phone: '(044)-538-10-21'},
    { id: 18, number: '888', address: 'м. Київ, вул., Франко 7, кв. 509', enterpriseId: 5, email: 'info@com.ua', phone: '(044)-538-10-21'},
];