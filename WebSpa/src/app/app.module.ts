import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthLayoutComponent } from './layout/auth-layout/auth-layout.component';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { LayoutModule } from './layout/layout.module';
import { SharedModule } from './shared/shared.module';
import { ViewsModule } from './views/views.module';

import { ApiModule } from './apiClient'

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    ViewsModule,
    LayoutModule,
    ApiModule,
  ],
  declarations: [
    AppComponent,
    AuthLayoutComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


