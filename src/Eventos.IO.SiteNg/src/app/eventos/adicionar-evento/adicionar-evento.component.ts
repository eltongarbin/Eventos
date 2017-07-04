import { Component, ViewChildren, ElementRef, OnInit, ViewContainerRef } from '@angular/core';
import { FormControlName, FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";

import { GenericValidator } from "app/utils/generic-form-validator";
import { DateUtils } from "app/utils/date-utils";
import { Evento, Categoria, Endereco } from "app/eventos/evento";
import { EventoService } from "app/eventos/evento.service";

import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/debounceTime';

import { ToastsManager, Toast } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'app-adicionar-evento',
    templateUrl: './adicionar-evento.component.html',
    styleUrls: ['./adicionar-evento.component.css']
})
export class AdicionarEventoComponent implements OnInit {
    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    public errors: any[] = [];
    public displayMessage: { [key: string]: string } = {};
    private validationMessages: { [key: string]: { [key: string]: string } };
    private genericValidator: GenericValidator;
    public myDatePickerOptions = DateUtils.getMyDatePickerOptions();
    public eventoForm: FormGroup;
    private evento: Evento;
    private categorias: Categoria[];

    constructor(private fb: FormBuilder,
        private eventoService: EventoService,
        public toastr: ToastsManager,
        vcr: ViewContainerRef,
        private router: Router) {
        this.toastr.setRootViewContainerRef(vcr);

        this.validationMessages = {
            nome: {
                required: 'O Nome é requerido.',
                minlength: 'O Nome precisa ter no mínimo 2 caracteres',
                maxlength: 'O Nome precisa ter no máximo 150 caracteres'
            },
            dataInicio: {
                required: 'Informe a data de início'
            },
            dataFim: {
                required: 'Informe a data de encerramento'
            },
            categoriaId: {
                required: 'Informe a categoria'
            }
        }

        this.genericValidator = new GenericValidator(this.validationMessages);
        this.evento = new Evento();
        this.evento.endereco = new Endereco();
    }

    ngOnInit(): void {
        this.eventoForm = this.fb.group({
            nome: ['', [
                Validators.required,
                Validators.minLength(2),
                Validators.maxLength(150)
            ]],
            categoriaId: ['', Validators.required],
            descricaoCurta: '',
            descricaoLonga: '',
            dataInicio: ['', Validators.required],
            dataFim: ['', Validators.required],
            gratuito: '',
            valor: '0',
            online: '',
            nomeEmpresa: '',
            logradouro: '',
            numero: '',
            complemento: '',
            bairro: '',
            cep: '',
            cidade: '',
            estado: ''
        });

        this.eventoService.obterCategorias().subscribe(
            categorias => this.categorias = categorias,
            error => this.errors
        );
    }

    ngAfterViewInit(): void {
        let controlBlurs: Observable<any>[] = this.formInputElements.map(
            (formControl: ElementRef) => Observable.fromEvent(formControl.nativeElement, 'blur')
        );

        Observable.merge(this.eventoForm.valueChanges, ...controlBlurs)
            .debounceTime(5000)
            .subscribe(value => {
                this.displayMessage = this.genericValidator.processMessages(this.eventoForm);
            });
    }

    adicionarEvento() {
        if (this.eventoForm.dirty && this.eventoForm.valid) {
            let user = this.eventoService.obterUsuario();

            let eventoMapped = Object.assign({}, this.evento, this.eventoForm.value);
            eventoMapped.organizadorId = user.id;
            eventoMapped.dataInicio = DateUtils.getMyDatePickerDate(eventoMapped.dataInicio);
            eventoMapped.dataFim = DateUtils.getMyDatePickerDate(eventoMapped.dataFim);
            eventoMapped.endereco.logradouro = eventoMapped.logradouro;
            eventoMapped.endereco.numero = eventoMapped.numero;
            eventoMapped.endereco.complemento = eventoMapped.complemento;
            eventoMapped.endereco.bairro = eventoMapped.bairro;
            eventoMapped.endereco.cep = eventoMapped.cep;
            eventoMapped.endereco.cidade = eventoMapped.cidade;
            eventoMapped.endereco.estado = eventoMapped.estado;

            this.eventoService.registrarEvento(eventoMapped).subscribe(
                result => this.onSaveComplete(),
                error => this.onError(error)
            );
        }
    }

    onError(error): void {
        this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
        this.errors = JSON.parse(error._body).errors;
    }

    onSaveComplete(): void {
        this.eventoForm.reset();
        this.errors = [];

        this.toastr.success('Evento registrado com sucesso!', 'Oba :D', { dismiss: 'controlled' })
            .then((toast: Toast) => {
                setTimeout(() => {
                    this.toastr.dismissToast(toast);
                    this.router.navigate(['/home']);
                }, 2500);
            });
    }
}