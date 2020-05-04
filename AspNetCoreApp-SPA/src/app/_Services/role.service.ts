import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Role } from '../_modeles/role';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  baseUrl = environment.apiUrl + 'Role/';

  constructor(private http: HttpClient) {}

  getRole(id): Observable<Role> {
    return this.http.get<Role>(this.baseUrl + id);
  }

  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(this.baseUrl);
  }

  updateRole(id: number, role: Role) {
    return this.http.put(this.baseUrl + id, role);
  }

  deleteRole(id: number) {
    return this.http.delete(this.baseUrl + id);
  }

  generateRole(role: Role) {
    console.log(role);
    return this.http.post(this.baseUrl + 'generateRole', role);
  }
}
