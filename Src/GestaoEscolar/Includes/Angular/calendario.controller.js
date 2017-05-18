﻿'use strict';
/**
 * function CalendarioContoller
 * @namespace Controller
 */
(function (angular) {

    //angular
    //    .module('app', []);
        
    angular
        .module('app')
        .controller("CalendarioController", CalendarioController);

    angular
       .module('app')
       .service("trocarAnoService", function () {
        this.subscribers = [];

        this.addSubscriber = function (sub) {
            this.subscribers.push(sub);
        };

        this.reload = function () {
            var len = this.subscribers.length;
            for (var i = 0; i < len; i++) {
                this.subscribers[i].reload();
            }
        };
    });

    CalendarioController.$inject = ['$scope', '$timeout', '$http', '$location', '$filter', 'trocarAnoService'];

    function CalendarioController($scope, $timeout, $http, $location, $filter, trocarAnoService) {
       
        function init() {
            configVariables();
        };

        /**
        * @function 
        * @name 
        * @namespace CalendarioContoller
        * @memberOf Controller
        * @private
        * @param
        * @return
        */
        function configVariables() {
            $scope.baseUrl = $location.absUrl().split("/");
            $scope.site = $scope.baseUrl[0] + "//" + $scope.baseUrl[2]; // site;
            $scope.logos = core;
            $scope.api = api;

            $scope.trocarAno = function (ano, mtu_id) {
                initVars();
                $scope.params.ano = ano;
                $scope.params.mtu_id = mtu_id;
                params.ano = ano;
                params.mtu_id = mtu_id;
                params.MtuIds = mtu_id;
                getCalendarios();
                trocarAnoService.reload();
            }


            initVars();
            getCalendarios();
        };

        function initVars() {
            $scope.listCalendario = [];
            $scope.mensagemAlerta = "";
            $scope.params = params;
        };

        /**
        * @function 
        * @name 
        * @namespace CalendarioContoller
        * @memberOf Controller
        * @private
        * @param
        * @return
        */
        function getCalendarios() {
            if (!$scope.params || !$scope.params.alu_id) {
                $scope.mensagemErro = "Parâmetros inválidos";
            }
            else {
                var url = $scope.api + "/calendarios_anuais?alu_id=" + $scope.params.alu_id;
                $http({
                    method: 'GET',
                    url: url
                }).then(function successCallback(response) {
                    //console.log(response);
                    if (response.data == null) {
                        $scope.mensagemErro = "Falha inesperada ao carregar o anos.";
                    }
                    else if (response.data[0] && response.data[0].Status && response.data[0].Status == 1) {
                        $scope.mensagemErro = response.data[0].StatusDescription;
                    }
                    else {
                        try {

                            if (response.data.length > 0) {

                                $scope.listCalendario = $filter('orderBy')(response.data, '-cal_ano');
                                if (!$scope.params.ano) {
                                    $scope.params.ano = $scope.listCalendario[0].cal_ano;
                                }

                                if (!$scope.params.mtu_id) {
                                    $scope.params.mtu_id = $scope.listCalendario[0].mtu_id;
                                    params.MtuIds = "'" + $scope.params.mtu_id + "'"
                                }
                            }

                        }
                        catch (e) {
                            console.log(e);
                            $scope.mensagemErro = "Ocorreu um erro ao carregar o boletim.";
                        }
                    }
                }, function errorCallback(response) {
                    if (response.status == 404)
                        $scope.mensagemErro = "Falha ao recuperar os dados - API indisponível";
                    else if (response.status == 500)
                        $scope.mensagemErro = "Falha ao recuperar os dados - erro na API";
                    else
                        $scope.mensagemErro = "Falha inesperada ao carregar os ano.";
                });
            }
        };

        $scope.safeApply = function __safeApply() {
            var $scope, fn, force = false;
            if (arguments.length === 1) {
                var arg = arguments[0];
                if (typeof arg === 'function') {
                    fn = arg;
                } else {
                    $scope = arg;
                }
            } else {
                $scope = arguments[0];
                fn = arguments[1];
                if (arguments.length === 3) {
                    force = !!arguments[2];
                }
            }
            $scope = $scope || this;
            fn = fn || function () { };

            if (force || !$scope.$$phase) {
                $scope.$apply ? $scope.$apply(fn) : $scope.apply(fn);
            } else {
                fn();
            }
        };
        init();
    }

})(angular);
