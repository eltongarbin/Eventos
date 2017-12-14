import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';

import { Organizador } from "../usuario/models/organizador";

import { BaseService } from "./base.service";


@Injectable()
export class OrganizadorService extends BaseService {

  constructor(private http: Http) { super(); }

  registrarOrganizador(organizador: Organizador): Observable<Organizador> {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    let jsons = JSON.stringify(organizador);
    let response = this.http
      .post(this.UrlServiceV1 + "nova-conta ", organizador, options)
      .map(super.extractData)
      .catch((super.serviceError));
    return response;
  };

  login(organizador: Organizador): Observable<Organizador> {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    let jsons = JSON.stringify(organizador);
    let response = this.http
      .post(this.UrlServiceV1 + "conta ", organizador, options)
      .map(super.extractData)
      .catch((super.serviceError));
    return response;
  };
}


