import { Routes, RouterModule } from '@angular/router';

import { IndexComponent } from './index.component';
import { HistoryComponent } from './history.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: IndexComponent, data: { title: 'Home' } },
    { path: 'history', component: HistoryComponent, data: { title: 'History' } }
];

export const routing = RouterModule.forRoot(appRoutes);

export const routedComponents = [IndexComponent, HistoryComponent ];