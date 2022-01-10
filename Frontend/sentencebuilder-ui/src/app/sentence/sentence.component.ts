import {AfterViewInit, Component, OnInit} from '@angular/core';
import {RepositoryService} from '../shared/repository.service';
import {WordTypeModel} from './_model/wordType.model';
import {WordModel} from './_model/word.model';
// import { Observable } from 'rxjs';
// import 'rxjs/add/operator/map';

@Component({
    selector: 'app-sentence',
    templateUrl: './sentence.component.html',
    styleUrls: ['./sentence.component.css']
})

export class SentenceComponent implements OnInit, AfterViewInit  {
    public wordTypes : Array<WordTypeModel> = [];
    public words : Array<WordModel> = [];
    public sentence = '';
    public saveSentenceFeedBack = '';

    constructor(private repoService: RepositoryService) { }

    ngOnInit(): void {
        this.getWordTypes();
    }

    ngAfterViewInit(){
        setTimeout( ()=> {
            this.saveSentenceFeedBack = ''
        }, 10000)
      }
     

    public wordTypeDropDownClick = (wordTypeDropDownValue: number) => {
        this.getWords(wordTypeDropDownValue);
    }

    public wordDropDownClick = (word: string) => {
        this.sentence += ` ${word}`;
    }

    public removeLastWord = () => {
        if(this.sentence !== ""){
            var lastIndex = this.sentence.lastIndexOf(" ");
            this.sentence = this.sentence.substring(0, lastIndex);
        }
    }

    public AddSentence = () => {
        this.saveSentence(this.sentence);

    }

    private getWordTypes = () => {
        this.repoService.getData(`wordtype`).subscribe( response => {            
            this.wordTypes = response as WordTypeModel[];
        },
        error => {
            //Todo: use toast msg
            console.log('error :', error);
        });
    }

    private getWords = (wordTypesId:number) => {
        this.repoService.getData(`word/get/${wordTypesId}`).subscribe( response => {
            this.words = response as WordModel[];
        },
        error => {
            //Todo: use toast msg
            console.log('error :', error);
        });
    }

    private saveSentence = (sentence: string) => {
        this.repoService.create(`sentence/add`, {text:sentence}).subscribe(response => {
            if(response == 1){                
                this.saveSentenceFeedBack = 'Saved sentence successfully!';
            }
        },
        error => {
            //Todo: use toast msg
            console.log('error :', error);
        });
    }
}