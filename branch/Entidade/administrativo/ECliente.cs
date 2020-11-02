using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela tb_cliente
    /// </summary>
    [Serializable]
    public class ECliente
    {
        /// <summary>
        /// Id Cliente
        /// </summary>
        public int IsnCliente { get; set; }     

        /// <summary>
        /// Nome da operadora do cartão
        /// Visa ou Master
        /// </summary>
        public string DscCartaoCredito { get; set; }

        /// <summary>
        /// Numero do Cartão de Crédito
        /// </summary>
        public string DscNumeroCartao { get; set; }

        /// <summary>
        /// Validade do cartão de Crédito
        /// </summary>
        public string DscValidadeCartao { get; set; }

        /// <summary>
        /// Código de segurança
        /// </summary>
        public string DscCodigoSeguranca { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }

        ///// <summary>
        ///// Relacionamento com Pessoa
        ///// </summary>
        public EPessoa pessoa { get; set; }

        ///// <summary>
        ///// Relacionamento com Empresa
        ///// Empresa na qual o cliente faz parte
        ///// </summary>
        public EEmpresa empresa { get; set; }
    }
}
