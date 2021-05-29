import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import {MatSnackBar} from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { PersonService } from 'src/app/apiClient';
import { PersonModel } from 'src/app/data/model/personModel';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit, AfterViewInit  {
  public persons: Array<PersonModel> = [];
  displayedColumns: string[] = ['id', 'name', 'telephone', 'cellPhone', 'action'];
  dataSource = new MatTableDataSource<PersonModel>();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private cd: ChangeDetectorRef, public personService: PersonService, 
              private snackBar: MatSnackBar, private router: Router) { }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit() {
    this.loadPersons();
  }

  private loadPersons()
  {
    this.personService.personGETAll().subscribe((response) => {
      this.persons = [];

      ((response as any).data.personObjects).forEach(el => {
        this.persons.push({ 
          id: el.id, name: el.name, 
          telephone: el.phones.some(x => x.phoneNumberTypeID === 1) ? el.phones.filter(x => x.phoneNumberTypeID == 1)[0].phoneNumber : '', 
          cellPhone: el.phones.some(x => x.phoneNumberTypeID === 2) ? el.phones.filter(x => x.phoneNumberTypeID == 2)[0].phoneNumber : '' 
        });
      });

      this.dataSource.data = this.persons;
    });
  }
  
  public edit(id: number): void {
    this.router.navigate(['/person/create-person'], { queryParams: { id: id }});
  }

  public delete(id: number): void {
    this.personService.personDELETE(id).subscribe(Response => {
      this.snackBar.open('Pessoa excluída com sucesso!', 'Ok', { duration: 3000 });
      this.loadPersons();
    });
  }
}

