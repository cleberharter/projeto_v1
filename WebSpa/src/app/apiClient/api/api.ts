export * from './example.service';
import { ExampleService } from './example.service';
export * from './person.service';
import { PersonService } from './person.service';
export const APIS = [ExampleService, PersonService];
