import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRoute, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";

@Injectable()
export class AuthService implements CanActivate {
    public token: string;
    public user;

    constructor(private router: Router, route: ActivatedRoute) {
        this.token = localStorage.getItem('eio.token');
        this.user = JSON.parse(localStorage.getItem('eio.user'));
    }

    canActivate(routeAc: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (!this.token) {
            this.router.navigate(['/entrar']);
            return false;
        }

        if (routeAc.data.length > 0) {
            let claim = routeAc.data[0]['claim'];

            if (claim) {
                let userClaims = this.user.claim.some(x => x.type === claim.nome && x.value === claim.valor);
                if (!userClaims) {
                    this.router.navigate(['/acesso-negado']);
                    return false;
                }
            }
        }

        return true;
    }
}