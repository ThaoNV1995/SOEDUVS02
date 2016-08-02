﻿/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module app.services {
    'use strict';

    export interface IBeersService {
        getBeers(): ng.IPromise<Beer[]>;
        addBeer(beer: Beer): ng.IPromise<Beer>;
    };

    export class Beer {
        id: number;
        name: string;
        colour: string;
        hasTried: Boolean;
    }

    class BeerService implements IBeersService {
        static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) { }

        getBeers(): ng.IPromise<Beer[]> {
            return this.$http.get('http://localhost:3192/api/Beer')
                .then((response: ng.IHttpPromiseCallbackArg<Beer[]>): Beer[]=> {
                    return <Beer[]>response.data;
                });
        }

        addBeer(beer: Beer): ng.IPromise<Beer> {
            //var xhr = new XMLHttpRequest();
            //xhr.withCredentials = true;
            //console.log(xhr);
            return this.$http.post('http://localhost:3192/api/Beer', beer)
                .then((response: ng.IHttpPromiseCallbackArg<Beer>): any => {
                    return <Beer>response.data;
                });
        }
    }

    factory.$inject = ['$http'];
    function factory($http: ng.IHttpService): IBeersService {
        return new BeerService($http);
    }

    angular
        .module('app')
        .factory('app.services.BeerService', factory);

}


  