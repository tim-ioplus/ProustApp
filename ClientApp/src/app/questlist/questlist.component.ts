import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-questlist',
    templateUrl: './questlist.component.html'
 })
 export class QuestListComponent
 {
    public questionnaire: Questionnaire = 
    {
        id: 0,
        author: '',
        topic: '',
        responseAuthor: '',
        dialogs: {}    
     }
    
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        // @Todo replace subscribe with observable
        var fullurl = baseUrl+ 'questlist';
        http.get<Questionnaire>(fullurl).subscribe(result => 
        {            
            this.questionnaire = result;
        }, 
        error => console.error(error));
    }
 }

 interface Questionnaire
 {
    id: number, 
    author: string,
    topic: string,
    responseAuthor: string,
    dialogs: object
 }



