using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.administrativo;

namespace Facade.administrativo
{
    public class FPessoa 
    {        
        /// <summary>
        /// Variavel de conexão
        /// </summary>
        ConexaoPostGre conn = new ConexaoPostGre();

        /// <summary>
        /// String de sql
        /// </summary>
        private String sql;

        /// <summary>
        /// Lista a sequnece de pesseoa
        /// </summary>
        /// <returns>Um inteiro, número da sequence</returns>
        private int Sequence()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select ";
                //Executa consulta
                conn.ExecuteReader(sql);

                EPessoa pessoa = ConvertList(conn)[0];

                int sequence = pessoa.IsnPessoa;

                //Retorna Item
                return sequence;
            }
            catch (Exception e)
            {
                //Exceção
                throw e;
            }
            finally
            {
                //Fecha conexão
                conn.Close();
            }
        }

        /// <summary>
        /// Lista todas as entidades
        /// </summary>
        /// <returns>Lista de Pessoas</returns>
        public List<EPessoa> Lista()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_pessoa, dsc_nome_razao, flg_ativo from tb_pessoa";
                //Executa consulta
                conn.ExecuteReader(sql);
                //Retorna Item
                return ConvertList(conn);
            }
            catch (Exception e)
            {
                //Exceção
                throw e;
            }
            finally
            {
                //Fecha conexão
                conn.Close();
            }
        }

        /// <summary>
        /// Lista os cargos a partir de um codigo
        /// </summary>
        /// <param name="isn">código do cargo</param>
        /// <returns>ECargo</returns>
        public EPessoa Buscar(int isn)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cargo, dsc_cargo, flg_ativo from tb_cargo where isn_cargo = " + isn;
                //Executa consulta
                conn.ExecuteReader(sql);
                //Retorna Item
                return ConvertList(conn)[0];
            }
            catch (Exception e)
            {
                //Exceção
                throw e;
            }
            finally
            {
                //Fecha conexão
                conn.Close();
            }
        }

        /// <summary>
        /// Lista os cargos a partir de uma descrição
        /// </summary>
        /// <param name="dsc">Descrição do cargo</param>
        /// <returns>ECargo</returns>
        public List<EPessoa> Lista(string dsc)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cargo, dsc_cargo, flg_ativo from tb_cargo where dsc_cargo like '%" + dsc + "%'";
                //Executa consulta
                conn.ExecuteReader(sql);
                //Retorna Item
                return ConvertList(conn);
            }
            catch (Exception e)
            {
                //Exceção
                throw e;
            }
            finally
            {
                //Fecha conexão
                conn.Close();
            }
        }

        /// <summary>
        /// Lista entidades ativas
        /// </summary>
        /// <returns>Lista Cargos</returns>
        public List<EPessoa> ListaAtivos()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cargo, dsc_cargo, flg_ativo from tb_cargo where flg_ativo = 1";
                //Executa consulta
                conn.ExecuteReader(sql);
                //Retorna Item
                return ConvertList(conn);
            }
            catch (Exception e)
            {
                //Exceção
                throw e;
            }
            finally
            {
                //Fecha conexão
                conn.Close();
            }
        }

        /// <summary>
        /// Insere uma novo cargo
        /// </summary>
        /// <param name="usuario">Recebe a entidade cargo como parametro</param>
        /// <returns>Inserido corretamente retorna true</returns>
        //public bool Inserir(EPessoa cargo)
        //{
        //    try
        //    {
        //        //Abre conexão
        //        conn.Open();

        //        //Lista de parametros
        //        Object[] param = new Object[3];
        //        param[0] = Sequence();
        //        param[1] = cargo.DscCargo;
        //        param[2] = cargo.FlgAtivo;

        //        //Sql do Insert
        //        string sql = "Insert into tb_cargo (isn_cargo, dsc_cargo, flg_ativo) values ({0} , '{1}' , '{2}')";
        //        //Comando executado
        //        conn.ExecuteNonQuery(sql, param);
        //        //retorno
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        //Execeção retorna false
        //        //*******************Temos que melhorar o tratamento de exceções************
        //        return false;
        //    }
        //    finally
        //    {
        //        //Conexão fechada
        //        conn.Close();
        //    }

        //}

        /// <summary>
        /// Altera um novo cargo
        /// </summary>
        /// <param name="usuario">Recebe a entidade cargo como parametro</param>
        /// <returns>Altera corretamente retorna true</returns>
        //public bool Alterar(EPessoa cargo)
        //{
        //    try
        //    {
        //        //Abre conexão
        //        conn.Open();

        //        //Lista de parametros
        //        Object[] param = new Object[3];
        //        param[0] = cargo.IsnCargo;
        //        param[1] = cargo.DscCargo;
        //        param[2] = cargo.FlgAtivo;

        //        //Sql do Update
        //        string sql = "Update into tb_cargo set dsc_cargo = '{1}', flg_ativo = '{2}' where isn_cargo = {0})";
        //        //Comando executado
        //        conn.ExecuteNonQuery(sql, param);
        //        //retorno
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        //Execeção retorna false
        //        //*******************Temos que melhorar o tratamento de exceções************
        //        return false;
        //    }
        //    finally
        //    {
        //        //Conexão fechada
        //        conn.Close();
        //    }

        //}

        /// <summary>
        /// Faz a conversão das listas
        /// </summary>
        /// <param name="conexao">Recebe a conexão</param>
        /// <returns>Lista convertida</returns>
        private List<EPessoa> ConvertList(ConexaoPostGre conexao)
        {
            List<EPessoa> lst = new List<EPessoa>();
            EPessoa contrato;

            while (conexao.Reader.Read())
            {
                contrato = new EPessoa();
                contrato.IsnPessoa = conexao.Reader.GetInt32(0);
                contrato.DscNomeRazao = conexao.Reader.GetString(1);
                contrato.DthCadastro = conexao.Reader.GetDateTime(2);
                contrato.estadoCivil = new FEstadoCivil().Buscar(conexao.Reader.GetInt32(3));
                contrato.Naturalidade = new FCidade().Buscar(conexao.Reader.GetInt32(4));
                contrato.NaturalidadeUF = new FEstado().Buscar(conexao.Reader.GetInt32(5));
                contrato.cidade = new FCidade().Buscar(conexao.Reader.GetInt32(6));
                contrato.estado = new FEstado().Buscar(conexao.Reader.GetInt32(7));
                contrato.DscCnpj = conexao.Reader.GetString(8);
                contrato.DscCpf = conexao.Reader.GetString(9);
                contrato.DscRg = conexao.Reader.GetString(10);
                contrato.DscOrgaoExpeditor = conexao.Reader.GetString(11);
                contrato.DthExpedicao = conexao.Reader.GetDateTime(12);
                contrato.DscInscricaoMunicipal = conexao.Reader.GetString(13);
                contrato.DscNomeFantasia = conexao.Reader.GetString(14);
                contrato.DthNascimento = conexao.Reader.GetDateTime(15);
                contrato.DscSexo = conexao.Reader.GetChar(16);
                contrato.DscEndereco = conexao.Reader.GetString(17);
                contrato.DscComplemento = conexao.Reader.GetString(18);
                contrato.DscNumero = conexao.Reader.GetString(19);
                contrato.DscBairro = conexao.Reader.GetString(20);
                contrato.DscFoneResidencial = conexao.Reader.GetString(21);
                contrato.DscFoneComercial = conexao.Reader.GetString(22);
                contrato.DscFax = conexao.Reader.GetString(23);
                contrato.DscCelular = conexao.Reader.GetString(24);
                contrato.DscEmail = conexao.Reader.GetString(25);
                contrato.DscContato = conexao.Reader.GetString(26);
                contrato.DscTelefoneContato = conexao.Reader.GetString(27);
                contrato.DscObservacaoContato = conexao.Reader.GetString(28);
                contrato.DscReferenciaComercial1 = conexao.Reader.GetString(29);
                contrato.DscReferenciaComercial2 = conexao.Reader.GetString(30);
                contrato.DscReferenciaPessoal1 = conexao.Reader.GetString(31);
                contrato.DscReferenciaPessoal2 = conexao.Reader.GetString(32);
                contrato.DscFoto = conexao.Reader.GetString(33);
                contrato.DscPai = conexao.Reader.GetString(34);
                contrato.DscMae = conexao.Reader.GetString(35);
                contrato.DscObservacao = conexao.Reader.GetString(36);
                contrato.FlgAtivo = conexao.Reader.GetBoolean(37);
                contrato.FlgTipoPessoa = conexao.Reader.GetChar(38);
                lst.Add(contrato);
            }

            return lst;
        }
    }
}
