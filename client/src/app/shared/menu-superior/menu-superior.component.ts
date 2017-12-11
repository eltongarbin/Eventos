import { Component } from '@angular/core';

@Component({
  selector: 'app-menu-superior',
  templateUrl: './menu-superior.component.html'
})
export class MenuSuperiorComponent {
  private token: string;

  constructor() { }

  usuarioLogado(): boolean {
    this.token = localStorage.getItem('eio.token');
    if (!this.token) {
      return false;
    }

    return true;
  }
}
