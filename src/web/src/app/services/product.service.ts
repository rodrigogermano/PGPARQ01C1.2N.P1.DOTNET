import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private http: HttpClient,
    private oauthService: OAuthService) { }

  public Post(version: string, body: any) : Observable<any> {

    let options = {
      headers: new HttpHeaders()
                   .set('Authorization', `Bearer ${this.oauthService.getAccessToken()}`)
                   .set('api-version', version),
      body: body
    };

    console.log(options);

    return this.http.request("POST", `${environment.urlApiGateway}/product`, options);
  }
}
