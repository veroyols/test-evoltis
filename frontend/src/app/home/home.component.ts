import { Component } from '@angular/core';
import { ApiService } from '../service/api.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Contact } from '../interfaces/contact';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent  {
  data: Contact[] = [];
  contactForm!: FormGroup;
  edit: boolean = false;
  inEdit: number | null = null;
  modal: boolean = false;

  dataFiltered: Contact[] = [];
  filterName: string = '';

  constructor(private apiService: ApiService, private form: FormBuilder) {}

  ngOnInit(): void {
    this.contactForm = this.form.group({
      name: ['', [Validators.required, Validators.pattern(/^[a-zA-Z\s]+$/)]],
      phone: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
    });

    this.getAllContacts();
  }

  getAllContacts(): void {
    this.apiService.getContacts().subscribe({
      next: (contacts: Contact[]) => {
        this.data = contacts;
        this.filterContacts(); 
      },
      error: (msg) => console.error('No se han podido recuperar los contactos', msg)
    });
  }
  
  openModal() {
    this.edit = false;
    this.contactForm.reset();
    this.modal = true;
  }
  

  onSubmit(): void {
    if (this.contactForm.invalid) {
    
      return;
    }

    if (this.edit && this.inEdit !== null) {
      const updated = {
        id: this.inEdit,
        ...this.contactForm.value
      };
      this.apiService.updateContact(updated).subscribe({
        next: () => {
          this.resetForm();
          this.getAllContacts();
        },
        error: (msg) => console.error('Error al actualizar contacto', msg)
      });
    } else {
      this.apiService.addContact(this.contactForm.value).subscribe({
        next: () => {
          this.contactForm.reset();
          this.getAllContacts();
        },
        error: (err) => console.error('Error al agregar contacto', err)
      });
    }
    this.contactForm.reset();
    this.edit = false;
    this.modal = false;
  }

  editarContacto(contacto: any): void {
    this.edit = true;
    this.inEdit = contacto.id;
    this.contactForm.patchValue({
      name: contacto.name,
      phone: contacto.phone
    });

    this.modal = true; 
  }

  eliminarContacto(id: number): void {
    this.apiService.deleteContactById(id).subscribe({
      next: () => this.getAllContacts(),
      error: (msg) => console.error('Error al eliminar contacto', msg)
    });
  }

  resetForm(): void {
    this.edit = false;
    this.inEdit = null;
    this.contactForm.reset();
  }

  cancelar() {
    this.modal = false;
    this.contactForm.reset();
    this.edit = false;
  }
  
  filterContacts(): void {
    if (!this.filterName || this.filterName.trim() === '') {
      this.dataFiltered = this.data;
    } else {
      this.dataFiltered = this.data.filter(contact =>
        contact.name.toLowerCase().includes(this.filterName.toLowerCase())
      );
    }
  }
  
}