using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dotnetraptors.Brazil.Boleto;
using Facade.administrativo;


namespace Integrasoft.Administracao
{
    public partial class WebBoleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            FBloqueto connBloqueto = new FBloqueto();

            string strCB = connBloqueto.CodigoBarras();
            string strLD = connBloqueto.LinhaDigitavel(strCB);            

            //string DataAtual = System.DateTime.Now.ToString("dd/MM/yyyy");          

            string DataAtual = "22/02/2012";

            Boleto bolBB = new BoletoBrasil();

            bolBB.Aceite = "sim";
            bolBB.CedenteAgencia = "3474";
            bolBB.CedenteConta = "33228";
            bolBB.CedenteContaDV = "3";
            bolBB.CedenteNome = "Integra Softwares Soluções e Serviços Ltda";
            bolBB.Carteira = 17;
            bolBB.Instrucao1 = "Não aceitar após vencimento";
           
            bolBB.Sequencial = 000002; //variavel
            bolBB.Documento = "00000001";
            bolBB.Contrato = 2338947;
            bolBB.DtDocumento = Convert.ToDateTime(DataAtual);
            bolBB.DtEmissao = Convert.ToDateTime(DataAtual);
            bolBB.DtProcessamento = Convert.ToDateTime(DataAtual);
            bolBB.DtVencimento = Convert.ToDateTime(DataAtual).AddDays(1);
            bolBB.Valor = 5;//float.Parse(dtInscrito.Rows[0][61].ToString()); 

            bolBB.SacadoNome = "Daniel Teófilo Vasconcelos"; //variavel
            bolBB.SacadoEndereco = "Rua Recanto do Passaré 107"; //variavel
            bolBB.SacadoCPF_CNPJ = "76976076387";  //varicael
            bolBB.SacadoCidade = "Fortaleza";  //variavel
            bolBB.SacadoUF = "CE";  //variavel
            bolBB.SacadoBairro = "Passaré"; //variavel
            bolBB.SacadoCEP = "60744-050"; //variavel

            //Adaptação
            DateTime dtData = Convert.ToDateTime(DataAtual).AddDays(1);
            DataAtual = dtData.ToString("dd/MM/yyyy");
            string Ref = "2338947000000020000";
            Ref = Ref + 18;

            //Boletos connBoletos = new Boletos();
            // string strLinha = connBoletos.Calculo_LinhaEditavel(Ref, "5", DataAtual);
            //string strCodBarras = connBoletos.Monta_CodBarras(Ref, "5", DataAtual);

           // Boletos connBoletos = new Boletos();
           // string strLinha = connBoletos.Calculo_LinhaEditavel(Ref, "5", DataAtual);
            //string strCodBarras = connBoletos.Monta_CodBarras(Ref, "5", DataAtual);


            HTMLBoleto geraBoleto = new HTMLBoleto();
            geraBoleto.ImagesFolder = "imagesBoleto";

            //geraBoleto.AddBoleto(bolBB, strLinha, strCodBarras);
            //geraBoleto.AddBoleto(bolBB, strLD, strCB);

            //geraBoleto.AddBoleto(bolBB, strLinha, strCodBarras);
            geraBoleto.AddBoleto(bolBB, strLD, strCB);  

            Response.Write(geraBoleto.ToString());

          
        }
    }
}