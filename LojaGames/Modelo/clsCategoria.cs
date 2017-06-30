using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaGames.ConexaoBD;
using System.Data;
using System.IO;

namespace LojaGames.Modelo// e deu certo erro namespace
{
    class clsCategoria
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }

        private string strNome;

        public string StrNome
        {
            get { return strNome; }
            set { strNome = value; }
        }

        public clsCategoria()
        {

        }

        public void Salvar()
        {
            //instrucoes para salvar o objeto categoria
            String SQl = "insert into CATEGORIA (CODIGO, NOME) values (categoria_seq1.nextval,'" + strNome + "')";
            try
            {
                int numTuplas = BancoOracle.GetInstancia().Persistir(SQl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar()
        {
            //instrucoes para alterar o objeto cliente
            string SQL = "UPDATE CATEGORIA SET NOME = '" + strNome + "' WHERE CODIGO = '" + intCodigo + "'";
            try
            {
                BancoOracle.GetInstancia().Persistir(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Excluir()
        {
            //instrucoes para excluir o objeto categoria
            String SQl = "delete from CATEGORIA where codigo =  " + intCodigo + "";
            try
            {
                int numTuplas = BancoOracle.GetInstancia().Persistir(SQl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable recuperarTodos()
        {
            string SQL = "SELECT CODIGO, NOME  FROM CATEGORIA ORDER BY CODIGO";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os clientes cadastrados "
                    + ex.Message);
            }
        }



        public static DataTable recuperarTodosFiltro(string filtro)
        {
            //instrucoes para consultar objetos do tipo CLIENTE"
            string SQL = "SELECT CODIGO, NOME FROM CATEGORIA WHERE NOME LIKE '%"
                + filtro + "%' ORDER BY NOME";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os clientes cadastrados "
                    + ex.Message);
            }

        }

        public static List<clsCategoria> listaCategoria()
        {
            List<clsCategoria> objLista = new List<clsCategoria>();
            DataTable dtApoio = recuperarTodos();
            foreach (DataRow linha in dtApoio.Rows)
            {
                clsCategoria objCategoria = new clsCategoria();
                objCategoria.IntCodigo = Convert.ToInt16(linha["CODIGO"].ToString());
                objCategoria.StrNome = linha["NOME"].ToString();
                objLista.Add(objCategoria);
            }
            return objLista;
        }

        public static bool exportarTXT(string caminho)
        {
            try
            {
                File.Delete(@caminho);
                StreamWriter objSW = new StreamWriter(@caminho, true);
                objSW.WriteLine("Cabeçalho: Dados da Categoria");
                List<clsCategoria> lista = listaCategoria();
                foreach (clsCategoria objA in lista)
                {
                    String linha = objA.IntCodigo + ";" + objA.StrNome;
                    objSW.WriteLine(linha);
                }

                objSW.Close();
                return true;
            }
            catch (Exception ex)
            {
                //throw new Exception (ex.Message);
                throw ex;
            }
        }

        public static bool importarTXT(string caminho)
        {
            try
            {
                StreamReader objSR = new StreamReader(@caminho, true);
                while (!objSR.EndOfStream)
                {
                    string linha = objSR.ReadLine();
                    if ((linha != "Cabeçalho: Dados da Categoria") && (linha != ""))
                    {
                        String[] vetor = linha.Split(';');
                        clsCategoria objCategoria = new clsCategoria();
                        objCategoria.IntCodigo = Convert.ToInt16(vetor[0].ToString());
                        objCategoria.StrNome = vetor[1].ToString();

                        //verificar se ID ja existe no BD
                        DataTable dtApoio = recuperarCodigo(objCategoria.IntCodigo);
                        if (dtApoio.Rows.Count == 0)
                        {
                            objCategoria.Salvar();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                //throw new Exception (ex.Message);
                throw ex;
            }
        }

        public static DataTable recuperarCodigo(int codigo)
        {
            string SQL = "SELECT CODIGO, NOME FROM CATEGORIA WHERE CODIGO = " + codigo;
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os dados das categorias cadastradas "
                    + ex.Message);
            }

        }
    }
}
