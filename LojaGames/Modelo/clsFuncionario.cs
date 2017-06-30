using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaGames.ConexaoBD;
using System.Data;
using System.IO;

namespace LojaGames.Modelo
{
    class clsFuncionario
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }

        private string strSenha;

        public string StrSenha
        {
            get { return strSenha; }
            set { strSenha = value; }
        }

        private string strCPF;

        public string StrCPF
        {
            get { return strCPF; }
            set { strCPF = value; }
        }

        private string strNome;

        public string StrNome
        {
            get { return strNome; }
            set { strNome = value; }
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


        public clsFuncionario()
        {

        }
        public void Salvar()
        {
            //instrucoes para salvar o objeto cliente
            String SQl = "insert into FUNCIONARIO (CODIGO, SENHA, CPF, NOME, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO) values ( funcionario_seq1.nextval, '" + strSenha + "' ,'" + strCPF + "','" + strNome + "', '" + strEndereco + "', '" + strNumero + "', '" + strBairro + "', '" + strCidade + "', '" + strEstado + "')";
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
            string SQL = "DELETE FROM FUNCIONARIO WHERE CODIGO = '" + intCodigo + "'";
            try
            {
                BancoOracle.GetInstancia().Persistir(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     
        public void Alterar()
        {
            //instrucoes para alterar o objeto cliente
            string SQL = "UPDATE FUNCIONARIO SET SENHA = '" + strSenha + "', CPF = '" + strCPF + "', NOME = '" + strNome + "', ENDERECO = '" + strEndereco + "', NUMERO = '" + strNumero + "' , BAIRRO = '" + strBairro + "', CIDADE = '" + strCidade + "', ESTADO = '" + strEstado + "'  WHERE CODIGO = '" + intCodigo + "'";
            try
            {
                BancoOracle.GetInstancia().Persistir(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarSenha()
        {
            //instrucoes para alterar o objeto cliente
            string SQL = "UPDATE FUNCIONARIO SET SENHA = '" + strSenha + "' WHERE CODIGO = '" + intCodigo + "'";
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
            string SQL = "SELECT CODIGO, SENHA, CPF, NOME, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO  FROM FUNCIONARIO ORDER BY CODIGO";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os funcionarios cadastrados "
                    + ex.Message);
            }
        }

        public static DataTable recuperarSenha()
        {
            string SQL = "SELECT CODIGO, SENHA  FROM FUNCIONARIO";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os dados dos funcionarios cadastrados "
                    + ex.Message);
            }
        }



        public static DataTable recuperarTodosFiltro(string filtro)
        {
            //instrucoes para consultar objetos do tipo CLIENTE"
            string SQL = "SELECT CODIGO, SENHA, CPF, NOME, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO FROM FUNCIONARIO WHERE NOME LIKE '%"
                + filtro + "%' ORDER BY NOME";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os funcionarios cadastrados "
                    + ex.Message);
            }

        }

        public static List<clsFuncionario> listaFuncionario()
        {
            List<clsFuncionario> objLista = new List<clsFuncionario>();
            DataTable dtApoio = recuperarTodos();
            foreach (DataRow linha in dtApoio.Rows)
            {
                clsFuncionario objFuncionario = new clsFuncionario();
                objFuncionario.IntCodigo = Convert.ToInt32(linha["CODIGO"].ToString());
                objFuncionario.StrSenha = linha["SENHA"].ToString();
                objFuncionario.StrCPF = linha["CPF"].ToString();
                objFuncionario.StrNome = linha["NOME"].ToString();
                objFuncionario.StrEndereco = linha["ENDERECO"].ToString();
                objFuncionario.StrNumero = linha["NUMERO"].ToString();
                objFuncionario.StrBairro = linha["BAIRRO"].ToString();
                objFuncionario.StrCidade = linha["CIDADE"].ToString();
                objFuncionario.StrEstado = linha["ESTADO"].ToString();

                objLista.Add(objFuncionario);
            }
            return objLista;
        }

        public static bool exportarTXT(string caminho)
        {
            try
            {
                File.Delete(@caminho);
                StreamWriter objSW = new StreamWriter(@caminho, true);
                objSW.WriteLine("Cabeçalho: Dados do Funcionario");
                List<clsFuncionario> lista = listaFuncionario();
                foreach (clsFuncionario objA in lista)
                {
                    String linha = objA.IntCodigo + ";" + objA.StrSenha + ";" + objA.StrCPF + ";" + objA.StrNome + ";" + objA.StrEndereco + ";" + objA.StrNumero + ";" + objA.StrBairro + ";" + objA.StrCidade + ";" + objA.StrEstado;
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
                    if ((linha != "Cabeçalho: Dados do Funcionario") && (linha != ""))
                    {
                        String[] vetor = linha.Split(';');
                        clsFuncionario objFuncionario = new clsFuncionario();
                        objFuncionario.IntCodigo = Convert.ToInt16(vetor[0].ToString());
                        objFuncionario.StrSenha = vetor[1].ToString();
                        objFuncionario.StrCPF = vetor[2].ToString();
                        objFuncionario.StrNome = vetor[3].ToString();
                        objFuncionario.StrEndereco = vetor[4].ToString();
                        objFuncionario.StrNumero = vetor[5].ToString();
                        objFuncionario.StrBairro = vetor[6].ToString();
                        objFuncionario.StrCidade = vetor[7].ToString();
                        objFuncionario.StrEstado = vetor[8].ToString();


                        //verificar se ID ja existe no BD
                        DataTable dtApoio = recuperarCodigo(objFuncionario.IntCodigo);
                        if (dtApoio.Rows.Count == 0)
                        {
                            objFuncionario.Salvar();
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
            string SQL = "SELECT CODIGO, CPF, NOME, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO FROM FUNCIONARIO WHERE CODIGO = " + codigo;
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os dados dos funcionarios cadastrados "
                    + ex.Message);
            }

        }

        //preencher relatorio
        public static DataTable recuperarFuncionario()
        {
            string SQL = "SELECT CODIGO, NOME FROM FUNCIONARIO ";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os dados dos funcionarios cadastrados "
                    + ex.Message);
            }

        }
    }
}
