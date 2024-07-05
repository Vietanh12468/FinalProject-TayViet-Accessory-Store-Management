import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './api.service';

import { NotificationComponent } from './notification/notification.component';
import { SalesInformationComponent } from './sales-information/sales-information.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NotificationComponent, SalesInformationComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  items: any[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadItems();
  }

  loadItems(): void {
    this.apiService.getItems().subscribe(data => {
      this.items = data;
    });
  }

}
  
