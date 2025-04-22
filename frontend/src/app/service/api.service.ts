import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private urlApi = 'https://localhost:7280/api/Contacts';

  constructor(private http: HttpClient) { }

  public getContacts() : Observable<any> {
    return this.http.get<any>(this.urlApi)
  }
  
  public addContact(contact: any): Observable<any> {
    return this.http.post<any>(this.urlApi, contact);
  }

  public getContactById(id: number): Observable<any> {
    return this.http.get<any>(`${this.urlApi}/${id}`);
  }

  public deleteContactById(id: number): Observable<any> {
    return this.http.delete<any>(`${this.urlApi}/${id}`);
  }
}
