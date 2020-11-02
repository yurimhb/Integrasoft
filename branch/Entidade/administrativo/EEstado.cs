using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe Estado que representa a tabela tb_estado
    /// </summary>
    [Serializable]
    public class EEstado
    {
        /// <summary>
        /// ID da tabela de Estado
        /// </summary>
        public int IsnEstado { get; set; }

        /// <summary>
        /// Descrição do Estado
        /// </summary>
        public string DscEstado { get; set; }

        /// <summary>
        /// Sigla do Estado
        /// </summary>
        public string DscSigla { get; set; }

        /// <summary>
        /// Flag de ativação da tabela Estado
        /// </summary>
        public bool FlgAtivo { get; set; }

       
    }
}
