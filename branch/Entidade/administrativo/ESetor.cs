using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{    
    /// <summary>
    /// Classe Setor que representa a tabela tb_setor
    /// </summary>
    [Serializable]
    public class ESetor
    {
        /// <summary>
        /// ID da tabela tb_setor
        /// </summary>
        public int IsnSetor { get; set; }

        /// <summary>
        /// descrição do Setor
        /// </summary>
        public string DscSetor { get; set; }

        /// <summary>
        /// Flag de ativação de setor
        /// </summary>
        public bool FlgAtivo { get; set; }
    }
}
