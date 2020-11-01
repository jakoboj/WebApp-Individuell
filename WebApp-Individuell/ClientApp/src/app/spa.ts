import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { FAQ } from './faq/faq';

@Component({
  selector: 'app-root',
  templateUrl: 'spa.html'
})
export class SPA {

  stillSpm: boolean;
  visListe: boolean;
  alleFAQs: Array<FAQ>;
  laster: boolean;
  skjema: FormGroup;

  validering = {
    id: [""],
    spm: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZæøåÆØÅ\\-. ]{2,100}")])    
    ],
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

  vedSubmit() {
    if (this.stillSpm) {
      this.leggTilSpm();
    }
  }

  leggTilSpm() {
    const nyttSpm = new FAQ();

    nyttSpm.question = this.skjema.value.spm;
    nyttSpm.category = this.skjema.value.kategori;

    this._http.post("api/faq/", nyttSpm).subscribe(retur => {
      this.hentAlleFAQs();
      this.stillSpm = false;
      this.visListe = true;
    },
      error => console.log(error)
    )
  }
}
