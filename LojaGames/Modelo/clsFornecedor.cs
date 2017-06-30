using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LojaGames.ConexaoBD;
using System.IO;

namespace LojaGames.Modelo
{
    class clsFornecedor
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }

        private string strCNPJ;

        public string StrCNPJ
        {
            get { return strCNPJ; }
            set { strCNPJ = value; }
        }

        private string strNome;

        public string StrNome
        {
            get { return strNome; }
            set { strNome = value; }
        }

        private string strRazaoSocial;

        public string StrRazaoSocial
        {
            get { return strRazaoSocial; }
            set { strRazaoSocial = value; }
        }

        private string strEndereco;

        public string StrEndereco
        {
            get { return strEndereco; }
            set { strEndereco = value; }
        }

        private string strNumero;

        public string StrNumero
        {
            get { return strNumero; }
            set { strNumero = value; }
        }

        private string strBairro;

        public string StrBairro
        {
            get { return strBairro; }
            set { strBairro = value; }
        }

        private string strCidade;

        public string StrCidade
        {
            get { return strCidade; }
            set { strCidade = value; }
        }

        private string strEstado;

        public string StrEstado
        {
            get { return strEstado; }
            set { strEstado = value; }
        }

        private string strEmail;

        public string StrEmail
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        private string strTelefone;

        public string StrTelefone
        {
            get { return strTelefone; }
            set { strTelefone = value; }
        }

        public clsFornecedor()
        {

        }
        public void Salvar()
        {
            //instrucoes para salvar o objeto categoria
            String SQl = "insert into FORNECEDOR (CODIGO, CNPJ, NOME, RAZAOSOCIAL, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, TELEFONE, EMAIL) values (fornecedor_seq1.nextval, '" + strCNPJ + "', '" + strNome + "', '" + strRazaoSocial + "', '" + strEndereco + "', '" + strNumero + "', '" + strBairro + "', '" + strCidade + "', '" + strEstado + "', '" + strTelefone + "','" + strEmail + "')";
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
            string SQL = "UPDATE FORNECEDOR SET CNPJ = '" + strCNPJ + "', NOME = '" + strNome + "', RAZAOSOCIAL = '" + strRazaoSocial + "', ENDERECO = '" + strEndereco + "', NUMERO = '" + strNumero + "', BAIRRO = '" + strBairro + "', CIDADE = '" + strCidade + "', ESTADO = '" + strEstado + "', TELEFONE = '" + strTelefone + "', EMAIL = '" + strEmail + "' WHERE CODIGO = '" + intCodigo + "'";
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
            String SQl = "delete from FORNECEDOR where codigo =  " + intCodigo + "";
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
            string SQL = "SELECT CODIGO, CNPJ, NOME, RAZAOSOCIAL, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, TELEFONE, EMAIL  FROM FORNECEDOR ORDER BY CODIGO";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os fornecedores cadastrados "
                    + ex.Message);
            }
        }



        public static DataTable recuperarTodosFiltro(string filtro)
        {
            //instrucoes para consultar objetos do tipo CLIENTE"
            string SQL = "SELECT CODIGO, CNPJ, NOME, RAZAOSOCIAL, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, TELEFONE, EMAIL FROM fornecedor WHERE NOME LIKE '%"
                + filtro + "%' ORDER BY NOME";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os fornecedores cadastrados "
                    + ex.Message);
            }

        }

        public static List<clsFornecedor> listaFornecedor()
        {
            List<clsFornecedor> objLista = new List<clsFornecedor>();
            DataTable dtApoio = recuperarTodos();
            foreach (DataRow linha in dtApoio.Rows)
            {
                clsFornecedor objFornecedor = new clsFornecedor();
                objFornecedor.IntCodigo = Convert.ToInt16(linha["CODIGO"].ToString());
                objFornecedor.StrCNPJ = linha["CNPJ"].ToString();
                objFornecedor.StrNome = linha["NOME"].ToString();
                objFornecedor.StrRazaoSocial = linha["RAZAOSOCIAL"].ToString();
                objFornecedor.StrEndereco = linha["ENDERECO"].ToString();
                objFornecedor.StrNumero = linha["NUMERO"].ToString();
                objFornecedor.StrBairro = linha["BAIRRO"].ToString();
                objFornecedor.StrCidade = linha["CIDADE"].ToString();
                objFornecedor.StrEstado = linha["ESTADO"].ToString();
                objFornecedor.StrTelefone = linha["TELEFONE"].ToString();
                objFornecedor.StrEmail = linha["EMAIL"].ToString();

                objLista.Add(objFornecedor);
            }
            return objLista;
        }

        public static bool exportarTXT(string caminho)
        {
            try
            {
                File.Delete(@caminho);
                StreamWriter objSW = new StreamWriter(@caminho, true);
                objSW.WriteLine("Cabeçalho: Dados do Fornecedor");
                List<clsFornecedor> lista = listaFornecedor();
                foreach (clsFornecedor objA in lista)
                {
                    String linha = objA.IntCodigo + ";" + objA.StrCNPJ + ";" + objA.StrNome + ";" + objA.StrRazaoSocial + ";" + objA.StrEndereco + ";" + objA.StrNumero + ";" + objA.StrBairro + ";" + objA.StrCidade + ";" + objA.StrEstado + ";" + objA.StrTelefone + ";" + objA.StrEmail;
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
                    if ((linha != "Cabeçalho: Dados do Fornecedor") && (linha != ""))
                    {
                        String[] vetor = linha.Split(';');
                        clsFornecedor objFornecedor = new clsFornecedor();
                        objFornecedor.IntCodigo = Convert.ToInt16(vetor[0].ToString());
                        objFornecedor.StrCNPJ = vetor[1].ToString();
                        objFornecedor.StrNome = vetor[2].ToString();
                        objFornecedor.StrRazaoSocial = vetor[3].ToString();
                        objFornecedor.StrEndereco= vetor[4].ToString();
                        objFornecedor.StrNumero = vetor[5].ToString();
                        objFornecedor.StrBairro = vetor[6].ToString();
                        objFornecedor.StrCidade = vetor[7].ToString();
                        objFornecedor.StrEstado = vetor[8].ToString();
                        objFornecedor.StrTelefone = vetor[9].ToString();
                        objFornecedor.StrEmail = vetor[10].ToString();


                        //verificar se ID ja existe no BD
                        DataTable dtApoio = recuperarCodigo(objFornecedor.IntCodigo);
                        if (dtApoio.Rows.Count == 0)
                        {
                            objFornecedor.Salvar();
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
            string SQL = "SELECT CODIGO, CNPJ, NOME, RAZAOSOCIAL, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, TELEFONE, EMAIL FROM FORNECEDOR WHERE CODIGO = " + codigo;
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os dados dos fornecedores cadastrados "
                    + ex.Message);
            }

        }
    }
}
