import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { SelfedProductViewModel } from 'src/app/models/viewmodels/selfed-product-view-model';
import { SelfedProductService } from 'src/app/services/data/selfed-product.service';
import { NotifyService } from 'src/app/services/notify.service';
import { AppConstants } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-selfed-product-view',
  templateUrl: './selfed-product-view.component.html',
  styleUrls: ['./selfed-product-view.component.css']
})
export class SelfedProductViewComponent implements OnInit{
  barCodePath = AppConstants.apiUrl+"/barcodes"
  selfedProducts:SelfedProductViewModel[] =[];
  dataSource:MatTableDataSource<SelfedProductViewModel> = new MatTableDataSource(this.selfedProducts);
  columns=["inventoryCode", "productName", "rackName","selfQuantity","sold", "barcodeImage" ];
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private slefedProductService:SelfedProductService,
    private notifyService:NotifyService
  ){}
  ngOnInit(): void {
    this.slefedProductService.getVM()
    .subscribe({
      next:r=>{
        this.selfedProducts=r;
        console.log(r)
        this.dataSource.data= this.selfedProducts;
        this.dataSource.sort= this.sort;
        this.dataSource.paginator=this.paginator;
      },
      error:err=>{
        console.log(err)
        this.notifyService.fail("Failed to load product selfing data", "DISMISS");
      }
    });
  }

}
