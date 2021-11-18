/// <binding BeforeBuild='clean, copy' AfterBuild='copy' />
module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/js/*", "wwwroot/css/*"],
        copy: {
            js: {
                expand: true,
                cwd: './node_modules',
                dest: './wwwroot/js/libs/',
                flatten: true,
                filter: 'isFile',
                src: [
                    './bootstrap/dist/js/bootstrap.min.js',
                    './jquery/jquery.min.js',
                    './popper.js/dist/umd/popper.min.js'
                ]
            },
            css: {
                expand: true,
                cwd: './node_modules',
                dest: './wwwroot/css/',
                flatten: true,
                filter: 'isFile',
                src: [
                    './bootstrap/dist/css/bootstrap.css',
                    './bootstrap/dist/css/bootstrap-theme.css'
                ]
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.loadNpmTasks("grunt-contrib-clean");
}