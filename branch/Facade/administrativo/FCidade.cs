using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.administrativo;

namespace Facade.administrativo
{
    public class FCidade
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
        /// Lista a sequnece de cidade
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

                ECidade cidade = ConvertList(conn)[0];

                int sequence = cidade.IsnCidade;

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
        /// <returns>Lista de Cidades</returns>
        public List<ECidade> Lista()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cidade,isn_estado, dsc_cidade, flg_ativo from tb_cidade";
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
        /// Lista os cidades a partir de um codigo
        /// </summary>
        /// <param name="isn">código do cidade</param>
        /// <returns>ECidade</returns>
        public ECidade Buscar(int isn)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cidade,isn_estado, dsc_cidade, flg_ativo from tb_cidade where isn_cidade = " + isn;
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
        /// Lista os cidades a partir de uma descrição
        /// </summary>
        /// <param name="dsc">Descrição do cidade</param>
        /// <returns>ECidade</returns>
        public List<ECidade> Lista(string dsc)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cidade, isn_estado, dsc_cidade, flg_ativo from tb_cidade where dsc_cidade like '%" + dsc + "%'";
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
        public List<ECidade> ListaAtivos()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cidade, isn_estado, dsc_cidade, flg_ativo from tb_cidade where flg_ativo = 1";
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
        /// Insere uma novo cidade
        /// </summary>
        /// <param name="usuario">Recebe a entidade cidade como parametro</param>
        /// <returns>Inserido corretamente retorna true</returns>
        public bool Inserir(ECidade cidade)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[4];
                param[0] = Sequence();
                param[1] = cidade.estado.IsnEstado;
                param[2] = cidade.DscCidade;
                param[3] = cidade.FlgAtivo;

                //Sql do Insert
                string sql = "Insert into tb_cidade (isn_cidade,isn_estado, dsc_cidade, flg_ativo) values ({0} , {1} , '{2}', '{3}')";
                //Comando executado
                conn.ExecuteNonQuery(sql, param);
                //retorno
                return true;
            }
            catch (Exception e)
            {
                //Execeção retorna false
                //*******************Temos que melhorar o tratamento de exceções************
                return false;
            }
            finally
            {
                //Conexão fechada
                conn.Close();
            }

        }

        /// <summary>
        /// Altera um novo cidade
        /// </summary>
        /// <param name="usuario">Recebe a entidade cidade como parametro</param>
        /// <returns>Altera corretamente retorna true</returns>
        public bool Alterar(ECidade cidade)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[4];
                param[0] = Sequence();
                param[1] = cidade.estado.IsnEstado;
                param[2] = cidade.DscCidade;
                param[3] = cidade.FlgAtivo;

                //Sql do Update
                string sql = "Update into tb_cidade set dsc_cidade = '{2}', flg_ativo = '{3}', isn_estado = {1} where isn_cidade = {0})";
                //Comando executado
                conn.ExecuteNonQuery(sql, param);
                //retorno
                return true;
            }
            catch (Exception e)
            {
                //Execeção retorna false
                //*******************Temos que melhorar o tratamento de exceções************
                return false;
            }
            finally
            {
                //Conexão fechada
                conn.Close();
            }

        }

        /// <summary>
        /// Faz a conversão das listas
        /// </summary>
        /// <param name="conexao">Recebe a conexão</param>
        /// <returns>Lista convertida</returns>
        private List<ECidade> ConvertList(ConexaoPostGre conexao)
        {
            List<ECidade> lst = new List<ECidade>();
            ECidade contrato;

            while (conexao.Reader.Read())
            {
                contrato = new ECidade();
                contrato.IsnCidade = conexao.Reader.GetInt32(0);
                contrato.estado = new FEstado().Buscar(conexao.Reader.GetInt32(1));                
                contrato.DscCidade = conexao.Reader.GetString(2);
                contrato.FlgAtivo = conexao.Reader.GetBoolean(3);
                lst.Add(contrato);
            }

            return lst;
        }
    }
}
