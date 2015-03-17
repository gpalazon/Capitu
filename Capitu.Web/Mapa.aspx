<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="Capitu.Web.Mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        //function InicializaMapa() {
        //    var latlng = new google.maps.LatLng(-15.682543, -47.978874);
        //    var opcoes = {
        //        zoom: 8,
        //        center: latlng,
        //        mapTypeId: google.maps.MapTypeId.ROADMAP
        //    };
        //    var mapa = new google.maps.Map(document.getElementById("mapa"), opcoes);
        //}
        //window.onload = InicializaMapa;

        var mapa;

        function RetornaHtml(nome, imagem, idade, etnia, olhos, custo)
        {            
            var conteudo = '<html><body><table><tr><td></td><td rowspan="6"><img alt="" src="' + imagem + '" width="75px" /></td><td></td><td>Nome: &nbsp;</td><td>' + nome + '</td></tr><tr><td></td><td></td><td>Idade: &nbsp;</td><td>' + idade + '</td></tr><tr><td></td><td></td><td>Etnia: &nbsp;</td><td>' + etnia + '</td></tr><tr><td></td><td></td><td>Olhos: &nbsp;</td><td>' + olhos + '</td></tr><tr><td></td><td></td><td>Preço: &nbsp;</td><td>' + custo + '</td></tr><tr><td></td><td></td><td colspan="2"><a href="../Perfil.aspx">Visualizar Perfil</a></td></tr></table></body></html>';
            return conteudo;
        }

        function IniciaMapa() {
            //var latlng = new google.maps.LatLng(-23.5645154, 46.6525527);
            var latlng = new google.maps.LatLng(-23.561965, -46.6557745);
            var Opcoes = {
                zoom: 14,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            mapa = new google.maps.Map(document.getElementById("mapa"), Opcoes);

            var marker = new google.maps.Marker
            (
                {
                    position: new google.maps.LatLng(-23.561965, -46.6557745),                    
                    map: mapa,
                    title: 'Clique aqui'
                }
            );
            var infowindow = new google.maps.InfoWindow({
                content: '<html><body><table><tr><td></td><td rowspan="6"><img alt="" src="Images/modelo1.jpg" width="75px" /></td><td></td><td>Nome: &nbsp;</td><td>Ana Bella</td></tr><tr><td></td><td></td><td>Idade: &nbsp;</td><td>28</td></tr><tr><td></td><td></td><td>Etnia: &nbsp;</td><td>Morena</td></tr><tr><td></td><td></td><td>Olhos: &nbsp;</td><td>Verdes</td></tr><tr><td></td><td></td><td>Preço: &nbsp;</td><td>R$200</td></tr><tr><td></td><td></td><td colspan="2"><a href="../Perfil.aspx">Visualizar Perfil</a></td></tr></table></body></html>'
                //content: RetornaHtml('Ana Bella',  'Images/modelo1.jpg', '22', 'Morena', 'Castanhos', 'R$300,00')
            });

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(mapa, marker);
            });

            var marker2 = new google.maps.Marker
            (
                {
                    position: new google.maps.LatLng(-23.5681011, -46.6552704),
                    map: mapa,
                    title: 'Clique aqui'
                }
            );
            
            var infowindow2 = new google.maps.InfoWindow({                
                content: '<html><body><table><tr><td></td><td rowspan="6"><img alt="" src="Images/modelo2.png" width="75px" /></td><td></td><td>Nome: &nbsp;</td><td>Barbara</td></tr><tr><td></td><td></td><td>Idade: &nbsp;</td><td>25</td></tr><tr><td></td><td></td><td>Etnia: &nbsp;</td><td>Morena</td></tr><tr><td></td><td></td><td>Olhos: &nbsp;</td><td>Verdes</td></tr><tr><td></td><td></td><td>Preço: &nbsp;</td><td>R$250</td></tr><tr><td></td><td></td><td colspan="2"><a href="../Perfil.aspx">Visualizar Perfil</a></td></tr></table></body></html>'
            });

            google.maps.event.addListener(marker2, 'click', function () {
                infowindow2.open(mapa, marker2);
            });

            var marker3 = new google.maps.Marker
            (
                {
                    position: new google.maps.LatLng(-23.566491, -46.6482424),
                    map: mapa,
                    title: 'Clique aqui'
                }
            );

            var infowindow3 = new google.maps.InfoWindow({                
                content: '<html><body><table><tr><td></td><td rowspan="6"><img alt="" src="Images/modelo4.jpg" width="75px" /></td><td></td><td>Nome: &nbsp;</td><td>Julia</td></tr><tr><td></td><td></td><td>Idade: &nbsp;</td><td>19</td></tr><tr><td></td><td></td><td>Etnia: &nbsp;</td><td>Loira</td></tr><tr><td></td><td></td><td>Olhos: &nbsp;</td><td>Verdes</td></tr><tr><td></td><td></td><td>Preço: &nbsp;</td><td>R$275</td></tr><tr><td></td><td></td><td colspan="2"><a href="../Perfil.aspx">Visualizar Perfil</a></td></tr></table></body></html>'
            });

            google.maps.event.addListener(marker3, 'click', function () {
                infowindow3.open(mapa, marker3);
            });
            
            var marker4 = new google.maps.Marker
            (
                {
                    position: new google.maps.LatLng(-23.567757, -46.6509546),
                    map: mapa,
                    title: 'Clique aqui'
                }
            );

            var infowindow4 = new google.maps.InfoWindow({
                content: '<html><body><table><tr><td></td><td rowspan="6"><img alt="" src="Images/modelo12.jpg" width="75px" /></td><td></td><td>Nome: &nbsp;</td><td>Jessica</td></tr><tr><td></td><td></td><td>Idade: &nbsp;</td><td>23</td></tr><tr><td></td><td></td><td>Etnia: &nbsp;</td><td>Negra</td></tr><tr><td></td><td></td><td>Olhos: &nbsp;</td><td>Pretos</td></tr><tr><td></td><td></td><td>Preço: &nbsp;</td><td>R$250</td></tr><tr><td></td><td></td><td colspan="2"><a href="../Perfil.aspx">Visualizar Perfil</a></td></tr></table></body></html>'
            });

            google.maps.event.addListener(marker4, 'click', function () {
                infowindow4.open(mapa, marker4);
            });

        }
        window.onload = IniciaMapa;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>        
        <%--<div id="mapa" style="width: 100%; top: 68px; left: 272px; position: absolute; height: 100%"></div>--%>
        <div id="mapa" style="width: 100%; position: absolute; height: 100%"></div>
    </div>
</asp:Content>

