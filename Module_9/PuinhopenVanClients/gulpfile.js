
var gulp = require("gulp");
var less = require("gulp-less");
var sass = require("gulp-sass");

var files = { root: "./wwwroot/" };
files.sass = "./Styles/*.scss";
files.less = "./Styles/*.less";

gulp.task("sass", function () {
    return gulp.src(files.sass).pipe(sass()).pipe(gulp.dest(files.root));
});
//gulp.task("less", function () {
//    return gulp.src(files.less).pipe(less()).pipe(gulp.dest(files.root));
//});


