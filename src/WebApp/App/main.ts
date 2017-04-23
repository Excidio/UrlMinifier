import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app.module';

//platformBrowserDynamic().bootstrapModule(AppModule);
platformBrowserDynamic().bootstrapModule(AppModule)
    .catch((err: any) => console.error(err));