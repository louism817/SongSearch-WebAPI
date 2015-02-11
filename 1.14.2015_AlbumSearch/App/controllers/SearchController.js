searchApp.controller('SearchController', function ($scope, SearchService, $routeParams) {
    $scope.string = SearchService.getString();
    $scope.genres = [];
    $scope.songs = [];
    $scope.newGenre = {};
    $scope.newSong = {};
    $scope.search = {};
    $scope.search.Artist = "";
    $scope.search.Title = "";
    $scope.search.Album = "";
    $scope.search.Genre = "";
    $scope.searchResults = [];
    

    $scope.getGenres = function()
    {
        SearchService.getGenres().then(function (data) {
            $scope.genres = data;
        }, function () { });
    }

    $scope.getGenres();

    $scope.addGenre = function (newGenre)
    {
        SearchService.addGenre(newGenre).then(function () {
           
        }, function (){ });
    }
    
    $scope.getSongs = function () {
        SearchService.getSongs().then(function (data) {
            $scope.songs = data;
        }, function () { });
    }
    $scope.getSongs();

    $scope.addSong = function (newSong) {
        SearchService.addSong(newSong).then(function () {
            $scope.getSongs();
        }, function () { });
    }

    $scope.searchSongs = function (search) {
        SearchService.searchSongs(search).then(function (data) {
            $scope.searchResults = data;
        }, function (status) {
            console.log(status)
        });
    }

    $scope.updateSong = function (song) {
        SearchService.updateSong(song).then(function () {
            $scope.songs = data;
        }, function () { });
    }

    $scope.deleteSong = function (song) {
        SearchService.deleteSong(song).then(function (data) {
            $scope.songs = data;
        }, function () { });
    }
});