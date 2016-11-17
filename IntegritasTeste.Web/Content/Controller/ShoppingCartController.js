app.controller('ShoppingCartController', function ($rootScope, $location, $http) {
    $rootScope.activetab = $location.path();

    $rootScope.GetCurrentPrice = function (Prices) {

        for (var i = 0; i < Prices.length; i++) {
            return Prices[i].Value;
        }
        return 0;

    };

    $rootScope.TotalCart = function () {
        var total = 0;

        products = $rootScope.cart.products;
        for (var i = 0; i < products.length; i++) {
            total += $rootScope.GetCurrentPrice(products[i].Prices) * products[i].Quantity;
        }
        return total;
    }
    var updateCart = function () {
        $http.get('/Cart/Get').then(function (cart) {
            $rootScope.cart = cart.data;
        }, function (error) {

        });
    }
    updateCart();


    $rootScope.RemoveCart = function (productId) {
        //alert(productId);

        var product = $rootScope.produtos[productId];

        $http.post("/Cart/Remove", product).then(function (response) {

            if (response.data.success) {

                $('#AddProductToCart div.modal-body p').html("Product " + product.Name + " was removed from your cart!");
                $('#AddProductToCart').modal('show');
                updateCart();

            } else {
                alert('Erro no sitema');
            }
        },
            function () {
                alert('Erro no sitema');
            });
    };

    $rootScope.UpdateCart = function () {

        var products = [];



        for (var i = 0; i < $('div.product').length; i++) {
            products.push({
                ProductID: $($('div.product')[i]).attr('productid'),
                Quantity: $($('div.product')[i]).find('input').val()
            });
        }


        $http.post("/Cart/Update", products).then(function (response) {
            if (response.data.success) {
                $('#AddProductToCart div.modal-body p').html("Your shopping cart was updated!");
                $('#AddProductToCart').modal('show');
                updateCart();

            } else {
                alert('Erro no sitema');
            }
        },
            function () {
                alert('Erro no sitema');
            });
    };




});