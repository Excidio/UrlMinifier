import { NgModule, enableProdMode } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { routing, routedComponents } from './app.routing';
import { APP_BASE_HREF, Location } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';

//enableProdMode();

@NgModule({
    imports: [BrowserModule, routing, HttpModule, FormsModule],
    declarations: [AppComponent, routedComponents],
    providers: [Title, { provide: APP_BASE_HREF, useValue: '/' }],
    bootstrap: [AppComponent]
})
export class AppModule { }