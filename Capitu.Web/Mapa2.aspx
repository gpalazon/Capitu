<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Mapa2.aspx.cs" Inherits="Capitu.Web.Mapa2" %>

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

            var mapa;

            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (p) {

                    var LatLng = new google.maps.LatLng(p.coords.latitude, p.coords.longitude);
                    var mapOptions = {
                        center: LatLng,
                        zoom: 14,
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    };
                    
                    mapa = new google.maps.Map(document.getElementById("mapa"), mapOptions);
                    var markerPos = new google.maps.Marker({
                        position: LatLng,
                        map: mapa,
                        draggable: true,
                        icon: 'Images/user2.png'
                        //title: "<div style = 'height:60px;width:200px'><b>Your location:</b><br />Latitude: " + p.coords.latitude + "<br />Longitude: " + p.coords.longitude
                    });
                    
                });
            } else {

                var  latlng = new google.maps.LatLng(-23.561965, -46.6557745);

                var mapOptions = {
                    center: LatLng,
                    zoom: 13,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                mapa = new google.maps.Map(document.getElementById("mapa"), mapOptions);

                alert('Ops... Não foi possível encontrar a sua localização!.');
            }


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



            var marker5 = new google.maps.Marker
            (
                {
                    position: new google.maps.LatLng(-23.5654815, -46.657557),
                    map: mapa,
                    //animation: google.maps.Animation.DROP,
                    title: 'Clique aqui',
                    icon: 'Images/hotel.png'
                }
            );

            var infowindow5 = new google.maps.InfoWindow({
                content: '<html><body><table><tr><td></td><td rowspan="6"><img alt="" src="Images/modelo6.jpg" width="75px" /></td><td></td><td style="text-align: center;" colspan="2">Athenas Girls</td></tr><tr><td></td><td></td><td>Entrada: &nbsp;</td><td>R$50,00</td></tr><tr><td></td><td></td><td>Preço: &nbsp;</td><td>150-300</td></tr><tr><td></td><td></td><td colspan="2">Lindas garotas, shows todas <br />as noites e com direito a jantar <br />(seg a sex das 18:00 as 22:00)</td></tr><tr><td></td><td></td><td colspan="2"><a href="~/Perfil.aspx">Visualizar Perfil</a></td></tr></table></body></html>'
            });

            google.maps.event.addListener(marker5, 'click', function () {
                infowindow5.open(mapa, marker5);
            });
            
            /*var loc = {};
            var latlng;
            var geocoder = new google.maps.Geocoder();

            loc.lat = -23.561965;
            loc.lng = -46.6557745;

            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(
                    function (p) {
                        //get position from p.coords.latitude and p.coords.longitude
                        loc.lat = p.coords.latitude;
                        loc.lng = p.coords.longitude;
                    },
                    function () {
                        //denied or error
                        //use google.loader.ClientLocation
                        loc.lat = google.loader.ClientLocation.latitude;
                        loc.lng = google.loader.ClientLocation.longitude;
                    }
                );
            } else {
                //use google.loader.ClientLocation

                if (google.loader.ClientLocation) {
                    loc.lat = google.loader.ClientLocation.latitude;
                    loc.lng = google.loader.ClientLocation.longitude;

                    //latlng = new google.maps.LatLng(loc.lat, loc.lng);
                    //geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                    //    if (status == google.maps.GeocoderStatus.OK) {
                    //        alert(results[0]['formatted_address']);
                    //    };
                    //});
                }

            }            

            //var latlng = new google.maps.LatLng(-23.5645154, 46.6525527);
            //latlng = new google.maps.LatLng(-23.561965, -46.6557745);
            latlng = new google.maps.LatLng(loc.lat, loc.lng);
            

            var Opcoes = {
                zoom: 14,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            mapa = new google.maps.Map(document.getElementById("mapa"), Opcoes);

            var markerPos = new google.maps.Marker({
                map: mapa,
                draggable: true,
                icon: 'Images/user2.png'
            });

            markerPos.setPosition(latlng);

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

            

            var marker5 = new google.maps.Marker
            (
                {
                    position: new google.maps.LatLng(-23.5654815, -46.657557),
                    map: mapa,
                    //animation: google.maps.Animation.DROP,
                    title: 'Clique aqui',
                    icon: 'Images/hotel.png'
                }
            );

            var infowindow5 = new google.maps.InfoWindow({
                content: '<html><body><table><tr><td></td><td rowspan="6"><img alt="" src="Images/modelo6.jpg" width="75px" /></td><td></td><td style="text-align: center;" colspan="2">Athenas Girls</td></tr><tr><td></td><td></td><td>Entrada: &nbsp;</td><td>R$50,00</td></tr><tr><td></td><td></td><td>Preço: &nbsp;</td><td>150-300</td></tr><tr><td></td><td></td><td colspan="2">Lindas garotas, shows todas <br />as noites e com direito a jantar <br />(seg a sex das 18:00 as 22:00)</td></tr><tr><td></td><td></td><td colspan="2"><a href="~/Perfil.aspx">Visualizar Perfil</a></td></tr></table></body></html>'
            });

            google.maps.event.addListener(marker5, 'click', function () {
                infowindow5.open(mapa, marker5);
            });
            */
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

