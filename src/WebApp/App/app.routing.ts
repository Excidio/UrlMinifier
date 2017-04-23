import { Routes, RouterModule } from '@angular/router';

import { IndexComponent } from './index.component';
import { HistoryComponent } from './history.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'main-page', pathMatch: 'full' },
    { path: 'main-page', component: IndexComponent, data: { title: 'Home' } },
    { path: 'history-page', component: HistoryComponent, data: { title: 'History' } }
];

export const routing = RouterModule.forRoot(appRoutes);

export const routedComponents = [IndexComponent, HistoryComponent ];