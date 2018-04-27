var app = angular.module('App', []);
app.controller('menuController', ['$scope', '$http', function ($scope, $http) {
    $scope.SiteMenu = [];
    $http.get('/home/GetSiteMenu').then(function (data) {
        $scope.SiteMenu = data.data;
    }, function (error) {
        alert('Error');
    })
}])