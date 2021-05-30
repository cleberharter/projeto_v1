import { AddOrUpdatePersonDto } from './../../../../apiClient/model/AddOrUpdatePersonDto';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { PersonService } from 'src/app/apiClient/api/person.service';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { PersonPhoneDto } from 'src/app/apiClient';
import { of, Subscription } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { PersonModel } from 'src/app/data/model/personModel';
import { CrudType } from 'src/app/shared/enums/crudTypeEnum';

@Component({
  selector: 'app-create-or-edit',
  templateUrl: './create-or-edit.component.html',
  styleUrls: ['./create-or-edit.component.scss']
})
export class CreateOrEditComponent implements OnInit {
  person: PersonModel = new PersonModel();
  addOrUpdatePersonDto: AddOrUpdatePersonDto = {};
  title: string = 'Cadastro de Pessoa';
  sub = new Subscription();
  personId: number = 0;
  personFormGroup: FormGroup;
  crudType: CrudType;

  constructor(public personService: PersonService, private snackBar: MatSnackBar, 
              private formBuilder: FormBuilder, private router: Router, private route: ActivatedRoute,) { }

  ngOnInit() { 
    this.createForm();
    this.crudType = CrudType.Create;

    this.route.queryParams.pipe(
      switchMap(
        (params: ParamMap) => {
          this.personId = +params['id'] || 0;
          if (this.personId == 0) return of(undefined);

          this.title = 'Editar de Pessoa';
          this.crudType = CrudType.Edit;
          return this.personService.personGETById(this.personId);
        }
      )
    ).subscribe(response => { 
      if(response == undefined) return;

      const resp = (response as any).data;
      if(!resp.person) return;

      this.person = { 
        id: resp.person.id, name: resp.person.name, 
        telephone: resp.person.phones.some(x => x.phoneNumberTypeID === 1) ? resp.person.phones.filter(x => x.phoneNumberTypeID == 1)[0].phoneNumber : '', 
        cellPhone: resp.person.phones.some(x => x.phoneNumberTypeID === 2) ? resp.person.phones.filter(x => x.phoneNumberTypeID == 2)[0].phoneNumber : '' 
      };

      this.personFormGroup.get("id").setValue(this.person.id);
      this.personFormGroup.get("name").setValue(this.person.name);
      this.personFormGroup.get("telephone").setValue(this.person.telephone);
      this.personFormGroup.get("cell").setValue(this.person.cellPhone);
    });
  }

  private createForm() {
    this.personFormGroup = this.formBuilder.group({
                            id: [this.person.id],
                            name: [this.person.name, Validators.required],
                            telephone: [this.person.telephone],
                            cell: [this.person.cellPhone]
                          });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  onSubmit() {
    if (!this.personFormGroup.valid) {
      return;
    }
    
    this.setPersonDto();

    if(this.crudType == CrudType.Create)
    {
      this.personService.personPOST(this.addOrUpdatePersonDto).subscribe(response =>
      {
        const resp = (response as any);
        resp.data.success ? this.ShowSuccess() : this.showErrors(resp.data.errors);
      });
    }
    else if(this.crudType = CrudType.Edit)
    {
      this.personService.personPUT(this.person.id, this.addOrUpdatePersonDto).subscribe(response =>
      {
        const resp = (response as any).data;
        response.isSuccess ? this.ShowSuccess() : this.showErrors(resp.errors);
      });
    }
  }

  private ShowSuccess()
  {
    this.snackBar.open(`Pessoa ${ this.crudType == CrudType.Create ? 'cadastrada' : 'alterada' } com sucesso!`, 'Ok', { duration: 5000 });
    this.personFormGroup.reset();
    this.router.navigate(['/person/index']);
  }

  private showErrors(errors: Array<any>)
  {
    let message: string = '';
    errors.forEach(x => {
      message = message + x.message + (message !== '' ? ', ' : '');
    });

    this.snackBar.open(message !== '' ? message : `Ops, houve um erro ao ${ this.crudType == CrudType.Create ? 'cadastrar' : 'editar' } o usuário!`, 
                    'Ok', { duration: 5000, panelClass: ['error'], }); 
  }

  private setPersonDto() {
    let phones: Array<PersonPhoneDto> = new Array();

    if(this.personFormGroup.controls['telephone'].value)
      phones.push({ id: 0, phoneNumber:  this.personFormGroup.controls['telephone'].value, PhoneNumberTypeID: 1 });
    if(this.personFormGroup.controls['cell'].value)
      phones.push({ id: 0, phoneNumber:  this.personFormGroup.controls['cell'].value, PhoneNumberTypeID: 2 });

    this.addOrUpdatePersonDto.id = this.personFormGroup.controls['id'].value;
    this.addOrUpdatePersonDto.name = this.personFormGroup.controls['name'].value;
    this.addOrUpdatePersonDto.phones = phones;
  }
}
