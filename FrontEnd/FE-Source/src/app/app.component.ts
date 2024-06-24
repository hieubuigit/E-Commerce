import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { SidebarModule } from 'primeng/sidebar';
import { TestApiServiceService } from './test/test-api-service.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ButtonModule, SidebarModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'HB Store';
  sidebarVisible: any;
  resultTest = "";

  constructor (private _testSvc: TestApiServiceService) {
  }

  TestApi() {
    console.log("clicked!");
    this._testSvc.tesApi();
  }
}


