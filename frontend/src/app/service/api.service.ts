import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../interfaces/contact';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private urlApi = 'https://localhost:7280/api/Contacts';

  constructor(private http: HttpClient) { }

  public getContacts() : Observable<Contact[]> {
    return this.http.get<Contact[]>(this.urlApi)
  }
  
  public addContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(this.urlApi, contact);
  }

  public getContactById(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${this.urlApi}/${id}`);
  }

  public deleteContactById(id: number): Observable<Contact> {
    return this.http.delete<Contact>(`${this.urlApi}/${id}`);
  }

  public updateContact(contact: Contact): Observable<Contact> {
    return this.http.put<Contact>(`${this.urlApi}/${contact.id}`, contact);
  }
}
