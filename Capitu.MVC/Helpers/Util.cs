using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}