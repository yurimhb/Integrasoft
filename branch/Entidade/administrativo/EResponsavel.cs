using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela Responsavel
    /// </summary>
    public class EResponsavel
    {
        /// <summary>
        /// Id de responsavel
        /// </summary>
        public int IsnResponsavel { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Relacionamento com Pessoa
        /// </summary>
        public EPessoa pessoa { get; set; }

        /// <summary>
        /// Relacionamento com Empresa
        /// Responsavel daquela empresa
        /// </summary>
        public EEmpresa empresa { get; set; }
    }
}
