import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'urlminifier-app',
    templateUrl: '/home/appComponent'
})
export class AppComponent {
    public constructor(private titleService: Title) { }

    //angularClientSideData = 'Angular';

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }
}