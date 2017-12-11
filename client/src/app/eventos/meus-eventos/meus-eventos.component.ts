import { Component, OnInit } from '@angular/core';

import { Evento } from "app/eventos/evento";
import { EventoService } from "app/eventos/evento.service";

@Component({
    selector: 'app-meus-eventos',
    templateUrl: './meus-eventos.component.html'
})
export class MeusEventosComponent implements OnInit {
    public eventos: Evento[];
    public errorMessage: string = "";

    constructor(private eventoService: EventoService) { }

    ngOnInit(): void {
        this.eventoService.obterMeusEventos().subscribe(
            eventos => this.eventos = eventos,
            error => this.errorMessage
        );
    }
}