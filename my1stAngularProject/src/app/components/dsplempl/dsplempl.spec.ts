import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dsplempl } from './dsplempl';

describe('Dsplempl', () => {
  let component: Dsplempl;
  let fixture: ComponentFixture<Dsplempl>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Dsplempl]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Dsplempl);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
