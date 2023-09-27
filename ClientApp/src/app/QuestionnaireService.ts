import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Questionnaire } from './Questionnaire';

@Injectable({
  providedIn: 'root',
})

export class QuestionnaireService {
    private apiUrl = '/api/questionnaires';

    constructor(private http: HttpClient) {}

    //
    // Implement methods for CRUD operations (get, create, update, delete)
    //
    
    
    public Create(questionnaire: Questionnaire): number 
    {
        const q: Questionnaire = {id:0,author:'',topic:'', responseAuthor:'', dialogs: new Map<string, string>()};

        return q.id;
    }

    public Read(id: number): Questionnaire 
    {
        const q: Questionnaire = {id:0,author:'',topic:'', responseAuthor:'', dialogs: new Map<string, string>()};

        return q;
    }

    public Update(questionnaire: Questionnaire): Questionnaire 
    {
        const q: Questionnaire = {id:0,author:'',topic:'', responseAuthor:'', dialogs: new Map<string, string>()};

        return q;
    }

    public Delete(id: number): boolean 
    {
        const q: Questionnaire = {id:0,author:'',topic:'', responseAuthor:'', dialogs: new Map<string, string>()};

        return false;
    }

    public List(): Questionnaire[]  
    {
        const list: Questionnaire[] = [{id:0,author:'',topic:'', responseAuthor:'', dialogs: new Map<string, string>()}];

        return list;
    }

    public ListSurveys(): Map<number, Questionnaire> 
    {
        const q: Questionnaire = {id:0,author:'',topic:'', responseAuthor:'', dialogs: new Map<string, string>()};
        const list: Map<number, Questionnaire> = new Map<number, Questionnaire>();

        return list;
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