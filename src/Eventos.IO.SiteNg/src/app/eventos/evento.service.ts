import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";

import { Observable } from "rxjs/Observable";

import { Categoria, Evento } from "./evento";
import { ServiceBase } from "app/shared/service-base";

@Injectable()
export class EventoService extends ServiceBase {
    constructor(private http: Http) { super(); }

    obterTodos(): Observable<Evento[]> {
        return this.http.get(this.UrlServiceV1 + 'eventos')
            .map((res: Response) => <Evento[]>res.json())
            .catch(super.serviceError);
    }

    obterCategorias(): Observable<Categoria[]> {
        return this.http.get(this.UrlServiceV1 + 'eventos/categorias')
            .map((res: Response) => <Categoria[]>res.json())
            .catch(super.serviceError);
    }

    obterUsuario() {
        return JSON.parse(localStorage.getItem('eio.user'));
    }

    registrarEvento(evento: Evento): Observable<Evento> {
        let options = super.obterAuthHeader();
        evento.id = undefined;

        return this.http.post(this.UrlServiceV1 + 'eventos', evento, options)
            .map(this.extractData)
            .catch(super.serviceError)
    }

    private extractData(response: Response) {
        let body = response.json();
        return body.data || {};
    }
}