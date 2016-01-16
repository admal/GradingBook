var baseUrl = 'http://localhost:53716/';
angular.module('GradingBookApp', ['ngAnimate', "ui.bootstrap"])
    .controller('GroupController',['$scope','$http','modalService', function ($scope, $http, modalService) {
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
                    if ($scope.groups.length == 0) {

                    } else {
                        $scope.currGroup = data[0];
                    }
                    
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
        $scope.toggleSection = function(idx) {
            if (idx < $scope.showSections.length && idx >= 0)
                $scope.showSections[idx] = !$scope.showSections[idx];
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
        $scope.editGroup = function() {
            $scope.isEditing = !$scope.isEditing;
        }
        $scope.changeYear = function (id) {

        }
        //end changeYear()

        $scope.saveEditForm = function() {
            $scope.isLoading = true;
            if ($scope.isEditing) {
                var groups = {
                    id: $scope.currGroup.id,
                    name: $scope.currGroup.name,
                    description: $scope.currGroup.description
                };

                $http.put(baseUrl + 'api/groups/' + $scope.currGroup.id, groups).success(
                    function(data, status, headers, config) {
                        $scope.isLoading = false;
                        $scope.addAlert('success', 'Group was succesfully edited!');
                    }).error(function() {
                        $scope.errorMsg = 'Oops sth went wrong...';
                    $scope.errorMsg += status;
                        $scope.isLoading = false;
                        //after error reload page
                        $scope.loadGroups($scope.currUser);
                });
            } else {
                $scope.errorMsg = 'Unknown error occured!';
                $scope.isLoading = false;
                $scope.loadGroups($scope.currUser);
            }
            $scope.isEditing = false;
        };
        //end saveEditForm()

        $scope.leaveDeleteGroupClick = function () {
            if ($scope.isAdmin()) {
                $scope.deleteGroup();
            } else {
                $scope.leaveGroup();
            }
        };
        //end leaveDeleteGroupClick()

        $scope.deleteGroup = function() {
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete group',
                headerText: 'Delete ' + $scope.currGroup.name + '?',
                bodyText: 'Are you sure you want to delete this group?'
            };
            modalService.showModal({}, modalOptions).then(function(result) {
                $http.delete(baseUrl + 'api/Groups/' + $scope.currGroup.id, null).success(
                    function(data, status, headers, config) {
                        $scope.isLoading = false;

                        var idx = -1;
                        for (var i = 0; i < $scope.groups.length; i++) {
                            if ($scope.groups[i].id == data.id) {
                                idx = i;
                                break;
                            }
                        }
                        if (idx >= 0)
                            $scope.groups.splice(idx, 1);
                        if ($scope.groups.length == 0) {
                            $scope.currGroup = {}; //tmp
                        } else {
                            $scope.currGroup = $scope.groups[0];
                        }

                        $scope.addAlert('success', 'Group was succesfully deleted!');
                    }).error(function() {
                        $scope.errorMsg = 'Oops sth went wrong...';
                        $scope.errorMsg += status;
                        $scope.isLoading = false;
                        //after error reload page
                        $scope.loadGroups($scope.currUser);
                });
            });
        };
        //end deleteGroup()

        $scope.leaveGroup = function() {
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Leave group',
                headerText: 'Leave ' + $scope.currGroup.name + ' group?',
                bodyText: 'Are you sure you want to leave this group?'
            };
            modalService.showModal({}, modalOptions).then(function(result) {
                $http.delete(baseUrl+'api/GroupDetails/RemoveDetailByUsername/'+$scope.currGroup.id+'/'+$scope.currUser, 
                    null).success(
                    function (data, status, headers, config) {
                        $scope.isLoading = false;

                        var idx = -1;
                        for (var i = 0; i < $scope.groups.length; i++) {
                            if ($scope.groups[i].id == data.group_id) {
                                idx = i;
                                break;
                            }
                        }
                        console.log(idx);
                        if (idx >= 0)
                            $scope.groups.splice(idx, 1);
                        if ($scope.groups.length == 0) {
                            $scope.currGroup = {}; //tmp
                        } else {
                            $scope.currGroup = $scope.groups[0];
                        }


                        $scope.addAlert('success', 'You have left the group!');
                    }).error(function () {
                        $scope.errorMsg = 'Oops sth went wrong...';
                        $scope.isLoading = false;
                        //after error reload page
                        $scope.loadGroups($scope.currUser);
                    });
            });
        };
        //end leavegroup()

        $scope.addUser = function(newUser) {
            console.log(newUser);
            for (var i = 0; i < $scope.currGroup.GroupDetails.length; i++) {
                if ($scope.currGroup.GroupDetails[i].username == newUser) {
                    $scope.addAlert('danger', 'There is already ' + newUser + ' in the group!');
                    return;
                }
            }
            $scope.isLoading = true;
            $http.get(baseUrl + 'api/users/getbyusername/' + newUser).success(
                function (data, status, headers, config) {
                    var loadedUser = data;
                    if (loadedUser == null) {
                        $scope.isLoading = false;
                        $scope.addAlert('danger', 'There is no user: ' + newUser);
                        return;
                    }

                    var newDetail = {
                        user_id: loadedUser.id,
                        group_id: $scope.currGroup.id,
                        username: loadedUser.username
                    };
                    $http.post(baseUrl + 'api/groupdetails', newDetail).success(function() {
                        $scope.isLoading = false;
                        $scope.currGroup.GroupDetails.push(newDetail);
                        $scope.addAlert('success', 'User added succesfuly!');
                    }).error(function() {
                        $scope.errorMsg = 'Ooops sth gone wrong...';
                        $scope.loadGroups($scope.currUser); //reload
                    });

                }).error(function() {

            });
        }
        //end addUser()

        $scope.removeUser = function(user) {
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Remove him!!!',
                headerText: 'Remove ' + user.username,
                bodyText: 'Are you sure you want to remove this user?'
            };
            modalService.showModal({}, modalOptions).then(function(result) {
                $http.delete(baseUrl+'api/GroupDetails/RemoveDetailByUsername/'+$scope.currGroup.id+'/'+user.username, 
                    null).success(function (data, status, headers, config) {
                        $scope.isLoading = false;

                        for (var i = 0; i < $scope.currGroup.GroupDetails.length; i++) {
                            if ($scope.currGroup.GroupDetails[i].user_id == user.user_id) {
                                console.log(i);
                                console.log(angular.toJson($scope.currGroup.GroupDetails[i]));
                                $scope.currGroup.GroupDetails.splice(i,1);
                                break;
                            }
                        }

                        $scope.addAlert('success', user.username+' was removed from the group: '+$scope.currGroup.name+'!');
                    }).error(function () {
                        $scope.errorMsg = 'Oops sth went wrong...';
                        $scope.isLoading = false;
                        //after error reload page
                        $scope.loadGroups($scope.currUser);
                    });
            });
        }
        //end removeUser()


        //YEAR stuff
        $scope.newYear = {
            name: '',
            start: new Date(),
            end_date: new Date(),
            year_desc: ''
        };

        $scope.createYear = function () {
            $scope.isLoading = true;

            var year = {
                name: $scope.newYear.name,
                start: $scope.newYear.start,
                end_date: $scope.newYear.end_date,
                year_desc: $scope.newYear.year_desc,
                group_id: $scope.currGroup.id
            };

            $http.post(baseUrl + 'api/Years', year).success(function() {
                $scope.isLoading = false;
                $scope.currGroup.Years.push($scope.newYear);
                $scope.addAlert('success', 'Year was added successfuly!');
                $scope.hideSection(3);
                console.log(angular.toJson(year));
            }).error(function() {
                $scope.errorMsg = 'Oops sth went wrong...';
                $scope.isLoading = false;
                //after error reload page
                $scope.loadGroups($scope.currUser);
            });
        }

        $scope.deleteYear = function (year) {
            var id = year.id;
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Remove it!!!',
                headerText: 'Remove year',
                bodyText: 'Are you sure you want to remove this year?'
            };
            modalService.showModal({}, modalOptions).then(function (result) {
                $http.delete(baseUrl + 'api/Years/' + id, null).success(
                    function (data, status, headers, config) {
                        $scope.isLoading = false;

                        for (var i = 0; i < $scope.currGroup.Years.length; i++) {
                            if ($scope.currGroup.Years[i].id == id) {
                                $scope.currGroup.Years.splice(i, 1);
                                break;
                            }
                        }

                        $scope.addAlert('success', 'Year was removed successfuly!');
                    }).error(function () {
                        $scope.errorMsg = 'Oops sth went wrong...';
                        $scope.isLoading = false;
                        //after error reload page
                        $scope.loadGroups($scope.currUser);
                    });
            });
        }

        //DATEPICKER

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

        $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        $scope.format = $scope.formats[2];
        $scope.altInputFormats = ['M!/d!/yyyy'];

        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        var afterTomorrow = new Date();
        afterTomorrow.setDate(tomorrow.getDate() + 1);
        $scope.events =
          [
            {
                date: tomorrow,
                status: 'full'
            },
            {
                date: afterTomorrow,
                status: 'partially'
            }
          ];

        $scope.getDayClass = function(date, mode) {
            if (mode === 'day') {
                var dayToCheck = new Date(date).setHours(0,0,0,0);

                for (var i = 0; i < $scope.events.length; i++) {
                    var currentDay = new Date($scope.events[i].date).setHours(0,0,0,0);

                    if (dayToCheck === currentDay) {
                        return $scope.events[i].status;
                    }
                }
            }

            return '';
        };
    
}]);