import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
import { Questionnaire } from "../Questionnaire";
import { QuestionnaireService } from "../QuestionnaireService";

@Component({
    selector: 'app-questionnairecreate',
    templateUrl: './questionnairecreate.component.html'
 })
 
 export class QuestionnaireCreateComponent
 {    
    public questionnaire: Questionnaire = 
    {
        id: 0,
        author: '',
        topic: '',
        responseAuthor: '',
        dialogs:  new Map<string, string>()  
     }

    public mybaseUrl = 'BASE_URL';
    http: any;
    router: Router;
    
    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string, private routerc: Router)
    {
        this.http = httpc;
        this.mybaseUrl = baseUrl;
        this.router = routerc;
        var resourceUrl = baseUrl+ '/questionnaire';
        var id = document.URL.replace(resourceUrl+'/','');
        var fullurl = resourceUrl + '/' + id;

        // Do not laod questionnaire data, its going to be created here        
    }

    onSubmit():void 
    {
        var newquestionnaire = new QuestionnaireService(this.http, this.mybaseUrl).GetFromDOM(document);
        console.log(newquestionnaire);
        var url = this.mybaseUrl + '/questionnaire';
        var res = new QuestionnaireService(this.http, this.mybaseUrl).Create(newquestionnaire);

        this.router.navigate(['questionnaire', res]);
    }  

    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.questionnaire.dialogs);
        return mkeys;
    }
}
