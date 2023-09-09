import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { InventoryCreateComponent } from './components/inventory/inventory-create/inventory-create.component';
import { InventoryEditComponent } from './components/inventory/inventory-edit/inventory-edit.component';
import { InventoryViewComponent } from './components/inventory/inventory-view/inventory-view.component';
import { SelfedProductCreateComponent } from './components/product-selfing/selfed-product-create/selfed-product-create.component';
import { SelfedProductEditComponent } from './components/product-selfing/selfed-product-edit/selfed-product-edit.component';
import { SelfedProductViewComponent } from './components/product-selfing/selfed-product-view/selfed-product-view.component';
import { StockEntryEditComponent } from './components/stock-entry/stock-entry-edit/stock-entry-edit.component';
import { StockEntryViewComponent } from './components/stock-entry/stock-entry-view/stock-entry-view.component';
import { SupplierCreateComponent } from './components/supplier/supplier-create/supplier-create.component';
import { SupplierViewComponent } from './components/supplier/supplier-view/supplier-view.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  {path:'suppliers', component:SupplierViewComponent},
  {path:'supplier-create', component:SupplierCreateComponent},
  {path: 'inventories', component:InventoryViewComponent},
  {path: 'inventory-edit/:id', component:InventoryEditComponent},
  {path: 'inventory-create', component:InventoryCreateComponent},
  {path: 'stock-entries', component:StockEntryViewComponent},
  {path: 'stock-entries/:id', component:StockEntryEditComponent},
  {path: 'stock-entries-create', component:StockEntryEditComponent},
  {path: 'selfed-products', component:SelfedProductViewComponent},
  {path: 'selfed-product/:id', component:SelfedProductEditComponent},
  {path: 'selfed-product-create', component:SelfedProductCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
