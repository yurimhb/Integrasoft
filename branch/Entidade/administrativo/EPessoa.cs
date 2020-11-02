using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.administrativo
{
    /// <summary>
    /// Classe que representa a tabela Pessoa
    /// </summary>
    [Serializable]
    public class EPessoa
    {
        /// <summary>
        /// Id de Pessoa
        /// </summary>
        public int IsnPessoa { get; set; }

        /// <summary>
        /// Nome ou Razão Social
        /// </summary>
        public string DscNomeRazao { get; set; }

        /// <summary>
        /// Data de Cadastro
        /// </summary>
        public DateTime DthCadastro { get; set; }

        /// <summary>
        /// Relacionamento com EstadoCivil só para pessoa fisica
        /// </summary>
        public EEstadoCivil estadoCivil { get; set; }

        /// <summary>
        /// Relacionamento com Cidade
        /// Cidade onde a pessoa nasceu
        /// </summary>
        public ECidade Naturalidade { get; set; }

        /// <summary>
        /// Relacionamento com Estado
        /// Estado onde a pessoa nasceu
        /// </summary>
        public EEstado NaturalidadeUF { get; set; }

        /// <summary>
        /// Relacionamento com Cidade
        /// Cidade de residencia
        /// </summary>
        public ECidade cidade { get; set; }

        /// <summary>
        /// Relacionamento com Estado
        /// Estado de residencia
        /// </summary>
        public EEstado estado { get; set; }

        /// <summary>
        /// CNPJ - Pessoa Juridica
        /// </summary>
        public string DscCnpj { get; set; }

        /// <summary>
        /// CPF - Pessoa Fisica
        /// </summary>
        public string DscCpf { get; set; }

        /// <summary>
        /// RG - Pessoa Fisica
        /// </summary>
        public string DscRg { get; set; }

        /// <summary>
        /// Orgao Expeditor do RG
        /// </summary>
        public string DscOrgaoExpeditor { get; set; }

        /// <summary>
        /// Data de Expedição do RG
        /// </summary>
        public DateTime DthExpedicao { get; set; }

        /// <summary>
        /// Inscrição Municipal - Pessoa Juridica
        /// </summary>
        public string DscInscricaoMunicipal { get; set; }

        /// <summary>
        /// Nome Fantasia - Pessoa Juridica
        /// </summary>
        public string DscNomeFantasia { get; set; }

        /// <summary>
        /// Nascimento - Pessoa Fisica
        /// </summary>
        public DateTime DthNascimento { get; set; }

        /// <summary>
        /// Sexo - Pessoa Fisica
        /// </summary>
        public char DscSexo { get; set; }

        /// <summary>
        /// Endereço
        /// </summary>
        public string DscEndereco { get; set; }

        /// <summary>
        /// Complemento do Endereço
        /// </summary>
        public string DscComplemento { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        public string DscNumero { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string DscBairro { get; set; }

        /// <summary>
        /// Fone residencial
        /// </summary>
        public string DscFoneResidencial { get; set; }

        /// <summary>
        /// Fone Comercial
        /// </summary>
        public string DscFoneComercial { get; set; }

        /// <summary>
        /// ´Numero de Fax
        /// </summary>
        public string DscFax { get; set; }

        /// <summary>
        /// Celular
        /// </summary>
        public string DscCelular { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string DscEmail { get; set; }

        /// <summary>
        /// Contato
        /// </summary>
        public string DscContato { get; set; }

        /// <summary>
        /// Telefone do Contato
        /// </summary>
        public string DscTelefoneContato { get; set; }

        /// <summary>
        /// Observação sobre o contato
        /// </summary>
        public string DscObservacaoContato { get; set; }

        /// <summary>
        /// Referencia Comercial 01
        /// </summary>
        public string DscReferenciaComercial1 { get; set; }

        /// <summary>
        /// Referencial Comercial 02
        /// </summary>
        public string DscReferenciaComercial2 { get; set; }

        /// <summary>
        /// Referencia Pessoal 1
        /// </summary>
        public string DscReferenciaPessoal1 { get; set; }

        /// <summary>
        /// Referencia Pessoal 2
        /// </summary>
        public string DscReferenciaPessoal2 { get; set; }

        /// <summary>
        /// Foto
        /// </summary>
        public string DscFoto { get; set; }

        /// <summary>
        /// Nome do Pai - Pessoa Fisica
        /// </summary>
        public string DscPai { get; set; }

        /// <summary>
        /// Nome da Mae - Pessoa Fisica
        /// </summary>
        public string DscMae { get; set; }

        /// <summary>
        /// Observação
        /// </summary>
        public string DscObservacao { get; set; }

        /// <summary>
        /// Flag de ativação
        /// </summary>
        public bool FlgAtivo { get; set; }

        /// <summary>
        /// Flas de tipo de Pessoa
        /// j - Pessoa Juridica, f - Pessoa Fisica
        /// </summary>
        public char FlgTipoPessoa { get; set; }
    }
}
