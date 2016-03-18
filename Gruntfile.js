module.exports= function(grunt)
{
    grunt.loadNomTasks('grunt-contrib-uglify');
    grunt.loadNomTasks('grunt-contrib-watch');
    
    grunt.initConfig({
        uglify:{
            my_target:{
                files:{'wwwroot/app.js':['Scripts/app.js','Scripts/**/*.js']}
            }
        },
        watch:{
            scripts:{
                files:['Scripts/**/*.js'],
                tasks:['uglify']
            }
        }
    });
    grunt.registerTasj('default',['uglify','watch']);
};