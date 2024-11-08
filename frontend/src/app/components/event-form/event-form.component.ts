// src/app/components/event-form/event-form.component.ts
import { Component } from '@angular/core';
import { EventService, EventLog } from '../../services/event.service';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css']
})
export class EventFormComponent {
  event: any = { fecha: new Date(), description: '', tipoEvento: '' };
  message: string = '';

  constructor(private eventService: EventService) {}

  registerEvent() {
    console.log("Evento: ", this.event)
    this.eventService.createEvent(this.event).subscribe({
      next: () => this.message = 'Evento registrado exitosamente',
      error: () => this.message = 'Error al registrar el evento'
    });
  }
}
