using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.administrativo;

namespace Facade.administrativo
{
    public class FEstadoCivil
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
        /// Lista a sequnece de EstadoCivil
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

                EEstadoCivil estadoCivil = ConvertList(conn)[0];

                int sequence = estadoCivil.IsnEstadoCivil;

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
        /// <returns>Lista de Cargos</returns>
        public List<EEstadoCivil> Lista()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_estado_civil, dsc_estado_civil, flg_ativo from tb_estado_civil";
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
        /// Lista os Estado Civil a partir de um codigo
        /// </summary>
        /// <param name="isn">código do estado civil</param>
        /// <returns>EEstadoCivil</returns>
        public EEstadoCivil Buscar(int isn)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_estado_civil, dsc_estado_civil, flg_ativo from tb_estado_civil where isn_estado_civil = " + isn;
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
        /// Lista os estado civil a partir de uma descrição
        /// </summary>
        /// <param name="dsc">Descrição do Estado Civil</param>
        /// <returns>EEstadoCivil</returns>
        public List<EEstadoCivil> Lista(string dsc)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_estado_civil, dsc_estado_civil, flg_ativo from tb_estado_civil where dsc_estado_civil like '%" + dsc + "%'";
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
        /// <returns>Lista EEstadoCivil</returns>
        public List<EEstadoCivil> ListaAtivos()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_estado_civil, dsc_estado_civil, flg_ativo from tb_estado_civil where flg_ativo = 1";
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
        /// Insere uma novo estado civil
        /// </summary>
        /// <param name="usuario">Recebe a entidade estado civil como parametro</param>
        /// <returns>Inserido corretamente retorna true</returns>
        public bool Inserir(EEstadoCivil estadoCivil)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[3];
                param[0] = Sequence();
                param[1] = estadoCivil.DscEstadoCivil;
                param[2] = estadoCivil.FlgAtivo;

                //Sql do Insert
                string sql = "Insert into tb_estado_civil (isn_estado_civil, dsc_estado_civil, flg_ativo) values ({0} , '{1}' , '{2}')";
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
        /// Altera um novo estado civil
        /// </summary>
        /// <param name="usuario">Recebe a entidade estado civil como parametro</param>
        /// <returns>Altera corretamente retorna true</returns>
        public bool Alterar(EEstadoCivil estadoCivil)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[3];
                param[0] = estadoCivil.IsnEstadoCivil;
                param[1] = estadoCivil.DscEstadoCivil;
                param[2] = estadoCivil.FlgAtivo;

                //Sql do Update
                string sql = "Update into tb_estado_civil set dsc_estado_civil = '{1}', flg_ativo = '{2}' where isn_estado_civil = {0})";
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
        private List<EEstadoCivil> ConvertList(ConexaoPostGre conexao)
        {
            List<EEstadoCivil> lst = new List<EEstadoCivil>();
            EEstadoCivil contrato;

            while (conexao.Reader.Read())
            {
                contrato = new EEstadoCivil();
                contrato.IsnEstadoCivil = conexao.Reader.GetInt32(0);
                contrato.DscEstadoCivil = conexao.Reader.GetString(1);
                contrato.FlgAtivo = conexao.Reader.GetBoolean(2);
                lst.Add(contrato);
            }

            return lst;
        }
    }
}
