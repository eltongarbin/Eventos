import { Component, OnInit } from '@angular/core';

import { Evento } from "../models/evento";
import { EventoService } from "../services/evento.service";

@Component({
    selector: 'app-lista-eventos',
    templateUrl: './lista-eventos.component.html'
})
export class ListaEventosComponent implements OnInit {
    public eventos: Evento[];
    public errorMessage: string = "";

    constructor(private eventoService: EventoService) { }

    ngOnInit(): void {
        this.eventoService.obterTodos().subscribe(
            eventos => this.eventos = eventos,
            error => this.errorMessage
        );
    }
}