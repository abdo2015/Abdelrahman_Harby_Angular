import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  
//baseUrl = "https://localhost:5001/";
baseUrl = "https://localhost:44314/";    //using IIS


UploadFileUrl = this.baseUrl + "api/Document";
  constructor(private http: HttpClient) {
  }

 UploadFile(model: any): Observable<any> {
   return this.http.post<any>(this.UploadFileUrl , model);
   
 }
 getDocuments(): Observable<any> {
  return this.http.get<any>(this.UploadFileUrl );
}
deleteDocuments(id:string): Observable<any> {
  return this.http.delete<any>(this.UploadFileUrl + '/' +id);
}
getItem(id:string): Observable<any> {
  return this.http.get<any>(this.UploadFileUrl + '/' +id);
}
}