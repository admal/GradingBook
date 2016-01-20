var baseUrl = 'http://localhost:53716/';

angular.module('GradingBookApp', ["ngAnimate", "ui.bootstrap"])
    .controller('SettingsController', function($scope, $http) {
            $scope.errorMsg = '';
            $scope.isLoading = false;
            
            $scope.currUser = {};
            $scope.alerts = [];
            $scope.addAlert = function (type, msg) {
                $scope.alerts.push({ type: type, msg: msg });
            };
            $scope.closeAlert = function (index) {
                $scope.alerts.splice(index, 1);
            };


            $scope.loadUser = function (username) {
                $scope.isLoading = true;
                $http.get(baseUrl + 'api/Users/GetByUsername/' + username).success(
                    function (data, status, headers, config) {
                        $scope.currUser = data;
                        $scope.isLoading = false;
                    }).error(function(data, status, headers, config) {
                        $scope.errorMsg = "Something went wrong!";
                        $scope.isLoading = false;
                });
            }

            $scope.saveCredentials = function () {
                $scope.isLoading = true;
                $http.put(baseUrl + 'api/Users/' + $scope.currUser.id, $scope.currUser).success(
                    function (data, status, headers, config) {
                        $scope.addAlert('success', 'Your credentials were saved succesfully!');
                        $scope.isLoading = false;
                    }).error(function() {
                    $scope.errorMsg = 'Error has occured!';
                    $scope.isLoading = false;
                });
            }
    }
);