import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {

  constructor(private http:HttpClient) { }

  searchFromApi(text:string):any{
    return this.http.get("https://localhost:4601/api/Products/Search?text="+text)
  }

  Search(text:string) {
    this.searchFromApi(text)
      .subscribe((data: any)=>{
       console.log(data)
      });
  }
}
