import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {
  public static getValidationErrorMessage(validatorName: string, validatorValue?: any, labelName?: string): any {
    const config = {
      required: `Campo obrigatório.`,
      invalidPassword: 'Senha inválida. A senha deve ter pelo menos 6 caracteres e conter um número.',
      maxlength: `O campo não pode conter mais de ${validatorValue.requiredLength} caracteres.`,
      minlength: `O campo deve conter pelo menos ${validatorValue.requiredLength} caracteres.`
    };

    return config[validatorName];
  }

  public static passwordValidator(control: AbstractControl): any {
    if (!control.value) { return; }
    
    return (control.value.match(/^(?=.*\d)(?=.*[a-zA-Z!@#$%^&*])(?!.*\s).{6,100}$/)) ? '' : { invalidPassword: true };
  }
}
