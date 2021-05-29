import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ControlMessagesComponent } from './components/control-messages/control-messages.component';
import { MaterialModule } from './material.module';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';
import {
  faPlus,
  faEdit,
  faTrash,
  faTimes,
  faCaretUp,
  faCaretDown,
  faExclamationTriangle,
  faFilter,
  faTasks,
  faCheck,
  faSquare,
  faLanguage,
  faPaintBrush,
  faLightbulb,
  faWindowMaximize,
  faStream,
  faBook,
  faUserCircle,
  faAsterisk
} from '@fortawesome/free-solid-svg-icons';
import { faMediumM, faGithub } from '@fortawesome/free-brands-svg-icons';
import { LoaderComponent } from './components/loader/loader.component';
import { SharedFacade } from './shared.facade';
import { SharedState } from './state/shared.state';
import { LoaderInterceptor } from '../core/interceptor/loader.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

const EXPORT_COMPONENTS = [
  ControlMessagesComponent,
  LoaderComponent
];

const PIPES = [];

const MODULES = [
  
];

library.add(
  faCoffee,
  faGithub,
  faMediumM,
  faPlus,
  faEdit,
  faTrash,
  faTimes,
  faCaretUp,
  faCaretDown,
  faExclamationTriangle,
  faFilter,
  faTasks,
  faCheck,
  faSquare,
  faLanguage,
  faPaintBrush,
  faLightbulb,
  faWindowMaximize,
  faStream,
  faBook,
  faUserCircle,
  faAsterisk
);

@NgModule({
  declarations: [...EXPORT_COMPONENTS, ...PIPES, ],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterModule, FontAwesomeModule,  ...MODULES],
  exports: [CommonModule, FormsModule, ReactiveFormsModule, RouterModule, MaterialModule, FontAwesomeModule, ...EXPORT_COMPONENTS, ...PIPES],
  entryComponents: [],
  providers: [
    SharedFacade,
    SharedState,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
  ]
})
export class SharedModule { }

