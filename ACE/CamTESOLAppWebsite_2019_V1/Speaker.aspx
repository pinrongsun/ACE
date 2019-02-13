<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Speaker.aspx.vb" Inherits="Speaker" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Speaker</title><meta charset="UTF-8"><meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <link rel="Stylesheet" type="text/css" href="/Styles/sp.css" /><link rel="Stylesheet" type="text/css" href="/Styles/sm.css" />
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.min.js"></script>
    <link href="css/camtesol_app.css" rel="stylesheet" />
    <link href="Styles/user_menu.css" rel="stylesheet" />
    <link rel="stylesheet" href="ism/css/my-slider.css" />
    <script src="js/jquery-latest.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/sliderMenu1.2.css" />
    <link rel="stylesheet" href="css/sliderMenuJquery.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="mainScriptManager"></asp:ScriptManager>
        <div class="mainContainer">
			<%--<div class="top_bar" id="menuAppBar"><span id="openButton" class="menu-buttonApp">Open Menu</span></div>
            <div class="menu-wrap">
                <div><img src="/Upload_s/Icon/Small banner-01.jpg" class="div_logo"/></div>
                <nav class="menu"><div id="icon_List" class="icon-list" runat="server"></div></nav>
            </div>--%>
            <div class="top_bar">
                        <div id="Div_Breadscrum" style="float: left; display: none;" runat="server"></div>
                        <div style="float:left;font-weight:700;"><a href="#" runat="server" id="hrefBack" visible="true">Back</a></div>
                        <div class="wrapper-demo">
                            <div id="dd" class="wrapper-dropdown-5" tabindex="1">
                                <%--<div class="menu-button" style="color: #fff !important; top: -25px; left: -30px;"></div>--%>
                                <div style="position: relative;top: -13px;left: -115px;width: 170px;text-align: right;font-weight:700;"><asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label></div>
                                <ul class="dropdown">
                                    <li>
                                        <a id="hrefMyProfile" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=13&amp;ArticleID=66&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=0">
                                            <img src="/Upload_s/Icon/My Profile.png" style="float: left;" width="30px" height="30px"><i class="icon-user"></i>My Profile</a></li>
                                    <li>
                                        <a id="hrefPresentation" runat="server" class="icon-user" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=19&amp;ArticleID=68&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=0">
                                            <img src="/Upload_s/Icon/Submission Abstract.png" style="float: left;" width="30px" height="30px"><i class="icon-user"></i>My Presentation</a></li>
                                    <li>
                                        <a id="hrefSchedule" runat="server" class="icon-user" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=25&amp;ArticleID=110&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=0">
                                            <img src="/Upload_s/Icon/Schedule.png" style="float: left;" width="30px" height="30px"><i class="icon-user"></i>My Schedule</a>
                                    </li>
                                    <li>
                                        <a id="hrefPassword" runat="server" href="http://114.134.189.211:84/resetpwd?appView">
                                        <img src="/Upload_s/Icon/password.png" style="float: left; border: 1px solid #086aa9; background: #086aa9" width="30px" height="30px"><i class="icon-user"></i>Password</a>
                                    </li>
                                    <li>
                                        <a id="hrefLogOut" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=14&amp;ArticleID=0&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=1">
                                            <img src="https://camtesol.org/Upload_s/Icon/Log out.png" style="float: left;" width="30px" height="30px"><i class="icon-user"></i>Sign Out</a>
                                    </li>
                                </ul>
                            </div>
                        </div>


                        <%--<button id="openButton" class="menu-button">Open Menu</button>
                 <div id="Div_Breadscrum" runat="server" style="text-align:center;padding-top:15px;display:none"></div>
                 <div style="margin-left:0px;margin-right:0px;margin-top:40px;display:none">
                    <asp:LinkButton runat="server" ID="btnLogin" Text="Log In" CssClass="btnLogin" OnClick="btnLogin_Click" Visible="False"></asp:LinkButton>
                 </div>--%>
                    </div>

            <div style="position:fixed;width:100%;height:100%;z-index:991000;display:none;top:0;left:0" id="menuPanel" onclick="hideMenu(window.event)"></div>

            <div class="bottom_bar" runat="server" id="bottomMenu">
                    <div class="menu_icon">
                        <%--<a runat="server" id="hrefHome" ><img src="Upload_s/Icon/Accomodation.png" width="20px" height="20px"><br /><span style="top: -5px;position: relative;font-size:small;">Home</span></a>--%>
                        <a runat="server" id="hrefHome" href="eace.aspx?homeMenu">
                            <img src="Upload_s/Icon/Home.png" width="30px" height="30px">
                            <p style="color: #333">Home</p>
                        </a>
                    </div>
                    <div class="menu_icon">
                        <%--<a runat="server" id="hrefNews" ><img src="Upload_s/Icon/News.png" width="20px" height="20px"><br /><span style="top: -5px;position: relative;font-size:small;">News</span></a>--%>
                        <a runat="server" id="hrefNews">
                            <img src="Upload_s/Icon/News.png" width="30px" height="30px">
                            <p style="color: #333">News</p>
                        </a>
                    </div>
                    <div class="menu_icon">
                        <%--<a runat="server" id="hrefProgram" ><img src="Upload_s/Icon/Program.png" width="20px" height="20px"><br /><span style="top: -5px;position: relative;font-size:small;">Program</span></a>--%>
                        <a runat="server" id="hrefProgram">
                            <img src="Upload_s/Icon/Program.png" width="30px" height="30px">
                            <p style="color: #333">Program</p>
                        </a>
                    </div>
                    <%--<div class="menu_icon">
             <a runat="server" id="hrefPersonalise" ><img src="Upload_s/Icon/My Profile.png" width="20px" height="20px"><br /><span style="top: -5px;position: relative;font-size:small;">Personalise</span></a>
            </div>--%>
                    <div style="clear: both;"></div>
                </div>

            <asp:UpdatePanel runat="server" ID="panelSpeaker" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:HiddenField runat="server" ID="hidSpeakerID" Value="" ClientIDMode="Static"/>
                    <div class="speakerContainer" runat="server" id="speakerContainer" style="margin-bottom:4em;"></div>
                    <div class="popupPanel" id="popupPanelSpeaker"></div>
                    <div class="popupBox" id="popupBoxSpeaker">
                        <div class="popupBody" runat="server" id="popupBodySpeaker" style="padding: 0 20px;"></div>
                        <div class="popupFooter"><input type="button" value="Close" onclick="closePopup('popupBoxSpeaker', 'popupPanelSpeaker');" class="btnPopupNo"/></div>
                    </div>
                    <asp:Button runat="server" ID="btnSpeakerTopic" style="display: none;" OnClick="btnSpeakerTopic_Click"/>
					<div class="noConnectionBox"><img class="noConnectionImg" src="Upload_s/warning.png" /><div class="noConnectionText">No Connection</div></div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
		<asp:UpdateProgress runat="server" ID="progressSpeaker" AssociatedUpdatePanelID="panelSpeaker"><ProgressTemplate><div class="popupPanelLoader"></div><div class="loader"></div></ProgressTemplate></asp:UpdateProgress>
    </form>
    <script type="text/javascript" src="/Scripts/sp.js"></script>
    <%--<script type="text/javascript" src="/Scripts/main.1.0.js">--%>
    </script><script type="text/javascript" src="/Scripts/classie.js"></script>
    <script type="text/javascript" src="/Scripts/slideJS.js"></script>
    <script src="js/user_menu.js"></script>
    <%--<script src="js/bootstrap.min.js"></script>--%>
</body>
</html>
