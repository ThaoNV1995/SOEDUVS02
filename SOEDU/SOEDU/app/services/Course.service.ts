﻿/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module app.services {

    export class Course {
        Course_ID: string;
        Course_Name: string;
        Avatar: string;
        Video: string;
        Description: string;
        IsPrice: number;
        IsPriceSale: number;
        ViewCount: number;
        CreateDate: string;
        Status: boolean;
        IsOrder: number;
    }

    export interface ICourse {
        addCourse(course: Course): ng.IPromise<Course>;
        getCourseById(courseId: string): ng.IPromise<Course>;
    }

    class CourseService implements ICourse {
        static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) { }
        addCourse(course: Course): ng.IPromise<Course> {
            return this.$http.post('http://localhost:49401/api/Course/CreateCourse', course)
                .then((response: ng.IHttpPromiseCallbackArg<Course>): any=> { 
                    location.href = "/"+response.data + "/cai-dat-khoa-hoc" ;
                    return <Course>response.data;
                });
        }

        getCourseById(courseId: string): ng.IPromise<Course> {
            return this.$http.get('http://localhost:49401/api/values/'+courseId)
                .then((response: ng.IHttpPromiseCallbackArg<Course>): any=> {
                    console.log(response.data);
                });
        }
    }
    factory.$inject = ['$http'];
    function factory($http: ng.IHttpService): ICourse {
        return new CourseService($http);
    }


    angular
        .module('app')
        .factory('app.services.CourseService', factory);
} 