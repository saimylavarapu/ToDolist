import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAlltasksComponent } from './view-alltasks.component';

describe('ViewAlltasksComponent', () => {
  let component: ViewAlltasksComponent;
  let fixture: ComponentFixture<ViewAlltasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAlltasksComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewAlltasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
