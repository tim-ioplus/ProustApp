import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Quest } from './Quest';

@Injectable({
  providedIn: 'root',
})

export class QuestService 
{
    private resourceFragment = 'api/quest';
    private httpClient: HttpClient;
    private fullUrl=''; 

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.fullUrl = baseUrl + this.resourceFragment;
    }

   
    public Create(questionnaire: Quest): Observable<number> 
    {
        return this.httpClient.post<number>(this.fullUrl, questionnaire);
    }

    public Read(id: string): Observable<Quest> 
    {
        var resourceUrl = this.fullUrl + '/' + id;
        console.log("Read quest " + resourceUrl);
        return this.httpClient.get<Quest>(resourceUrl);
    }

    public Update(questionnaire: Quest): Observable<boolean> 
    {
        return this.httpClient.put<boolean>(this.fullUrl, questionnaire);
    }

    public Delete(id: number): Observable<boolean> 
    {
        var resourceUrl = this.fullUrl + '/' + id;
        return this.httpClient.delete<boolean>(resourceUrl);
    }

    // 
    // Gets List-View of Questionnaires 
    // 1. 'choose' empty Questionnaires 
    // 2. 'read' filled out Questionnaires  
    // 
    public List(datafilter: string = ''): Observable<Quest[]>  
    {
        return this.httpClient.get<Quest[]>(this.fullUrl + '/list/' + datafilter);
    }

    public ListToFill()
    {
        return this.List("fill");
    }

    public ListToRead()
    {
        return this.List("read");
    }

    //
    //
    //
    GetFromDOM(document: any) : Observable<Quest> 
    {
        return new Observable<Quest>((observer) => {          
            var questionnaireIdElement = <HTMLInputElement> document.getElementsByName('questionnaire-id')[0];
            var questionnaireAuthorElement = <HTMLInputElement> document.getElementsByName('questionnaire-author')[0];
            var questionnaireTopicElement = <HTMLInputElement> document.getElementsByName('questionnaire-topic')[0];
            var questionnaireResponseAuthorElement = <HTMLInputElement> document.getElementsByName('questionnaire-responseauthor')[0];

            var newquestionnaire: Quest = 
            {
                id: parseInt(questionnaireIdElement.value),
                author: questionnaireAuthorElement.value,
                topic: questionnaireTopicElement.value,
                responseAuthor: questionnaireResponseAuthorElement.value,
                dialogs:  new Map<string, string>()
            }

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

            observer.next(newquestionnaire);

            observer.complete();
        });        
    }
}