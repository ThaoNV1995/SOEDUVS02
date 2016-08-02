﻿/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module app.services {

    export class CourseByTeacher {
        Course_ID: string;
        Avatar: string;
        Course_Name: string;
        IsPrice: number;
        IsPriceSale: number;
        IsName: string;
        User_ID: string;
        IsFoto: string;
        IsLevel: string;
        CountTarget: number;
        CountStudent: number;
        IsStar1: number;
        IsStar2: number;
        IsStar3: number;
        IsStar4: number;
        IsStar5: number;
    }

    export interface ICourseByTeacher {
        getListCourseByTeacher(): ng.IPromise<CourseByTeacher[]>;
    }

    class CourseByTeacherService implements ICourseByTeacher {
        static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) {
            
        }
        getListCourseByTeacher(): ng.IPromise<CourseByTeacher[]> {
            return this.$http.post('http://localhost:49401/api/teacher',CourseByTeacher)
                .then((response: ng.IHttpPromiseCallbackArg<CourseByTeacher[]>): CourseByTeacher[] => {
                    return <CourseByTeacher[]>response.data;
                });
        }
    }

    factory.$inject = ['$http'];
    function factory($http: ng.IHttpService): ICourseByTeacher {
        return new CourseByTeacherService($http)
    }

    angular
        .module('app')
        .factory('app.services.CourseByTeacherService', factory);
}