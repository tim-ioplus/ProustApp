export interface Questionnaire
 {
    id: number;
    author: string;
    topic: string;
    responseAuthor: string;
    dialogs: Map<string, string>;
 }