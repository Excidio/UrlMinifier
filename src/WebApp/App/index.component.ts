import { Component } from '@angular/core';
import { UrlService } from './url.service';

@Component({
    templateUrl: '/partial/IndexComponent',
    providers: [UrlService]
})

export class IndexComponent {
    shortUrl: string;
    isProcessing: boolean;

    constructor(private urlService: UrlService) { }

    minify(url: string): void {
        this.isProcessing = true;
        this.urlService
            .minify(url)
            .subscribe((data) => {
                this.shortUrl = (data as string);
                this.isProcessing = false;
            });
    }
}