import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'MiniShopClient';
}

$.get('https://localhost:7102/api/products', data => {
  console.log(data);
});
