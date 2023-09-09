import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Supplier } from 'src/app/models/data/supplier';
import { InventoryInputModel } from 'src/app/models/viewmodels/input/inventory-input-model';
import { InventoryService } from 'src/app/services/data/inventory.service';
import { SuppliersService } from 'src/app/services/data/suppliers.service';
import { NotifyService } from 'src/app/services/notify.service';

@Component({
  selector: 'app-inventory-edit',
  templateUrl: './inventory-edit.component.html',
  styleUrls: ['./inventory-edit.component.css']
})
export class InventoryEditComponent implements OnInit{
  inventory:InventoryInputModel ={};
  inventoryForm:FormGroup= new FormGroup({
    inDate: new FormControl(undefined, Validators.required),
    supplierId: new FormControl('', Validators.required),
    productId: new FormControl('', Validators.required),
    quantity: new FormControl(undefined, Validators.required),
    unitPrice: new FormControl(undefined, Validators.required),
    selfPrice: new FormControl(undefined, Validators.required)
  });
  //for dropdowns
  suppliers:Supplier[]=[];
  products: {productId?:number, productName?:string}[]=[];
  constructor(
    private inventoryService:InventoryService,
    private supplierSerice: SuppliersService,
    private notifyService:NotifyService,
    private activatedRoute:ActivatedRoute,
    private datePipe:DatePipe
  ){}
  get f() {
    return this.inventoryForm.controls;
  }
  save(){
      if(this.inventoryForm.invalid) return;
      Object.assign(this.inventory, this.inventoryForm.value);
      this.inventory.inDate = <string>this.datePipe.transform(this.f["inDate"].value, "yyyy-MM-dd");
      this.inventoryService.put(this.inventory)
      .subscribe({
        next:r=> {
          this.notifyService.success("Successfully updated data", "DISMISS");
        },
        error: err=>{
          this.notifyService.fail("Failed update data", "DISMISS")
        }
      })
  }
  ngOnInit(): void {
    this.inventoryService.getProductsForDDL()
    .subscribe({
      next:r=>{
        this.products=r;
        console.log(this.products);
      },
      error: err=>{
        this.notifyService.fail("Failed to load products", "DISMISS");
      }
    });
    this.supplierSerice.get()
    .subscribe({
      next:r=>{
        this.suppliers=r;
        console.log(this.suppliers);
      },
      error: err=>{
        this.notifyService.fail("Failed to load suppliers", "DISMISS");
      }
    });
    let id:number = this.activatedRoute.snapshot.params['id'];
    this.inventoryService.get(id)
    .subscribe({
      next:r=>{
        this.inventory=r;
        this.inventoryForm.patchValue(this.inventory);
      },
      error:err=>{
        this.notifyService.fail("Failed to load inventory", "DISMISS")
      }
    })
  }
}
