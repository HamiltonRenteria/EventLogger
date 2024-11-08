// src/app/components/event-list/event-list.component.ts
import { Component, OnInit } from '@angular/core';
import { EventService, EventLog } from '../../services/event.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  events: any[] = [];
  fechaInicio?: Date;
  fechaFin?: Date;
  tipoEvento?: string;

  constructor(private eventService: EventService) {}

  ngOnInit() {
    this.getAllEnvents();
    this.getEvents();
  }

  getAllEnvents() {
    this.eventService.getAllEvents().subscribe(events => {
      console.log("Eventos totales: ", events.data)
      this.events = events.data;
    })
  }

  getEvents() {
    this.eventService.getEvents(this.fechaInicio, this.fechaFin, this.tipoEvento).subscribe(events => {
      this.events = events;
    });
  }
}
