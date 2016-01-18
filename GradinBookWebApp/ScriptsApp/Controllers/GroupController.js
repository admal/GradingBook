var baseUrl = 'http://localhost:53716/';
angular.module('GradingBookApp', ['ngAnimate', "ui.bootstrap"])
    .controller('HomeController', function ($scope, $http) {
        //utility managers
        $scope.errorMsg = '';
        $scope.isLoading = false;
        $scope.currUser = '';
        $scope.showSections = [true, false, false, false]; //idx: 0 - group view; 1 - edit/create group view
                                                            //2 - add user; 3 - add/edit year
        $scope.alerts = [];
        //data managers
        $scope.editedGroup = {};
        $scope.currGroup = {};
        $scope.groups = [];


        $scope.addAlert = function (type, msg) {
            $scope.alerts.push({type: type, msg: msg });
        };
        //end addAlert
        $scope.closeAlert = function (index) {
            $scope.alerts.splice(index, 1);
        };
        //end closeAlert()
        $scope.loadGroups = function(username) {
            $scope.isLoading = true;
            $http.get(baseUrl + "api/groups/getusersgroups/" + username).success(
                function (data, status, headers, config) {
                    $scope.groups = data;
                    $scope.currGroup = data[0];
                    $scope.isLoading = false;
                    $scope.currUser = username;
                }).error(function (data, status, headers, config) {
                    $scope.isLoading = false;
                    $scope.errorMsg = "Oops... something went wrong";
                });
        }
        //end loadGroups()
        $scope.isAdmin = function() {
            if ($scope.currGroup.ownerName == $scope.currUser)
                return true;
            return false;
        }

        $scope.showSection = function(idx) {
            if (idx < $scope.showSections.length && idx >= 0)
                $scope.showSections[idx] = true;
        }
        //end showSection()
        $scope.hideSection = function (idx) {
            if (idx < $scope.showSections.length && idx >= 0)
                $scope.showSections[idx] = false;
        }
        //end hideSection()
        $scope.showCreateGroupForm = function () {
            $scope.editedGroup = { name: '', description: '', ownerName: $scope.currUser, createdAt: new Date() };
            $scope.hideSection(0);
            $scope.showSection(1);
        }
        $scope.showMainForm =function() {
            $scope.hideSection(1);
            $scope.showSection(0);
        }
        //end showMain()
        $scope.createNewGroup = function() {
            $scope.isLoading = true;
            var group = $scope.editedGroup;
            $http.post(baseUrl + 'api/groups/creategroup', group).success(
                function(data, status, headers, config) {
                    $scope.isLoading = false;
                    $scope.loadGroups($scope.currUser);
                    $scope.addAlert('success', 'Group was created properly!');
                    $scope.showMainForm();
                }).error(function(data, status, headers, config) {
                    $scope.errorMsg = 'Oops sth went wrong...';
                    $scope.isLoading = false;
                });

        }
        //end createNewGroup()
        $scope.isEditing = false;
        $scope.editDesc = function() {
            $scope.isEditing = !$scope.isEditing;
        }
        $scope.changeYear = function (id) {

        }
        //end changeYear()

        $scope.deleteItem = function () {

        };

});