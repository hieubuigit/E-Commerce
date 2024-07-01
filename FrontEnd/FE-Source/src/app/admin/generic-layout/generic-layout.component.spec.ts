import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericLayoutComponent } from './generic-layout.component';

describe('GenericLayoutComponent', () => {
  let component: GenericLayoutComponent;
  let fixture: ComponentFixture<GenericLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenericLayoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GenericLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
