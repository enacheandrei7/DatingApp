import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root',
})
// In the router AuthGuard, the elements subscribe themselves (no need for .currentUser$.subscribe())
export class AuthGuard implements CanActivate {
  constructor(
    private accountService: AccountService,
    private toastr: ToastrService
  ) {}

  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map((user) => {
        // without .pipe(map()), return true would get an error, but by using pipe and map we get true as an observable, so no error
        if (user) return true;
        this.toastr.error('You shall not pass!');
      })
    );
  }
}
