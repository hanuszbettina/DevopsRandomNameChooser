import { Injectable } from '@angular/core';
import { Name } from './name';
import { map, Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { NameCreateDto } from './name-create-dto';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class NameService {

  names: Observable<Name[]>;
  constructor(private http: HttpClient, private configService: ConfigService) {
    this.names = http.get<Name[]>(this.configService.cfg.backendUrl + '/name');
  }

  delete(id: string){
    return this.http.delete(this.configService.cfg.backendUrl + '/name/' + id).pipe(tap(t => {
      this.names = this.http.get<Name[]>(this.configService.cfg.backendUrl + '/name');
    }));
  }

  create(t: NameCreateDto){
    return this.http.post<Name>(this.configService.cfg.backendUrl + '/name', t).pipe(tap(t => {
      this.names = this.http.get<Name[]>(this.configService.cfg.backendUrl + '/name');
    }));
  }
  random(): Observable<Name> {
    return this.names.pipe(
      map(namesArray => {
        if (!namesArray || namesArray.length === 0) {
          throw new Error('Nincs elérhető név.');
        }
        const randIndex = Math.floor(Math.random() * namesArray.length);
        return namesArray[randIndex];
      })
    );
  }
  
}
