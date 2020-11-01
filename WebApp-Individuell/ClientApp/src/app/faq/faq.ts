import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'router-outlet',
  templateUrl: './faq.html'
})
export class FAQ {
  id: number;
  question: string;
  answer: string;
  category: string;
  thumbs: number;

  visListe: boolean;
  alleFAQs: Array<FAQ>;

  constructor(private _http: HttpClient) { }


  ngOnInit() {
    this.hentAlleFAQs();
    this.visListe = true;
    console.log("Dette funker");
  }

  hentAlleFAQs() {
    this._http.post<FAQ[]>("api/faq/").subscribe(FAQs => {
      this.alleFAQs = FAQs;
      console.log("Funker");
    }, error => console.log(error),
      () => console.log("ferdig get-api/faq")
    );
    console.log("Her fucker det seg");
  };

  giTommelOpp(id: number) {
    this._http.get<FAQ>("api/faq/" + id).subscribe(faq => {
      console.log(this.thumbs);
    },
      error => console.log(error)
    );
    
  }

}
