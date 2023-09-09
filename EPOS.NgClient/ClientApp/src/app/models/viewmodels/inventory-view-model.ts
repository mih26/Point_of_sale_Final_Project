export interface InventoryViewModel {
    inventoryId?:number;
    inventoryCode?:string;
    inDate?:Date|string;
    supplierId?:number;
    productId?:number;
    quantity?:number;
    supplierName?:string;
    productName?:string;
    unitPrice?:number;
    selfPrice?:number;
    onSelf?:number;
    sold?:number;
    stock?:number;
}
