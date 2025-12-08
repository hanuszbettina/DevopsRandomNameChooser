import { Component } from '@angular/core';
import { NameService } from '../name.service';
import { Name } from '../name';
import { NameCreateDto } from '../name-create-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  standalone: false,
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent {
  randomName?: Name;
  actual: NameCreateDto = new NameCreateDto();
  constructor(public service: NameService, private router: Router) { }
  generateRandom() {
    this.service.random().subscribe(name => {
      this.randomName = name;
    });
  }
  create(){
    this.service.create(this.actual).subscribe(t => {
      this.actual = new NameCreateDto();
      this.router.navigate(['list']);
    })
  }
}
