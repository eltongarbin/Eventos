import { Component, ViewChildren, ElementRef, OnInit, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControlName, Validators } from "@angular/forms";
import { Router } from "@angular/router";

import { CustomValidators } from "ng2-validation";

import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/debounceTime';
import { Observable } from "rxjs/Observable";

import { Organizador } from "./../organizador";
import { OrganizadorService } from "./../organizador.service";
import { GenericValidator } from "app/utils/generic-form-validator";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, AfterViewInit {
    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    public errors: any[] = [];
    public displayMessage: { [key: string]: string } = {};
    private validationMessages: { [key: string]: { [key: string]: string } };
    public loginForm: FormGroup;
    private organizador: Organizador;
    private genericValidator: GenericValidator;

    constructor(private fb: FormBuilder,
        private router: Router,
        private organizadorService: OrganizadorService) {
        this.validationMessages = {
            email: {
                required: 'Informe o e-mail',
                email: 'E-mail inválido'
            },
            password: {
                required: 'Informe a senha',
                minlength: 'A senha deve possuir no mínimo 6 caracteres'
            }
        };

        this.organizador = new Organizador();
        this.genericValidator = new GenericValidator(this.validationMessages);
    }

    ngOnInit(): void {
        this.loginForm = this.fb.group({
            email: ['', [
                Validators.required,
                CustomValidators.email
            ]],
            password: ['', [
                Validators.required,
                Validators.minLength(6)
            ]]
        })
    }

    ngAfterViewInit(): void {
        let controlBlurs: Observable<any>[] = this.formInputElements.map(
            (formControl: ElementRef) => Observable.fromEvent(formControl.nativeElement, 'blur')
        );

        Observable.merge(this.loginForm.valueChanges, ...controlBlurs)
            .debounceTime(5000)
            .subscribe(value => {
                this.displayMessage = this.genericValidator.processMessages(this.loginForm);
            });
    }

    logar(): void {
        if (this.loginForm.dirty && this.loginForm.valid) {
            let organizadorMapped = Object.assign({}, this.organizador, this.loginForm.value);

            this.organizadorService.logarOrganizador(organizadorMapped)
                .subscribe(
                result => this.onSaveComplete(result),
                error => { this.errors = JSON.parse(error._body).errors; }
                );
        }
    }

    onSaveComplete(response: any): void {
        this.loginForm.reset();
        this.errors = [];

        localStorage.setItem('eio.token', response.result.access_token);
        localStorage.setItem('eio.user', JSON.stringify(response.result.user));

        this.router.navigate(['/home']);
    }
}