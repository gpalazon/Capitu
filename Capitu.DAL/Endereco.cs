//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capitu.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public Nullable<int> CidadeId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<int> Numero { get; set; }
        public string Complemento { get; set; }
    }
}