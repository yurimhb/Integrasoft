using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela tb_estado_civil
    /// </summary>
    [Serializable]
    public class EEstadoCivil
    {
        /// <summary>
        /// ID de Sistema
        /// </summary>
        public int IsnEstadoCivil { get; set; }

        /// <summary>
        /// Descrição de Sistema
        /// </summary>
        public string DscEstadoCivil { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }
    }
}
