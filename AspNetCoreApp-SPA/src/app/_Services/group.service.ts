import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Group } from '../_modeles/group';

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  baseUrl = environment.apiUrl + 'Group/';

  constructor(private http: HttpClient) {}

  getGroup(id): Observable<Group> {
    return this.http.get<Group>(this.baseUrl + id);
  }

  getGroups(): Observable<Group[]> {
    return this.http.get<Group[]>(this.baseUrl);
  }

  updateGroup(id: number, group: Group) {
    return this.http.put(this.baseUrl + id, group);
  }

  generateRole(group: Group) {
    return this.http.post(this.baseUrl + 'generateGroup', group);
  }
}
