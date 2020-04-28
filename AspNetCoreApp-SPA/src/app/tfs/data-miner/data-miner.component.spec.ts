/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DataMinerComponent } from './data-miner.component';

describe('DataMinerComponent', () => {
  let component: DataMinerComponent;
  let fixture: ComponentFixture<DataMinerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataMinerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataMinerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
