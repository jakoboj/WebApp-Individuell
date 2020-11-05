import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { FAQ } from './faq/faq';
import { CAT } from './faq/cat';

@Component({
  selector: 'app-root',
  templateUrl: 'spa.html'
})
export class SPA {
  visListe: boolean;
  alleFAQs: Array<FAQ>;
  alleCATs: Array<CAT>;
  laster: boolean;
  skjema: FormGroup;
  teller: number;

  validering = {
    id: [""],
    spm: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZæøåÆØÅ\\-. ]{2,100}")])    
    ],
    svar: [""],
    kategori: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZæøåÆØÅ\\-. ]{2,100}")])
    ]
  }

  constructor(private _http: HttpClient, private fb: FormBuilder) {
    this.skjema = fb.group(this.validering); 
  }


  ngOnInit() {
    this.laster = true;
    this.hentAlleFAQs();
    this.visListe = true;
    console.log("Dette funker");
  }

  hentAlleFAQs() {
    console.log("Hei");
    this._http.get<FAQ[]>("api/faq/").subscribe(FAQs => {
      this.alleFAQs = FAQs;
      this.laster = false;
    }, error => console.log(error),
      () => console.log("ferdig get-api/faq")
    );
  };

  /*hentCats() {
    console.log("Hei cats")
    this._http.get<CAT[]>("api/faq/").subscribe(CATs => {
      this.alleCATs = CATs;
      console.log(this.alleCATs);
    })
  }*/

  leggTilSpm() {
    const nyttSpm = new FAQ();

    nyttSpm.question = this.skjema.value.spm;
    nyttSpm.answer = this.skjema.value.svar;
    nyttSpm.category = this.skjema.value.kategori;

    console.log(this.skjema.value.kategori);
    console.log(nyttSpm.category);

    this._http.post("api/faq/", nyttSpm).subscribe(retur => {
      this.hentAlleFAQs();
      this.visListe = true;
    },
      error => console.log(error)
    );

  }

  endreTommelOpp(id, question, answer, category, thumbsUp, thumbsDown) {
    const endreRating = new FAQ();
    endreRating.id = id;
    endreRating.question = question;
    endreRating.answer = answer;
    endreRating.category = category;
    endreRating.thumbsUp = thumbsUp + 1;
    endreRating.thumbsDown = thumbsDown;

    this._http.put("api/faq", endreRating).subscribe(retur => {
      this.hentAlleFAQs();
    },
      error => console.log(error)
    );
  }

  endreTommelNed(id, question, answer, category, thumbsUp, thumbsDown) {
    const endreRating = new FAQ();
    endreRating.id = id;
    endreRating.question = question;
    endreRating.answer = answer;
    endreRating.category = category;
    endreRating.thumbsUp = thumbsUp;
    endreRating.thumbsDown = thumbsDown - 1;

    this._http.put("api/faq", endreRating).subscribe(retur => {
      this.hentAlleFAQs();
    },
      error => console.log(error)
    );
  }

}
