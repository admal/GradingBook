angular.module('GradingBookApp', ["ngTable", "ui.bootstrap"])
    .controller('HomeController', function ($scope, $http, ngTableParams, $uibModal) {
        $scope.getUser = '';
        $scope.isLoading = false;
        $scope.data = [];
        $scope.currYear = {};
        $scope.errorMsg = '';
        $scope.groups = [];
        $scope.getYears = [];
        //$scope.usersGroups = [];
        
        $scope.findUser = function (username) {
            $scope.isLoading = true;
            $http.get("http://localhost:53716/api/years/getallbyusername/" + username).success(
                function (data, status, headers, config) {
                    $scope.getYears = data;
                    //$scope.usersGroups = data.GroupDetails;
                    $scope.currYear = data[0];
                    $scope.isLoading = false;
                    $scope.changeYear(data[0].id);
                }).error(function (data, status, headers, config) {
                    $scope.isLoading = false;
                    $scope.errorMsg= "Oops... something went wrong";
                });
        }
        //end findUser
        $scope.changeYear = function (id) {
            $scope.yearsTable = new ngTableParams({
                page: 1,
                count: 10
            }, {
                total: $scope.getYears.length,
                getData: function ($defer, params) {
                    $scope.data = $scope.currYear.Subjects;
                    $defer.resolve($scope.data);
                }
            });
        }
        //end chnageYear()

        $scope.addGrade = function(subId) {
            
        }
        //end addGrade()
        $scope.showAddYearModal = function() {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/ScriptsApp/ModalsTemplates/AddYearModal.html',
                size: 'lg'
            });
        }
        //end showAddYearModal

        //dates
        $scope.popupStart = {
            opened: false
        };
        $scope.openCalendar = function () {
            $scope.popupStart.opened = true;
        };
});


