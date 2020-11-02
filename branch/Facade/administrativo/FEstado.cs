using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.administrativo;

namespace Facade.administrativo
{
    public class FEstado
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
        /// Lista a sequnece de cargo
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

                EEstado estado = ConvertList(conn)[0];

                int sequence = estado.IsnEstado;

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
        /// <returns>Lista de Estados</returns>
        public List<EEstado> Lista()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_estado, dsc_estado, dsc_sigla, flg_ativo from tb_estado";
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
        /// Lista os estados a partir de um codigo
        /// </summary>
        /// <param name="isn">código do estado</param>
        /// <returns>EEstado</returns>
        public EEstado Buscar(int isn)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_estado, dsc_estado, dsc_sigla, flg_ativo from tb_estado where isn_estado = " + isn;
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
        /// Lista os estados a partir de uma descrição
        /// </summary>
        /// <param name="dsc">Descrição do estado</param>
        /// <returns>EEstado</returns>
        public List<EEstado> Lista(string dsc)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_estado, dsc_estado, dsc_sigla, flg_ativo from tb_estado where dsc_estado like '%" + dsc + "%'";
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
        /// <returns>Lista Estados</returns>
        public List<EEstado> ListaAtivos()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_estado, dsc_estado, dsc_sigla, flg_ativo from tb_estado where flg_ativo = 1";
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
        /// Insere uma novo estado
        /// </summary>
        /// <param name="usuario">Recebe a entidade estado como parametro</param>
        /// <returns>Inserido corretamente retorna true</returns>
        public bool Inserir(EEstado estado)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[4];
                param[0] = Sequence();
                param[1] = estado.DscEstado;
                param[2] = estado.DscSigla;
                param[3] = estado.FlgAtivo;

                //Sql do Insert
                string sql = "Insert into tb_estado (isn_estado, dsc_estado,dsc_sigla, flg_ativo) values ({0} , '{1}' , '{2}', '{3}')";
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
        /// Altera um novo estado
        /// </summary>
        /// <param name="usuario">Recebe a entidade estado como parametro</param>
        /// <returns>Altera corretamente retorna true</returns>
        public bool Alterar(EEstado estado)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[4];
                param[0] = Sequence();
                param[1] = estado.DscEstado;
                param[2] = estado.DscSigla;
                param[3] = estado.FlgAtivo;

                //Sql do Update
                string sql = "Update into tb_estado set dsc_estado = '{1}', flg_ativo = '{3}', dsc_sigla = '{2}' where isn_estado = {0})";
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
        private List<EEstado> ConvertList(ConexaoPostGre conexao)
        {
            List<EEstado> lst = new List<EEstado>();
            EEstado contrato;

            while (conexao.Reader.Read())
            {
                contrato = new EEstado();
                contrato.IsnEstado = conexao.Reader.GetInt32(0);
                contrato.DscEstado = conexao.Reader.GetString(1);
                contrato.DscSigla = conexao.Reader.GetString(2);
                contrato.FlgAtivo = conexao.Reader.GetBoolean(3);
                lst.Add(contrato);
            }

            return lst;
        }
    }
}
