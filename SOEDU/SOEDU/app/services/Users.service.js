/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        ;
        var Beer = (function () {
            function Beer() {
            }
            return Beer;
        })();
        services.Beer = Beer;
        var BeerService = (function () {
            function BeerService($http) {
                this.$http = $http;
            }
            BeerService.prototype.getBeers = function () {
                return this.$http.get('http://localhost:3192/api/Beer')
                    .then(function (response) {
                    return response.data;
                });
            };
            BeerService.prototype.addBeer = function (beer) {
                //var xhr = new XMLHttpRequest();
                //xhr.withCredentials = true;
                //console.log(xhr);
                return this.$http.post('http://localhost:3192/api/Beer', beer)
                    .then(function (response) {
                    return response.data;
                });
            };
            BeerService.$inject = ['$http'];
            return BeerService;
        })();
        factory.$inject = ['$http'];
        function factory($http) {
            return new BeerService($http);
        }
        angular
            .module('app')
            .factory('app.services.BeerService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
//# sourceMappingURL=Users.service.js.map