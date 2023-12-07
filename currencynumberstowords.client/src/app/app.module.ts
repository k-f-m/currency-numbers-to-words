import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ConversionService } from './services/conversion.service';

/**
 * This module represents the root module of the application.
 * It declares the root component and imports and configures all the necessary modules and services required by the application.
 */
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule,
    BrowserAnimationsModule, MatCardModule,
    MatSelectModule, MatInputModule, MatFormFieldModule,
    MatIconModule, MatButtonModule, MatToolbarModule,
    ReactiveFormsModule
  ],
  providers: [ConversionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
