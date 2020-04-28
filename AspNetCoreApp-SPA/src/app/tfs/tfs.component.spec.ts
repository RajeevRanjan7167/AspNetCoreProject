/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TfsComponent } from './tfs.component';

describe('TfsComponent', () => {
  let component: TfsComponent;
  let fixture: ComponentFixture<TfsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TfsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TfsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
