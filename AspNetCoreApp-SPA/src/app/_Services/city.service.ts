import { Injectable } from '@angular/core';
import { City } from '../_modeles/city';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CityService {
  baseUrl = environment.apiUrl + 'City/';

  constructor(private http: HttpClient) {}

  getCity(id): Observable<City> {
    return this.http.get<City>(this.baseUrl + id);
  }

  getCitys(): Observable<City[]> {
    return this.http.get<City[]>(this.baseUrl);
  }

  updateCity(id: number, city: City) {
    return this.http.put(this.baseUrl + id, city);
  }

  generateCity(city: City) {
    return this.http.post(this.baseUrl + 'generateCity', city);
  }
}
