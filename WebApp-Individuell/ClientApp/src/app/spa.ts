import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { FAQ } from './faq/faq';

@Component({
  selector: 'app-root',
  templateUrl: 'spa.html'
})
export class SPA {

  // Variabler
  alleFAQs: Array<FAQ>;
  skjema: FormGroup;
  generellSpm: boolean;
  avgangSpm: boolean;
  stasjonSpm: boolean;
  bestillingSpm: boolean;
  ubesvartSpm: boolean;
  stilleSpm: boolean;
  clicked: boolean;

  // Validering
  validering = {
    spm: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZæøåÆØÅ\\-.?@ ]{10,500}")])    
    ]
    
  }

  constructor(private _http: HttpClient, private fb: FormBuilder) {
    this.skjema = fb.group(this.validering); 
  }

  // Når komponenten kalles
  ngOnInit() {
    this.hentAlleFAQs();
    this.generellSpm = false;
    this.avgangSpm = false;
    this.stasjonSpm = false;
    this.bestillingSpm = false;
    this.ubesvartSpm = false;
    this.stilleSpm = false;
    this.clicked = false;
  }

  // Henter alle FAQs
  hentAlleFAQs() {
    console.log("Hei");
    this._http.get<FAQ[]>("api/faq/").subscribe(FAQs => {
      this.alleFAQs = FAQs;
    }, error => console.log(error),
      () => console.log("ferdig get-api/faq")
    );
  };

  clearInput() {
    this.skjema.setValue({
      spm: ""
    });
    this.skjema.markAsPristine();
  }

  // Legger til spørsmål i db og omdirigerer deg til 'ubesvarte spørsmål'-siden
  leggTilSpm() {
    const nyttSpm = new FAQ();
    nyttSpm.question = this.skjema.value.spm;
    nyttSpm.answer = this.skjema.value.svar;
    nyttSpm.cid = 5;
    nyttSpm.thumbsUp = 0;
    nyttSpm.thumbsDown = 0;

    this._http.post("api/faq", nyttSpm).subscribe(retur => {
      this.hentAlleFAQs();
    },
      error => console.log(error)
    );

    this.stilleSpm = false;
    this.ubesvartSpm = true;
  }

  // Endrer db når 'tommel opp' trykkes
  endreTommelOpp(id, question, answer, cid, category, thumbsUp, thumbsDown) {
    const endreRating = new FAQ();
    endreRating.id = id;
    endreRating.question = question;
    endreRating.answer = answer;
    endreRating.cid = cid;
    endreRating.category = category;
    endreRating.thumbsUp = thumbsUp + 1;
    endreRating.thumbsDown = thumbsDown;

    console.log(endreRating.thumbsUp);
    this._http.put("api/faq", endreRating).subscribe(retur => {
      this.hentAlleFAQs();
    },
      error => console.log(error)
    );

    this.clicked = true;
  }

  // Endrer db når 'tommel ned' trykkes
  endreTommelNed(id, question, answer, cid, category, thumbsUp, thumbsDown) {
    const endreRating = new FAQ();
    endreRating.id = id;
    endreRating.question = question;
    endreRating.answer = answer;
    endreRating.cid = cid;
    endreRating.category = category;
    endreRating.thumbsUp = thumbsUp;
    endreRating.thumbsDown = thumbsDown - 1;

    this._http.put("api/faq", endreRating).subscribe(retur => {
      this.hentAlleFAQs();
    },
      error => console.log(error)
    );

    this.clicked = true;
  }
}
