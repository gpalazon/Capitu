using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capitu.MVC.Models;

namespace Capitu.MVC.Helpers
{
    public static class Util
    {

        public static string InsereImagem(string caminho, int tamanho)
        {
            //debug
            //string imgUrl = "<img src=" + caminho.Replace("~", "..") + " alt=" + caminho.Replace("~", "..") + " max-height='" + tamanho.ToString() +"px' />";
            string imgUrl = "<img src=" + caminho.Replace("~", "..") + " alt=" + caminho.Replace("~", "..") + " class='stretch' />";
            
            //string imgUrl = "<img src='/todotrampo" + caminho + "' alt='/todotrampo" + caminho + "' width='" + tamanho.ToString() + "px' />";

            return imgUrl;
        }

        public static string InsereAtributos(FornecedorVO model) 
        {
            //string "Morena, Olhos verdes, 28 anos, 1.80 de altura, 60 kilos."
            string ret = model.Etnia;
            
            if (model.Olhos != null)
                ret += ", Olhos " + model.Olhos;
            
            if (model.Idade != null)
                ret += ", " + model.Idade + " anos";

            if (model.Altura != null)
                ret += ", " + model.Altura + " de altura";
            
            if (model.Peso != null)
                ret += ", " + model.Peso + " kilos";

            ret += ".";

            return ret;
            
        }
    }
}