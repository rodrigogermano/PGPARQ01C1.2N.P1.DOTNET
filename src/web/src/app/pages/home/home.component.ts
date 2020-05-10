import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    private oauthService: OAuthService,
    private productService: ProductService) { }

  ngOnInit(): void {
    console.log(this.oauthService.getAccessToken());
  }

  criar() : void {
    this.productService.Post("1.0", {
      Id: 0,
      Name: "teste",
      Description: 'teste',
      Price: 10,
      Photo: 'teste'
    }).subscribe(
      success => console.log(success),
      error => console.error(error)
    )
  }

}
