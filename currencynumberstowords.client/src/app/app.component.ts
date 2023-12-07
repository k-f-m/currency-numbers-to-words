import { Component } from '@angular/core';
import { ConversionService } from './services/conversion.service';
import { NgForm } from '@angular/forms';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  convertedValue?: string;

  constructor(private conversionService: ConversionService) { }

  /**
 * This method is called when the user submits a form and takes an instance of NgForm as an argument.
 * NgForm is the Angular built-in directive used to create forms.
 * After an initial input validity check, it calls the convert method of the ConversionService and subscribes to the response.
 * Error responses are displayed to the user when conversion cannot be performed.
 */
  onSubmit(num: NgForm) {
    console.log('You entered: ' + num.value.input)
    if (num.value.input === null || num.value.input === '') {
      this.convertedValue = "Please enter a number!";
    }
    else {
      this.conversionService.convert(num.value.input).pipe(
        catchError((error) => {
          if (error.status == 400) {
            this.convertedValue = error.error;
            return throwError(() => new Error("Bad request: " + error.message));
          }
          else {
            this.convertedValue = error.error;
            return throwError(() => new Error("An error occurred: " + error.message));
          }
        })
      ).subscribe((response) => {
        this.convertedValue = response;
      });
    }
  }
}
