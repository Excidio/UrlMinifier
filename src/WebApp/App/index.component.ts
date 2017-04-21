import { Component } from '@angular/core';
import { DataService } from './history.service';

@Component({
    templateUrl: '/partial/IndexComponent',
    providers: [DataService]
})

export class IndexComponent {
    shortUrl: string;
    constructor(private dataService: DataService) { }

    minify(url: string): void {
        this.dataService.minify(url)
            .subscribe((data) => { console.log(data); this.shortUrl = ""; });;
    }
}