using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe Cidade que representa a tabela tb_cidade
    /// </summary>
    [Serializable]
    public class ECidade
    {
        /// <summary>
        /// ID da tabela Cidade
        /// </summary>
        public int IsnCidade { get; set; }     

        /// <summary>
        /// Descrição da Cidade
        /// </summary>
        public string DscCidade { get; set; }

        /// <summary>
        /// Flag de ativação da tabela Cidade
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Relacionamento com a classe Estado
        /// </summary>
        public EEstado estado { get; set; }

       

       
    }
}
