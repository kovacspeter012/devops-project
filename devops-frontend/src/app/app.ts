import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { WeatherForecast } from '../model/weather-forecast.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  private http = inject(HttpClient);

  availableCities: string[] = ['London', 'New York', 'Tokyo', 'Moscow', 'Sydney'];
  
  searchCity: string = this.availableCities[0]; 
  
  weatherData: WeatherForecast | null = null;
  errorMessage: string = '';

  private apiUrl = 'https://devops-project-kp-backend.jcloud.jedlik.cloud/WeatherForecast'; 

  getWeather() {
    if (!this.searchCity) {
      return;
    }
    
    this.errorMessage = '';
    this.weatherData = null;

    this.http.get<WeatherForecast>(`${this.apiUrl}/${this.searchCity}`).subscribe({
      next: (data) => {     
        this.weatherData = data;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
}
