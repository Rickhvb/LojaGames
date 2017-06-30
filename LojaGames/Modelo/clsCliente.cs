using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LojaGames.ConexaoBD;
using System.IO;

namespace LojaGames.Modelo
{
    class clsCliente
    {
        private string strCPFCliente;

        public string StrCPFCliente
        {
            get { return strCPFCliente; }
            set { strCPFCliente = value; }
        }

        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }

        private string strNomeCliente;

        public string StrNomeCliente
        {
            get { return strNomeCliente; }
            set { strNomeCliente = value; }
        }
        private string strEmail;

        public string StrEmail
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        private string strNascimento;

        public string StrNascimento
        {
            get { return strNascimento; }
            set { strNascimento = value; }
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

        private string strTelefone;

        public string StrTelefone
        {
            get { return strTelefone; }
            set { strTelefone = value; }
        }

        
        public clsCliente()
        {

        }
        public void Salvar()
        {
            //instrucoes para salvar o objeto cliente
            String SQl = "insert into CLIENTE (CPF, CODIGO, NOME, TELEFONE, EMAIL, NASCIMENTO, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO) values ('" + strCPFCliente + "', cliente_seq1.nextval,'" + strNomeCliente + "','" + strTelefone + "', '" + strEmail + "', '" + strNascimento + "', '" + strEndereco + "', '" + strNumero + "', '" + strBairro + "', '" + strCidade + "', '" + strEstado + "')";
            try
            {
                int numTuplas = BancoOracle.GetInstancia().Persistir(SQl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Excluir()
        {
            //instrucoes para excluir o objeto cliente
            string SQL = "DELETE FROM CLIENTE WHERE CODIGO = '"+ intCodigo +"'";
            try
            {
                BancoOracle.GetInstancia().Persistir(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Consultar()
        {

        }

        public void Alterar()
        {
            //instrucoes para alterar o objeto cliente
            string SQL = "UPDATE CLIENTE SET CPF = '" + strCPFCliente + "',NOME = '" + strNomeCliente + "',TELEFONE = '" + strTelefone + "', EMAIL = '" + strEmail + "', NASCIMENTO = '" + strNascimento + "', ENDERECO = '" + strEndereco + "', NUMERO = '" + strNumero + "' , BAIRRO = '" + strBairro + "', CIDADE = '" + strCidade + "', ESTADO = '" + strEstado + "'  WHERE CODIGO = '" + intCodigo + "'";
            try
            {
                BancoOracle.GetInstancia().Persistir(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public static DataTable recuperarTodos()
        {
            string SQL = "SELECT CPF, CODIGO, NOME, Nascimento, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, EMAIL as Email, TELEFONE  FROM CLIENTE ORDER BY CODIGO";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception ("Erro ao recuperar todos os clientes cadastrados " 
                    + ex.Message);
            } 
        }

        public static DataTable recuperaDadosCliente(int codigo)
        {
            String SQL = "SELECT CPF, CODIGO, NOME, Nascimento, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, EMAIL, TELEFONE  FROM CLIENTE where codigo = '"+codigo+"'";
            return BancoOracle.GetInstancia().Consultar(SQL);
        }




        public static DataTable recuperarTodosFiltro(string filtro)
        {
            //instrucoes para consultar objetos do tipo CLIENTE"
            string SQL = "SELECT CPF, CODIGO, NOME, Nascimento, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, EMAIL as Email, Telefone FROM CLIENTE WHERE NOME LIKE '%" 
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

        public static List<clsCliente> listaCliente()
        {
            List<clsCliente> objLista = new List<clsCliente>();
            DataTable dtApoio = recuperarTodos();
            foreach (DataRow linha in dtApoio.Rows)
            {
                clsCliente objCliente = new clsCliente();
                objCliente.StrCPFCliente = linha["CPF"].ToString();
                objCliente.IntCodigo = Convert.ToInt16(linha["CODIGO"].ToString());
                objCliente.StrNomeCliente = linha["NOME"].ToString();
                objCliente.StrNascimento = linha["NASCIMENTO"].ToString();
                objCliente.StrEndereco = linha["ENDERECO"].ToString();
                objCliente.StrNumero = linha["NUMERO"].ToString();
                objCliente.StrBairro = linha["BAIRRO"].ToString();
                objCliente.StrCidade= linha["CIDADE"].ToString();
                objCliente.StrEstado = linha["ESTADO"].ToString();
                objCliente.StrTelefone = linha["TELEFONE"].ToString();
                objCliente.StrEmail = linha["EMAIL"].ToString();

                objLista.Add(objCliente);
            }
            return objLista;
        }

        public static bool exportarTXT(string caminho)
        {
            try
            {
                File.Delete(@caminho);
                StreamWriter objSW = new StreamWriter(@caminho, true);
                objSW.WriteLine("Cabeçalho: Dados do Cliente");
                List<clsCliente> lista = listaCliente();
                foreach (clsCliente objA in lista)
                {
                    String linha = objA.StrCPFCliente + ";" + objA.IntCodigo + ";" + objA.StrNomeCliente + ";" + objA.StrNascimento + ";" + objA.StrEndereco + ";" + objA.StrNumero + ";" + objA.StrBairro + ";" + objA.StrCidade + ";" + objA.StrEstado + ";" + objA.StrEmail + ";" + objA.StrTelefone;
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
                    if ((linha != "Cabeçalho: Dados do Cliente") && (linha != ""))
                    {
                        String[] vetor = linha.Split(';');
                        clsCliente objCliente = new clsCliente();
                        objCliente.StrCPFCliente = vetor[0].ToString();
                        objCliente.IntCodigo = Convert.ToInt16(vetor[1].ToString());
                        objCliente.StrNomeCliente = vetor[2].ToString();
                        objCliente.StrNascimento = vetor[3].ToString();
                        objCliente.StrEndereco = vetor[4].ToString();
                        objCliente.StrNumero = vetor[5].ToString();
                        objCliente.StrBairro = vetor[6].ToString();
                        objCliente.StrCidade = vetor[7].ToString();
                        objCliente.StrEstado = vetor[8].ToString();
                        objCliente.StrEmail = vetor[9].ToString();
                        objCliente.StrTelefone = vetor[10].ToString();
                        
                        

                        //verificar se ID ja existe no BD
                        DataTable dtApoio = recuperarCodigo(objCliente.IntCodigo);
                        if (dtApoio.Rows.Count == 0)
                        {
                            objCliente.Salvar();
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
            string SQL = "SELECT CPF, CODIGO, NOME, Nascimento, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, EMAIL as Email, TELEFONE  FROM CLIENTE WHERE CODIGO = " + codigo;
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os dados dos clientes cadastrados "
                    + ex.Message);
            }

        }
        
    }
}
