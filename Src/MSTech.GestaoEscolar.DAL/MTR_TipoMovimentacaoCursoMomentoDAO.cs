/*
	Classe gerada automaticamente pelo MSTech Code Creator
*/

using System;
using System.Data;
using MSTech.Data.Common;
using MSTech.GestaoEscolar.Entities;
using MSTech.GestaoEscolar.DAL.Abstracts;

namespace MSTech.GestaoEscolar.DAL
{
	
	/// <summary>
	/// 
	/// </summary>
	public class MTR_TipoMovimentacaoCursoMomentoDAO : Abstract_MTR_TipoMovimentacaoCursoMomentoDAO
    {
        #region Métodos de consulta

        /// <summary>
        /// Retorna todos os momentos do parâmetro de movimentação não excluídos logicamente
        /// </summary>                
        /// <param name="tmo_id">ID do parâmetro de movimentação</param>        
        public DataTable SelectBy_tmo_id
        (
            int tmo_id
        )
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_MTR_TipoMovimentacaoCursoMomento_SelectBy_tmo_id", _Banco);
            try
            {
                #region PARAMETROS

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@tmo_id";
                Param.Size = 4;                
                Param.Value = tmo_id;
                qs.Parameters.Add(Param);

                #endregion

                qs.Execute();

                return qs.Return;
            }
            catch
            {
                throw;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }

        /// <summary>
        /// Retorna os momentos do parâmetro de movimentação por tipo de movimentção e ano letivo dos momentos de movimentação.
        /// </summary>
        /// <param name="tmo_id">ID do tipo de movimentação.</param>
        /// <param name="mom_ano">Ano letivo do momento de movimentação.</param>
        /// <param name="mom_id">ID do momento de movimentação.</param>
        /// <param name="ent_id">ID da entidade do usuário logado.</param>
        /// <returns></returns>
        public DataTable SelecionaPorTipoMovimentacaoMomentoAno(int tmo_id, int mom_ano, int mom_id, Guid ent_id)
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_MTR_TipoMovimentacaoCursoMomento_SelecionaPorTipoMovimentacaoMomentoAno", _Banco);

            try
            {
                #region Parâmetros

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@tmo_id";
                Param.Size = 4;
                Param.Value = tmo_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@mom_ano";
                Param.Size = 4;
                Param.Value = mom_ano;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@mom_id";
                Param.Size = 4;
                Param.Value = mom_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.DbType = DbType.Guid;
                Param.ParameterName = "@ent_id";
                Param.Size = 16;
                Param.Value = ent_id;
                qs.Parameters.Add(Param);

                #endregion

                qs.Execute();

                return qs.Return;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }

        #endregion

        #region Métodos Sobrescritos

        /// <summary>
        /// Override do nome da ConnectionString.
        /// </summary>
        protected override string ConnectionStringName
        {
            get
            {
                return "GestaoEscolar";
            }
        }

        /// <summary>
        /// Override do método inserir
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="entity"></param>
        protected override void ParamInserir(QuerySelectStoredProcedure qs, MTR_TipoMovimentacaoCursoMomento entity)
        {
            base.ParamInserir(qs, entity);

            qs.Parameters["@tcm_dataCriacao"].Value = DateTime.Now;
            qs.Parameters["@tcm_dataAlteracao"].Value = DateTime.Now;
        }

        /// <summary>
        /// Override do método alterar
        /// </summary>
        protected override void ParamAlterar(QueryStoredProcedure qs, MTR_TipoMovimentacaoCursoMomento entity)
        {
            base.ParamAlterar(qs, entity);

            qs.Parameters.RemoveAt("@tcm_dataCriacao");
            qs.Parameters["@tcm_dataAlteracao"].Value = DateTime.Now;
        }

        /// <summary>
        /// Método alterado para que o update não faça a alteração da data de criação
        /// </summary>
        /// <param name="entity"> Entidade MTR_TipoMovimentacaoCursoMomento</param>
        /// <returns>true = sucesso | false = fracasso</returns>  
        protected override bool Alterar(MTR_TipoMovimentacaoCursoMomento entity)
        {
            __STP_UPDATE = "NEW_MTR_TipoMovimentacaoCursoMomento_UPDATE";
            return base.Alterar(entity);
        }

        /// <summary>
        /// Parâmetros para efetuar a exclusão lógica.
        /// </summary>
        protected override void ParamDeletar(QueryStoredProcedure qs, MTR_TipoMovimentacaoCursoMomento entity)
        {
            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@tmo_id";
            Param.Size = 4;
            Param.Value = entity.tmo_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@cur_id";
            Param.Size = 4;
            Param.Value = entity.cur_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@crr_id";
            Param.Size = 4;
            Param.Value = entity.crr_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@tcm_id";
            Param.Size = 4;
            Param.Value = entity.tcm_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Byte;
            Param.ParameterName = "@tcm_situacao";
            Param.Size = 1;
            Param.Value = 3;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.DateTime;
            Param.ParameterName = "@tcm_dataAlteracao";
            Param.Size = 8;
            Param.Value = DateTime.Now;
            qs.Parameters.Add(Param);
        }

        /// <summary>
        /// Método alterado para que o delete não faça exclusão física e sim lógica (update).
        /// </summary>
        /// <param name="entity"> Entidade MTR_TipoMovimentacaoCursoMomento</param>
        /// <returns>true = sucesso | false = fracasso</returns>        
        public override bool Delete(MTR_TipoMovimentacaoCursoMomento entity)
        {
            __STP_DELETE = "NEW_MTR_TipoMovimentacaoCursoMomento_Update_Situacao";
            return base.Delete(entity);
        }

        #endregion

        #region Comentados

		///// <summary>
        ///// Inseri os valores da classe em um registro ja existente
        ///// </summary>
        ///// <param name="entity">Entidade com os dados a serem modificados</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //protected override bool Alterar(MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    return base.Alterar(entity);
        //}
        ///// <summary>
        ///// Inseri os valores da classe em um novo registro
        ///// </summary>
        ///// <param name="entity">Entidade com os dados a serem inseridos</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //protected override bool Inserir(MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    return base.Inserir(entity);
        //}
        ///// <summary>
        ///// Carrega um registro da tabela usando os valores nas chaves
        ///// </summary>
        ///// <param name="entity">Entidade com os dados a serem carregados</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //public override bool Carregar(MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    return base.Carregar(entity);
        //}
        ///// <summary>
        ///// Exclui um registro do banco
        ///// </summary>
        ///// <param name="entity">Entidade com os dados a serem apagados</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //public override bool Delete(MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    return base.Delete(entity);
        //}
        ///// <summary>
        ///// Configura os parametros do metodo de Alterar
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados para preenchimento dos parametros</param>
        //protected override void ParamAlterar(QueryStoredProcedure qs, MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    base.ParamAlterar(qs, entity);
        //}
        ///// <summary>
        ///// Configura os parametros do metodo de Carregar
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados para preenchimento dos parametros</param>
        //protected override void ParamCarregar(QuerySelectStoredProcedure qs, MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    base.ParamCarregar(qs, entity);
        //}
        ///// <summary>
        ///// Configura os parametros do metodo de Deletar
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados para preenchimento dos parametros</param>
        //protected override void ParamDeletar(QueryStoredProcedure qs, MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    base.ParamDeletar(qs, entity);
        //}
        ///// <summary>
        ///// Configura os parametros do metodo de Inserir
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados para preenchimento dos parametros</param>
        //protected override void ParamInserir(QuerySelectStoredProcedure qs, MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    base.ParamInserir(qs, entity);
        //}
        ///// <summary>
        ///// Salva o registro no banco de dados
        ///// </summary>
        ///// <param name="entity">Entidade com os dados para preenchimento para inserir ou alterar</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //public override bool Salvar(MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    return base.Salvar(entity);
        //}
        ///// <summary>
        ///// Realiza o select da tabela
        ///// </summary>
        ///// <returns>Lista com todos os registros da tabela</returns>
        //public override IList<MTR_TipoMovimentacaoCursoMomento> Select()
        //{
        //    return base.Select();
        //}
        ///// <summary>
        ///// Realiza o select da tabela com paginacao
        ///// </summary>
        ///// <param name="currentPage">Pagina atual</param>
        ///// <param name="pageSize">Tamanho da pagina</param>
        ///// <param name="totalRecord">Total de registros na tabela original</param>
        ///// <returns>Lista com todos os registros da p�gina</returns>
        //public override IList<MTR_TipoMovimentacaoCursoMomento> Select_Paginado(int currentPage, int pageSize, out int totalRecord)
        //{
        //    return base.Select_Paginado(currentPage, pageSize, out totalRecord);
        //}
        ///// <summary>
        ///// Recebe o valor do auto incremento e coloca na propriedade 
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //protected override bool ReceberAutoIncremento(QuerySelectStoredProcedure qs, MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    return base.ReceberAutoIncremento(qs, entity);
        //}
        ///// <summary>
        ///// Passa os dados de um datatable para uma entidade
        ///// </summary>
        ///// <param name="dr">DataRow do datatable preenchido</param>
        ///// <param name="entity">Entidade onde ser�o transferidos os dados</param>
        ///// <returns>Entidade preenchida</returns>
        //public override MTR_TipoMovimentacaoCursoMomento DataRowToEntity(DataRow dr, MTR_TipoMovimentacaoCursoMomento entity)
        //{
        //    return base.DataRowToEntity(dr, entity);
        //}
        ///// <summary>
        ///// Passa os dados de um datatable para uma entidade
        ///// </summary>
        ///// <param name="dr">DataRow do datatable preenchido</param>
        ///// <param name="entity">Entidade onde ser�o transferidos os dados</param>
        ///// <param name="limparEntity">Indica se a entidade deve ser limpada antes da transferencia</param>
        ///// <returns>Entidade preenchida</returns>
        //public override MTR_TipoMovimentacaoCursoMomento DataRowToEntity(DataRow dr, MTR_TipoMovimentacaoCursoMomento entity, bool limparEntity)
        //{
        //    return base.DataRowToEntity(dr, entity, limparEntity);
        //}

        #endregion
    }
}