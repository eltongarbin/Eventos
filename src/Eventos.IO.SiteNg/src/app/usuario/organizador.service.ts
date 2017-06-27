import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { Organizador } from "./organizador";

import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class OrganizadorService {
    constructor(private http: Http) { }

    private extractData(response: Response) {
        let body = response.json();
        return body.data || {};
    }

    private serviceError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }

        return Observable.throw(error);
    }

    registrarOrganizador(organizador: Organizador): Observable<Organizador> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers });

        let response = this.http
            .post('http://localhost:50049/api/v1/nova-conta', organizador, options)
            .map(this.extractData)
            .catch(this.serviceError);

        return response;
    }
}