using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaGames.ConexaoBD;
using System.Data;
using System.IO;

namespace LojaGames.Modelo
{
    class clsEstoque
    {
        private int intCodProduto;

        public int IntCodProduto
        {
            get { return intCodProduto; }
            set { intCodProduto = value; }
        }

        private int intQtde;

        public int IntQtde
        {
            get { return intQtde; }
            set { intQtde = value; }
        }

        public void Salvar()
        {
            String SQl = "insert into ESTOQUE (CODIGOPRODUTO, QTDE) values ('" + intCodProduto + "','" + intQtde + "')";
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
            string SQL = "UPDATE ESTOQUE SET QTDE = '" + intQtde +"' WHERE CODIGOPRODUTO = '" + intCodProduto + "'";
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
            string SQL = "SELECT E.CODIGOPRODUTO, P.NOME, E.QTDE, P.MARCA AS QUANTIDADE  FROM ESTOQUE E, PRODUTO P WHERE E.CODIGOPRODUTO = P.CODIGO ORDER BY CODIGOPRODUTO";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os dados cadastrados "
                    + ex.Message);
            }
        }

        public static DataTable recuperarTodosFiltro(string filtro)
        {
            string SQL = "SELECT E.CODIGOPRODUTO, P.NOME, E.QTDE AS QUANTIDADE  FROM ESTOQUE E, PRODUTO P WHERE E.CODIGOPRODUTO = P.CODIGO and P.NOME LIKE '%"
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

        public static DataTable recuperarQtdeProduto(int codigo)
        {
            string SQL = "SELECT QTDE FROM ESTOQUE WHERE CODIGOPRODUTO = '"+ codigo +"'";
            return BancoOracle.GetInstancia().Consultar(SQL);
        }
    }
}
