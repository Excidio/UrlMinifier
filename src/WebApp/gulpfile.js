﻿/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp");
var config = require('./gulp.config')();
var $ = require('gulp-load-plugins')({ lazy: true });

gulp.task("clean:js", function (cb) {
    return $.rimraf(config.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    $.rimraf(config.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("copy:angular", function () {

    return gulp.src(config.angular,
        { base: config.node_modules + "@angular/" })
        .pipe(gulp.dest(config.lib + "@angular/"));
});

gulp.task("copy:corejs", function () {
    return gulp.src(config.corejs,
        { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:zonejs", function () {
    return gulp.src(config.zonejs,
        { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:systemjs", function () {
    return gulp.src(config.systemjs,
        { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:rxjs", function () {
    return gulp.src(config.rxjs,
        { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:app", function () {
    return gulp.src(config.app)
        .pipe(gulp.dest(config.appDest));
});

gulp.task("dependencies", ["copy:angular",
    "copy:corejs",
    "copy:zonejs",
    "copy:systemjs",
    "copy:rxjs",
    "copy:app"]);


gulp.task("default", ["clean", "dependencies"]);