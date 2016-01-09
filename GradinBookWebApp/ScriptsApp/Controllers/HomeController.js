
angular.module('GradingBookApp', ["ngTable"])
    .controller('HomeController', function ($scope, $http, ngTableParams) {
        $scope.getUser = '';
        $scope.isLoading = false;
        $scope.data = [];
        $scope.findUser = function (username) {
            $scope.isLoading = true;
            $http.get("http://localhost:53716/api/Users/getbyusername/" + username).success(
                function (data, status, headers, config) {
                    
                    $scope.getUser = data.email;
                    $scope.getYears = data.Years;
                    $scope.isLoading = false;

                    $scope.yearsTable = new ngTableParams({
                        page: 1,
                        count: 10
                    }, {
                        total: $scope.getYears.length,
                        getData: function ($defer, params) {
                            $scope.data = data.Years;
                            $defer.resolve($scope.data);
                        } });

                }).error(function (data, status, headers, config) {
                    $scope.getUser= "Oops... something went wrong";
                });

        }
});


