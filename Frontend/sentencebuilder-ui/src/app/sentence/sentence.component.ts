import {Component, OnInit} from '@angular/core';
import {RepositoryService} from '../shared/repository.service';
import {WordTypeModel} from './_model/wordType.model';
import {WordModel} from './_model/word.model';

@Component({
    selector: 'app-sentence',
    templateUrl: './sentence.component.html',
    styleUrls: ['./sentence.component.css']
})

export class SentenceComponent implements OnInit {
    private wordTypes : Array<WordTypeModel> = [];
    private word : Array<WordModel> = [];
    private sentence : Array<WordModel> = [];
    private obj : Array<any> = [];

    constructor(private repoService: RepositoryService) { }

    ngOnInit(): void {
        this.getWordTypes();
    }

    private getWordTypes = () => {
        this.repoService.getData(`wordtype`).subscribe( response =>{
            // this.wordTypes.push(response as WordTypeModel);
            this.obj.push(response);
            console.log('wordTypes :', this.wordTypes);
        },
        error => {
            console.log('error :', error);
        });
    }
}