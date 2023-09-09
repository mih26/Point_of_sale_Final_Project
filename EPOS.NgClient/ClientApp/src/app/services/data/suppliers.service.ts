import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Supplier } from 'src/app/models/data/supplier';
import { AppConstants } from 'src/app/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class SuppliersService {

  constructor(private http:HttpClient) { }
  get():Observable<Supplier[]>{
    return this.http.get<Supplier[]>(`${AppConstants.apiUrl}/api/Suppliers`);
  }
  insert(data:Supplier):Observable<Supplier>{
    return this.http.post<Supplier>(`${AppConstants.apiUrl}/api/Suppliers`, data);
  }
  delete(id:number):Observable<Supplier>{
    return this.http.delete<Supplier>(`${AppConstants.apiUrl}/api/Suppliers/${id}`);
  }
  
}
