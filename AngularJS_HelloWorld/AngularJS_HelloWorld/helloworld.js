/// <reference path="angular.js" />
/// <reference path="jquery-1.9.1.min.js" />

function HelloCtrl($scope) {
    // Set inital value
    $scope.yourName = "Nathan";
}

function TodoCtrl($scope) {
    $scope.numTodos = 3;
    $scope.todos = [
        { text: "Wake up", done: false },
        { text: "Be awesome", done: false }
    ];

    $scope.addTodo = function () {
        $scope.todos.push({ text: $scope.formTodoText, done: false });
        $scope.formTodoText = '';
    }
    
    $scope.clearCompleted = function () {
        var oldTodos = $scope.todos;
        $scope.todos = [];
        //for (var i = 0; i < oldTodos.length; i++) {
        //    if (!oldTodos[i].done) $scope.todos.push(oldTodos[i]);
        //}
        //$.each(oldTodos, function (i, val) {
        //    if (!val.done) $scope.todos.push(val);
        //});
        $scope.todos = oldTodos.filter(function (todo) {
            return !todo.done;
        });
    }
}