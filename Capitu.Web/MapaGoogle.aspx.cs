using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capitu.Web
{
    public partial class MapaGoogle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GoogleMapForASPNet.GoogleMapObject.APIKey = "AIzaSyDG5b7ElYvhQKNrziU_AkjAe8ZWgkdp1w0";
                GoogleMapForASPNet.GoogleMapObject.APIVersion = "2";
                GoogleMapForASPNet.GoogleMapObject.Width = "800px";
                GoogleMapForASPNet.GoogleMapObject.Height = "600px";
                GoogleMapForASPNet.GoogleMapObject.ZoomLevel = 14;

                GoogleMapForASPNet.GoogleMapObject.CenterPoint = new GooglePoint("CenterPoint", 43.66619, -79.44268);

                GoogleMapForASPNet.GoogleMapObject.Points.Add(new GooglePoint("1", 43.65669, -79.45278));

                /*GooglePoint GP = new GooglePoint();
                GP.ID = "1";
                GP.Latitude = 43.65669;
                GP.Longitude = -79.43270;
                GoogleMapForASPNet.GoogleMapObject.Points.Add(GP);*/

                
            }
        }
    }
}