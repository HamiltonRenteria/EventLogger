// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7026/api';

  constructor(private http: HttpClient) {}

  // Método para iniciar sesión
  login(username: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/Login/Generate/Token`, { username, password });
  }

  // Almacenar token en el localStorage
  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  // Obtener el token del localStorage
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  // Eliminar token al cerrar sesión
  logout() {
    localStorage.removeItem('token');
  }

  // Verificar si el usuario está autenticado
  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

  register(username: string, password: string, email: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/Login/Register`, { username, passwordHash: password, email });
  }
}