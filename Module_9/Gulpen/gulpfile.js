var gulp = require('gulp');
const babel = require('gulp-babel');
var sass = require('gulp-sass');

sass.compiler = require('node-sass');

gulp.task('inmijnsass', function () {
  return gulp.src('./styles/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest('./dist/css'));
});

gulp.task('babel', function() {
    gulp.src('sources/*.js')
        .pipe(babel({
            presets: ['@babel/env']
        }))
        .pipe(gulp.dest('dist'));
    }
);

gulp.task('bla', function(cb){
    console.log('hoi');
    cb();
});

gulp.task('all', ['babel', 'inmijnsass','bla']);