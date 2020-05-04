import { Injectable } from '@angular/core';
import { Field } from '../_modeles/field';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FieldService {
  baseUrl = environment.apiUrl + 'Field/';

  constructor(private http: HttpClient) {}

  getField(id): Observable<Field> {
    return this.http.get<Field>(this.baseUrl + id);
  }

  getFields(): Observable<Field[]> {
    return this.http.get<Field[]>(this.baseUrl);
  }

  updateField(id: number, field: Field) {
    return this.http.put(this.baseUrl + id, field);
  }

  generateField(field: Field) {
    return this.http.post(this.baseUrl + 'generateField', field);
  }
}
