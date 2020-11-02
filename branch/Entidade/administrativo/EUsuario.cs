using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela tb_usuario
    /// </summary>
    [Serializable]
    public class EUsuario
    {
        /// <summary>
        /// Id Usuario
        /// </summary>
        public int IsnUsuario { get; set; }

        /// <summary>
        /// Login do usuario
        /// </summary>
        public string DscLogin { get; set; }

        /// <summary>
        /// Senha do usuario
        /// </summary>
        public string DscSenha { get; set; }

        /// <summary>
        /// data de criação
        /// </summary>
        public DateTime DthCriacao { get; set; }

        /// <summary>
        /// Data da ultima autenticacao do usuario
        /// </summary>
        public DateTime DthUltimaAutenticacao { get; set; }

        /// <summary>
        /// Numero de acessoa ao sistema
        /// </summary>
        public int Contador { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Relacionamento com Pessoa
        /// </summary>
        public EPessoa pessoa { get; set; }
    }
}
