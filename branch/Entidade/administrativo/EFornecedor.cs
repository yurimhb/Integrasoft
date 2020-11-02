using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela tb_fornecedor
    /// </summary>
    [Serializable]
    public class EFornecedor
    {
        /// <summary>
        /// Id de Fornecedor
        /// </summary>
        public int IsnFornecedor { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Relacionamento com empresa
        /// </summary>
        public EEmpresa Empresa { get; set; }

        /// <summary>
        /// Relacionamento com pessoa
        /// </summary>
        public EPessoa Pessoa { get; set; }     
    }
}
