﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Estoque.DAL.Persistence;
using Estoque.Entity.Entities;

namespace Estoque.Site.Admin
{
    public partial class CadastroProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropDownList();
                DropDownFornecedor.Items.Insert(0, new ListItem("Selecione o Fornecedor", ""));
                DropDownFornecedor.SelectedIndex = 0;
            }
        }

        protected void dropDownList()
        {
            FornecedorDal d = new FornecedorDal();
            DropDownFornecedor.DataSource = d.FindAll();
            DropDownFornecedor.DataTextField = "Nome";
            DropDownFornecedor.DataValueField = "IdFornecedor";
            DropDownFornecedor.DataBind();
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {

                Produto p = new Produto();

                p.IdFornecedor = Convert.ToInt32(DropDownFornecedor.SelectedValue);
                p.Nome = txtNome.Text;
                p.Preco = Convert.ToDecimal(txtPreco.Text);
                p.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                p.Descricao = txtDescricao.Text;


                ProdutoDal d = new ProdutoDal();
                d.Insert(p);

                lblMensagem.Text = "Produto " + p.Nome + ", cadastrado com sucesso";

                txtNome.Text = string.Empty;
                txtPreco.Text = string.Empty;
                txtQuantidade.Text = string.Empty;
                txtDescricao.Text = string.Empty;
                DropDownFornecedor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }

        }
    }
}