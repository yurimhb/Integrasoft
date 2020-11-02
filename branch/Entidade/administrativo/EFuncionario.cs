using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    [Serializable]
    public class EFuncionario
    {
        /// <summary>
        /// Id de Funcionario
        /// </summary>
        public int IsnFuncionario { get; set; }

        /// <summary>
        /// Salario base ou salario bruto em carteira
        /// </summary>
        public decimal VlrSalarioBase { get; set; }

        /// <summary>
        /// Valor de Premiação ou Adicional ou extra carteira
        /// </summary>
        public decimal VrlPremiacao { get; set; }

        /// <summary>
        /// Valor plano odontologico
        /// </summary>
        public decimal VrlPlanoOdontologico { get; set; }

        /// <summary>
        /// Data de admissao
        /// </summary>
        public DateTime Dthadmissao { get; set; }

        /// <summary>
        /// Flag de vale transporte
        /// </summary>
        public bool FlgValeTransporte { get; set; }

        /// <summary>
        /// Ativação de Funcionario
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Relacionamento com Pessoa
        /// </summary>
        public EPessoa pessoa { get; set; }

        /// <summary>
        /// Relacionamento com Cargo
        /// </summary>
        public ECargo cargo { get; set; }

        /// <summary>
        /// Relacionamento com Empresa
        /// </summary>
        public EEmpresa empresa { get; set; }

        /// <summary>
        /// Relacionamento com Setor
        /// </summary>
        public ESetor setor { get; set; }     
    }
}
