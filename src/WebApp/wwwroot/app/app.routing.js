"use strict";
var router_1 = require("@angular/router");
var index_component_1 = require("./index.component");
var history_component_1 = require("./history.component");
var appRoutes = [
    { path: '', redirectTo: 'main-page', pathMatch: 'full' },
    { path: 'main-page', component: index_component_1.IndexComponent, data: { title: 'Home' } },
    { path: 'history-page', component: history_component_1.HistoryComponent, data: { title: 'History' } }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
exports.routedComponents = [index_component_1.IndexComponent, history_component_1.HistoryComponent];
//# sourceMappingURL=app.routing.js.map