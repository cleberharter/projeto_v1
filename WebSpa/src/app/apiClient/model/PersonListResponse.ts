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

import { PersonDto } from "./PersonDto";


export interface PersonListResponse {
    personObjects?: Array<PersonDto>;
    success?: boolean;
    errors?: Array<any>;
}
