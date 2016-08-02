/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var services;
    (function (services) {
        var Course = (function () {
            function Course() {
            }
            return Course;
        })();
        services.Course = Course;
        var CourseService = (function () {
            function CourseService($http) {
                this.$http = $http;
            }
            CourseService.prototype.addCourse = function (course) {
                return this.$http.post('http://localhost:49401/api/Course/CreateCourse', course)
                    .then(function (response) {
                    location.href = "/" + response.data + "/cai-dat-khoa-hoc";
                    return response.data;
                });
            };
            CourseService.prototype.getCourseById = function (courseId) {
                return this.$http.get('http://localhost:49401/api/values/' + courseId)
                    .then(function (response) {
                    console.log(response.data);
                });
            };
            CourseService.$inject = ['$http'];
            return CourseService;
        })();
        factory.$inject = ['$http'];
        function factory($http) {
            return new CourseService($http);
        }
        angular
            .module('app')
            .factory('app.services.CourseService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
//# sourceMappingURL=Course.service.js.map