using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela usuario empresa
    /// Diz em qual empresa aquele usuario pertence
    /// </summary>
    [Serializable]
    public class EUsuarioEmpresa
    {
        /// <summary>
        /// Id de usuarioempresa
        /// </summary>
        public int IsnUsuarioEmpresa { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Relacionamento com Usuario
        /// </summary>
        public EUsuario usuario { get; set; }

        /// <summary>
        /// relacionamento com empresa
        /// </summary>
        public EEmpresa empresa { get; set; }
    }
}
