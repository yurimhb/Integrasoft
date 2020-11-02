using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrasoft.Flash.flash
{
    public partial class teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Funcoes func = new Funcoes();

            String nome = Request.QueryString["t1"];
            String email = Request.QueryString["t2"];
            String telefone = Request.QueryString["t3"];
            String mensagem = Request.QueryString["t4"];

            String corpomail = "<br/>";
            corpomail += "Nome: " + nome.Trim() + " <br/>";
            corpomail += "Email: " + email.Trim() + " <br/>";
            corpomail += "Tel: " + telefone.Trim() + " <br/>";
            corpomail += "Descricao: " + mensagem.Trim() + " <br/>";

            func.EnviarEmail("comercial@integrasoft.com.br", "Fale Conosco - Site", "cmrcmr", corpomail);

            
        }
    }
}