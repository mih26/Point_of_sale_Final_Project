import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InventoryInputModel } from 'src/app/models/viewmodels/input/inventory-input-model';
import { InventoryViewModel } from 'src/app/models/viewmodels/inventory-view-model';
import { AppConstants } from 'src/app/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  constructor(
    private http:HttpClient
  ) { }
  getVM():Observable<InventoryViewModel[]>{
    return this.http.get<InventoryViewModel[]>(`${AppConstants.apiUrl}/api/Inventories/VM`);
  }
  get(id:number):Observable<InventoryInputModel>{
    return this.http.get<InventoryInputModel>(`${AppConstants.apiUrl}/api/Inventories/VM/Edit/${id}`)
  }
  post(data:InventoryInputModel):Observable<any>{
    return this.http.post<any>(`${AppConstants.apiUrl}/api/Inventories/VM`, data);
  }
  put(data:InventoryInputModel):Observable<any>{
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Inventories/VM/${data.inventoryId}`, data)
  }
  getProductsForDDL():Observable<{productId?:number, productName?:string}[]>{
    return this.http.get<{productId?:number, productName?:string}[]>(`${AppConstants.apiUrl}/api/Products`);
  }
}
