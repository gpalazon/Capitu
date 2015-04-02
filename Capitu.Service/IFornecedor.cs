using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Capitu.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFornecedor" in both code and config file together.
    [ServiceContract]
    public interface IFornecedor
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [Description("Retorna uma lista com todos os fornecedores cadastrados")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        List<FornecedorDTO> GetFornecedores();


        [OperationContract]
        [Description("Retorna o Fornecedor de acordo com o ID.")]
        [WebInvoke(Method="GET",
        BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetFornecedor?id={id}")]        
        FornecedorDTO GetFornecedorById(int id);
    }
}
