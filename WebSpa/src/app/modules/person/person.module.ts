import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared/shared.module';
import { PersonRoutingModule } from './person-routing.module';
import { IndexComponent } from './list/index.component';
import { CreateOrEditComponent } from './createOrEdit/create-or-edit/create-or-edit.component';
import { IConfig, NgxMaskModule } from 'ngx-mask';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = null;

@NgModule({
  declarations: [IndexComponent, CreateOrEditComponent],
  imports: [
    PersonRoutingModule,
    SharedModule,
    NgxMaskModule.forRoot(),
  ]
})
export class PersonModule { }
