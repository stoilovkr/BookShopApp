import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Book } from '../shared/book';
import { BookDetailService } from './book-detail.service';
import { MessageService } from '../messages/message.service';
import { ShoppingcartService } from '../shoppingcart/shoppingcart.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private bookDetailService: BookDetailService,
    private location: Location,
    private messageService: MessageService,
    private shoppingCartService: ShoppingcartService
    ) { }
  
  ngOnInit() {
    this.getBookDetail();
  }

  book : Book;

  getBookDetail(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.bookDetailService.getBookDetail(id)
      .subscribe(book => this.book = book);
  }

  addToCart(): void {
    this.shoppingCartService.AddItem(this.book);
  }
}
