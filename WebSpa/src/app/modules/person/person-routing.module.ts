import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateOrEditComponent } from './createOrEdit/create-or-edit/create-or-edit.component';

import { IndexComponent } from './list/index.component';

const routes: Routes = [
  {
    path: 'index',
    component: IndexComponent
  },
  {
    path: 'create-person',
    component: CreateOrEditComponent
  },
  {
    path: 'create-person/:id',
    component: CreateOrEditComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonRoutingModule { }
