import { Injectable } from '@angular/core';
import { Book } from '../shared/book'
import { Observable, of } from 'rxjs';
import { MessageService } from '../messages/message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CatalogService {

  constructor(
      private http: HttpClient,
      private messageService: MessageService) { }

  private catalogRootUrl = 'http://localhost:54200/api/books/';

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.catalogRootUrl + "getallbooks")
      .pipe(
        tap(_ => this.log('fetched all books')),
        catchError(this.handleError<Book[]>('getBooks', [])))
  }

  getBooksByAuthor(id: Number): Observable<Book[]> {
    return this.http.get<Book[]>(this.catalogRootUrl + "getbooksbyauthor")
      .pipe(
        tap(_ => this.log(`CatalogService: fetched books by author id=${id}`)),
        catchError(this.handleError<Book[]>('getBooks', [])))
  }

  getBooksByGenre(genreName: string): Observable<Book[]> {
    return this.http.get<Book[]>(this.catalogRootUrl + "getbooksbygenre")
      .pipe(
        tap(_ => this.log(`CatalogService: fetched books by author id=${genreName}`)),
        catchError(this.handleError<Book[]>('getBooks', [])))
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
