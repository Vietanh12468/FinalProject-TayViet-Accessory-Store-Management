import { Component } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  cartItems = [
    {
      name: "Italy Pizza",
      description: "Extra cheese and toping",
      image: "https://cdn.builder.io/api/v1/image/assets/TEMP/3e24cbed2ab206e70822774ac2eb87c9756cc6b3ffa7c702c9572d6400f58569?placeholderIfAbsent=true&apiKey=e51cda157a3647efb6a362a799ee758d",
      quantity: 1,
      price: 999
    },
    {
      name: "Combo Plate",
      description: "Extra cheese and toping",
      image: "https://cdn.builder.io/api/v1/image/assets/TEMP/2fd0884298bf943476303043f2f321eeb620fd69befdb1d5230981dc104bccd0?placeholderIfAbsent=true&apiKey=e51cda157a3647efb6a362a799ee758d",
      quantity: 1,
      price: 999
    },
    {
      name: "Spanish Rice",
      description: "Extra garllic",
      image: "https://cdn.builder.io/api/v1/image/assets/TEMP/55c8d629e48534e5d021a4e1588a15eb219d6c69802bfd76887cd20a1a8084b6?placeholderIfAbsent=true&apiKey=e51cda157a3647efb6a362a799ee758d",
      quantity: 1,
      price: 999
    }
  ];
  paymentOption = 'PayOnDelivery'
}
