using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.administrativo;

namespace Facade.administrativo
{
    public class FPerfil
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
        /// Lista a sequnece de perfil
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

                EPerfil perfil = ConvertList(conn)[0];

                int sequence = perfil.IsnPerfil;

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
        /// <returns>Lista de Perfil</returns>
        public List<EPerfil> Lista()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_perfil, dsc_perfil, flg_ativo from tb_perfil";
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
        /// Lista os perfis a partir de um codigo
        /// </summary>
        /// <param name="isn">código do perfil</param>
        /// <returns>EPerfil</returns>
        public EPerfil Buscar(int isn)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_perfil, dsc_perfil, flg_ativo from tb_perfil where isn_perfil = " + isn;
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
        /// Lista os perfis a partir de uma descrição
        /// </summary>
        /// <param name="dsc">Descrição do pefil</param>
        /// <returns>EPerfil</returns>
        public List<EPerfil> Lista(string dsc)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_perfil, dsc_perfil, flg_ativo from tb_perfil where dsc_perfil like '%" + dsc + "%'";
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
        public List<EPerfil> ListaAtivos()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_perfil, dsc_perfil, flg_ativo from tb_perfil where flg_ativo = 1";
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
        /// Insere uma novo perfil
        /// </summary>
        /// <param name="usuario">Recebe a entidade perfil como parametro</param>
        /// <returns>Inserido corretamente retorna true</returns>
        public bool Inserir(EPerfil perfil)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[3];
                param[0] = Sequence();
                param[1] = perfil.DscPerfil;
                param[2] = perfil.FlgAtivo;

                //Sql do Insert
                string sql = "Insert into tb_perfil (isn_perfil, dsc_perfil, flg_ativo) values ({0} , '{1}' , '{2}')";
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
        /// Altera um novo perfil
        /// </summary>
        /// <param name="usuario">Recebe a entidade perfil como parametro</param>
        /// <returns>Altera corretamente retorna true</returns>
        public bool Alterar(EPerfil perfil)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[3];
                param[0] = perfil.IsnPerfil;
                param[1] = perfil.DscPerfil;
                param[2] = perfil.FlgAtivo;

                //Sql do Update
                string sql = "Update into tb_perfil set dsc_perfil = '{1}', flg_ativo = '{2}' where isn_perfil = {0})";
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
        private List<EPerfil> ConvertList(ConexaoPostGre conexao)
        {
            List<EPerfil> lst = new List<EPerfil>();
            EPerfil contrato;

            while (conexao.Reader.Read())
            {
                contrato = new EPerfil();
                contrato.IsnPerfil = conexao.Reader.GetInt32(0);
                contrato.DscPerfil = conexao.Reader.GetString(1);
                contrato.FlgAtivo = conexao.Reader.GetBoolean(2);
                lst.Add(contrato);
            }

            return lst;
        }
    }
}
