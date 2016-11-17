var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider
        .when('/Products', {
            templateUrl: '/Store/Products',
            controller: 'ProductsController'
        })
        .when('/ShoppingCart', {
            templateUrl: '/Store/ShoppingCart',
            controller: 'ShoppingCartController'
        })
             .when('/Checkout', {
                 templateUrl: '/Store/Checkout',
                 controller: 'CheckoutController'
             })
        .otherwise({ redirectTo: '/Products' });
});

