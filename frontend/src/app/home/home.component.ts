import { Component } from '@angular/core';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  data : any[] = []

  constructor(private apiService: ApiService) {}

  ngOnInit() : void {
    this.getAllContacts();
  }

  getAllContacts() {
    this.apiService.getContacts().subscribe( contacts => {
      this.data = contacts;
      console.log(this.data);
    } )
  }
}
