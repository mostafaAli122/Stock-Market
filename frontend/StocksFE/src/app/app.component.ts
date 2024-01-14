import { SignalRService } from './signal-r.service';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './core/navbar/navbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [SignalRService],
})
export class AppComponent implements OnInit {
  constructor(
   ) {}
  ngOnInit(): void {
   
  }
  title = 'stocks';
}
