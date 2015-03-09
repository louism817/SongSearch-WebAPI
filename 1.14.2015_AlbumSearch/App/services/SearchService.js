
//http://www.last.fm/api/show/album.getInfo look at to get album art

searchApp.factory('SearchService', function ($http, $q) {
    var genres = [];
    var songs = [];
    var searchedSongs = [];
    var getString = function()
    {
        return "dog";
    }

    var findSong = function (id)
    {
        var song = null;
        for (var i = 0; i < songs.length; i++)
        {
            song = songs[i];
            if (song.SongId = id) {
                return song;
            }
        }
    }

    var removeSong = function (song) {        
        var i = songs.indexOf(song);
        if (i >= 0) {
            songs.splice(i, 1);
        }           
    }

    var replaceSong = function(song)
    {
        var i = findSong(song.SongId);
        songs[i] = song;
    }

    var findGenre = function (id) {
        var song = null;
        for (var i = 0; i < genres.length; i++) {
            genre = genres[i];
            if (genre.GenreId = id) {
                return genre;
            }
        }
    }
    var removeGenre = function (genre) {
        var i = genres.indexOf(genre);
        if (i >= 0) {
            genres.splice(i, 1);
        }
    }

    var replaceGenre = function (genre) {
        var i = findGenre(genre.GenreId);
        genres[i] = genre;
    }

    var getGenres = function ()
    {
        var deferred = $q.defer();
        $http.get("/api/Genre").success(function (data) {
            genres.length = 0;
            for (var g in data) {
                genres.push(data[g])
            }
            deferred.resolve(genres);
        }).error(function (data, status) {

            deferred.reject();
        })
        return deferred.promise;
    }

    var addGenre = function (genre) {
        var deferred = $q.defer();
        $http.post("/api/Genre", genre).success(function (data) {
            // genres.push(genre) nice try but genre won't have id and causes problems if edited/removed before a reload
 
            deferred.resolve();
        }).error(function (data, status) {

            deferred.reject();
        })
        return deferred.promise;
    }

    var deleteGenre = function (genre) {
        var deferred = $q.defer();
        $http.delete("/api/Genre/"+genre.GenreId).success(function (data) {
            removeGenre(genre);

            deferred.resolve(genres);
        }).error(function (data, status) {

            deferred.reject();
        })
        return deferred.promise;
    }

    var updateGenre = function (genre) {
        var deferred = $q.defer();
        $http.put("/api/Genre", genre).success(function (data) {
            replaceGenre(genre);

            deferred.resolve(genres);
        }).error(function (data, status) {

            deferred.reject();
        })
        return deferred.promise;
    }
    
    var getSongs = function () {
        var deferred = $q.defer();
        $http.get("/api/Song").success(function (data) {
            songs.length = 0;
            for (var s in data) {
                songs.push(data[s])
            }
            deferred.resolve(songs);
        }).error(function (data, status) {

            deferred.reject();
        })
        return deferred.promise;
    }

    var addSong = function (newSong) {
        var deferred = $q.defer();
        $http.post("/api/Song", newSong).success(function (data) {
  //          songs.push(newSong) nice try but newsong won't have id and causes problems if edited/removed before a reload
            
            deferred.resolve();
        }).error(function (data, status) {

            deferred.reject();
        })
        return deferred.promise;
    }

    var deleteSong = function (song) {
        var deferred = $q.defer();
        $http.delete("/api/Song/"+song.SongId).success(function (data) {
            removeSong(song);

            deferred.resolve(songs);
        }).error(function (data, status) {

            deferred.reject();
        })
        return deferred.promise;
    }

    var updateSong = function (song) {
        var deferred = $q.defer();
        $http.put("/api/Song", song).success(function (data) {
            // need to update genreName since it may have changed
            var newGenre = findGenre(song.GenreId);
            song.GenreName = newGenre.Name;
           // replaceSong(song);

            deferred.resolve();
        }).error(function (data, status) {

            deferred.reject();
        })
        return deferred.promise;
    }

    var searchSongs = function (search) {
        var deferred = $q.defer();
        var path = "api/Search?artist=" + search.Artist + "&title=" + search.Title + "&album=" + search.Album + "&genre=" + search.Genre + "";

        $http.get(path).success(function (data) {
            searchedSongs.length = 0;
            for (var s in data) {
                searchedSongs.push(data[s]);
            }
            return deferred.resolve(searchedSongs);
        }).error(function (status) {
            return deferred.reject(status);
        })
        return deferred.promise;
    }

    return {
        getString: getString,
        getGenres: getGenres,
        addGenre: addGenre,
        addSong: addSong,
        getSongs: getSongs,
        searchSongs: searchSongs,
        updateSong: updateSong,
        deleteSong: deleteSong,
        updateGenre: updateGenre,
        deleteGenre: deleteGenre
    };
            
});