import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class searchService {

  constructor(private http:HttpClient) { }

  searchFromApi(text:string):Observable<product[]>{
    return this.http.get<product[]>("http://localhost:64786/api/Products?text="+text);
  }

 
}