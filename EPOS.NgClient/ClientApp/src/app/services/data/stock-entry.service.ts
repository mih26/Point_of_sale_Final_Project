import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SotckEntryViewModel } from 'src/app/models/viewmodels/sotck-entry-view-model';
import { AppConstants } from 'src/app/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class StockEntryService {

  constructor( private http:HttpClient) { }
  getVM():Observable<SotckEntryViewModel[]>{
    console.log(`${AppConstants.apiUrl}/api/StockEntries/VM`)
    return this.http.get<SotckEntryViewModel[]>(`${AppConstants.apiUrl}/api/StockEntries/VM`)
  }
  get():Observable<SotckEntryViewModel[]>{
    console.log(`${AppConstants.apiUrl}/api/Stocks/VM`)
    return this.http.get<SotckEntryViewModel[]>(`${AppConstants.apiUrl}/api/Stocks/VM`)
  }
}
