import { Author } from './author'

export class Book {
    id: number;
    title: string;
    synopsis: string;
    price: number;
    genreName: string;
    authorEntity: Author;
}