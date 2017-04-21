import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class DataService {
    constructor(private http: Http) { }
    
    getData() {
        return this.http.get('/Url/GetHistory');
    }

    minify(url: string) {
        const body = JSON.stringify({ url: url });
        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });

        return this.http.post('/Url/Minify', body, { headers: headers })
            .map((resp: Response) => resp.json())
            .catch((error: any) => { return Observable.throw(error); });
    }
}