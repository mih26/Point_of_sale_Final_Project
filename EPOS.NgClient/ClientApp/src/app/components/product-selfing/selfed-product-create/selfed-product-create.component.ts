import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SelfedProductInputModel } from 'src/app/models/viewmodels/input/selfed-product-input-model';
import { SelfedProductService } from 'src/app/services/data/selfed-product.service';
import { NotifyService } from 'src/app/services/notify.service';

@Component({
  selector: 'app-selfed-product-create',
  templateUrl: './selfed-product-create.component.html',
  styleUrls: ['./selfed-product-create.component.css']
})
export class SelfedProductCreateComponent implements OnInit{
  selfed:SelfedProductInputModel = {};
  products:{productId?:number, productName?:string}[]=[];
  inventories: {code?:string, name?:string }[] =[];
  racks:{rackId?:number, rackName?:string}[] =[];
  hint = '';
  maxQuantity =0;
  maxQError = false;
  
  selfedForm: FormGroup = new FormGroup({
    productId: new FormControl(undefined, Validators.required),
    inventoryCode:new FormControl(undefined, Validators.required),
    rackId: new FormControl(undefined, Validators.required),
    selfQuantity: new FormControl(undefined, Validators.required)
  });
  constructor(
    private selfedProductService:SelfedProductService,
    private notifyService:NotifyService

  ){}
  get f() {
    return this.selfedForm.controls;
  }
  onProductChange(ob:any){
    console.log(ob.value)
    this.inventories=[];
    this.selfedProductService.getInventoryOptions(ob.value)
    .subscribe({
      next:r=>{
        this.inventories=r;
        console.log(this.inventories);
      }, error:err=>{
        this.notifyService.fail("Cannot load inentory data", "DISMISS")
      }
    });
  }
  onInventroyChange(ob:any){
    
    console.log(ob.value);
    this.selfedProductService.getQuantity(ob.value)
    .subscribe({
      next:r=>{
        this.f['selfQuantity'].patchValue(r)
        this.maxQuantity=r;
        this.hint = `No more than ${this.maxQuantity}`
      }, error:err=>{
        this.notifyService.fail("Cannot fetch self quantity", "DISMISS");
      }
    })
  }
  save(){
    if(this.selfedForm.invalid) return;
    if(this.f['selfQuantity'].value > this.maxQuantity) {
      this.f['selfQuantity'].setErrors({
        maxQ:true
      })
      return;
    }
    Object.assign(this.selfed, this.selfedForm.value);
    console.log(this.selfed)
    this.selfedProductService.post(this.selfed)
    .subscribe({
      next: r=>{
        this.notifyService.success("Product selfing updated", "DISMISS");
      },
      error: err=>{
        this.notifyService.fail("Cannot save selfing", "DISMISS");
      }
    })
  }
  ngOnInit(): void {
    
    this.selfedProductService.getProductOptions()
    .subscribe({
      next:r=>{
        this.products=r;
        console.log(this.products);
      }, error:err=>{
        this.notifyService.fail("Cannot load product data", "DISMISS")
      }
    });
    this.selfedProductService.getRacks()
    .subscribe({
      next:r=>{
        this.racks=r;
        console.log(this.racks);
      }, error:err=>{
        this.notifyService.fail("Cannot load racks data", "DISMISS")
      }
    });
  }

}
