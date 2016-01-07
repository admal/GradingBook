
angular.module('GradingBookApp', [])
    .controller('HomeController', function($scope, $http) {
        $scope.hello = "Angular hard!";
        $scope.getUser = '';
        $scope.findUser = function(username) {
            $http.get("http://localhost:53716/api/Users/getbyusername/" + username).success(
                function (data, status, headers, config) {
                    $scope.getUser = data.email;

                }).error(function (data, status, headers, config) {
                    $scope.getUser= "Oops... something went wrong";
                });
        }
});
