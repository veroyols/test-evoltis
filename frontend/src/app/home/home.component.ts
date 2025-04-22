import { Component } from '@angular/core';
import { ApiService } from '../service/api.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  data : any[] = [];
  contactForm!: FormGroup;

  constructor(private apiService: ApiService, private form: FormBuilder) {}

  ngOnInit(): void {
    this.contactForm = this.form.group({
      name: [''],
      phone: ['']
    });

    this.getAllContacts();
  }

  getAllContacts() {
    this.apiService.getContacts().subscribe( contacts => {
      this.data = contacts;
      console.log("Contactos: ", this.data);
    } )
  }

  addContact() {
    this.apiService.addContact(this.contactForm.value).subscribe( contacts => {
      this.contactForm.reset();
      this.getAllContacts();
    } )
  }
}
