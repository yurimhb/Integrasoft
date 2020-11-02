using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela tb_perfil
    /// </summary>
    [Serializable]
    public class EPerfil
    {
        /// <summary>
        /// Id de Perfil
        /// </summary>
        public int IsnPerfil { get; set; }

        /// <summary>
        /// Descrição do Perfil
        /// </summary>
        public string DscPerfil { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }
    }
}
