import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TostyTestComponent } from './tosty-test.component';

describe('TostyTestComponent', () => {
  let component: TostyTestComponent;
  let fixture: ComponentFixture<TostyTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TostyTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TostyTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
