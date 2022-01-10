import {Component, OnInit, ViewChild} from '@angular/core';
import {RepositoryService} from '../shared/repository.service';
import {WordTypeModel} from './_model/wordType.model';
import {WordModel} from './_model/word.model';
import { SentenceModel } from './_model/sentence.model';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
    selector: 'app-sentence',
    templateUrl: './sentence.component.html',
    styleUrls: ['./sentence.component.css']
})

export class SentenceComponent implements OnInit  {
    public wordTypes : Array<WordTypeModel> = [];
    public words : Array<WordModel> = [];
    public sentence = '';
    public feedBackMessage = '';
    public showSentenceList = true;
    public showCreateSentence = false;
    public dataSource = new MatTableDataSource<SentenceModel>();
    public displayedColumns = ['text', 'recordDate'];

    @ViewChild(MatTable) table: MatTable<SentenceModel>;
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    constructor(private repoService: RepositoryService) { }

    ngOnInit(): void {
        this.getWordTypes();
        this.getSentences();
    } 

    public ngAfterViewInit(): void {
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }

    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
      }

    public wordTypeDropDownClick = (wordTypeDropDownValue: number) => {
        this.getWords(wordTypeDropDownValue);
    }

    public wordDropDownClick = (word: string) => {
        this.sentence += ` ${word}`;
    }

    public clearSentenceTextBox = () => {
        if(this.sentence !== ''){
            this.sentence = '';
        }
    }

    public changeCurrentDisplayPage = (showSentenceList:boolean, showCreateSentence: boolean) => {
        this.showSentenceList = showSentenceList;
        this.showCreateSentence = showCreateSentence;
        this.getSentences();

    }

    public removeLastWord = () => {
        if(this.sentence !== ""){
            var lastIndex = this.sentence.lastIndexOf(" ");
            this.sentence = this.sentence.substring(0, lastIndex);
        }
    }

    public AddSentence = () => {
        if(this.sentence !== ''){
            this.saveSentence(this.sentence);
            this.removeFeedBackMessageFromPage();
        }        
    }

    private getWordTypes = () => {
        this.repoService.getData(`wordtype`).subscribe( response => {            
            this.wordTypes = response as WordTypeModel[];
        },
        error => {
            this.feedBackMessage = `Failed to load Word Types. ${error.message}`;
            this.removeFeedBackMessageFromPage();
        });
    }

    private getWords = (wordTypesId:number) => {
        this.repoService.getData(`word/get/${wordTypesId}`).subscribe( response => {
            this.words = response as WordModel[];
        },
        error => {
            this.feedBackMessage = `Failed to load Words. ${error.message}`;
            this.removeFeedBackMessageFromPage();
        });
    }

    private getSentences = () => {
        this.repoService.getData("sentence").subscribe( response => {
            this.dataSource.data = response as SentenceModel[];
          });
    }

    private saveSentence = (sentence: string) => {
        this.repoService.create(`sentence/add`, {text:sentence}).subscribe(response => {
            console.log('executed add sentence')
            if(response == 1){                
                this.feedBackMessage = 'Saved sentence successfully!';
            }
        },
        error => {
            this.feedBackMessage = `Failed to save sentence. ${error.message}`;
            this.removeFeedBackMessageFromPage();
        });
    }

    private removeFeedBackMessageFromPage = () => {
        setTimeout( ()=> {
            this.feedBackMessage = ''
        }, 6000)
    }
}