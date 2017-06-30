using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LojaGames.ConexaoBD;

namespace LojaGames.Modelo
{
    class clsVenda
    {
        
        
        private int intCodigoVenda;

        public int IntCodigoVenda
        {
            get { return intCodigoVenda; }
            set { intCodigoVenda = value; }
        }

        private int intCodigoVendedor;

        public int IntCodigoVendedor
        {
            get { return intCodigoVendedor; }
            set { intCodigoVendedor = value; }
        }

        private string strValorCompra;

        public string StrValorCompra
        {
            get { return strValorCompra; }
            set { strValorCompra = value; }
        }

        private string strValorDesconto;

        public string StrValorDesconto
        {
            get { return strValorDesconto; }
            set { strValorDesconto = value; }
        }

        private int intNumParcela;

        public int IntNumParcela
        {
            get { return intNumParcela; }
            set { intNumParcela = value; }
        }

        private int intFormaPag;

        public int IntFormaPag
        {
            get { return intFormaPag; }
            set { intFormaPag = value; }
        }
        
        private string strDataV;

        public string StrDataV
        {
            get { return strDataV; }
            set { strDataV = value; }
        }


        private int intCodCli;

        public int IntCodCli
        {
            get { return intCodCli; }
            set { intCodCli = value; }
        }
        
        public clsVenda()
        {

        }
        public void Salvar()
        {
            String SQl = "insert into COMPRA (CODIGO, DATACOMPRA, VALOR, CODIGOCLI, CODFUNC, NUMPARCELAS, FORMPAGAMENTO, DESCONTO) values (compra_seq1.nextval,'" + strDataV + "','" + strValorCompra + "'," + intCodCli + "," + intCodigoVendedor + "," + intNumParcela + "," + intFormaPag + ",'" + strValorDesconto + "') ";
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
            String SQl = "delete from COMPRA where codigo =  " + intCodigoVenda + "";
            try
            {
                int numTuplas = BancoOracle.GetInstancia().Persistir(SQl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Consultar()
        {

        }

        // preencher o relatorio
        public static DataTable recuperaTodasVendas()
        {
            string SQL = "select f.codigo as codigofuncionario, f.nome as nomefuncionario, c.codigo as codigovenda, c.datacompra as datavenda, TO_NUMBER(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(c.VALOR,'R$ ',''),',','-'),'.','*'),'*',','),'-','.'),'9999.99') as valorvenda from funcionario f inner join compra c on c.codfunc = f.codigo";
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
        
        public static DataTable recuperaVendas()
        {
            string SQL = "select codigo as codigovenda, datacompra as datavenda, codfunc as codigofuncionario, TO_NUMBER(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(VALOR,'R$ ',''),',','-'),'.','*'),'*',','),'-','.'),'9999.99') compra";
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

        public static DataTable recuperarTodos()
        {
            string SQL = "SELECT C.CODIGO as Código_Venda, C.DATACOMPRA as Data_Compra, C.VALOR as Valor_Compra, CLI.CODIGO, CLI.CPF, CLI.NOME as Cliente, F.NOME as Vendedor, C.NUMPARCELAS as Parcelas, P.NOME as Pagamento, C.DESCONTO as Desconto FROM COMPRA C, CLIENTE CLI, FUNCIONARIO F, FORMAPAGAMENTO P WHERE CLI.CODIGO = C.CODIGOCLI AND F.CODIGO = C.CODFUNC AND P.CODIGO = C.FORMPAGAMENTO ORDER BY C.CODIGO";
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
            string SQL = "SELECT C.CODIGO as Código_Venda, C.DATACOMPRA as Data_Compra, C.VALOR as Valor_COMPRA,CLI.CODIGO, CLI.CPF,CLI.NOME as Cliente, F.NOME as Vendedor, C.NUMPARCELAS as Parcelas, P.NOME as Pagamento, C.DESCONTO as Desconto FROM COMPRA C, CLIENTE CLI, FUNCIONARIO F, FORMAPAGAMENTO P WHERE CLI.NOME LIKE '"
                + filtro + "%' AND CLI.CODIGO = C.CODIGOCLI AND F.CODIGO = C.CODFUNC AND P.CODIGO = C.FORMPAGAMENTO  ORDER BY CLI.NOME, C.DATACOMPRA, C.CODIGO";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos as vendas cadastradas "
                    + ex.Message);
            }

        }

        public static DataTable recuperaProdutos()
        {
            string SQL = "SELECT  P.CODIGO, P.NOME, P.VALOR, E.QTDE  FROM PRODUTO P, ESTOQUE E WHERE P.CODIGO = E.CODIGOPRODUTO";
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

        public static DataTable recuperaTodosProdutos(string filtro)
        {
            string SQL = "SELECT P.CODIGO, P.NOME, P.VALOR, E.QTDE  FROM PRODUTO P, ESTOQUE E WHERE P.CODIGO = E.CODIGOPRODUTO AND P.NOME LIKE '%"
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


        public static DataTable RecuperarCodigo(int codigo)
        {
            String SQL = "SELECT CODIGO, DATACOMPRA, VALOR, CODIGOCLI, CODFUNC, NUMPARCELAS, FORMPAGAMENTO, DESCONTO FROM COMPRA WHERE CODIGO = " + codigo;
            return BancoOracle.GetInstancia().Consultar(SQL);
        }
    }
}
