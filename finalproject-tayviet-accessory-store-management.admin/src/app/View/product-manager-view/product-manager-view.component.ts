import { Component, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../../Interface/iproduct';
import { SelectOption } from '../../Interface/iselect-option';
import { OutputSearch } from '../../Interface/ioutput-search';
import { TableComponent } from '../../Component/table/table.component';
import { Router } from '@angular/router';
import { APIService } from '../../Service/API/api.service';
@Component({
  selector: 'app-product-manager-view',
  templateUrl: './product-manager-view.component.html',
  styleUrl: './product-manager-view.component.css'
})
export class ProductManagerViewComponent {
  @ViewChild('tableComponent') tableComponent!: TableComponent;
  data: IProduct[] = [];
  total: number = 0;
  objectName: string = 'Product';
  selectOptions: SelectOption[] = [
    {
      nameOption: 'State',
      options: [
        'active',
        'inactive'
      ]
    },
    {
      nameOption: 'Order By',
      options: [
        'asc',
        'desc'
      ]
    }
  ]

  ignoredAttributes: string[] = ['subProductList'];
  detailLink = '/product-detail';
  ngOnInit() {  
    this.getPages();
  }
  constructor(private apiService: APIService, private router: Router) { }

  CustomerList: IProduct[] = [];

  getPages(page: number = 1) {
    this.apiService.getListObjects(this.objectName, page).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
      },
      (error) => {
        console.error(error);
      }
    )
    console.log(this.data);
  }

  searchSubmit(searchInfo: OutputSearch, page: number = 1) {
    this.apiService.searchListObjects(this.objectName, 'name', searchInfo.searchString, page).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onCreateClick() {
    this.router.navigate(['/product-manager/create']);
  }
}
