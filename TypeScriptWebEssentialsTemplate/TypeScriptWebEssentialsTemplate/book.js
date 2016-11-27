"use strict";
var Book = (function () {
    function Book() {
        this.title = "Title";
        this.author = "Author";
    }
    Book.prototype.bookInfo = function () {
        return this.title + " by " + this.author;
    };
    return Book;
}());
exports.Book = Book;
//# sourceMappingURL=book.js.map