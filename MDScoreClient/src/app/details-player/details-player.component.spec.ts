import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsPlayerComponent } from './details-player.component';

describe('DetailsPlayerComponent', () => {
  let component: DetailsPlayerComponent;
  let fixture: ComponentFixture<DetailsPlayerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsPlayerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsPlayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
