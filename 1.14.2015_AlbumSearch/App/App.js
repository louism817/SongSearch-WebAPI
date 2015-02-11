var searchApp = angular.module('searchApp', ['ngRoute']);

searchApp.config(function ($routeProvider, $httpProvider) {

    $routeProvider
       .when('/', {
           templateUrl: '/App/views/HomeView.html',
           controller: 'SearchController'
       })
       .when('/Home', {
           templateUrl: '/App/views/HomeView.html',
           controller: 'SearchController'
       })
       .when('/editsongs', {
           templateUrl: '/App/views/EditSongsView.html',
           controller: 'SearchController'
       })
       .when('/genres', {
           templateUrl: '/app/views/GenresView.html',
           controller: 'SearchController'
       })
       .otherwise({
           redirectTo: '/'
       });

 //   $httpProvider.interceptors.push('AuthService');



})

 