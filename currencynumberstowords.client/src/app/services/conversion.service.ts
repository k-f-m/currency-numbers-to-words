import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

/**
 * This is an Angular service that uses Injectable decorator to indicate that the class can be injected with dependencies.
 * The HttpClient is a built-in Angular service that is used to make HTTP requests.
 * Using the post method of the HttpClient we pass the apiUrl, an object containing the text, request type,
 * and an object containing the responseType property.
 * The post method returns an observable that emits the response from the API.
 */
@Injectable({
  providedIn: 'root'
})
export class ConversionService {
  // API endpoint URL
  private apiUrl = "https://localhost:7269/api/Conversion";

  constructor(private http: HttpClient) { }

  convert(value: string) {
    return this.http.post(this.apiUrl, { text: value, request: 'text' }, { responseType: 'text' });
  }
}
