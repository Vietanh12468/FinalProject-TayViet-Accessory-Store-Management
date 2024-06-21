import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';


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
  title = 'sellerstaticview';
  searchTerm: string = '';

  performSearch() {

    console.log('Performing search for:', this.searchTerm);

  }
}
