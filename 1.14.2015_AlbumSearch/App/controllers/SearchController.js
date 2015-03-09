searchApp.controller('SearchController', function ($scope, $filter, ngTableParams, SearchService, $routeParams) {
    $scope.string = SearchService.getString();
    $scope.genres = [];
    $scope.allSongs = [];
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
            $scope.getGenres(); // need to call since we won't have id of new song
            $scope.newGenre = {};
        }, function (){ });
    }
    
    $scope.getSongs = function () {
        SearchService.getSongs().then(function (data) {
            $scope.allSongs = data;
 
            $scope.tableParams = new ngTableParams({
                page: 1,            // show first page        
                count: 5,           // count per page   
                sorting: {
                    Title: 'asc'     // initial sorting
                }
            }, {
                total: $scope.allSongs.length, // number of songs
                counts: [5, 10, 25],
                
                getData: function ($defer, params) {
                    var orderedSongs = $filter('orderBy')($scope.allSongs, params.orderBy());
                    $scope.songs = orderedSongs.slice((params.page() - 1) * params.count(), params.page() * params.count());

                    $defer.resolve($scope.songs);
                }

             });
 
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
        SearchService.updateSong(song).then(function (data) {
        }, function () { });
    }

    $scope.deleteSong = function (song) {
        SearchService.deleteSong(song).then(function (data) {
            $scope.songs = data;
        }, function () { });
    }

    $scope.deleteGenre = function (genre) {
        SearchService.deleteGenre(genre).then(function (data) {
            $scope.genres = data;
        }, function () { });
    }

    $scope.updateGenre = function (genre) {
        SearchService.updateGenre(genre).then(function (data) {
            $scope.genres = data;
        }, function () { });
    }
});