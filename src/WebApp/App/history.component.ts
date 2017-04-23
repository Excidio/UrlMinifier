import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { UrlService } from './url.service';
import { UrlRecord } from './url-record';

@Component({
    templateUrl: '/partial/HistoryComponent',
    providers: [UrlService]
})

export class HistoryComponent {
    urlRecords: UrlRecord[];
    constructor(private urlService: UrlService) { }

    ngOnInit() {
        this.urlService
            .getHistory()
            .subscribe((data: Response) => this.urlRecords = data.json());
    }

    openLink(event: Event, i: number) {
        event.preventDefault();
        this.urlRecords[i].clickCount++;
        window.open(this.urlRecords[i].shortUrl);
    }
}