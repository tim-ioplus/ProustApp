import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
import { Questionnaire } from "../Questionnaire";
import { QuestionnaireService } from "../QuestionnaireService";

@Component({
    selector: 'app-questionnairedetail',
    templateUrl: './questionnairedetail.component.html'
 })
 
 export class QuestionnaireDetailComponent
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

    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        var splits = document.URL.split('/');
        var id = splits[splits.length-1];         
        
        new QuestionnaireService(httpc, baseUrl).Read(id)
        .subscribe(result => 
            {
                console.log('<service')
                console.log(result);
                console.log(JSON.stringify(result));
                this.questionnaire = result;
            }, 
            error => console.error(error));
    }

    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.questionnaire.dialogs);
        console.log(mkeys);
        mkeys.forEach(key => {
            var res = this.questionnaire.dialogs.get(key);
            console.log("key: " + key);
            console.log("res: " + res);
        });
        
        return mkeys;
    }
}