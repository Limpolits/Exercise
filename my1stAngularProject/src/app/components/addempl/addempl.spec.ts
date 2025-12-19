import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Addempl } from './addempl';

describe('Addempl', () => {
  let component: Addempl;
  let fixture: ComponentFixture<Addempl>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Addempl]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Addempl);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
