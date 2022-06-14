import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core'; 
import { catchError, Observable, throwError } from 'rxjs';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private notification: NotificationService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(catchError(error => {
      if (error instanceof HttpErrorResponse) {
        if (error.status === 400 || error.status === 500) { this.notification.warning('Help us improve your experience by sending an error report', 'Oops! Something went wrong!'); }
        if (error.status === 404) { this.notification.warning('Help us improve your experience by sending an error report', 'Oops! Something went wrong!'); }
      }
      return throwError(error);
    }));
  }
}
