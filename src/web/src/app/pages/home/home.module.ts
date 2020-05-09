import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { MenuTopModule } from 'src/app/components/menu-top/menu-top.module';
import { CarouselModule } from 'src/app/components/carousel/carousel.module';
import { CardComponent } from './components/card/card.component';
import { FooterModule } from 'src/app/components/footer/footer.module';



@NgModule({
  declarations: [
    HomeComponent,
    CardComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MenuTopModule,
    CarouselModule,
    FooterModule
  ]
})
export class HomeModule { }
