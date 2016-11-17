app.controller('ProductsController', function ($rootScope, $location, $http) {
    $rootScope.activetab = $location.path();

    $rootScope.AddCart = function (productId) {


        var product = $rootScope.produtos[productId];

        $http.post("/Cart/Add", product).then(function (response) {

            if (response.data.success) {

                $('#AddProductToCart div.modal-body p').html("Product " + product.Name + " was removed from your cart!");
                $('#AddProductToCart').modal('show');

            } else {
                alert('Erro no sitema');
            }
        },
            function () {
                alert('Erro no sitema');
            });
    };

    $rootScope.onCategoryChange = function () {

    };

    $http.get('/Api/Product').then(function (produtos) {
        $rootScope.produtos = produtos.data;
    }, function (error) {
    });


    $http.get('/Api/Category').then(function (categories) {
        $rootScope.categories = categories.data;
    }, function (error) {

    });




});