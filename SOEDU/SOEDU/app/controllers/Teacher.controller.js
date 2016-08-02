/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var CourseByTeacher;
    (function (CourseByTeacher_1) {
        var CourseByTeacherController = (function () {
            function CourseByTeacherController($http, CourseByTeacherService) {
                this.$http = $http;
                this.CourseByTeacherService = CourseByTeacherService;
                this.getListCourseByTeacher();
            }
            CourseByTeacherController.prototype.getListCourseByTeacher = function () {
                var _this = this;
                return this.CourseByTeacherService.getListCourseByTeacher()
                    .then(function (data) {
                    return _this.Course = data;
                });
            };
            CourseByTeacherController.$inject = ['$http', 'app.services.CourseByTeacherService'];
            return CourseByTeacherController;
        })();
        function myDirective() {
            return {
                restrict: 'A',
                replace: true,
                controller: CourseByTeacherController,
                link: function (scope, element, attributes, controller) {
                    var url = controller.getListCourseByTeacher();
                    url.then(function (data) {
                        scope.Course = data;
                        //element.text((<CourseByTeacher[]>data)[0].Course_Name.toString());
                    });
                    console.log(scope);
                    scope.initCarousel = function (element) {
                        console.log(element);
                        // provide any default options you want
                        var defaultOptions = {};
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
        function myDirectiveChild() {
            return {
                restrict: 'A',
                replace: true,
                controller: CourseByTeacherController,
                link: function (scope, element, attributes, controller) {
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
    })(CourseByTeacher = app.CourseByTeacher || (app.CourseByTeacher = {}));
})(app || (app = {}));
//# sourceMappingURL=Teacher.controller.js.map