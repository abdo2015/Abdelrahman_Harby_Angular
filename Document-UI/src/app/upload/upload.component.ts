import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, NgForm, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { DocumentService } from '../services/document.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  myForm = new FormGroup({
    description: new FormControl('', [Validators.required]),
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });
  
  get f(){
    return this.myForm.controls;
  }
  constructor(private documentService:DocumentService ,private http: HttpClient
    ,private _router:Router) { }

  ngOnInit(): void {
  }
  onFileChange(event:any) {
  
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.myForm.patchValue({
        fileSource: file
      });
    }
  }
  submit(){
    const formData = new FormData();
    if(this.myForm.valid){
      formData.append('file', this.myForm.get('fileSource')?.value);
      formData.append('description', this.myForm.controls.description.value);
  
      console.log(this.myForm.controls.description.value);
      this.documentService.UploadFile(formData).subscribe(
        res =>{
          console.log('res', res);
          alert('Uploaded Successfully.');
          this._router.navigateByUrl('/home');
        }
      );
    } else{
        alert('feilds are required');
    }

   
  }
  
}
