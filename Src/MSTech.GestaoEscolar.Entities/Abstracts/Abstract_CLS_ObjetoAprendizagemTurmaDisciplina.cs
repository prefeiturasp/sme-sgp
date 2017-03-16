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
    public abstract class Abstract_CLS_ObjetoAprendizagemTurmaDisciplina : Abstract_Entity
    {
		
		/// <summary>
		/// Propriedade tud_id.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual long tud_id { get; set; }

		/// <summary>
		/// Propriedade tpc_id.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual int tpc_id { get; set; }

		/// <summary>
		/// Propriedade oap_id.
		/// </summary>
		[MSNotNullOrEmpty]
		[DataObjectField(true, false, false)]
		public virtual int oap_id { get; set; }

    }
}