angular.module('home', [])
    .controller('HomeController', [
        '$scope', '$http', function($scope, $http) {

            $scope.getList = function() {
                $http.get('/api/Todo/GetTodoItems')
                    .success(function(data, status, headers, config) {
                        $scope.todoList = data;
                    });
            };

            $scope.postItem = function() {
                var item =
                {
                    text: $scope.newTaskText
                };

                if ($scope.newTaskText != '') {
                    $http.post('/api/Todo/PostTodoItem', item)
                        .success(function(data, status, headers, config) {
                            $scope.newTaskText = '';
                            $scope.getList();
                        });
                }
            };

            $scope.complete = function (index) {
                $http.post('/api/Todo/CompleteTodoItem/' + $scope.todoList[index].id)
                    .success(function(data, status, headers, config) {
                        $scope.getList();
                    });
            };

            $scope.delete = function (index) {
                $http.post('/api/Todo/DeleteTodoItem/' + $scope.todoList[index].id)
                    .success(function(data, status, headers, config) {
                        $scope.getList();
                    });
            };

            //Get the current user's list when the page loads.
            $scope.getList();
        }
    ]);