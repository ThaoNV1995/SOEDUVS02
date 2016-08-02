﻿/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module app.CourseByTeacher {

    import CourseByTeacher = app.services.CourseByTeacher;

    interface ICourseByTeacheaScope {
        getListCourseByTeacher(): ng.IPromise<CourseByTeacher[]>;
    }

    class CourseByTeacherController implements ICourseByTeacheaScope {

        Course: CourseByTeacher[];
        static $inject = ['$http', 'app.services.CourseByTeacherService'];
        constructor(private $http: ng.IHttpService, public CourseByTeacherService: services.ICourseByTeacher) {
            this.getListCourseByTeacher();

        }

        getListCourseByTeacher(): ng.IPromise<CourseByTeacher[]> {
            return this.CourseByTeacherService.getListCourseByTeacher()
                .then((data: ng.IHttpPromiseCallbackArg<CourseByTeacher[]>): any => {

                    return this.Course = <CourseByTeacher[]>data;
                });
        }
    }

    function myDirective(): ng.IDirective {
        
        return {
            restrict: 'A',
            replace: true,
            controller: CourseByTeacherController,
            link: (scope: any, element: ng.IAugmentedJQuery, attributes: ng.IAttributes, controller: ICourseByTeacheaScope): void => {
               
                let url = controller.getListCourseByTeacher();
                url.then((data: ng.IHttpPromiseCallbackArg<CourseByTeacher[]>): any => {
                    scope.Course=<CourseByTeacher[]>data;
                    //element.text((<CourseByTeacher[]>data)[0].Course_Name.toString());
                });
                console.log(scope);
                scope.initCarousel = function (element) {
                    console.log(element);
                    // provide any default options you want
                    var defaultOptions = {
                        
                    };
                    var customOptions = scope.$eval($(element).attr('data-options'));
                    // combine the two options objects
                    for (var key in customOptions) {
                        defaultOptions[key] = customOptions[key];
                    }
                    // init carousel
                    element.owlCarousel({
                        autoPlay: false,
                        items: 4,
                        itemsDesktop: [1199, 4],
                        itemsDesktopSmall: [991, 3],
                        itemsTablet: [767, 2],
                        itemsMobile: [480, 1],
                        slideSpeed: 3000,
                        paginationSpeed: 3000,
                        rewindSpeed: 3000,
                        navigation: true,
                        stopOnHover: true,
                        pagination: false,
                        scrollPerPage: true,
                    });
                };
                
            }
        };
    }

    function myDirectiveChild(): ng.IDirective {

        return {
            restrict: 'A',
            replace: true,
            controller: CourseByTeacherController,
            link: (scope: any, element: ng.IAugmentedJQuery, attributes: ng.IAttributes, controller: ICourseByTeacheaScope): void => {
                console.log(element.parent());
                if (scope.$last) {
                    scope.initCarousel(element.parent());
                }
            }
        };
    }
    angular
        .module('app')
        .directive('owlCarousel', myDirective).directive('owlCarouselItem', myDirectiveChild);
}