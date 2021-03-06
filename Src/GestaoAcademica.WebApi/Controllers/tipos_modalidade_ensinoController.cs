﻿using MSTech.GestaoEscolar.BLL;
using MSTech.GestaoEscolar.ObjetosSincronizacao.DTO.Entrada;
using MSTech.GestaoEscolar.ObjetosSincronizacao.DTO.Saida;
using MSTech.GestaoEscolar.ObjetosSincronizacao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GestaoAcademica.WebApi.Controllers
{
    public class tipos_modalidade_ensinoController : ApiController
    {
        /// <summary>
        /// Seleciona todas as modalidades de ensino ativas.
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        public List<ACA_TipoModalidadeEnsinoDTO> GetAtivas()
        {
            try
            {
                List<ACA_TipoModalidadeEnsinoDTO> dto = ApiBO.SelecionarTipoModalidadeEnsinoAtivas();
                if (dto != null && dto.Count > 0) return dto;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Erro: " + e.Message)
                });
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
