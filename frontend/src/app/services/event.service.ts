// src/app/services/event.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface EventLog {
  id?: number;
  fecha: Date;
  descripcion: string;
  tipoEvento: string;
}

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private apiUrl = 'https://localhost:7026/api/EventLogs/';

  constructor(private http: HttpClient) {}

  // Crear un nuevo evento
  createEvent(event: any): Observable<any> {
    return this.http.post(`${this.apiUrl}RegisterEvent`, event);
  }

  // Consultar eventos con filtros
  getEvents(fechaInicio?: Date, fechaFin?: Date, tipoEvento?: string): Observable<any> {
    let params = new HttpParams();
    if (fechaInicio) params = params.append('fechaInicio', fechaInicio.toISOString());
    if (fechaFin) params = params.append('fechaFin', fechaFin.toISOString());
    if (tipoEvento) params = params.append('tipoEvento', tipoEvento);

    return this.http.get<any>(`${this.apiUrl}`, { params });
  }

  getAllEvents() {
    return this.http.get<any>(`${this.apiUrl}GetEvents`);
  }
}
