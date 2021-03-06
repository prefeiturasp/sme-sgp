USE [GestaoPedagogica]
GO

	DECLARE @tce_id_cieja INT = (SELECT tce_id FROM ESC_TipoClassificacaoEscola WHERE tce_nome = 'CIEJA')

	UPDATE ESC_Escola
	SET esc_controleSistema = 1
	FROM ESC_Escola ESC WITH(NOLOCK)
	INNER JOIN ESC_EscolaClassificacao ECL WITH(NOLOCK)
		ON ECL.esc_id = ESC.esc_id
	INNER JOIN ESC_TipoClassificacaoEscola TCE WITH(NOLOCK)
		ON TCE.tce_id = ECL.tce_id
		AND TCE.tce_id = @tce_id_cieja

GO

