import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { InventoryViewModel } from 'src/app/models/viewmodels/inventory-view-model';
import { InventoryService } from 'src/app/services/data/inventory.service';
import { NotifyService } from 'src/app/services/notify.service';

@Component({
  selector: 'app-inventory-view',
  templateUrl: './inventory-view.component.html',
  styleUrls: ['./inventory-view.component.css']
})
export class InventoryViewComponent implements OnInit {
  
  inventories:InventoryViewModel[]=[];
  dataSource:MatTableDataSource<InventoryViewModel> = new MatTableDataSource(this.inventories);
  columns=["inventoryCode", "inDate", "quantity", "supplierName", "productName","unitPrice","selfPrice", 'onSelf', 'stock' , "actions"];
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private inventoryService:InventoryService,
    private notifyService:NotifyService
  ){}
  ngOnInit(): void {
    this.inventoryService.getVM()
    .subscribe({
      next:r=>{
        this.inventories= r;
        console.log(r);
        this.dataSource.data=this.inventories;
        this.dataSource.sort= this.sort;
        this.dataSource.paginator=this.paginator;
      },
      error:err=>{
        this.notifyService.fail("Fail to load inventoris", "DISMISS");
      }
    })
  }
}
