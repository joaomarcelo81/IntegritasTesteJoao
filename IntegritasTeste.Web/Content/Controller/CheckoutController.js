app.controller('CheckoutController', function ($rootScope, $location, $http) {
    $rootScope.activetab = $location.path();


    var updateCart = function () {
        $http.get('/Cart/Get').then(function (cart) {
            $rootScope.cart = cart.data;
        }, function (error) {

        });
    }
    updateCart();


    $rootScope.TotalCart = function () {
        var total = 0;

        products = $rootScope.cart.products;
        for (var i = 0; i < products.length; i++) {
            total += $rootScope.GetCurrentPrice(products[i].Prices) * products[i].Quantity;
        }
        return total;
    }

});