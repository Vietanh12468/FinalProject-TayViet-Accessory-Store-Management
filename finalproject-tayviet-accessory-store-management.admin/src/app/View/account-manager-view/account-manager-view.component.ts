import { Component, OnInit, ViewChild, OnChanges, SimpleChanges } from '@angular/core';
import { IAccount } from '../../Interface/iaccount';
import { SelectOption } from '../../Interface/iselect-option';
import { OutputSearch } from '../../Interface/ioutput-search';
import { TableComponent } from '../../Component/table/table.component';
import { Router } from '@angular/router';
import { APIService } from '../../Service/API/api.service';

@Component({
  selector: 'app-account-manager-view',
  templateUrl: './account-manager-view.component.html',
  styleUrl: './account-manager-view.component.css'
})
export class AccountManagerViewComponent implements OnInit, OnChanges {
  @ViewChild('tableComponent') tableComponent!: TableComponent;
  data: IAccount[] = [];
  total: number = 0;
  objectName: string = 'Admin';
  selectOptions: SelectOption[] = [
    {
      nameOption: 'AccountType',
      options: [
        'Admin',
        'Customer',
        'Employee'
      ]
    },
    {
      nameOption: 'State',
      options: [
        'active',
        'inactive'
      ]
    },
    {
      nameOption: 'OrderBy',
      options: [
        'asc',
        'desc'
      ]
    }
  ]

  ignoredAttributes: string[] = ['password'];
  detailLink = 'account-detail';

  ngOnInit() {
    this.getCustomers();
  }

  ngOnChanges(simpleChanges: SimpleChanges) {
  }
  constructor(private apiService: APIService, private router: Router) { }

  CustomerList: IAccount[] = [];

  getCustomers(page: number = 1) {
    this.apiService.getListObjects(this.objectName, page).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
      },
      (error) => {
        console.error(error);
      }
    )
  }

  searchSubmit(searchInfo: OutputSearch, page: number = 1) {
    this.apiService.searchListObjects(this.objectName, 'username', searchInfo.searchString, page).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onCreateUserClick() {
    this.router.navigate(['/account-manager/create']);
  }
}
