import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ShoppingCartDetail } from './shoppingcartdetail';
import { Book } from '../shared/book';
import { Observable, of } from 'rxjs';
import { MessageService } from '../messages/message.service';
import { catchError, map, tap } from 'rxjs/operators';
import { ShoppingCart } from './shoppingcart';

@Injectable({
  providedIn: 'root'
})
export class ShoppingcartService {

  constructor(
    private httpClient: HttpClient,
    private messageService: MessageService) { }
    
  rootUrl = 'http://localhost:54400/api/shoppingcart/'

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
    withCredentials: true
  }

  AddItem(book: Book) {
    let shoppingCartDetail = new ShoppingCartDetail();
    shoppingCartDetail.bookEntity = book;
    shoppingCartDetail.price = book.price;
    
    this.httpClient.post(this.rootUrl + 'additem', shoppingCartDetail, this.httpOptions)
        .subscribe(
            () => {},
            err => {console.error(err)}
        ); 
  }
   
  getAllDetails(): Observable<ShoppingCart> {
    return this.httpClient.post<ShoppingCart>(this.rootUrl + "shoppingcartdetails", {}, this.httpOptions)
    .pipe(
      tap(_ => this.log('fetched all details')),
      catchError(this.handleError<ShoppingCart>('getDetails')))
  }

  private log(message: string) {
    this.messageService.add(`CatalogService: ${message}`);
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  finishOrder(shoppingCart: ShoppingCart): void {
    this.httpClient.post(this.rootUrl + 'finishorder', shoppingCart, this.httpOptions)
        .subscribe(
          data  => {
            alert(data);
          },
          err => {
            console.error(err)
          }
        ); 
  }
}
