using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela tb_usuario_sistema
    /// Classe usada para definir um perfil de um sistema para um usuario
    /// </summary>
    [Serializable]
    public class EUsuarioSistema
    {
        /// <summary>
        /// Id de usuarioSistema
        /// </summary>
        public int IsnUsuarioSistema { get; set; }

        /// <summary>
        /// Flag de Ativação
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Relacionamento com a classe Usuario
        /// </summary>
        public EUsuario usuario { get; set; }

        /// <summary>
        /// Relacionamento com a classe Perfil
        /// </summary>
        public EPerfil perfil { get; set; }

        /// <summary>
        /// Relacionamento com a classe Sistema
        /// </summary>
        public ESistema sistema { get; set; }
    }
}
