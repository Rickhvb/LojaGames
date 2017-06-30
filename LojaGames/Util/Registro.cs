using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//para usar o registry do Windows
using Microsoft.Win32;

namespace LojaGames.Util
{
    class Registro
    {
        private String strCaminho;

        public Registro()
        {
            strCaminho = "HKEY_CURRENT_USER\\Software\\LojaGames\\";
        }

        public void setValor(String campo, String valor)
        {
            Registry.SetValue(strCaminho, campo, valor, RegistryValueKind.String);
        }


        public String getValor(String campo)
        {
            try
            {
                return Registry.GetValue(strCaminho, campo, "").ToString();
            }
            catch (Exception)
            {
                Registry.SetValue(strCaminho, campo, "", RegistryValueKind.String);
                throw new Exception("SubChave '" + campo + "' não existe.");
            }
        }
    }
}
