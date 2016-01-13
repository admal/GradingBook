angular.module('GradingBookApp', ["ngTable", "ui.bootstrap"])
    .controller('HomeController', function($scope, $http, ngTableParams, $uibModal) {
        $scope.errorMsg = '';
        $scope.isLoading = false;

        $scope.groups = [];
        $scope.loadGroups = function(username) {
            $scope.isLoading = true;
            $http.get("http://localhost:53716/api/groups/getusersgroups/" + username).success(
                function (data, status, headers, config) {
                    $scope.groups = data;
                    $scope.isLoading = false;
                }).error(function (data, status, headers, config) {
                    $scope.isLoading = false;
                    $scope.errorMsg = "Oops... something went wrong";
                });
        }

});