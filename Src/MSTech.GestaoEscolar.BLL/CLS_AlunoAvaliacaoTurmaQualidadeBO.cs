/*
	Classe gerada automaticamente pelo MSTech Code Creator
*/

namespace MSTech.GestaoEscolar.BLL
{
	using MSTech.Business.Common;
	using MSTech.GestaoEscolar.Entities;
	using MSTech.GestaoEscolar.DAL;
    using System.Data;
    using MSTech.Data.Common;
    using System.Collections.Generic;
    using System.Linq;
    using MSTech.Validation.Exceptions;
	
	/// <summary>
	/// Description: CLS_AlunoAvaliacaoTurmaQualidade Business Object. 
	/// </summary>
	public class CLS_AlunoAvaliacaoTurmaQualidadeBO : BusinessBase<CLS_AlunoAvaliacaoTurmaQualidadeDAO, CLS_AlunoAvaliacaoTurmaQualidade>
    {
        #region Consultas

        /// <summary>
        /// Seleciona os tipo de qualidade por matr�cula do aluno.
        /// </summary>
        /// <param name="tur_id">ID da turma.</param>
        /// <param name="alu_id">ID do aluno.</param>
        /// <param name="mtu_id">ID da matr�cula turma do aluno.</param>
        /// <param name="fav_id">ID do formato de avalia��o.</param>
        /// <param name="ava_id">ID da avalia��o.</param>
        /// <returns></returns>
        public static DataTable SelecionaPorMatriculaTurma(long tur_id, long alu_id, int mtu_id, int fav_id, int ava_id)
        {
            return new CLS_AlunoAvaliacaoTurmaQualidadeDAO().SelecionaPorMatriculaTurma(tur_id, alu_id, mtu_id, fav_id, ava_id);
        }

        /// <summary>
        /// Seleciona uma lista de tipo de qualidade por matr�cula do aluno.
        /// </summary>
        /// <param name="tur_id">ID da turma.</param>
        /// <param name="alu_id">ID do aluno.</param>
        /// <param name="mtu_id">ID da matr�cula turma do aluno.</param>
        /// <param name="fav_id">ID do formato de avalia��o.</param>
        /// <param name="ava_id">ID da avalia��o.</param>
        /// <returns></returns>
        public static List<CLS_AlunoAvaliacaoTurmaQualidade> SelecionaListaPorMatriculaTurma(long tur_id, long alu_id, int mtu_id, int fav_id, int ava_id, TalkDBTransaction banco = null)
        {
            CLS_AlunoAvaliacaoTurmaQualidadeDAO dao = banco == null ?
                                                      new CLS_AlunoAvaliacaoTurmaQualidadeDAO() :
                                                      new CLS_AlunoAvaliacaoTurmaQualidadeDAO { _Banco = banco };

            return (from DataRow dr in dao.SelecionaPorMatriculaTurma(tur_id, alu_id, mtu_id, fav_id, ava_id).Rows
                    select dao.DataRowToEntity(dr, new CLS_AlunoAvaliacaoTurmaQualidade())).ToList();
        }


        #endregion

        #region Saves

        /// <summary>
        /// O m�todo salva as qualidade cadastradas para o aluno e deleta as que forem desmarcadas.
        /// </summary>
        /// <param name="tur_id">ID da turma.</param>
        /// <param name="alu_id">ID do aluno.</param>
        /// <param name="mtu_id">ID da matr�cula turma do aluno.</param>
        /// <param name="fav_id">ID do formato de avalia��o.</param>
        /// <param name="ava_id">ID da avalia��o.</param>
        /// <param name="lista">Lista de qualidades adicionadas</param>
        /// <param name="banco"></param>
        /// <returns></returns>
        public static bool Salvar(long tur_id, long alu_id, int mtu_id, int fav_id, int ava_id, List<CLS_AlunoAvaliacaoTurmaQualidade> lista, TalkDBTransaction banco)
        {
            bool retorno = true;

            List<CLS_AlunoAvaliacaoTurmaQualidade> listaCadastrados = SelecionaListaPorMatriculaTurma(tur_id, alu_id, mtu_id, fav_id, ava_id, banco);
            if (lista.Any())
            {
                List<CLS_AlunoAvaliacaoTurmaQualidade> listaExcluir = !listaCadastrados.Any() ?
                    new List<CLS_AlunoAvaliacaoTurmaQualidade>() : listaCadastrados.Where(p => !lista.Contains(p)).ToList();

                List<CLS_AlunoAvaliacaoTurmaQualidade> listaSalvar = listaCadastrados.Any() ?
                    lista.Where(p => !listaCadastrados.Contains(p)).ToList() : lista;

                retorno &= !listaExcluir.Any() ? retorno : listaExcluir.Aggregate(true, (excluiu, qualidade) => excluiu & Delete(qualidade, banco));
                retorno &= !listaSalvar.Any() ? retorno : listaSalvar.Aggregate(true, (salvou, qualidade) => salvou & Save(qualidade, banco));
            }
            else
            {
                retorno &= !listaCadastrados.Any() ? retorno : listaCadastrados.Aggregate(true, (excluiu, qualidade) => excluiu & Delete(qualidade, banco));
            }

            return retorno;
        }

        /// <summary>
        /// O m�todo salva um registro na tabela CLS_AlunoAvaliacaoTurmaQualidade.
        /// </summary>
        /// <param name="entity">Entidade CLS_AlunoAvaliacaoTurmaQualidade</param>
        /// <param name="banco"></param>
        /// <returns></returns>
        public static new bool Save(CLS_AlunoAvaliacaoTurmaQualidade entity, TalkDBTransaction banco)
        {
            if (entity.Validate())
            {
                return new CLS_AlunoAvaliacaoTurmaQualidadeDAO { _Banco = banco }.Salvar(entity);
            }

            throw new ValidationException(GestaoEscolarUtilBO.ErrosValidacao(entity));
        }

        /// <summary>
        /// O m�todo salva um registro na tabela CLS_AlunoAvaliacaoTurmaQualidade.
        /// </summary>
        /// <param name="entity">Entidade CLS_AlunoAvaliacaoTurmaQualidade</param>
        /// <returns></returns>
        public static new bool Save(CLS_AlunoAvaliacaoTurmaQualidade entity)
        {
            if (entity.Validate())
            {
                return new CLS_AlunoAvaliacaoTurmaQualidadeDAO().Salvar(entity);
            }

            throw new ValidationException(GestaoEscolarUtilBO.ErrosValidacao(entity));
        }

        #endregion
    }
}