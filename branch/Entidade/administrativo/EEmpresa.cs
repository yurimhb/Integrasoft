using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela tb_empresa
    /// </summary>
    [Serializable]
    public class EEmpresa
    {
        /// <summary>
        /// Id da Empresa
        /// </summary>
        public int IsnEmpresa { get; set; }

        /// <summary>
        /// Mapeamento com a classe Pessoa
        /// </summary>
        public EPessoa pessoa { get; set; }

        /// <summary>
        /// Flag quando positivo é Matriz
        /// </summary>
        public bool FlgMatriz { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }
    }
}
