import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Resources } from '../_modeles/Resources';

@Injectable({
  providedIn: 'root',
})
export class ResourcesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getResource(Id): Observable<Resources> {
    return this.http.get<Resources>(this.baseUrl + 'Resources/' + Id);
  }

  getResources(): Observable<Resources[]> {
    return this.http.get<Resources[]>(this.baseUrl + 'Resources/');
  }

  updateResource(id: number, Resource: Resources){
    return this.http.put(this.baseUrl + 'Resources/' + id, Resource);
  }

}
