﻿using MSTech.CoreSSO.BLL;
using MSTech.GestaoEscolar.BLL;
using MSTech.GestaoEscolar.Web.WebProject;
using System;
using System.Data;

namespace GestaoEscolar.Academico.ObjetoAprendizagem
{
    public partial class BuscaDisciplina : MotherPageLogado
    {
        public int tds_id
        {
            get
            {
                return Convert.ToInt32(_grvTipoDisciplina.DataKeys[_grvTipoDisciplina.EditIndex].Value);
            }
        }

        private DataTable VS_Disciplinas
        {
            get
            {
                if (ViewState["VS_Disciplinas"] == null)
                    ViewState["VS_Disciplinas"] = ACA_TipoDisciplinaBO.SelecionaTipoDisciplinaNaoPaginado(__SessionWEB.__UsuarioWEB.Usuario.ent_id);

                return (DataTable)ViewState["VS_Disciplinas"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UCComboTipoNivelEnsino1.MostrarMessageSelecione = true;
                fdsResultados.Visible = false;
            }

        }

        private void LoadGridView()
        {
            try
            {
                string qtItensPagina = SYS_ParametroBO.ParametroValor(SYS_ParametroBO.eChave.QT_ITENS_PAGINACAO);
                int itensPagina = string.IsNullOrEmpty(qtItensPagina) ? ApplicationWEB._Paginacao : Convert.ToInt32(qtItensPagina);

                string filter = string.Empty;

                if (_ddlBase.SelectedIndex > 0 && UCComboTipoNivelEnsino1.Texto != "-- Selecione um nível de ensino --")
                    filter = string.Concat("tds_base_nome = '", _ddlBase.SelectedItem.Text, "' AND tne_nome = '", UCComboTipoNivelEnsino1.Texto, "'");
                else if (_ddlBase.SelectedIndex > 0)
                    filter = string.Concat("tds_base_nome = '", _ddlBase.SelectedItem.Text, "'");
                else if (UCComboTipoNivelEnsino1.Texto != "-- Selecione um nível de ensino --")
                    filter = string.Concat("tne_nome = '", UCComboTipoNivelEnsino1.Texto, "'");

                _grvTipoDisciplina.PageSize = itensPagina;
                _grvTipoDisciplina.DataSource = VS_Disciplinas.Select(filter).CopyToDataTable();
                _grvTipoDisciplina.DataBind();
            }
            catch (Exception ex)
            {
                ApplicationWEB._GravaErro(ex);
                _lblMessage.Text = UtilBO.GetErroMessage("Erro ao carregar tipos de disciplinas.", UtilBO.TipoMensagem.Erro);
            }
        }

        protected void _btnPesquisar_Click(object sender, EventArgs e)
        {
            LoadGridView();

            fdsResultados.Visible = true;
        }

        protected void _btnLimparPesquisa_Click(object sender, EventArgs e)
        {
            UCComboTipoNivelEnsino1.Valor = -1;
            _ddlBase.SelectedValue = "-1";

            fdsResultados.Visible = false;
        }

        protected void _grvTipoDisciplina_DataBound(object sender, EventArgs e)
        {
            UCTotalRegistros1.Total = _grvTipoDisciplina.Rows.Count;
        }

        protected void _grvTipoDisciplina_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            _grvTipoDisciplina.EditIndex = e.NewEditIndex;
        }
    }
}