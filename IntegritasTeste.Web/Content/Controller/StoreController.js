app.controller('StoreController', function ($rootScope, $location, $http) {
    $rootScope.activetab = $location.path();
});