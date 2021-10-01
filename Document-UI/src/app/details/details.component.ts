import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DocumentService } from '../services/document.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  item:any ;
  constructor(private documentService:DocumentService,private Activeroute:ActivatedRoute,
    private route:Router) { }

  ngOnInit(): void {
    if(this.Activeroute.snapshot.paramMap.get('id') != null){
     const documentId=this.Activeroute.snapshot.paramMap.get('id');
      this.getItem(documentId);
    }
  }
  getItem(id:any){
    this.documentService.getItem(id).subscribe(
      res =>{
        console.log('res', res);
        this.item=res;
      }
    );
}
}
