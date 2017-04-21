import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { DataService } from './history.service';
import { UrlRecord } from './url-record';

@Component({
    templateUrl: '/partial/HistoryComponent',
    providers: [DataService]
})

export class HistoryComponent {
    urlRecords: UrlRecord[];
    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getData()
            .subscribe((data: Response) => this.urlRecords = data.json());
    }
}