import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/forms/register/register.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { NewProductComponent } from './components/forms/new-product/new-product.component';
import { AddCartComponent } from './components/forms/add-cart/add-cart.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { EditProductComponent } from './components/forms/edit-product/edit-product.component';
import { ProductoComponent } from './components/producto/producto.component';
import { AdminComponent } from './components/admin/admin.component';
import { ListproductAdminComponent } from './components/listproduct-admin/listproduct-admin.component';


const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component:RegisterComponent},
  {path: 'home/:idUsuario', component:HomeComponent},
  {path: 'ProductList', component:ProductListComponent},
  {path: 'admin/:idUsuario', component:AdminComponent,
  children: [
    {
      path: 'listProducAdmin',
      component: ListproductAdminComponent,
}]
},
  {path: 'products', component:ProductoComponent },
  {path: 'shoppingcart',component:ShoppingCartComponent},
  {path:'newProduct', component:NewProductComponent},
  {path: 'editProduct', component:EditProductComponent},
  {path:'addCart', component:AddCartComponent},
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
