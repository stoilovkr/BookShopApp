import { Injectable } from '@angular/core';
import { Book } from '../shared/book'
import { Observable, of } from 'rxjs';
import { MessageService } from '../messages/message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookDetailService {

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

    private bookDetailUrl = 'http://localhost:54200/api/books/getbookbyid/?id=';

    getBookDetail(id: Number): Observable<Book> {
      return this.http.get<Book>(this.bookDetailUrl + id)
        .pipe(
          tap(_ => this.log(`fetched book detail id=${id}`)),
          catchError(this.handleError<Book>('getBookDetail')))
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
}
