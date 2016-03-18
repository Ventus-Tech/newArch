(function () {
    'use strict';

    angular
        .module("PersonasApp")
        .controller("ListController", ListController);
    function ListController($http) {
        var vm = this;
        vm.ListaPersonas = [];
        vm.ListaDepos = [];
        vm.back = false;
        vm.MuestraTabla = true;
            
        // get Depos from server
        var DeposJson = $http.post('../Angular/DeposList');
        DeposJson.success(function (data) {
            vm.ListaDepos = data;
        });

        var jsonResponse = $http.get("../Angular/List");
        jsonResponse.success(function (data, status, headers, config) {
            vm.ListaPersonas = data;

        });

        vm.Borrar = function (row) {
            if (confirm("¿Quiere eliminar el registro?")) {
                $http.post("../Angular/Borrar", row.IdPersona).success(function (data) {
                    if (data == 1) {
                        var index = vm.ListaPersonas.indexOf(row);
                        vm.ListaPersonas.splice(index, 1);
                    }
                    else
                        alert("No se pudo borrar el registro");
                });
            }
        };
        vm.Regresar = function () {
            vm.back = false;
            vm.MuestraTabla = true;
        }
        vm.Nuevo = function () {
            vm.form = {};
            vm.back = true;
            vm.MuestraTabla = false;

        }
        vm.Grabar = function (row) {
            $http.post("../Angular/Grabar", row).success(function (data) {

                if (data != null) {
                    if (vm.Edita == false) {
                        debugger;
                        vm.ListaPersonas.push(data);
                    }
                    vm.MuestraTabla = false;

                }
            });

        }
        vm.Editar = function (model) {
            // var index = vm.ListaPersonas.indexOf(model);
            vm.form = model;

        }
    }
})();