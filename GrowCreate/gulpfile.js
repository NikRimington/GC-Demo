var gulp = require("gulp"),
    sass = require("gulp-sass"),
    cleanCSS = require("gulp-clean-css"),
    autoprefixer = require("gulp-autoprefixer"),
    concat = require('gulp-concat'),
    rename = require('gulp-rename'),
    uglify = require('gulp-uglify');


gulp.task("styles", function () {
    gulp.src("Assets/sass/*.scss")
        .pipe(sass().on("error", sass.logError))
        .pipe(cleanCSS({ compatibility: "ie8" }))
        .pipe(autoprefixer({
            browsers: ["last 2 versions", "ie >= 11"],
            cascade: false,
            grid: true
        }))
        .pipe(gulp.dest("Assets/css/"));
});

