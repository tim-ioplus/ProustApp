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
   public questionnaire: Questionnaire = 
    {
        id: 0,
        author: '',
        topic: '',
        responseAuthor: '',
        dialogs:  new Map<string, string>()  
   }
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        
    }
    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.questionnaire.dialogs);
        return mkeys;
    }
 }
