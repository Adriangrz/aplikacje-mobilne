import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { WebPoint } from '../interfaces/webpoint.interface';

@Injectable({
  providedIn: 'root',
})
export class WebPointService {
  constructor(private http: HttpClient) {}

  getWebPoints(gameId: string) {
    return this.http
      .get<WebPoint[]>(`/api/Game/${gameId}/WebPoint`)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0 || error.status >= 500 || !error.error) {
      return throwError(() => 'Coś poszło nie tak');
    }
    return throwError(() => error.error);
  }
}
