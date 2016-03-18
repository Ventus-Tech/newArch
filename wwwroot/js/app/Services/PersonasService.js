(function () {
    'use strict';
    var PersonasService = angular.module('PersonasService', ['ngResource']);
    PersonasService.factory('Personas', ['$resource'],
        function ($resource) {
            return $resource("/api/Spa", {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        });

})();