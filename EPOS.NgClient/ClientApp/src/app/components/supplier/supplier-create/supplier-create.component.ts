import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Supplier } from 'src/app/models/data/supplier';
import { SuppliersService } from 'src/app/services/data/suppliers.service';
import { NotifyService } from 'src/app/services/notify.service';

@Component({
  selector: 'app-supplier-create',
  templateUrl: './supplier-create.component.html',
  styleUrls: ['./supplier-create.component.css']
})
export class SupplierCreateComponent implements OnInit {
  supplier:Supplier={};
  supplierForm:FormGroup = new FormGroup({
    companyName: new FormControl('', Validators.required),
    contactName: new FormControl('', Validators.required),
    contactNo:new FormControl('', Validators.required)
  });
  constructor(
    private suppliersService:SuppliersService,
    private notifyService:NotifyService
  ){}
  get f(){
    return this.supplierForm.controls;
  }
  save(){
    if(this.supplierForm.invalid) return;
    Object.assign(this.supplier, this.supplierForm.value);
    //console.log(this.supplier)
    this.suppliersService.insert(this.supplier)
    .subscribe({
      next:r=>{
        console.log(r)
        this.notifyService.fail("Successfully saved supplier", "DISMISS")
        this.supplier={};
        this.supplierForm.reset({});
        this.supplierForm.markAsPristine();
        this.supplierForm.markAsUntouched();
      },
      error: err=>{
        console.log(err.message || err);
        this.notifyService.fail("Falied to save supplier", "DISMISS")
      }
    })
  }
  ngOnInit(): void {
    
  }

}
