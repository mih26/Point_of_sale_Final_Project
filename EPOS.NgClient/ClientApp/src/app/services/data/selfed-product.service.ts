import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SelfedProductInputModel } from 'src/app/models/viewmodels/input/selfed-product-input-model';
import { SelfedProductViewModel } from 'src/app/models/viewmodels/selfed-product-view-model';
import { AppConstants } from 'src/app/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class SelfedProductService {

  constructor(
    private http:HttpClient
  ) { }
  getVM():Observable<SelfedProductViewModel[]>{
    return this.http.get<SelfedProductViewModel[]>(`${AppConstants.apiUrl}/api/SelfedProducts/VM`);
  }
  getInventoryOptions(id:Number):Observable<{code?:string, name?:string }[]>{
    return this.http.get<{code?:string, name?:string }[]>(`${AppConstants.apiUrl}/api/Inventories/Options/${id}`);
  }
  getProductOptions():Observable<{productId?:number, productName?:string }[]>{
    return this.http.get<{productId?:number, productName?:string }[]>(`${AppConstants.apiUrl}/api/Inventories/Products`);
  }
  getQuantity(code:string):Observable<number>{
    return this.http.get<number>(`${AppConstants.apiUrl}/api/Inventories/Value/${code}`);
  }
  getRacks():Observable<{rackId?:number, rackName?:string}[]>{
    return this.http.get<{rackId?:number, rackName?:string}[]>(`${AppConstants.apiUrl}/api/Racks`);
  }
  post(data:SelfedProductInputModel):Observable<SelfedProductViewModel>{
    return this.http.post<SelfedProductInputModel>(`${AppConstants.apiUrl}/api/SelfedProducts/VM`, data);
  }
    
  
}
