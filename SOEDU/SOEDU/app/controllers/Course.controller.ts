﻿/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module app.courses {
    import Course = app.services.Course;

    interface ICourseScope {
        addCourse(newCourse: Course): ng.IPromise<Course>;
        getCourseById(courseId: string): ng.IPromise<Course>;
        editCourse();
    }

    class CourseController implements ICourseScope {
      
        courses: Course[];

        static $inject = ['$http', 'app.services.CourseService'];

        constructor(private $http: ng.IHttpService, public courseService: services.ICourse) {
            
            this.getCourseById(GetID());
        }

        getCourseById(courseId: string): ng.IPromise<Course> {
            return this.courseService.getCourseById(courseId)
                .then((data: ng.IHttpPromiseCallbackArg<Course>): any=> {

                });
        }

        addCourse(newCourse: Course): ng.IPromise<Course> {
            return this.courseService.addCourse(newCourse)
                .then((data: ng.IHttpPromiseCallbackArg<Course>): any=> {
                    //this.courses.push(<Course>data);
                  
                });
        }


        
       
        editCourse() {
            alert(12);
        }
    }

    function GetID(): string {
        var id = "";
        var path = window.location.href;
        var result = String(path).split("/");
        if (result != null && result.length > 0) {
            var id = result[result.length - 1];
            return id;
        }
        return id;
    }
    angular
        .module('app')
        .controller('app.course.CourseController', CourseController);
}  