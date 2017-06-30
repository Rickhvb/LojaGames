using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaGames.ConexaoBD;
using System.Data;
using System.IO;

namespace LojaGames.Modelo
{
    class clsFormaPagamento
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

        public clsFormaPagamento()
        {

        }
        public void Salvar()
        {
            //instrucoes para salvar o objeto categoria
            String SQl = "insert into FORMAPAGAMENTO (CODIGO, NOME) values (formapagamento_seq1.nextval,'" + strNome + "')";
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
            string SQL = "UPDATE FORMAPAGAMENTO SET NOME = '" + strNome + "' WHERE CODIGO = '" + intCodigo + "'";
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
            String SQl = "delete from FORMAPAGAMENTO where codigo =  " + intCodigo + "";
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
            string SQL = "SELECT CODIGO, NOME  FROM FORMAPAGAMENTO ORDER BY CODIGO";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todas as formas de pagamento cadastradas "
                    + ex.Message);
            }
        }



        public static DataTable recuperarTodosFiltro(string filtro)
        {
            //instrucoes para consultar objetos do tipo CLIENTE"
            string SQL = "SELECT CODIGO, NOME FROM FORMAPAGAMENTO WHERE NOME LIKE '%"
                + filtro + "%' ORDER BY NOME";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todas as formas de pagamento cadastradas "
                    + ex.Message);
            }

        }

        public static List<clsFormaPagamento> listaFormasPagamento()
        {
            List<clsFormaPagamento> objLista = new List<clsFormaPagamento>();
            DataTable dtApoio = recuperarTodos();
            foreach (DataRow linha in dtApoio.Rows)
            {
                clsFormaPagamento objFormaPagamento = new clsFormaPagamento();
                objFormaPagamento.IntCodigo = Convert.ToInt16(linha["CODIGO"].ToString());
                objFormaPagamento.StrNome = linha["NOME"].ToString();

                objLista.Add(objFormaPagamento);
            }
            return objLista;
        }

        public static bool exportarTXT(string caminho)
        {
            try
            {
                File.Delete(@caminho);
                StreamWriter objSW = new StreamWriter(@caminho, true);
                objSW.WriteLine("Cabeçalho: Formas de Pagamento");
                List<clsFormaPagamento> lista = listaFormasPagamento();
                foreach (clsFormaPagamento objA in lista)
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
                    if ((linha != "Cabeçalho: Formas de Pagamento") && (linha != ""))
                    {
                        String[] vetor = linha.Split(';');
                        clsFormaPagamento objFormaPagamento = new clsFormaPagamento();
                        objFormaPagamento.IntCodigo = Convert.ToInt16(vetor[0].ToString());
                        objFormaPagamento.StrNome = vetor[1].ToString();

                        //verificar se ID ja existe no BD
                        DataTable dtApoio = recuperarCodigo(objFormaPagamento.IntCodigo);
                        if (dtApoio.Rows.Count == 0)
                        {
                            objFormaPagamento.Salvar();
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
            string SQL = "SELECT CODIGO, NOME from FORMAPAGAMENTO WHERE CODIGO = " + codigo;
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar as formas de pagamento cadastradas "
                    + ex.Message);
            }

        }
    }
}
