module.exports = function () {

    var base = {
        webroot: "./wwwroot/",
        node_modules: "./node_modules/"
    };

    var config = {
        /**
         * Files paths
         */
        angular: base.node_modules + "@angular/**/*.js",
        app: "App/**/*.*",
        appDest: base.webroot + "app",
        js: base.webroot + "js/**/*.js",
        css: base.webroot + "css/**/*.css",
        lib: base.webroot + "lib/",
        node_modules: base.node_modules,
        corejs: base.node_modules + "core-js/client/shim*.js",
        zonejs: base.node_modules + "zone.js/dist/zone*.js",
        systemjs: base.node_modules + "systemjs/dist/*.js",
        rxjs: base.node_modules + "rxjs/**/*.js",
    };

    return config;
};