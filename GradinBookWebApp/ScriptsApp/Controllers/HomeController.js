var baseUrl = 'http://localhost:53716/';
angular.module('GradingBookApp', ["ngAnimate", "ngTable", "ui.bootstrap"])
    .controller('HomeController', function ($scope, $http, modalService, ngTableParams, $uibModal) {
        $scope.getUser = '';
        $scope.user_id = {};
        $scope.group_id;
        $scope.isAdmin = true;
        $scope.isLoading = false;
        $scope.data = [];
        $scope.alerts = [];
        $scope.currYear = {};
        $scope.currSubject = {};
        $scope.errorMsg = '';
        $scope.groups = [];
        $scope.getYears = [];
        $scope.showSections = [true, false, false, false, false, false]; // [0]=main, [1]=year, [2]=subject, [3]=grade, [4]=edit year, [5]=edit subject
        //$scope.usersGroups = [];
        
        //returns true if given year is created by user 
        //(does not matter if user is group admin and there the year was created or it his private year)
        $scope.isYearsOwner = function(year) {
            if (year.group != null) //it is public year (created in group)
            {
                return year.group.ownerName == $scope.getUser;
            }
            return true;
        }




        /*///////////////////////-------------------------FUNCTIONS-----------------------/////////////////////////*/

        /*-----------ALERT MANAGEMENT-----------*/
        $scope.addAlert = function (type, msg) {
            $scope.alerts.push({ type: type, msg: msg });
        };
        $scope.closeAlert = function (index) {
            $scope.alerts.splice(index, 1);
        };

        //Sections management
        $scope.showSection = function (idx) {
            if (idx < $scope.showSections.length && idx >= 0)
                $scope.showSections[idx] = true;
        }
        $scope.hideSection = function (idx) {
            if (idx < $scope.showSections.length && idx >= 0)
                $scope.showSections[idx] = false;
        }
        $scope.toggleSection = function (idx) {
            if (idx < $scope.showSections.length && idx >= 0)
                $scope.showSections[idx] = !$scope.showSections[idx];
        }
        //hides everything and shows grade table
        $scope.showGradesTable = function () {
            $scope.hideSection(1);
            $scope.hideSection(2);
            $scope.hideSection(3);
            $scope.hideSection(4);
            $scope.hideSection(5);
            $scope.showSection(0);
        }

        $scope.hideAllSections = function(){
            $scope.hideSection(0);
            $scope.hideSection(1);
            $scope.hideSection(2);
            $scope.hideSection(3);
            $scope.hideSection(4);
            $scope.hideSection(5);
        }

        $scope.findUser = function (username) {
            $scope.isLoading = true;
            if ($scope.isAdmin) { //we are watching our profile so we load all years
                $scope.getUserId(username);
                $http.get(baseUrl + "api/years/getallbyusername/" + username).success(
                    function(data, status, headers, config) {
                        $scope.getYears = data;
                        //$scope.usersGroups = data.GroupDetails;
                        $scope.currYear = data[0];
                        $scope.isLoading = false;
                        $scope.changeYear(data[0].id);
                        $scope.getUser = username;
                    }).error(function(data, status, headers, config) {
                    $scope.isLoading = false;
                    $scope.errorMsg = "Oops... something went wrong";
                });
            } else { //we are watching other user's profile so we can see only grades of years in the group
                if ($scope.group_id == null) {
                    $scope.errorMsg = "Error occured!";
                    return;
                }
                $http.get(baseUrl + "api/years/getbygroupid/" + $scope.group_id).success(
                    function (data, status, headers, config) {
                        $scope.getYears = data;
                        $scope.currYear = data[0];
                        $scope.isLoading = false;
                        $scope.changeYear(data[0].id);
                        $scope.getUser = username;
                    }).error(function (data, status, headers, config) {
                        $scope.isLoading = false;
                        $scope.errorMsg = "Oops... something went wrong";
                    });
            }
        }

        $scope.getUserId = function (username) {
            $scope.isLoading = true;
            $http.get(baseUrl + "api/users/GetByUsername/" + username).success(
                function(data, status, headers, config){
                    $scope.user_id = data.id;
                    $scope.isLoading = false;
                }).error(function (data, status, headers, config) {
                    $scope.isLoading = false;
                    $scope.errorMsg = "Oops... something went wrong";
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
                    //$scope.data = $scope.currYear.Subjects;
                    $defer.resolve($scope.currYear.Subjects);
                }
            });
        }
        /*--------------------GRADE PART------------------------*/
        $scope.showAddGradeSection = function (subject) {
            $scope.hideAllSections();
            $scope.showSection(3);
            $scope.currSubject = subject;
        }

        $scope.newGrade = {
            grade_value: 0,
            grade_weight: 0,
            grade_date: new Date(),
            grade_desc: '',
        };
        //CREATE GRADE
        $scope.createGrade = function () {
            $scope.isLoading = true;

            var grade = {
                grade_value: $scope.newGrade.grade_value,
                grade_weight: $scope.newGrade.grade_weight,
                grade_desc: $scope.newGrade.grade_desc,
                grade_date: $scope.newGrade.grade_date,
                sub_id: $scope.currSubject.id,
                user_id: $scope.user_id,
            };
            $scope.showGradesTable();
            $http.post(baseUrl + 'api/SubjectDetails/', grade).success(function () {
                $scope.isLoading = false;
                $scope.currSubject.SubjectDetails.push($scope.newGrade);
                $scope.addAlert('success', 'Grade was added successfuly!');
                $scope.hideSection(2);
                $scope.findUser($scope.getUser);
                console.log(angular.toJson(grade));
            }).error(function () {
                $scope.errorMsg = 'Oops sth went wrong...';
                $scope.isLoading = false;
                //after error reload page
                $scope.findUser($scope.getUser);
            });
        }
        /*--------------------SUBJECT PART------------------------*/
        $scope.showAddSubjectSection = function () {
            $scope.hideAllSections();
            $scope.showSection(2);
        }
        $scope.showEditSubjectSection = function (subject) {
            $scope.hideAllSections();
            $scope.showSection(5);
            $scope.currSubject = subject;
        }

        $scope.newSubject = {
            name: '',
            sub_desc: '',
            teacher_mail: '',
            final_grade: '',
            
        };
        //CREATE SUBJECT
        $scope.createSubject = function () {
            $scope.isLoading = true;

            var subject = {
                name: $scope.newSubject.name,
                sub_desc: $scope.newSubject.sub_desc,
                teacher_mail: $scope.newSubject.teacher_mail,
                year_id: $scope.currYear.id,
                final_grade: $scope.currYear.final_grade,
            };
            $scope.showGradesTable();
            $http.post(baseUrl + 'api/Subjects/', subject).success(function () {
                $scope.isLoading = false;
                $scope.currYear.Subjects.push($scope.newSubject);
                $scope.addAlert('success', 'Subject was added successfuly!');
                $scope.hideSection(2);
                $scope.findUser($scope.getUser);
                console.log(angular.toJson(subject));
            }).error(function () {
                $scope.errorMsg = 'Oops sth went wrong...';
                $scope.isLoading = false;
                //after error reload page
                $scope.findUser($scope.getUser);
            });
        }
        //REMOVE SUBJECT
        $scope.deleteSubject = function (subject) {
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete subject',
                headerText: 'Delete ' + subject.name + '?',
                bodyText: 'Are you sure you want to delete this subject?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                $http.delete(baseUrl + 'api/subjects/' + subject.id, null).success(
                    function (data, status, headers, config) {
                        $scope.isLoading = false;
                        $scope.findUser($scope.getUser);
                        $scope.addAlert('success', 'Subject was succesfully deleted!');
                    }).error(function () {
                        $scope.errorMsg = 'Oops sth went wrong...';
                        $scope.errorMsg += status;
                        $scope.isLoading = false;
                        //after error reload page
                        $scope.findUser($scope.username);
                    });
            });
        }
        //UPDATE SUBJECT
        $scope.updateSubject = function () {
            $scope.isLoading = true;

            var subject = {
                id: $scope.currSubject.id,
                name: $scope.currSubject.name,
                sub_desc: $scope.currSubject.sub_desc,
                year_id: $scope.currSubject.year_id,
                teacher_mail: $scope.currSubject.teacher_mail,
                final_grade: $scope.currSubject.final_grade,
            };

            $http.put(baseUrl + 'api/subjects/' + $scope.currSubject.id, subject).success(
                function (data, status, headers, config) {
                    $scope.isLoading = false;
                    $scope.showGradesTable();
                    $scope.addAlert('success', 'Subject was succesfully edited!');
                }).error(function () {
                    $scope.errorMsg = 'Oops sth went wrong...';
                    $scope.errorMsg += status;
                    $scope.isLoading = false;
                    //after error reload page
                    $scope.findUser($scope.getUser);
                });
        }
        /*--------------------YEAR PART------------------------*/
        //visibility management
        $scope.showAddYearSection = function () {
            $scope.hideAllSections();
            $scope.showSection(1);
        }
        $scope.showEditYearSection = function () {
            $scope.hideAllSections();
            $scope.showSection(4);
        }

        $scope.newYear = {
            name: '',
            start: new Date(),
            end_date: new Date(),
            year_desc: ''
        };
        //CREATE YEAR
        $scope.createYear = function () {
            $scope.isLoading = true;

            var year = {
                name: $scope.newYear.name,
                start: $scope.newYear.start,
                end_date: $scope.newYear.end_date,
                year_desc: $scope.newYear.year_desc,
                user_id: $scope.user_id,
            };
            $scope.showGradesTable();
            $http.post(baseUrl + 'api/Years', year).success(function () {
                $scope.isLoading = false;
                $scope.getYears.push($scope.newYear);
                $scope.addAlert('success', 'Year was added successfuly!');
                $scope.hideSection(1);
                console.log(angular.toJson(year));
                $scope.findUser($scope.getUser);
            }).error(function () {
                $scope.errorMsg = 'Oops sth went wrong...';
                $scope.isLoading = false;
                //after error reload page
                $scope.findUser($scope.getUser);
            });
        }
        //DELETE YEAR
        $scope.deleteYear = function () {
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete year',
                headerText: 'Delete ' + $scope.currYear.name + '?',
                bodyText: 'Are you sure you want to delete this year?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                $http.delete(baseUrl + 'api/years/' + $scope.currYear.id, null).success(
                    function (data, status, headers, config) {
                        $scope.isLoading = false;

                        var idx = -1;
                        for (var i = 0; i < $scope.getYears.length; i++) {
                            if ($scope.getYears[i].id == data.id) {
                                idx = i;
                                break;
                            }
                        }
                        if (idx >= 0)
                            $scope.getYears.splice(idx, 1);
                        if ($scope.getYears.length == 0) {
                            $scope.currYear = {}; //tmp
                        } else {
                            $scope.currYear = $scope.getYears[0];
                        }
                        $scope.findUser($scope.getUser);
                        $scope.addAlert('success', 'Year was succesfully deleted!');
                    }).error(function () {
                        $scope.errorMsg = 'Oops sth went wrong...';
                        $scope.errorMsg += status;
                        $scope.isLoading = false;
                        //after error reload page
                        $scope.findUser($scope.getUser);
                    });
            });
        }
        //UPDATE YEAR
        $scope.updateYear = function () {
            $scope.isLoading = true;

            var year = {
                id: $scope.currYear.id,
                name: $scope.currYear.name,
                year_desc: $scope.currYear.year_desc,
                start: $scope.currYear.start,
                end_date: $scope.currYear.end_date,
                user_id: $scope.currYear.user_id,
                group_id: $scope.currYear.group_id
            };

            $http.put(baseUrl + 'api/years/' + $scope.currYear.id, year).success(
                function (data, status, headers, config) {
                    $scope.isLoading = false;
                    $scope.findUser($scope.getUser);
                    $scope.showGradesTable();
                    $scope.addAlert('success', 'Year was succesfully edited!');
                }).error(function () {
                    $scope.errorMsg = 'Oops sth went wrong...';
                    $scope.errorMsg += status;
                    $scope.isLoading = false;
                    //after error reload page
                    $scope.findUser($scope.getUser);
                });
        }


        //--------//DATEPICKER

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

        $scope.getDayClass = function (date, mode) {
            if (mode === 'day') {
                var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                for (var i = 0; i < $scope.events.length; i++) {
                    var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                    if (dayToCheck === currentDay) {
                        return $scope.events[i].status;
                    }
                }
            }

            return '';
        };
        $scope.popupStart = {
            opened: false
        };
        $scope.openCalendar = function () {
            $scope.popupStart.opened = true;
        };
});


