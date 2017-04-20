"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var HistoryComponent = (function () {
    function HistoryComponent() {
        this.items = [
            new Item("https://www.yandex.ru/", "http://ttt.com", 1, "01.01.0001"),
            new Item("https://www.google.ru/", "http://ttt.com", 2, "00.00.2000"),
            new Item("https://translate.google.ru/", "http://ttt.com", 0, "20.04.2017")
        ];
    }
    return HistoryComponent;
}());
HistoryComponent = __decorate([
    core_1.Component({
        templateUrl: '/url/HistoryComponent'
    })
], HistoryComponent);
exports.HistoryComponent = HistoryComponent;
var Item = (function () {
    function Item(originalUrl, shortUrl, clickCount, dateCreated) {
        this.originalUrl = originalUrl;
        this.shortUrl = shortUrl;
        this.clickCount = clickCount;
        this.dateCreated = dateCreated;
    }
    return Item;
}());
//# sourceMappingURL=history.component.js.map