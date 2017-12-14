import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';

import { BaseService } from "../../services/base.service";
import { Evento, Categoria, Endereco } from "../models/evento";

@Injectable()
export class EventoService extends BaseService {

  constructor(private http: Http) { super(); }

  public obterUsuario() {
    return JSON.parse(localStorage.getItem('eio.user'));
  }

  obterTodos(): Observable<Evento[]> {
    return this.http.get(this.UrlServiceV1 + "eventos")
      .map((res: Response) => <Evento[]>res.json())
      .catch(super.serviceError);
  }

  obterEvento(id: string): Observable<Evento> {
    return this.http.get(this.UrlServiceV1 + "eventos/" + id)
      .map((res: Response) => <Evento[]>res.json())
      .catch(super.serviceError);
  }

  obterMeusEventos(): Observable<Evento[]> {
    let options = this.obterAuthHeader();

    return this.http.get(this.UrlServiceV1 + "eventos/meus-eventos", options)
      .map((res: Response) => <Evento[]>res.json())
      .catch(super.serviceError);
  }

  obterCategorias(): Observable<Categoria[]> {
    return this.http.get(this.UrlServiceV1 + "eventos/categorias")
      .map((res: Response) => <Categoria[]>res.json())
      .catch(super.serviceError);
  }

  registrarEvento(evento: Evento): Observable<Evento> {
    let options = this.obterAuthHeader();
    evento.id = undefined;

    let response = this.http
      .post(this.UrlServiceV1 + "eventos", evento, options)
      .map(super.extractData)
      .catch((super.serviceError));
    return response;
  };

  atualizarEvento(evento: Evento): Observable<Evento> {
    let options = this.obterAuthHeader();

    let response = this.http
      .put(this.UrlServiceV1 + "eventos", evento, options)
      .map(super.extractData)
      .catch((super.serviceError));
    return response;
  };

  excluirEvento(id: string): Observable<Evento> {
    let options = this.obterAuthHeader();

    let response = this.http
      .delete(this.UrlServiceV1 + "eventos/" + id, options)
      .map(super.extractData)
      .catch((super.serviceError));
    return response;
  };

  adicionarEndereco(endereco: Endereco): Observable<Endereco> {
    let options = this.obterAuthHeader();

    let response = this.http
      .post(this.UrlServiceV1 + "endereco", endereco, options)
      .map(super.extractData)
      .catch((super.serviceError));
    return response;
  };

  atualizarEndereco(endereco: Endereco): Observable<Endereco> {
    let options = this.obterAuthHeader();

    let response = this.http
      .put(this.UrlServiceV1 + "endereco", endereco, options)
      .map(super.extractData)
      .catch((super.serviceError));
    return response;
  };
}


