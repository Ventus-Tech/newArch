 

    
    app.controller("PeopleCtrl", ListController);
    
    function ListController($scope,$http) {
      
        $scope.ListaPersonas = [];
        $scope.ListaDepos = [];
        $scope.back = false;
        $scope.MuestraTabla = true;
            
        // get Depos from server
        var DeposJson = $http.post('../Angular/DeposList');
        DeposJson.success(function (data) {
            $scope.ListaDepos = data;
        });

        var jsonResponse = $http.get("../Angular/List");
        jsonResponse.success(function (data, status, headers, config) {
            $scope.ListaPersonas = data;

        });

        $scope.Borrar = function (row) {
            if (confirm("¿Quiere eliminar el registro?")) {
                $http.post("../Angular/Borrar", row.IdPersona).success(function (data) {
                    if (data == 1) {
                        var index = $scope.ListaPersonas.indexOf(row);
                        $scope.ListaPersonas.splice(index, 1);
                    }
                    else
                        alert("No se pudo borrar el registro");
                });
            }
        };
        $scope.Regresar = function () { 
            $scope.back = false;
            $scope.MuestraTabla = true;
        }
        $scope.Nuevo = function () { 
            $scope.form = {};
            $scope.back = true;
            $scope.MuestraTabla = false;

        }
        $scope.Grabar = function (row) {
            $http.post("../Angular/Grabar", row).success(function (data) {

                if (data != null) {
                    if ($scope.Edita == false) {
                        debugger;
                        $scope.ListaPersonas.push(data);
                    }
                    $scope.MuestraTabla = false;

                }
            });

        }
        $scope.Editar = function (model) {
            // var index = $scope.ListaPersonas.indexOf(model);
            $scope.form = model;

        }
    }
 