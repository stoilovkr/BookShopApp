import { Component, OnInit } from '@angular/core';
import { Book } from '../shared/book'
import { CatalogService } from './catalog.service'

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {

  constructor(private catalogService: CatalogService) { }

  ngOnInit() {
    this.getAllBooks();
  }

  books : Book[];

  getAllBooks(): void {
    this.catalogService.getAllBooks()
        .subscribe(books => this.books = books);
  }

}
