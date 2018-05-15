/// <reference path="angular.min.js" />
/**
 * @document overview
 * @name movieTimeApp
 * @description
 * # movieTime
 *
 * Main module of the application.
 */

var movieTime = angular
    .module("movieTime", ["ui.router"])
   .filter('trustUrl', function ($sce) {
       return function (url) {
           return $sce.trustAsResourceUrl(url);
       };
   })
    .config(function ($stateProvider, $urlMatcherFactoryProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/BrowseMovie");
        $urlMatcherFactoryProvider.caseInsensitive(true);
        $stateProvider
        .state({
            name: 'BrowseMovie',
            url: "/BrowseMovie",
            templateUrl: "/Templates/BrowseMovie.html",
            controller: "getMovieList",
        })
        .state({
            name: 'movieDetails',
            url: "/movieDetails/:title?",
            templateUrl: "/Templates/movieDetails.html",
            controller: "getMovieDetails",
            controllerAs: "getMovieDetailsCtrl"
        })
        .state({
            name: 'about',
            url: "/about",
            templateUrl: "/Templates/about.html",
            controller: "getAboutPage"
        })
    }).controller("getMovieList", function ($scope, $http, movieListService) {
        $scope.movieList = null;
        $scope.spinner = true;
        movieListService.retrieveListOfMovies()
            .then(function (response) {
                $scope.movieList = response.data;
            }, function () {
                alert('Failed to retrieve data');
            })
        .finally(function () {
            $scope.spinner = false;
        });
    })
     .controller("getMovieDetails", function ($http, $stateParams, movieDetailsService) {
         var vm = this;
         movieDetailsService.retrieveDetailsOfMovies()
         .then(function (response) {
             vm.movieDetails = response.data;
            
         }, function () {
             alert('Failed to retrieve data');
         });

     })
.controller("getAboutPage", function () { })