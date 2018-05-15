/// <reference path="Script.js" />

/**
 * @movieTime function
 * @name MovieTime.service:movieListService
 * @description
 * # movieListService
 * retrieves list of movies for movieTimeApp
 */

movieTime.service('movieListService', function ($http) {
    var movies = {};
    movies.retrieveListOfMovies = function () {
        return $http.post('api/MovieService/GetMovieDetails')
    }
    return movies;
})