/// <reference path="script.js" />

/**
 * @movieTime function
 * @name MovieTime.service:movieDetailsService
 * @description
 * # movieDetailsService
 * retrieves details of movies based on title provided for movieTimeApp
 */
movieTime.service('movieDetailsService', function ($http, $stateParams) {
    var fac = {};
    fac.retrieveDetailsOfMovies = function () {
        return $http({
            url: "api/MovieService/GetMovieDetails",
            method: "get",
            params: { title: $stateParams.title }
        })
    }
    return fac;
})