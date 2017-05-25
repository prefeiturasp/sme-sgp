﻿'use strict';

(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('MovimentacaoController', MovimentacaoController);

    MovimentacaoController.$inject = ['$scope', '$timeout', '$http', '$location', '$filter', 'trocarAnoService', '$q'];

    function MovimentacaoController($scope, $timeout, $http, $location, $filter, trocarAnoService, $q) {

        this.reload = function () {
            initVars();
            getMovimentacoes();
        };
        trocarAnoService.addSubscriber(this);

        function init() {
            configVariables();
        };

        function configVariables() {
            $scope.movimentacaoLoaded = false;
            $scope.baseUrl = $location.absUrl().split("/");
            $scope.site = $scope.baseUrl[0] + "//" + $scope.baseUrl[2]; // site;
            $scope.logos = core;
            $scope.api = api;

            initVars();
            getMovimentacoes();
        };

        function initVars() {
            $scope.movimentacaoLoaded = false;
            $scope.listMovimentacoes = [];
            $scope.params = params;
            $scope.mensagemErro = "";
            $scope.mensagemAlerta = "";
        };

        function getMovimentacoes() {
            if (!$scope.params || !$scope.params.alu_id || !$scope.params.ano) {
                $scope.mensagemErro = "Parâmetros inválidos";
            } else {
                var url = $scope.api + "/movimentacoes?alu_id=" + $scope.params.alu_id + "&ano=" + $scope.params.ano;

                $http.defaults.headers.common.Authorization = 'Bearer ' + Token;

                $http({
                    method: 'GET',
                    url: url
                }).then(function successCallback(response) {
                    if (response.data == null) {
                        $scope.mensagemErro = "Falha inesperada ao carregar as movimentações.";
                    }
                    else if (response.data && response.data.Status && response.data.Status == 1) {
                        $scope.mensagemErro = response.data.StatusDescription;
                    }
                    else {
                        try {
                            $scope.listMovimentacoes = response.data.movimentacoes;
                        }
                        catch (e) {
                            console.log(e);
                            $scope.mensagemErro = "Ocorreu um erro ao carregar as movimentações.";
                        }
                    }
                }, function errorCallback(response) {
                    if (response.status == 401) {
                        RefreshToken();
                    }else if (response.status == 404)
                        $scope.mensagemErro = "Falha ao recuperar os dados - API indisponível";
                    else if (response.status == 500)
                        $scope.mensagemErro = "Falha ao recuperar os dados - erro na API";
                    else
                        $scope.mensagemErro = "Falha inesperada ao carregar as movimentações.";
                }).finally(function () {
                    $scope.movimentacaoLoaded = true;
                });
            }
        };

        function getToken() {
            var deferred = $q.defer();
            $http({
                method: "POST",
                url: "RelatorioPedagogico.aspx/CreateToken",
                dataType: 'json',
                data: '{ "usuario":  "' + Usuario + '", "entidade": "' + Entidade + '", "grupo": "' + Grupo + '" }',
                headers: {
                    "Content-Type": "application/json"
                }
            }).success(function (data) {
                deferred.resolve(data);
            });

            return deferred.promise;
        }

        function RefreshToken() {
            var promise = getToken();
            promise.then(function (data) {
                Token = data.d;
                initVars();
                getMovimentacoes();
            });
        }

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
