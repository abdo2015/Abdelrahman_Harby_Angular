import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DocumentService } from '../services/document.service';
import { DomSanitizer } from "@angular/platform-browser";

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  item:any ;
  PdfUrl :any;
  constructor(private documentService:DocumentService,private Activeroute:ActivatedRoute,
    private route:Router , private sanitizer:DomSanitizer) { }

  ngOnInit(): void {
    if(this.Activeroute.snapshot.paramMap.get('id') != null){
     const documentId=this.Activeroute.snapshot.paramMap.get('id');
      this.getItem(documentId);
    }
  }
  transform(url:any) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
     }
  getItem(id:any){
    this.documentService.getItem(id).subscribe(
      res =>{
        console.log('res', res);
        this.item=res;
        this.PdfUrl="https://localhost:44314/"+res.documentURL;
      }
    );
}
}
