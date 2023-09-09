import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Supplier } from 'src/app/models/data/supplier';
import { SuppliersService } from 'src/app/services/data/suppliers.service';
import { NotifyService } from 'src/app/services/notify.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-supplier-view',
  templateUrl: './supplier-view.component.html',
  styleUrls: ['./supplier-view.component.css']
})
export class SupplierViewComponent implements OnInit{
 
  suppliers:Supplier[]=[];
  columnList = ["companyName","contactName", "contactNo", "actions"]
  dataSource:MatTableDataSource<Supplier> = new MatTableDataSource(this.suppliers);
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private suppliersService:SuppliersService,
    private notifyService:NotifyService,
    private matDialog: MatDialog
  ){}
  confirmDelete(item: Supplier): void {
    this.matDialog.open(ConfirmDialogComponent, {
      width: '450px'
    }).afterClosed()
      .subscribe(s => {
        if (s) {
          this.suppliersService.delete(Number(item.supplierId))
          .subscribe({
            next: r=>{
              this.dataSource.data = this.dataSource.data.filter(b => b.supplierId != item.supplierId);
              this.notifyService.success("Supplier has been Deleted", "DISMISS")
            },
            error: err=>{
              this.notifyService.fail("Failed to Delete Brand", "DISMISS");
            }
          })
        }
      });
  }
  ngOnInit(): void {
    this.suppliersService.get()
    .subscribe({
      next: r=>{
        this.suppliers=r;
        this.dataSource.data = this.suppliers;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator= this.paginator;
      },
      error: err=>{
        console.log(err.message || err);
      }
    })
  }
}
