import { Component } from '@angular/core';
import { DataService } from './history.service';

@Component({
    templateUrl: '/partial/IndexComponent',
    providers: [DataService]
})

export class IndexComponent {
    shortUrl: string;
    isProcessing: boolean;

    constructor(private dataService: DataService) { }

    minify(url: string): void {
        this.isProcessing = true;
        this.dataService
            .minify(url)
            .subscribe((data) => {
                this.shortUrl = (data as string);
                this.isProcessing = false;
            });
    }
}