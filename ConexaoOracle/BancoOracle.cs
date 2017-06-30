using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

//Declarar a referência para a dll de data types do oracle
using Oracle.DataAccess.Types;
//Declarar a referência para o client do oracle
using Oracle.DataAccess.Client;

namespace LojaGames.ConexaoBD
{
    class BancoOracle
    {
        /// <summary>
        /// Esta rotina cria o objeto de conexão 
        /// </summary>
        /// <returns>OracleConnection</returns>
        /// 

        /// <summary>
        /// Conexão
        /// </summary>
        public OracleConnection objConexao;

        /// <summary>
        /// Instancia para o padrão Singleton
        /// </summary>
        private static BancoOracle instancia;

        /// <summary>
        /// DataSet e Adapter
        /// </summary>

        private DataSet objDataSet;
        private OracleDataAdapter objAdapter;

        /// <summary>
        /// Variaveis que formam a string de conexão
        /// </summary>
        private readonly String strServidor, strPorta, strLogin, strSenha, strBancoDados, strConexao;
        private String strErro;
        //fim da declaracao de variaveis

        public static BancoOracle GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new BancoOracle();
            }
            return instancia;
        }

        /// <summary>
        /// Construtor da classe: Obter os dados via Registro e estabelecer conexão com o banco
        /// </summary>
        private BancoOracle()
        {
            try
            {
                /*Registro objReg = new Registro();
                strServidor = objReg.getValor("Servidor");
                strPorta = objReg.getValor("Porta");
                strLogin = objReg.getValor("Login");
                strSenha = objReg.getValor("Senha");
                strBancoDados = objReg.getValor("Banco");*/

                strServidor = "localhost";
                strPorta = "1521";
                strLogin = "system";
                strSenha = "oracle123";
                strBancoDados = "SiGames";


                //strConexao = "Server=" + strServidor + ";" +
                //                "Port=" + strPorta + ";" +
                //                "User Id=" + strLogin + ";" +
                //                "Password=" + strSenha + ";" +
                //                "Database=" + strBancoDados + ";Timeout=300;CommandTimeout=300";

                strConexao = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + strServidor + ")(PORT=" + strPorta + ")))(CONNECT_DATA=(SERVICE_NAME=" + strBancoDados + "))); User Id=" + strLogin + "; Password=" + strSenha;
                objConexao = new OracleConnection(strConexao);
            }
            catch (Exception e)
            {
                strErro = e.Message;
                throw new Exception("Erro na Conexão: " + strErro);
            }
        }

        public String GetErro()
        {
            return strErro;
        }

        /// <summary>
        /// Testa conexão com banco de dados
        /// </summary>
        /// <returns>retorna true se a conexao foi estabelecida, caso contrario retorna false</returns>
        public bool TestaConexao()
        {
            try
            {
                objConexao = new OracleConnection(strConexao);
                objConexao.Open();
                objConexao.Close();
                return true;
            }
            catch (Exception ex)
            {
                strErro = ex.Message;
                return false;
            }
        }

        //persistir significa alterar o estado atual do BD
        //inserir, editar, excluir
        public Int32 Persistir(String sql)
        {
            try
            {
                objConexao.Open();
                OracleCommand exec = new OracleCommand(sql, objConexao);
                Int32 rows = exec.ExecuteNonQuery();
                objConexao.Close();
                return rows;
                //retorno o num de tuplas "tocadas"
            }
            catch (Exception ex)
            {
                desconectar();
                strErro = ex.Message;
                throw new Exception("Erro na conexão com o Banco de Dados. \n" + ex.Message);
                //return 0;
            }
        }

        public DataTable Consultar(String sql)
        {
            DataTable objDataTable = new DataTable();

            try
            {
                objConexao.Open();
                if (objConexao.State == ConnectionState.Open)
                {
                    objAdapter = new OracleDataAdapter(sql, objConexao);
                    objDataTable.Clear();
                    objAdapter.Fill(objDataTable);
                    objConexao.Close();
                }
                return objDataTable;
            }
            catch (Exception e)
            {
                objConexao.Close();
                throw new Exception("Erro na consulta: " + e.Message + "\n\nVerifique se a os dados para conexão com o Banco de Dados estão corretos!");
            }
        }

        public void desconectar()
        {
            try
            {
                objConexao.Close();
                instancia = null;
            }
            catch (Exception e)
            {
                throw new Exception("Erro na consulta: " + e.Message + "\n\nVerifique se a os dados para conexão com o Banco de Dados estão corretos!");
            }
        }
    }
}
