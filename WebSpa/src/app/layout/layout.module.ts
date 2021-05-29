import { CommonModule } from '@angular/common';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { RouterModule } from '@angular/router'

import { LayoutRoutes } from './layout.routing';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { FooterComponent } from './footer/footer.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
  declarations: [FooterComponent, SidebarComponent, NavbarComponent, AdminLayoutComponent],
  exports: [FooterComponent, SidebarComponent, NavbarComponent, AdminLayoutComponent],
  imports: [CommonModule, RouterModule.forChild(LayoutRoutes),],
  providers: [],
})
export class LayoutModule {
  
  constructor(
    @Optional()
    @SkipSelf()
    parentModule: LayoutModule
  ) {
    if (parentModule) {
      throw new Error('LayoutModule is already loaded. Import it in the AppModule only.');
    }
  }
}
