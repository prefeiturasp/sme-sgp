﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSTech.Data.Common.Abstracts;
using MSTech.GestaoEscolar.Entities;
using MSTech.Data.Common;
using System.Data;

namespace MSTech.GestaoEscolar.DAL.Abstracts
{
    /// <summary>
    /// Classe abstrata de DCL_ProtocoloReprocesso
    /// </summary>
    public abstract class Abstract_DCL_ProtocoloReprocessoDAO : Abstract_DAL<DCL_ProtocoloReprocesso>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "MSTech.DiarioClasse";
            }
        }

        /// <summary>
        /// Configura os parametros do metodo de carregar
        /// </ssummary>
        /// <param name="qs">Objeto da Store Procedure</param>
        protected override void ParamCarregar(QuerySelectStoredProcedure qs, DCL_ProtocoloReprocesso entity)
        {
            Param = qs.NewParameter();
            Param.DbType = DbType.Guid;
            Param.ParameterName = "@pro_id";
            Param.Size = 16;
            Param.Value = entity.pro_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@prp_seq";
            Param.Size = 4;
            Param.Value = entity.prp_seq;
            qs.Parameters.Add(Param);
        }

        /// <summary>
        /// Configura os parametros do metodo de Inserir
        /// </summary>
        /// <param name="qs">Objeto da Store Procedure</param>
        protected override void ParamInserir(QuerySelectStoredProcedure qs, DCL_ProtocoloReprocesso entity)
        {
            Param = qs.NewParameter();
            Param.DbType = DbType.Guid;
            Param.ParameterName = "@pro_id";
            Param.Size = 16;
            Param.Value = entity.pro_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@prp_seq";
            Param.Size = 4;
            Param.Value = entity.prp_seq;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.AnsiString;
            Param.ParameterName = "@prp_pacote";
            Param.Size = 2147483647;
            Param.Value = entity.prp_pacote;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Byte;
            Param.ParameterName = "@prp_status";
            Param.Size = 1;
            Param.Value = entity.prp_status;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.AnsiString;
            Param.ParameterName = "@prp_statusObervacao";
            Param.Size = 200;
            if (!string.IsNullOrEmpty(entity.prp_statusObervacao))
                Param.Value = entity.prp_statusObervacao;
            else
                Param.Value = DBNull.Value;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Byte;
            Param.ParameterName = "@prp_situacao";
            Param.Size = 1;
            Param.Value = entity.prp_situacao;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.DateTime;
            Param.ParameterName = "@prp_dataCriacao";
            Param.Size = 16;
            Param.Value = entity.prp_dataCriacao;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.DateTime;
            Param.ParameterName = "@prp_dataAlteracao";
            Param.Size = 16;
            Param.Value = entity.prp_dataAlteracao;
            qs.Parameters.Add(Param);
        }

        /// <summary>
        /// Configura os parametros do metodo de Alterar
        /// </summary>
        /// <param name="qs">Objeto da Store Procedure</param>
        protected override void ParamAlterar(QueryStoredProcedure qs, DCL_ProtocoloReprocesso entity)
        {
            Param = qs.NewParameter();
            Param.DbType = DbType.Guid;
            Param.ParameterName = "@pro_id";
            Param.Size = 16;
            Param.Value = entity.pro_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@prp_seq";
            Param.Size = 4;
            Param.Value = entity.prp_seq;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.AnsiString;
            Param.ParameterName = "@prp_pacote";
            Param.Size = 2147483647;
            Param.Value = entity.prp_pacote;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Byte;
            Param.ParameterName = "@prp_status";
            Param.Size = 1;
            Param.Value = entity.prp_status;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.AnsiString;
            Param.ParameterName = "@prp_statusObervacao";
            Param.Size = 200;
            if (!string.IsNullOrEmpty(entity.prp_statusObervacao))
                Param.Value = entity.prp_statusObervacao;
            else
                Param.Value = DBNull.Value;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Byte;
            Param.ParameterName = "@prp_situacao";
            Param.Size = 1;
            Param.Value = entity.prp_situacao;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.DateTime;
            Param.ParameterName = "@prp_dataCriacao";
            Param.Size = 16;
            Param.Value = entity.prp_dataCriacao;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.DateTime;
            Param.ParameterName = "@prp_dataAlteracao";
            Param.Size = 16;
            Param.Value = entity.prp_dataAlteracao;
            qs.Parameters.Add(Param);
        }

        /// <summary>
        /// Configura os parametros do metodo de Deletar
        /// </summary>
        /// <param name="qs">Objeto da Store Procedure</param>
        protected override void ParamDeletar(QueryStoredProcedure qs, DCL_ProtocoloReprocesso entity)
        {
            Param = qs.NewParameter();
            Param.DbType = DbType.Guid;
            Param.ParameterName = "@pro_id";
            Param.Size = 16;
            Param.Value = entity.pro_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@prp_seq";
            Param.Size = 4;
            Param.Value = entity.prp_seq;
            qs.Parameters.Add(Param);
        }

        /// <summary>
        /// Recebe o valor do auto incremento e coloca na propriedade 
        /// </summary>
        /// <param name="qs">Objeto da Store Procedure</param>
        protected override bool ReceberAutoIncremento(QuerySelectStoredProcedure qs, DCL_ProtocoloReprocesso entity)
        {
            return false;
        }
    }
}
