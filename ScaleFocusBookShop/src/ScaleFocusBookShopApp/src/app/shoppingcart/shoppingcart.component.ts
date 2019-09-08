import { Component, OnInit } from '@angular/core';
import { ShoppingcartService } from './shoppingcart.service';
import { ShoppingCart } from './shoppingcart';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css']
})
export class ShoppingcartComponent implements OnInit {

  constructor(private shoppingCartService: ShoppingcartService) { 
    this.shoppingCart = new ShoppingCart()
  }

  ngOnInit() {
    this.getAllDetails();
  }

  shoppingCart: ShoppingCart;

  getAllDetails(): void {
    this.shoppingCartService.getAllDetails()
        .subscribe(shoppingCart => this.shoppingCart = shoppingCart);
  }

  finishOrder(): void {
    this.shoppingCartService.finishOrder(this.shoppingCart);
  }
}
