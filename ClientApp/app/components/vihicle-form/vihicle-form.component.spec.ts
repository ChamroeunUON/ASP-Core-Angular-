import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VihicleFormComponent } from './vihicle-form.component';

describe('VihicleFormComponent', () => {
  let component: VihicleFormComponent;
  let fixture: ComponentFixture<VihicleFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VihicleFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VihicleFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
