/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var courses;
    (function (courses) {
        var CourseController = (function () {
            function CourseController($http, courseService) {
                this.$http = $http;
                this.courseService = courseService;
                this.getCourseById(GetID());
            }
            CourseController.prototype.getCourseById = function (courseId) {
                return this.courseService.getCourseById(courseId)
                    .then(function (data) {
                });
            };
            CourseController.prototype.addCourse = function (newCourse) {
                return this.courseService.addCourse(newCourse)
                    .then(function (data) {
                    //this.courses.push(<Course>data);
                });
            };
            CourseController.prototype.editCourse = function () {
                alert(12);
            };
            CourseController.$inject = ['$http', 'app.services.CourseService'];
            return CourseController;
        })();
        function GetID() {
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
    })(courses = app.courses || (app.courses = {}));
})(app || (app = {}));
//# sourceMappingURL=Course.controller.js.map