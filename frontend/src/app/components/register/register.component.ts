import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  username: string = '';
  password: string = '';
  confirmPassword: string = '';
  email: string = '';
  errorMessage: string = '';
  successMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onRegister() {
    if (this.password !== this.confirmPassword) {
      this.errorMessage = 'Las contraseñas no coinciden.';
      return;
    }

    this.authService.register(this.username, this.password, this.email).subscribe({
      next: () => {
        this.successMessage = 'Usuario registrado exitosamente. Ahora puedes iniciar sesión.';
        this.router.navigate(['/login']);
      },
      error: () => {
        this.errorMessage = 'Error al registrar el usuario. El nombre de usuario ya está en uso.';
      }
    });
  }
}
