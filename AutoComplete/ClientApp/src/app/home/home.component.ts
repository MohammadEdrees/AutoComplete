import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { GeneralService } from '../general.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  constructor(private generalService: GeneralService) {}

  ngOnInit(): void {

  }


  getText(text:string) {
    console.log(text);
    console.log(this.generalService.Search(text))
  }
 
}
