<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWithToolTipOnPushpins.aspx.cs" Inherits="Samples_MapWithTooltips" %>

<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Google Map with customized icons</title>
</head>
<body>
    <form id="form1" runat="server">
    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Google map with tooltips on Pushpins.</h3>
    Mouse over on pushpins to see tooltips.
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

</body>
</html>
