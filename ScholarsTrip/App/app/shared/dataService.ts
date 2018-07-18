import {HttpClient}  from "@angular/common/http";
import {Injectable}  from "@angular/core";

@Injectable()
export class DataService{

  constructor(private http: HttpClient){

  }

  public products = [{
    title: "First Product",
    price: 19.99
  },
  {
    title: "Second Product",
    price: 30
  },
  {
    title: "Third Product",
    price: 15
  }
  ];
}
