/*
	Classe gerada automaticamente pelo MSTech Code Creator
*/

namespace MSTech.GestaoEscolar.DAL
{
    using Data.Common;
    using MSTech.GestaoEscolar.DAL.Abstracts;
    using Entities;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Description: .
    /// </summary>
    public class CLS_AlunoFrequenciaExternaDAO : Abstract_CLS_AlunoFrequenciaExternaDAO
	{
        #region Consultas

        public DataTable SelecionaPor_MatriculasDisciplinaPeriodo(DataTable tbMatriculaTurmaDisciplina, int tpc_id)
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_CLS_AlunoFrequenciaExterna_SelectBy_MatriculasDisciplinaPeriodo", _Banco);

            #region PARAMETROS

            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = "@tbMatriculaTurmaDisciplina";
            sqlParam.SqlDbType = SqlDbType.Structured;
            sqlParam.TypeName = "TipoTabela_AlunoMatriculaTurmaDisciplina";
            sqlParam.Value = tbMatriculaTurmaDisciplina;
            qs.Parameters.Add(sqlParam);
            
            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@tpc_id";
            Param.Size = 4;
            Param.Value = tpc_id;
            qs.Parameters.Add(Param);

            #endregion PARAMETROS

            qs.Execute();

            return qs.Return;
        }

        /// <summary>
        /// Seleciona os dados para lançamento de frequencia externa do aluno
        /// </summary>
        /// <param name="alu_id">ID do aluno</param>
        /// <param name="mtu_id">ID da matrícula turma do aluno</param>
        /// <returns></returns>
        public DataTable SelecionaDadosAlunoLancamentoFrequenciaExterna(long alu_id, int mtu_id)
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_CLS_AlunoFrequenciaExterna_DadosAlunoLancamentoFrequenciaExterna", _Banco);

            try
            {
                #region Parâmetros

                Param = qs.NewParameter();
                Param.ParameterName = "@alu_id";
                Param.DbType = DbType.Int64;
                Param.Size = 8;
                Param.Value = alu_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.ParameterName = "@mtu_id";
                Param.DbType = DbType.Int32;
                Param.Size = 4;
                Param.Value = mtu_id;
                qs.Parameters.Add(Param);

                #endregion Parâmetros

                qs.Execute();

                return qs.Return;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }

        #endregion

        #region Métodos sobrescritos

        protected override void ParamInserir(QuerySelectStoredProcedure qs, CLS_AlunoFrequenciaExterna entity)
        {
            entity.afx_dataCriacao = entity.afx_dataAlteracao = DateTime.Now;
            base.ParamInserir(qs, entity);

            if (entity.afx_qtdFaltas > -1)
            {
                qs.Parameters["@afx_qtdFaltas"].Value = entity.afx_qtdFaltas;
            }
            else
            {
                qs.Parameters["@afx_qtdFaltas"].Value = DBNull.Value;
            }
        }

        protected override void ParamAlterar(QueryStoredProcedure qs, CLS_AlunoFrequenciaExterna entity)
        {
            entity.afx_dataAlteracao = DateTime.Now;
            base.ParamAlterar(qs, entity);
            qs.Parameters.RemoveAt("@afx_dataCriacao");

            if (entity.afx_qtdFaltas > -1)
            {
                qs.Parameters["@afx_qtdFaltas"].Value = entity.afx_qtdFaltas;
            }
            else
            {
                qs.Parameters["@afx_qtdFaltas"].Value = DBNull.Value;
            }
        }

        protected override bool Alterar(CLS_AlunoFrequenciaExterna entity)
        {
            __STP_UPDATE = "NEW_CLS_AlunoFrequenciaExterna_UPDATE";
            return base.Alterar(entity);
        }

        protected override void ParamDeletar(QueryStoredProcedure qs, CLS_AlunoFrequenciaExterna entity)
        {
            base.ParamDeletar(qs, entity);

            Param = qs.NewParameter();
            Param.DbType = DbType.Byte;
            Param.ParameterName = "@afx_situacao";
            Param.Size = 1;
            Param.Value = 3;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.DateTime;
            Param.ParameterName = "@afx_dataAlteracao";

            Param.Value = DateTime.Now;
            qs.Parameters.Add(Param);
        }

        public override bool Delete(CLS_AlunoFrequenciaExterna entity)
        {
            __STP_DELETE = "NEW_CLS_AlunoFrequenciaExterna_UpdateSituacao";
            return base.Delete(entity);
        }

        protected override bool ReceberAutoIncremento(QuerySelectStoredProcedure qs, CLS_AlunoFrequenciaExterna entity)
        {
            if (entity != null & qs != null)
            {
                entity.afx_id = Convert.ToInt32(qs.Return.Rows[0][0]);
                return entity.afx_id > 0;
            }

            return false;
        }

        #endregion Métodos sobrescritos
    }
}