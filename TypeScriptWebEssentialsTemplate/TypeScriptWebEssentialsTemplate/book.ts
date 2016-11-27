
    export interface IBook {
        title: string;
        author: string;
        bookInfo: () => string;
    }

    export class Book implements IBook {
        title: string = "Title";
        author: string = "Author";
        bookInfo(): string {
            return this.title + " by " + this.author;
        }
    }






