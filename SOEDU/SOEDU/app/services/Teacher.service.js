/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var services;
    (function (services) {
        var CourseByTeacher = (function () {
            function CourseByTeacher() {
            }
            return CourseByTeacher;
        })();
        services.CourseByTeacher = CourseByTeacher;
        var CourseByTeacherService = (function () {
            function CourseByTeacherService($http) {
                this.$http = $http;
            }
            CourseByTeacherService.prototype.getListCourseByTeacher = function () {
                return this.$http.post('http://localhost:49401/api/teacher', CourseByTeacher)
                    .then(function (response) {
                    return response.data;
                });
            };
            CourseByTeacherService.$inject = ['$http'];
            return CourseByTeacherService;
        })();
        factory.$inject = ['$http'];
        function factory($http) {
            return new CourseByTeacherService($http);
        }
        angular
            .module('app')
            .factory('app.services.CourseByTeacherService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
//# sourceMappingURL=Teacher.service.js.map