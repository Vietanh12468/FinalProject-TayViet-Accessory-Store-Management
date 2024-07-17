import { Component, EventEmitter, Input, OnChanges, SimpleChanges, Output, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAccount } from '../Interface/iaccount';

@Component({
  selector: 'app-detail-account-view',
  templateUrl: './detail-account-view.component.html',
  styleUrl: './detail-account-view.component.css'
})
export class DetailAccountViewComponent implements OnInit {
  @Input() id: string = '';
  public account: any = {"id": "", "username": "", "password": "", "email": "", "phoneNumber": "", "name": "", "role": "", "state": "", "image": ""};
  public attributes: string[] = []
  readDataAttributesCheck: boolean = false;
  ngOnInit() {
    this.readDataAttributesCheck = false
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (!this.readDataAttributesCheck) {
      this.getDetailCustomers();
      this.readDataAttributes();
      const reader = new FileReader();
      reader.onload = () => {
        this.account.image = reader.result;
      };
    }
  }
  constructor(private http: HttpClient) { }
  getDetailCustomers() {
    this.http.get<IAccount>(`/api/Account/${this.id}`).subscribe(
      (result) => {
        this.account = result;
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  readDataAttributes() {
    for (const key in this.account) {
      if (this.account.hasOwnProperty(key)) {
        this.attributes.push(key);
      }
    }
    this.readDataAttributesCheck = true
  }

  onResetPasswordClick(): void {
    console.log('Submit button clicked!');
    // Add your logic here for the submit button click event
  }

  onEditUserClick(): void {
    console.log('Cancel button clicked!');
    // Add your logic here for the cancel button click event
  }

  onBackClick(): void {
    console.log('Custom button clicked!');
    // Add your logic here for the custom button click event
  }
}
