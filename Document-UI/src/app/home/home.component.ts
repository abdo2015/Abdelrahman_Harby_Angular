import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../services/document.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
items: any = [];  
  constructor(private documentService:DocumentService) { }

  ngOnInit(): void {
    this.getAllData();
  }
getAllData() {
  console.log('fdg')
this.documentService.getDocuments().subscribe(
  res => {
    console.log('res' , res);
    this.items = res
  }
);
}
deleteItem(id:string){
  this.documentService.deleteDocuments(id).subscribe(
    res =>{
      console.log('res', res);
      this.items=res.value;
    }
  );
}

}
