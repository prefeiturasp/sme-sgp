/*
	Classe gerada automaticamente pelo MSTech Code Creator
*/

namespace MSTech.GestaoEscolar.Entities.Abstracts
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.ComponentModel;
	using MSTech.Data.Common.Abstracts;
	using MSTech.Validation;
	
	/// <summary>
	/// Description: .
	/// </summary>
	[Serializable]
    public abstract class AbstractACA_CurriculoControleSemestralDisciplinaPeriodo : Abstract_Entity
    {
		
		/// <summary>
		/// ID Curso.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual int cur_id { get; set; }

		/// <summary>
		/// ID Curriculo.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual int crr_id { get; set; }

		/// <summary>
		/// ID CurriculoPeriodo.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual int crp_id { get; set; }

		/// <summary>
		/// ID CurriculoPeriodoVigencia.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual int vig_id { get; set; }

		/// <summary>
		/// ID Disciplina.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual int dis_id { get; set; }

		/// <summary>
		/// ID TipoPeriodoCalendario.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual int tpc_id { get; set; }

		/// <summary>
		/// Se vai ou não mostrar a frequência do aluno.
		/// </summary>
		public virtual bool csp_frequencia { get; set; }

		/// <summary>
		/// Se vai ou não mostrar a nota do aluno.
		/// </summary>
		public virtual bool csp_nota { get; set; }

    }
}