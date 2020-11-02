using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe Cargo que representa a tabela tb_cargo
    /// </summary>  
    public class ECargo
    {
        /// <summary>
        /// ID da Tabela Cargo
        /// </summary>
        public int IsnCargo { get; set; }

        /// <summary>
        /// Descrição do Cargo
        /// </summary>
        public string DscCargo { get; set; }

        /// <summary>
        /// Flag de ativação da tabela cargo
        /// </summary>
        public bool FlgAtivo { get; set; }
    }
}
