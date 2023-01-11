import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { fromEvent} from 'rxjs';
import { product } from '../models/product';
import { searchService } from '../services/search.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  buttonSubscription: any;
  constructor(private searchService: searchService) {}
  searchResult:product[]= new Array<product>();
  @ViewChild('searchInput', {static: false}) input!: ElementRef;
  ngOnInit(): void {
    console.log("on init")
    console.log(this.searchResult)
  }
  onTextChange(changedText: string) {
      this.searchService
      .searchFromApi(changedText)
      .subscribe((response:product[])=>{
          console.log(response)
          this.searchResult=response;
          console.table(this.searchResult[0])
        },
        errorResponse => {
          console.error(errorResponse);
        }
      );
   
  }
  inputChange() {
    this.buttonSubscription =  fromEvent(this.input.nativeElement, 'keyup')
        .subscribe(res => console.log(res));
  }
  ngAfterViewInit() {
    this.inputChange();
  }
  ngOnDestroy() {
    this.buttonSubscription.unsubscribe()
  }
 
 
  //  cancelPendingRequests() {
  //   this.searchResult.forEach(sub => sub.unsubscribe());
  //  }


}




