using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Model;
using Proxy;

namespace ProjetoWebOO
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReloadTable();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            var pizza = new Pizza()
            {
                Descricao = txtDesc.Text
            };

            if (this.Crud().Insert(pizza))
            {
                lblMSG.Text = "Pedido Inserido com Sucesso!";
                SaveLog("Pedido Inserido com Sucesso!");
                ReloadTable();
            }
            else
            {
                lblMSG.Text = "Erro ao inserir pedido!";
                SaveLog("Erro ao inserir pedido!");
            }
        }

        private void ReloadTable()
        {
            GVPizza.DataSource = this.Crud().Select();
            GVPizza.DataBind();
            SaveLog("Consultou Informações");
        }

        private IPizzaDB Crud()
        {
            return new PizzaDB();
        }

        private void SaveLog(string msg)
        {
            IMonitore proxy = new Proxy.Proxy(new LogDB());
            proxy.SaveLog(msg);
        }

        private List<Log> GetLogs()
        {
            IMonitore proxy = new Proxy.Proxy(new LogDB());
            return proxy.Select();
        }

        protected void btnLogs_Click(object sender, EventArgs e)
        {
            GVLog.DataSource = GetLogs();
            GVLog.DataBind();
            SaveLog("Consultou Logs");
        }

        protected void btnLogss_Click(object sender, EventArgs e)
        {
            GVLog.DataSource = GetLogs();
            GVLog.DataBind();
            SaveLog("Consultou Logs");
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            txtDesc.Text = "";
            txtValor.Text = "";
            lblMSG.Text = "";
            GVLog.DataSource = null;
            GVLog.DataBind();
            txtDesc.Focus();
            txtValor.Focus();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            var pizza = new Pizza()
            {
                Descricao = txtDesc.Text,
            };

            new PizzaDB().Delete(pizza);

            lblMSG.Text = "Pedido Excluído com Sucesso!";
            GVPizza.DataSource = new PizzaDB().Select();
            GVPizza.DataBind();
        }
    }
}