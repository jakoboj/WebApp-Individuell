import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { Meny } from './nav-meny/nav-meny';
import { SPA } from './spa';



@NgModule({
  declarations: [
    Meny,
    SPA
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [Meny, SPA]
})
export class AppModule { }
