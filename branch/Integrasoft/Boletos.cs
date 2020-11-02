using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Boletos
/// </summary>
public class Boletos
{
    public Boletos()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Calcular o digito verificador dos campos da linha digitavel
    /// </summary>
    /// <param name="strNumero">Numero a ser calculado</param>
    /// <returns>Retorna o digito verificador</returns>
    private int Calculo_Dv10(string strNumero)
    {
        int numero = 0;
        int fator = 2;
        int total = 0;
        int TotalCaracter = strNumero.Length;

        for (int i = TotalCaracter - 1; i > -1; i--)
        {
            numero = Int32.Parse(strNumero.Substring(i, 1)) * fator;

            if (numero > 9)
            {
                string somadois = numero.ToString();
                int num1 = Int32.Parse(somadois.Substring(0, 1));
                int num2 = Int32.Parse(somadois.Substring(1, 1));
                numero = num1 + num2;
            }

            total = total + numero;

            if (fator == 2)
            {
                fator = 1;
            }
            else
            {
                fator = 2;
            }
        }

        int resto = total % 10;
        resto = 10 - resto;

        if (resto == 10)
        {
            return 0;
        }
        else
        {
            return resto;
        }
    }

    /// <summary>
    /// Calcula o digito verificador do código de barras
    /// </summary>
    /// <param name="sequencia">varivel para calculo</param>
    /// <returns>retorna o digito verificador</returns>
    private int Calculo_DivCodBarras(string sequencia)
    {
        int intNumero;
        int intTotalNumero = 0;
        int intMultiplicador;
        int intResto;
        int intResultado;
        string strCaracter;
        int num = sequencia.Length;

        intMultiplicador = 2;

        for (int i = num - 1; i > -1; i--)
        {
            strCaracter = sequencia.Substring(i, 1);
            if (intMultiplicador > 9)
            {
                intMultiplicador = 2;
                intNumero = 0;
            }
            intNumero = Int32.Parse(strCaracter) * intMultiplicador;
            intTotalNumero = intTotalNumero + intNumero;
            intMultiplicador = intMultiplicador + 1;
        }
        intResto = intTotalNumero % 11;
        intResultado = 11 - intResto;
        if ((intResultado == 10) || (intResultado == 11))
        {
            return 1;
        }
        else
        {
            return intResultado;
        }

    }

    /// <summary>
    /// Calcula o Fator da Data
    /// </summary>
    /// <param name="Data">Variavel com a data a ser calculada</param>
    /// <returns>Retorna o fator data</returns>
    private string Calculo_FatorData(string Data)
    {
        string Datas;
        DateTime data1 = Convert.ToDateTime(Data);
        DateTime data2 = Convert.ToDateTime("03/07/2000");
        int DiferenteDias = data1.Subtract(data2).Days + 1000;
        Datas = DiferenteDias.ToString();
        return Datas;
    }

    /// <summary>
    /// Calcula o valor do boleto já com os zeros a esquerda
    /// </summary>
    /// <param name="strValor">Valor da Fatura</param>
    /// <returns>Retorna a valor com os zeros a esquerda</returns>
    private string Calculo_ValorBoleto(string strValor)
    {
        decimal valorbruto = Decimal.Parse(strValor) * 100;
        decimal inteiro = Decimal.Truncate(valorbruto);
        int numerocaracter = inteiro.ToString().Length;
        numerocaracter = 10 - numerocaracter;
        string strValorInteiro = inteiro.ToString();
        for (int i = 1; i <= numerocaracter; i++)
        {
            strValorInteiro = "0" + strValorInteiro;
        }
        return strValorInteiro;
    }

    /// <summary>
    /// Função que gera a linha editável
    /// </summary>
    /// <param name="strRefCliente">Referencia do Cliente</param>
    /// <param name="strValor">Valor da Fatura</param>
    /// <param name="strDataVencimento">Data a Vencer</param>
    /// <returns>Retorna a propria linha editável</returns>
    public string Calculo_LinhaEditavel(string strRefCliente, string strValor, string strDataVencimento)
    {
        string strNBanco = "001";
        string strCodMoeda = "9";
        string strCVT = "0";
        string str1pCodCliente = "0000";
        string str2pCodCliente = "011";
        string strVago = "58";
        string strDv1, strDv2, strDv3, strDvCB;
        string strLD, strG1, strG2, strG3, strG4, strG5;
        string strRef1, strRef2;
        string strFV, strCodBarraCal, strValorComZeros;

        strFV = Calculo_FatorData(strDataVencimento);
        strValorComZeros = Calculo_ValorBoleto(strValor);

        //Grupo 1
        strLD = strNBanco + strCodMoeda + strCVT + str1pCodCliente;
        strDv1 = Calculo_Dv10(strLD).ToString();
        strG1 = strLD + strDv1;

        //Grupo 2
        strRef1 = strRefCliente.Substring(0, 9);
        //strLD = str2pCodCliente + strVago + strRef1;
        strLD = "0" + strRef1;
        strDv2 = Calculo_Dv10(strLD).ToString();
        strG2 = strLD + strDv2;

        //Grupo 3
        strRef2 = strRefCliente.Substring(9, 10);
        strDv3 = Calculo_Dv10(strRef2).ToString();
        strG3 = strRef2 + strDv3;

        //Grupo 4
        strCodBarraCal = strNBanco + strCodMoeda + strFV + strValorComZeros + strCVT + str1pCodCliente + str2pCodCliente + strVago + strRefCliente;
        strDvCB = Calculo_DivCodBarras(strCodBarraCal).ToString();
        strG4 = strDvCB;


        //Grupo 5
        strG5 = strFV + strValorComZeros;


        //String final da linha digitavel
        strLD = strG1.Substring(0, 5) + "." + strG1.Substring(5, 5) + " " + strG2.Substring(0, 5) + "." + strG2.Substring(5, 6);
        strLD += " " + strG3.Substring(0, 5) + "." + strG3.Substring(5, 6) + " " + strG4 + " " + " " + " " + strG5;

        return strLD;

    }

    /// <summary>
    /// Função que monta a string do codigo de barras
    /// </summary>
    /// <param name="strRefCliente">Referencia do Cliente</param>
    /// <param name="strValor">Valor da Fatura</param>
    /// <param name="strDataVencimento">Data a Vencer</param>
    /// <returns>retorna a string do codigo de barras</returns>
    public string Monta_CodBarras(string strRefCliente, string strValor, string strDataVencimento)
    {
        string strNBanco = "001";
        string strCodMoeda = "9";
        string strCVT = "0";
        string str1pCodCliente = "0000";
        //string str2pCodCliente = "011";
        //string strVago = "58";
        string strDvCB, strMonta;
        string strFV, strCodBarraCal, strValorComZeros;

        strFV = Calculo_FatorData(strDataVencimento);
        strValorComZeros = Calculo_ValorBoleto(strValor);

        //strCodBarraCal = strNBanco + strCodMoeda + strFV + strValorComZeros + strCVT + str1pCodCliente + str2pCodCliente + strVago + strRefCliente;
        strCodBarraCal = strNBanco + strCodMoeda + strFV + strValorComZeros + strCVT + str1pCodCliente + strRefCliente;
        strDvCB = Calculo_DivCodBarras(strCodBarraCal).ToString();

        //strMonta = strNBanco + strCodMoeda + strDvCB + strFV + strValorComZeros + strCVT + str1pCodCliente + str2pCodCliente + strVago + strRefCliente;
        strMonta = strNBanco + strCodMoeda + strDvCB + strFV + strValorComZeros + strCVT + str1pCodCliente + strRefCliente;

        return strMonta;
    }
}
