import { Component } from '@angular/core';

@Component({
    templateUrl: '/url/HistoryComponent'
})

export class HistoryComponent {
    items : Item[] = [
        new Item("https://www.yandex.ru/", "http://ttt.com", 1, "01.01.0001"),
        new Item("https://www.google.ru/", "http://ttt.com", 2, "00.00.2000"),
        new Item("https://translate.google.ru/", "http://ttt.com", 0, "20.04.2017")
    ];
}

class Item {
    constructor(
        originalUrl: string,
        shortUrl: string,
        clickCount: number,
        dateCreated: string) {
        this.originalUrl = originalUrl;
        this.shortUrl = shortUrl;
        this.clickCount = clickCount;
        this.dateCreated = dateCreated;
    }

    originalUrl: string;
    shortUrl: string;
    clickCount: number;
    dateCreated: string;
}
