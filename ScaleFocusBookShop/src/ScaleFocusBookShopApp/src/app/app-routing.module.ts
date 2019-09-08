import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CatalogComponent } from './catalog/catalog.component'
import { BookDetailComponent } from './book-detail/book-detail.component'
import { ShoppingcartComponent } from './shoppingcart/shoppingcart.component';


const routes: Routes = [
  { path: '', redirectTo: '/catalog', pathMatch: 'full' },
  { path: 'catalog', component: CatalogComponent },
  { path: 'book-detail/:id', component: BookDetailComponent },
  { path: 'shoppingcart', component: ShoppingcartComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
