import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Questionnaire } from './Questionnaire';

@Injectable({
  providedIn: 'root',
})

export class QuestionnaireService {
    private resourceUrl = '/questionnaires';
    private httpClient: any;
    private fullUrl=''; 

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string,) {
        this.httpClient = http;
        this.fullUrl = baseUrl + this.resourceUrl;
    }

   
    public Create(questionnaire: Questionnaire): number 
    {
        var id: number = -1;
        var resourceUrl = this.fullUrl;
        this.http.post(resourceUrl, questionnaire)
        .subscribe(
            (result: any) => 
            {
                console.log("Success   " + result);
                id = result[0] != null ? result[0] : '';                            
            }, 
            (error: any) => 
                console.log(error)
        );

        return id;
    }

    public Read(id: string): Questionnaire 
    {
        var questionnaire: Questionnaire = {id:0,author:'',topic:'', responseAuthor:'', dialogs: new Map<string, string>()};
        var resourceUrl = this.fullUrl + '/' + id;

        this.http.get<Questionnaire>(resourceUrl)
        .subscribe(result => 
        {
            questionnaire = result;
        }, 
        error => console.error(error));

        return questionnaire;
    }

    public Update(questionnaire: Questionnaire): boolean 
    {
        var updated: boolean = false;

        this.http.put(this.fullUrl, questionnaire)
        .subscribe(
            (result: any) => 
            {
                console.log("Success   " + result);
                updated = result[0] != null ? result[0] : '';                            
            }, 
            (error: any) => 
                console.log(error)
        );

        return updated;
    }

    public Delete(id: number): boolean 
    {
        var deleted: boolean = false;
        var resourceUrl = this.fullUrl + '/' + id;

        this.http.delete(resourceUrl)
        .subscribe(
            (result: any) => 
            {
                console.log("Success   " + result);
                deleted = result[0] != null ? result[0] : '';                            
            }, 
            (error: any) => 
                console.log(error)
        );

        return deleted;
    }

    // 
    // Filter Questionnaires for View and Data
    // 1. View: a) list, b) details
    // 2. Data: a) unresponsed Questionnaires b) responsed Questionnaires  
    //
    public List(viewfilter: string = '', datafilter: string = ''): Questionnaire[]  
    {
        var questionnaires: Questionnaire[] = [{id:0,author:'',topic:'', responseAuthor:'', dialogs: new Map<string, string>()}];
        var resourceUrl = this.fullUrl + '/' + viewfilter + '/' + datafilter;

        this.http.get<Questionnaire[]>(resourceUrl)
        .subscribe(result => 
        {
            questionnaires = result;
        }, 
        error => console.error(error));

        return questionnaires;
    }

    public GetFromDOM(document: any) : Questionnaire 
    {
        var newquestionnaire: Questionnaire = 
        {
            id: 0,
            author: '',
            topic: '',
            responseAuthor: '',
            dialogs:  new Map<string, string>()
        }
        
        var questionnaireIdElement = <HTMLInputElement> document.getElementsByName('questionnaire-id')[0];
        var questionnaireAuthorElement = <HTMLInputElement> document.getElementsByName('questionnaire-author')[0];
        var questionnaireTopicElement = <HTMLInputElement> document.getElementsByName('questionnaire-topic')[0];
        var questionnaireResponseAuthorElement = <HTMLInputElement> document.getElementsByName('questionnaire-responseauthor')[0];
        
        newquestionnaire.id = parseInt(questionnaireIdElement.value);
        newquestionnaire.author = questionnaireAuthorElement.value;
        newquestionnaire.topic = questionnaireTopicElement.value;
        newquestionnaire.responseAuthor = questionnaireResponseAuthorElement.value;

        var answers = document.getElementsByName('answer-text');
        var questions = document.getElementsByName('question-text');
                   
        for (let index = 0; index < answers.length; index++)
        {
            var answerElement = <HTMLTextAreaElement>answers[index];
            var answerText = answerElement.value;

            var questionElement = <HTMLTextAreaElement>questions[index];
            var questionText = questionElement.value;

            newquestionnaire.dialogs.set(questionText, answerText);
        }

        newquestionnaire.dialogs.get

        return newquestionnaire;
    }
}