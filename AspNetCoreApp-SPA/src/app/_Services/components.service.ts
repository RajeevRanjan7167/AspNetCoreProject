import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Components } from '../_modeles/components';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ComponentsService {
  baseUrl = environment.apiUrl + 'Components/';

  constructor(private http: HttpClient) {}

  getComponent(id): Observable<Components> {
    return this.http.get<Components>(this.baseUrl + id);
  }

  getComponents(): Observable<Components[]> {
    return this.http.get<Components[]>(this.baseUrl);
  }

  updateComponent(id: number, component: Components) {
    return this.http.put(this.baseUrl + id, component);
  }

  generateComponent(component: Components) {
    return this.http.post(this.baseUrl + 'GenerateComponent', component);
  }
}
