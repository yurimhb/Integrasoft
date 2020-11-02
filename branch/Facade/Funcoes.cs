using System;
using System.Data;
using System.Net.Mail;
using System.IO;
using System.Security;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Funcoes
/// </summary>
public class Funcoes
{
    public Funcoes()
    {
        //dadosSeguros = new SecureString();
    }

    public string Senha()
    {
        try
        {
            Guid senha = Guid.NewGuid();

            return senha.ToString().Substring(0, 4);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string ConverterData(string Data)
    {
        try
        {
            string ano = Data.Substring(6, 4);
            string mes = Data.Substring(3, 2);
            string dia = Data.Substring(0, 2);
            string DataMySQL = ano + "-" + mes + "-" + dia;

            return DataMySQL;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void EnviarEmail(string para, string strAssunto, string strMensagem)
    {
        MailMessage Email = new MailMessage();

        Email.From = new MailAddress("admin@Tramites.net", "Site");

        Email.To.Add(para);

        Email.Priority = MailPriority.High;

        Email.IsBodyHtml = true;

        Email.Subject = strAssunto;

        Email.Body = strMensagem;

        SmtpClient Smtp = new SmtpClient();
        Smtp.Host = "mail.Tramites.net";
        Smtp.Port = 25;

        try
        {
            //envia o email
            Smtp.Send(Email);
        }
        catch (SmtpException ex)
        {
            throw ex;
        }
    }

    public void EnviarEmail(string para, string strAssunto, string senha, string strMensagem)
    {
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        mail.To.Add(para);
        mail.From = new MailAddress(para, "Contato - Site", System.Text.Encoding.UTF8);
        mail.Subject = strAssunto;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = strMensagem;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();

        client.Credentials = new System.Net.NetworkCredential(para, senha); // Colocar Senha
        client.Port = 25; // Configurar Porta
        client.Host = "mail.integrasoft.com.br"; // Configurar Host
        //client.EnableSsl = true; // Requerido para enviar para Gmail.
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void EnviarEmail(string strAssunto, string strMsg)
    {
        MailMessage Email = new MailMessage();

        Email.From = new MailAddress("yuri.mhb@gmail.com", "Site");

        Email.To.Add("yuri.mhb@gmail.com");

        Email.Priority = MailPriority.High;

        Email.IsBodyHtml = true;

        Email.Subject = strAssunto;

        Email.Body = strMsg;

        SmtpClient Smtp = new SmtpClient();
        Smtp.Host = "smtp.gmail.com";
        Smtp.Port = 587;

        try
        {
            //envia o email
            Smtp.Send(Email);
        }
        catch (SmtpException ex)
        {
            throw ex;
        }
    }

    public bool ValidaCPFs(string vrCPF)
    {
        string valor = vrCPF.Replace(".", "");
        valor = valor.Replace("-", "");

        if (valor.Length != 11)
        {
            return false;
        }

        bool igual = true;

        for (int i = 1; i < 11 && igual; i++)
        {
            if (valor[i] != valor[0])
            {
                igual = false;
            }
        }


        if (igual || valor == "12345678909")
        {
            return false;
        }

        int[] numeros = new int[11];

        for (int i = 0; i < 11; i++)
        {
            numeros[i] = int.Parse(valor[i].ToString());
        }

        int soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += (10 - i) * numeros[i];
        }

        int resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[9] != 0)
            {
                return false;
            }
        }

        else if (numeros[9] != 11 - resultado)
        {
            return false;
        }

        soma = 0;

        for (int i = 0; i < 10; i++)
        {
            soma += (11 - i) * numeros[i];
        }
        resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[10] != 0)
            {
                return false;
            }
        }
        else if (numeros[10] != 11 - resultado)
        {
            return false;
        }

        return true;

    }

    public bool ValidaCNPJs(string cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;

        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cnpj.Length != 14)
            return false;

        tempCnpj = cnpj.Substring(0, 12);

        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCnpj = tempCnpj + digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cnpj.EndsWith(digito);
    }

    public string GeraDataLimpa()
    {
        string srtData = System.DateTime.Now.ToString();
        srtData = srtData.Replace("/", "");
        srtData = srtData.Replace(":", "");
        srtData = srtData.Replace(" ", "");
        return srtData;
    }

    /// <summary>
    /// Redimensiona imagem
    /// scrPath = path da imagem original
    /// destPath = path para a nova imagem
    /// caso o destPath seja igual ao scrPath, a nova imagem substitui a anterior
    /// </summary>
    public void Resize(string srcPath, string destPath, int nWidth, int nHeight)
    {

        string temp;
        // abre arquivo original
        System.Drawing.Image img = System.Drawing.Image.FromFile(srcPath);
        int oWidth = img.Width; // largura original
        int oHeight = img.Height; // altura original

        // redimensiona se necessario
        if (oWidth > nWidth || oHeight > nHeight)
        {

            if (oWidth > oHeight)
            {
                // imagem horizontal
                nHeight = (oHeight * nWidth) / oWidth;
            }
            else
            {
                // imagem vertical
                nWidth = (oWidth * nHeight) / oHeight;
            }
        }

        // cria a copia da imagem
        System.Drawing.Image imgThumb = img.GetThumbnailImage(nWidth, nHeight, null, new System.IntPtr(0));

        if (srcPath == destPath)
        {
            temp = destPath + ".tmp";
            imgThumb.Save(temp, ImageFormat.Jpeg);
            img.Dispose();
            imgThumb.Dispose();
            File.Delete(srcPath); // deleta arquivo original
            File.Copy(temp, srcPath); // copia a nova imagem
            File.Delete(temp); // deleta temporário
        }
        else
        {
            imgThumb.Save(destPath, ImageFormat.Jpeg); // salva nova imagem no destino
            imgThumb.Dispose(); // libera memoria
            img.Dispose(); // libera memória
        }
    }

    #region SecurityCript
    //static SecureString dadosSeguros;

    //public static bool isReadOnly
    //{
    //    get { return dadosSeguros.IsReadOnly(); }
    //}

    //public static void AddChar(char _char)
    //{
    //    if ((int)_char == 8)
    //        dadosSeguros.RemoveAt(dadosSeguros.Length - 1);
    //    else
    //        dadosSeguros.AppendChar(_char);
    //}

    //public static string getStringSecureDecript()
    //{
    //    return Marshal.PtrToStringBSTR(((IntPtr)getStringSecureCript()));
    //}

    //public static int getStringSecureCript()
    //{
    //    return (int)Marshal.SecureStringToBSTR(dadosSeguros);
    //}

    //public static void MaheReadOnly()
    //{
    //    dadosSeguros.MakeReadOnly();
    //}

    //public static void Dispose()
    //{
    //    dadosSeguros.Dispose();
    //}

    //~Funcoes()
    //{
    //    dadosSeguros.Dispose();
    //}
    #endregion
}

