import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MessageBoxComponent } from './message-box/message-box.component';
import { AlertBoxComponent } from './alert-box/alert-box.component';

@NgModule({
  declarations: [
    AppComponent,
    AlertBoxComponent
    MessageBoxComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
