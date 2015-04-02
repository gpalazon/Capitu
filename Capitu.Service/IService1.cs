using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Capitu.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/GetPin")]
        List<FornecedorDTO> GetPin();

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class FornecedorDTO 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Descricao { get; set; }

        [DataMember]
        public decimal Preco { get; set; }

        [DataMember]
        public string Endereco { get; set; }

        [DataMember]
        public double GeoLong { get; set; }

        [DataMember]
        public double GeoLat { get; set; }

        [DataMember]
        public int Idade { get; set; }

        [DataMember]
        public decimal Altura { get; set; }

        [DataMember]
        public string Olhos { get; set; }
        
        [DataMember]
        public string Etnia { get; set; }

        [DataMember]
        public string Imagem { get; set; }

        [DataMember]
        public List<ImagemDTO> Fotos { get; set; }

    }

    [DataContract]

    public class ImagemDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UrlImagem { get; set; }

    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
