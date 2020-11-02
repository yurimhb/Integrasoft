using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.administrativo;

namespace Facade.administrativo
{
    public class FCargo
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
                sql = "select " ;
                //Executa consulta
                conn.ExecuteReader(sql);

                ECargo cargo = ConvertList(conn)[0];
                
                int sequence = cargo.IsnCargo;

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
        public List<ECargo> Lista()
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cargo, dsc_cargo, flg_ativo from tb_cargo";
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
        public ECargo Buscar(int isn)
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
        public List<ECargo> Lista(string dsc)
        {
            try
            {
                //Abre conexão
                conn.Open();
                //Sql da consulta
                sql = "select isn_cargo, dsc_cargo, flg_ativo from tb_cargo where dsc_cargo like '%"+ dsc +"%'";
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
        public List<ECargo> ListaAtivos()
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
        public bool Inserir(ECargo cargo)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[3];
                param[0] = Sequence();
                param[1] = cargo.DscCargo;
                param[2] = cargo.FlgAtivo;               

                //Sql do Insert
                string sql = "Insert into tb_cargo (isn_cargo, dsc_cargo, flg_ativo) values ({0} , '{1}' , '{2}')";
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
        /// Altera um novo cargo
        /// </summary>
        /// <param name="usuario">Recebe a entidade cargo como parametro</param>
        /// <returns>Altera corretamente retorna true</returns>
        public bool Alterar(ECargo cargo)
        {
            try
            {
                //Abre conexão
                conn.Open();

                //Lista de parametros
                Object[] param = new Object[3];
                param[0] = cargo.IsnCargo;
                param[1] = cargo.DscCargo;
                param[2] = cargo.FlgAtivo;

                //Sql do Update
                string sql = "Update into tb_cargo set dsc_cargo = '{1}', flg_ativo = '{2}' where isn_cargo = {0})";
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
        private List<ECargo> ConvertList(ConexaoPostGre conexao)
        {
            List<ECargo> lst = new List<ECargo>();
            ECargo contrato;

            while (conexao.Reader.Read())
            {
                contrato = new ECargo();
                contrato.IsnCargo = conexao.Reader.GetInt32(0);                
                contrato.DscCargo = conexao.Reader.GetString(1);                
                contrato.FlgAtivo = conexao.Reader.GetBoolean(2);
                lst.Add(contrato);
            }

            return lst;
        }
    }
}
