/**
 * Example Api
 * Example Charge Api.
 *
 * OpenAPI spec version: v1
 * Contact: example@example.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

import { PersonPhoneDto } from "./PersonPhoneDto";


export interface PersonDto {
    id?: number;
    name?: string;
    phones?: Array<PersonPhoneDto>;
}
