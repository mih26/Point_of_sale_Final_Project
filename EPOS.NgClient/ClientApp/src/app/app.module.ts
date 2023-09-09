import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';

import { NavigationBarComponent } from './components/navigation-bar/navigation-bar.component';
import { HomeComponent } from './components/home/home.component';
import { MultilevelMenuService, NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { MatImportModule } from './modules/mat-import/mat-import.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SuppliersService } from './services/data/suppliers.service';
import { SupplierViewComponent } from './components/supplier/supplier-view/supplier-view.component';
import { SupplierCreateComponent } from './components/supplier/supplier-create/supplier-create.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NotifyService } from './services/notify.service';
import { ConfirmDialogComponent } from './components/shared/confirm-dialog/confirm-dialog.component';
import { InventoryViewComponent } from './components/inventory/inventory-view/inventory-view.component';
import { InventoryCreateComponent } from './components/inventory/inventory-create/inventory-create.component';
import { InventoryEditComponent } from './components/inventory/inventory-edit/inventory-edit.component';
import { InventoryService } from './services/data/inventory.service';
import { DatePipe } from '@angular/common';
import { StockEntryViewComponent } from './components/stock-entry/stock-entry-view/stock-entry-view.component';
import { StockEntryCreateComponent } from './components/stock-entry/stock-entry-create/stock-entry-create.component';
import { StockEntryEditComponent } from './components/stock-entry/stock-entry-edit/stock-entry-edit.component';
import { StockEntryService } from './services/data/stock-entry.service';
import { SelfedProductService } from './services/data/selfed-product.service';
import { SelfedProductViewComponent } from './components/product-selfing/selfed-product-view/selfed-product-view.component';
import { SelfedProductCreateComponent } from './components/product-selfing/selfed-product-create/selfed-product-create.component';
import { SelfedProductEditComponent } from './components/product-selfing/selfed-product-edit/selfed-product-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    HomeComponent,
    SupplierViewComponent,
    SupplierCreateComponent,
    ConfirmDialogComponent,
    InventoryViewComponent,
    InventoryCreateComponent,
    InventoryEditComponent,
    StockEntryViewComponent,
    StockEntryCreateComponent,
    StockEntryEditComponent,
    SelfedProductViewComponent,
    SelfedProductCreateComponent,
    SelfedProductEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatImportModule,
    NgMaterialMultilevelMenuModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule, 
    DatePipe
  ],
  entryComponents: [ConfirmDialogComponent],
  providers: [HttpClient,DatePipe, NotifyService, MultilevelMenuService, SuppliersService,StockEntryService,
    SelfedProductService,
  InventoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
