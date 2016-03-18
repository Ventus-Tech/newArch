(function () {
    'use strict';
 
    angular
        .module('PersonasApp')
        .controller('apiController', PersonasController);
 
    PersonasController.$inject = ['$scope', 'Personas'];
 
    function PersonasController($scope, Personas) {
        $scope.Personas = Personas.query();
    }
})();
