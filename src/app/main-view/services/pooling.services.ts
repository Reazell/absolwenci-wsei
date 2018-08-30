import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../app.config';

@Injectable()
export class PoolingService {
  controlArray: string[];
  constructor(private http: HttpClient, private config: AppConfig) {}

  sendPooling(pooling) {
    return this.http
      .post<any>(this.config.apiUrl + '/email', {
        Subject: 'testowe wysyłanie',
        Body: pooling
      })
      .map(data => {
        return data;
      });
  }
}
