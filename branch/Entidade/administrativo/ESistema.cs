using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe Sistema que representa a tabela tb_sistema
    /// </summary>
    [Serializable]
    public class ESistema
    {
        /// <summary>
        /// ID de Sistema
        /// </summary>
        public int IsnSistema { get; set; }

        /// <summary>
        /// Descrição do Sistema
        /// </summary>
        public string DscSistema { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgSistema { get; set; }
    }
}
