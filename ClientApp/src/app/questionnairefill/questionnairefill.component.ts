import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ignoreElements } from "rxjs";
import { Questionnaire } from "../Questionnaire";

@Component({
    selector: 'app-questionnairefill',
    templateUrl: './questionnairefill.component.html'
 })
 
 export class QuestionnaireFillComponent
 {
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        
    }
 }
