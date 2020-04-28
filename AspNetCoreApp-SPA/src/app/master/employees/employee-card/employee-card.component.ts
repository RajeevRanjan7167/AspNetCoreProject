import { Component, OnInit, Input } from '@angular/core';
import { Resources } from '../../../_modeles/Resources';

@Component({
  selector: 'app-employee-card',
  templateUrl: './employee-card.component.html',
  styleUrls: ['./employee-card.component.css']
})
export class EmployeeCardComponent implements OnInit {
  @Input() resource: Resources;

  constructor() { }

  ngOnInit() {
  }

}
