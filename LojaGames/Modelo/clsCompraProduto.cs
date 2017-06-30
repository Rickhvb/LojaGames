using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaGames.ConexaoBD;
using System.Data;
using System.IO;

namespace LojaGames.Modelo
{
    class clsCompraProduto
    {
        private int intCodCompra;

        public int IntCodCompra
        {
            get { return intCodCompra; }
            set { intCodCompra = value; }
        }

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

        public clsCompraProduto()
        {
        }

        public void Salvar()
        {
            String SQl = "insert into COMPRAPRODUTO (CODCOMPRA, CODPRODUTO, QTDE) values (" + intCodCompra + "," + intCodProduto + "," + intQtde + ") ";
            try
            {
                int numTuplas = BancoOracle.GetInstancia().Persistir(SQl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable recuperaDetalhes(int codigo)
        {
            string SQL = "select p.nome as nome_do_produto, p.marca, p.valor as valor_unitario, cp.qtde as quantidade from produto p, compra c, compraproduto cp where c.codigo = "
                + codigo +" and p.codigo = cp.codproduto and c.codigo = cp.codcompra order by p.nome, cp.qtde, p.valor";
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

        public static DataTable recuperaCodigoCompra()
        {
            string SQL = "SELECT COMPRA_SEQ1.CURRVAL FROM DUAL";
            try
            {
                return BancoOracle.GetInstancia().Consultar(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar código da compra "
                    + ex.Message);
            }
        }

    }
}
