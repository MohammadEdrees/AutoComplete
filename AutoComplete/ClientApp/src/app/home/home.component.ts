import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { debounceTime, distinctUntilChanged, filter, fromEvent, pluck } from 'rxjs';
import { product } from '../models/product';
import { searchService } from '../services/search.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})

export class HomeComponent implements AfterViewInit {
  buttonSubscription: any;
  constructor(private searchService: searchService) { }
  searchResult: product[] = new Array<product>();
  @ViewChild('searchInput') searchInput!: ElementRef;
  ngOnInit(): void {
   }
 
  ngAfterViewInit() {

     fromEvent(this.searchInput.nativeElement, 'keyup').pipe(
      pluck("target", "value"),
      filter((val: any) => val.length > 2),
      debounceTime(444),
      distinctUntilChanged(),
    ).subscribe(search => {
      this.SearchFunc(search);
    })

  }


  SearchFunc(text: any) {
    this.searchService
      .searchFromApi(text)
      .subscribe((response: product[]) => {
        console.log(response)
        this.searchResult = response;
         console.log("To Server")
      },
        errorResponse => {
          console.error(errorResponse);
        }
      );
  }

}




