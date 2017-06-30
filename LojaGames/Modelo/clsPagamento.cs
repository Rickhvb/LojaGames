using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaGames.ConexaoBD;
using System.Data;
using System.IO;

namespace LojaGames.Modelo
{
    class clsPagamento
    {
        private string strValorParcela;

        public string StrValorParcela
        {
            get { return strValorParcela; }
            set { strValorParcela = value; }
        }

        private int intCodigoVenda;

        public int IntCodigoVenda
        {
            get { return intCodigoVenda; }
            set { intCodigoVenda = value; }
        }

        private int intPagamento;

        public int IntPagamento
        {
            get { return intPagamento; }
            set { intPagamento = value; }
        }


        private string strDataP;

        public string StrDataP
        {
            get { return strDataP; }
            set { strDataP = value; }
        }

        private string strStatus;

        public string StrStatus
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        public clsPagamento()
        {

        }
        public void Salvar()
        {
            String SQl = "insert into PAGAMENTO (NPAGAMENTO, STATUS, CODCOMPRA, VALORPARCELA, DATAPAGAMENTO) values ( pagamento_seq1.nextval,'" + strStatus + "'," + intCodigoVenda + ", '" + strValorParcela + "', '" + strDataP + "') ";
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
            string SQL = "UPDATE pagamento SET STATUS = '" + strStatus + "', DATAPAGAMENTO = '" + strDataP + "' WHERE NPAGAMENTO = '" + intPagamento + "'";
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
            string SQL = "select p.npagamento as id_pagamento, p.codcompra as id_venda, cli.nome as cliente, p.datapagamento, C.DATACOMPRA, C.VALOR, c.numparcelas, p.valorparcela, p.status from pagamento p, cliente cli, compra c where c.codigocli = cli.codigo and p.codcompra = c.codigo";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os pagamentos cadastrados "
                    + ex.Message);
            }
        }

        public static DataTable recuperarTodosfiltro(string filtro)
        {

            string SQL = "select p.npagamento as id_pagamento, p.codcompra as id_venda, cli.nome as cliente, p.datapagamento, C.DATACOMPRA, C.VALOR, c.numparcelas, p.valorparcela, p.status from pagamento p, cliente cli, compra c where CLI.NOME LIKE '"
            + filtro + "%' and c.codigocli = cli.codigo and p.codcompra = c.codigo order by cli.nome, p.datapagamento, p.npagamento";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os pagamentos cadastrados "
                    + ex.Message);
            }
        }

        public static DataTable recuperarTodosfiltroStatus(string filtro)
        {

            string SQL = "select p.npagamento as id_pagamento, p.codcompra as id_venda, cli.nome as cliente, p.datapagamento, C.DATACOMPRA, C.VALOR, c.numparcelas, p.valorparcela, p.status from pagamento p, cliente cli, compra c where p.STATUS LIKE '"
            + filtro + "%' and c.codigocli = cli.codigo and p.codcompra = c.codigo order by cli.nome, p.datapagamento, p.npagamento";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar todos os pagamentos cadastrados "
                    + ex.Message);
            }
        }

    }
}
