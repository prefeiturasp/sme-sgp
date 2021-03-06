﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MSTech.GestaoEscolar.ObjetosSincronizacao.DTO.Entrada;
using MSTech.GestaoEscolar.ObjetosSincronizacao.DTO.Saida;
using MSTech.GestaoEscolar.BLL;
using System.Web.Http.Description;

namespace GestaoAcademica.WebApi.Controllers.SyncDiarioClasse
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApiListagemPlanejamentoTurmaController : ApiController
    {
        /// <summary>
        /// Retorna o planejamento filtrado pelo objeto com parâmetros de entrada.
        /// </summary>
        /// <param name="buscaEscolaEntradaDTO">Objeto com parâmetros de entrada</param>
        /// <returns></returns>

        public ListagemPlanejamentoTurmaSaidaDTO GetAll([FromUri] BuscaTurmasEntradaDTO filtroEntrada)
        {
            try
            {
                return ApiBO.BuscaPlanejamentoTurma(filtroEntrada);
            }
            catch
            {
                return null;
            }
        }
    }
}