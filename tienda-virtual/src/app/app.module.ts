import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/forms/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { ProductoComponent } from './components/producto/producto.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { NewProductComponent } from './components/forms/new-product/new-product.component';
import { AddCartComponent } from './components/forms/add-cart/add-cart.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { EditProductComponent } from './components/forms/edit-product/edit-product.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AdminComponent } from './components/admin/admin.component';
import { ListproductAdminComponent } from './components/listproduct-admin/listproduct-admin.component';
import { CardProductComponent } from './components/card-product/card-product.component';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ProductoComponent,
    ShoppingCartComponent,
    NewProductComponent,
    AddCartComponent,
    ProductListComponent,
    EditProductComponent,
    AdminComponent,
    ListproductAdminComponent,
    CardProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    FontAwesomeModule,
    ReactiveFormsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
