using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaGames.ConexaoBD;
using System.Data;
using System.IO;

namespace LojaGames.Modelo
{
    class clsProduto
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }

        private int intCodCat;

        public int IntCodCat
        {
            get { return intCodCat; }
            set { intCodCat = value; }
        }

        private int intCodForn;

        public int IntCodForn
        {
            get { return intCodForn; }
            set { intCodForn = value; }
        }

        private string strNome;

        public string StrNome
        {
            get { return strNome; }
            set { strNome = value; }
        }

        private string strMarca;

        public string StrMarca
        {
            get { return strMarca; }
            set { strMarca = value; }
        }

        private string strValor;

        public string StrValor
        {
            get { return strValor; }
            set { strValor = value; }
        }

        private string strDescricao;

        public string StrDescricao
        {
            get { return strDescricao; }
            set { strDescricao = value; }
        }


        public clsProduto()
        {

        }
        
        public void Salvar()
        {
            //instrucoes para salvar o objeto produto
            String SQl = "insert into PRODUTO (CODIGO, CATEGORIA, NOME, MARCA, VALOR, DESCRICAO, FORNECEDOR) values (produto_seq1.nextval, " + intCodCat + ",'" + strNome + "', '" + strMarca + "', '" + strValor + "', '" + strDescricao + "', " + intCodForn + ")";
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
            string SQL = "UPDATE PRODUTO SET CATEGORIA = " + intCodCat + ", NOME = '" + strNome + "', MARCA = '" + strMarca + "', VALOR = '" + strValor + "', DESCRICAO = '" + strDescricao + "', FORNECEDOR = " + intCodForn + "  WHERE CODIGO = '" + intCodigo + "'";
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
            String SQl = "delete from PRODUTO where codigo =  " + intCodigo + "";
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
            string SQL = "SELECT  P.CODIGO, P.NOME, C.NOME as categoria, F.NOME as fornecedor, P.MARCA, P.VALOR, P.DESCRICAO  FROM PRODUTO P, CATEGORIA C, FORNECEDOR F WHERE C.CODIGO = P.CATEGORIA AND F.CODIGO = P.FORNECEDOR ORDER BY P.CODIGO";
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
            string SQL = "SELECT P.CODIGO, P.NOME, C.NOME AS CATEGORIA, F.NOME AS FORNECEDOR, P.MARCA, P.VALOR, P.DESCRICAO FROM PRODUTO P, CATEGORIA C, FORNECEDOR F WHERE C.CODIGO = P.CATEGORIA AND F.CODIGO = P.FORNECEDOR and P.NOME LIKE '%"
                + filtro + "%' ORDER BY P.NOME";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os produtos cadastrados "
                    + ex.Message);
            }

        }

        public static List<clsProduto> listaProduto()
        {
            List<clsProduto> objLista = new List<clsProduto>();
            DataTable dtApoio = recuperarTodos();
            foreach (DataRow linha in dtApoio.Rows)
            {
                clsProduto objProduto = new clsProduto();
                objProduto.IntCodigo = Convert.ToInt16(linha["CODIGO"].ToString());
                objProduto.IntCodCat = Convert.ToInt16(linha["CATEGORIA"].ToString());
                objProduto.IntCodForn = Convert.ToInt16(linha["FORNECEDOR"].ToString());
                objProduto.StrNome = linha["NOME"].ToString();
                objProduto.StrMarca = linha["MARCA"].ToString();
                objProduto.StrValor = linha["VALOR"].ToString();
                objProduto.StrDescricao = linha["DESCRICAO"].ToString();

                objLista.Add(objProduto);
            }
            return objLista;
        }

        public static bool exportarTXT(string caminho)
        {
            try
            {
                File.Delete(@caminho);
                StreamWriter objSW = new StreamWriter(@caminho, true);
                objSW.WriteLine("Cabeçalho: Dados do Produto");
                List<clsProduto> lista = listaProduto();
                foreach (clsProduto objA in lista)
                {
                    String linha = objA.IntCodigo + ";" + objA.IntCodCat + ";" + objA.IntCodForn + ";" + objA.StrNome + ";" + objA.StrMarca + ";" + objA.StrValor + ";" + objA.StrDescricao;
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
                    if ((linha != "Cabeçalho: Dados do Produto") && (linha != ""))
                    {
                        String[] vetor = linha.Split(';');
                        clsProduto objProduto = new clsProduto();
                        objProduto.IntCodigo = Convert.ToInt16(vetor[0].ToString());
                        objProduto.IntCodCat = Convert.ToInt16(vetor[1].ToString());
                        objProduto.IntCodForn = Convert.ToInt16(vetor[2].ToString());
                        objProduto.StrNome = vetor[3].ToString();
                        objProduto.StrMarca = vetor[4].ToString();
                        objProduto.StrValor = vetor[5].ToString();
                        objProduto.StrDescricao = vetor[6].ToString();


                        //verificar se ID ja existe no BD
                        DataTable dtApoio = recuperarCodigo(objProduto.IntCodigo);
                        if (dtApoio.Rows.Count == 0)
                        {
                            objProduto.Salvar();
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
            string SQL = "SELECT CODIGO, CATEGORIA, FORNECEDOR, NOME, MARCA, VALOR, DESCRICAO FROM PRODUTO WHERE CODIGO = " + codigo;
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os dados dos produtos cadastrados "
                    + ex.Message);
            }

        }
    }
}
