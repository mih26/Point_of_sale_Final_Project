import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { SotckEntryViewModel } from 'src/app/models/viewmodels/sotck-entry-view-model';
import { StockEntryService } from 'src/app/services/data/stock-entry.service';
import { NotifyService } from 'src/app/services/notify.service';

@Component({
  selector: 'app-stock-entry-view',
  templateUrl: './stock-entry-view.component.html',
  styleUrls: ['./stock-entry-view.component.css']
})
export class StockEntryViewComponent implements OnInit {
  stockEntries:SotckEntryViewModel[]=[];
  dataSource:MatTableDataSource<SotckEntryViewModel>=new MatTableDataSource(this.stockEntries)
  columns=["productName", "stock","sold","onSelf" ];
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private stockEnryService:StockEntryService,
    private notifyService:NotifyService
  ){}
  ngOnInit(): void {
    this.stockEnryService.get()
    .subscribe({
      next:r=>{
        console.log(r);
        this.stockEntries=r;
        this.dataSource.data=this.stockEntries;
        this.dataSource.sort=this.sort;
        this.dataSource.paginator=this.paginator;
      },
      error:err=>{
        this.notifyService.fail("Failed to load stocks", "DISMISS")
      }
    })
  }
}
