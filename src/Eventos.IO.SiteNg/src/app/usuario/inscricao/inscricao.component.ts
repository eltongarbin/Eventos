import { Component, OnInit, AfterViewInit, ElementRef, ViewChildren } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, FormControlName } from '@angular/forms';
import { Router } from "@angular/router";

import { CustomValidators } from 'ng2-validation';

import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/debounceTime';
import { Observable } from "rxjs/Observable";

import { Organizador } from "../organizador";
import { OrganizadorService } from "./../organizador.service";
import { GenericValidator } from "app/utils/generic-form-validator";

@Component({
    selector: 'app-inscricao',
    templateUrl: './inscricao.component.html',
    styleUrls: ['./inscricao.component.css']
})
export class InscricaoComponent implements OnInit, AfterViewInit {
    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    public errors: any[] = [];
    public displayMessage: { [key: string]: string } = {};
    private validationMessages: { [key: string]: { [key: string]: string } };
    public inscricaoForm: FormGroup;
    private organizador: Organizador;
    private genericValidator: GenericValidator;

    constructor(private fb: FormBuilder,
        private router: Router,
        private organizadorService: OrganizadorService) {
        this.validationMessages = {
            nome: {
                required: 'O Nome é requerido.',
                minlength: 'O Nome precisa ter no mínimo 2 caracteres',
                maxlength: 'O Nome precisa ter no máximo 150 caracteres'
            },
            cpf: {
                required: 'Informe o CPF',
                rangeLength: 'CPF deve conter 11 caracteres'
            },
            email: {
                required: 'Informe o e-mail',
                email: 'E-mail inválido'
            },
            password: {
                required: 'Informe a senha',
                minlength: 'A senha deve possuir no mínimo 6 caracteres'
            },
            confirmPassword: {
                required: 'Informe a senha novamente',
                minlength: 'A senha deve possuir no mínimo 6 caracteres',
                equalTo: 'As senhas não conferem'
            }
        };

        this.organizador = new Organizador();
        this.genericValidator = new GenericValidator(this.validationMessages);
    }

    ngOnInit(): void {
        let password = new FormControl('', [Validators.required, Validators.minLength(6)]);
        let confirmPassword = new FormControl('', [
            Validators.required,
            Validators.minLength(6),
            CustomValidators.equalTo(password)
        ]);

        this.inscricaoForm = this.fb.group({
            nome: ['', [
                Validators.required,
                Validators.minLength(2),
                Validators.maxLength(150)
            ]],
            cpf: ['', [
                Validators.required,
                CustomValidators.rangeLength([11, 11])
            ]],
            email: ['', [
                Validators.required,
                CustomValidators.email
            ]],
            password: password,
            confirmPassword: confirmPassword
        });
    }

    ngAfterViewInit(): void {
        let controlBlurs: Observable<any>[] = this.formInputElements.map(
            (formControl: ElementRef) => Observable.fromEvent(formControl.nativeElement, 'blur')
        );

        Observable.merge(this.inscricaoForm.valueChanges, ...controlBlurs)
            .debounceTime(5000)
            .subscribe(value => {
                this.displayMessage = this.genericValidator.processMessages(this.inscricaoForm);
            });
    }

    adicionarOrganizador(): void {
        if (this.inscricaoForm.dirty && this.inscricaoForm.valid) {
            let organizadorMapped = Object.assign({}, this.organizador, this.inscricaoForm.value);

            this.organizadorService.registrarOrganizador(organizadorMapped)
                .subscribe(
                result => this.onSaveComplete(result),
                error => { this.errors = JSON.parse(error._body).errors; }
                );
        }
    }

    onSaveComplete(response: any): void {
        this.inscricaoForm.reset();
        this.errors = [];
    }
}