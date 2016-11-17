
app.controller('HomeController', function ($rootScope, $location, $http) {
    $rootScope.activetab = $location.path();
});