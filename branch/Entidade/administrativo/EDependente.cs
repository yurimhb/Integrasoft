using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela tb_dependente
    /// </summary>
    [Serializable]
    public class EDependente
    {
        /// <summary>
        /// Id de Dependente
        /// </summary>
        public int IsnDependente { get; set; }

        /// <summary>
        /// Descrição de Parentesco
        /// </summary>
        public string DscParentesco { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Relacionamento com funcionario
        /// </summary>
        public EFuncionario Funcionario { get; set; }

        /// <summary>
        /// Relacionamento com Pessoa
        /// </summary>
        public EPessoa Pessoa { get; set; }     
    }
}
