import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ContactForm {
  name: string;
  email: string;
  phone: string;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class ContactService {

 private apiUrl = 'http://localhost:5154/api/contact/send';


  constructor(private http: HttpClient) { }

  sendContact(formData: ContactForm): Observable<any> {
   return this.http.post(this.apiUrl, formData, { responseType: 'text' });

  }
}
