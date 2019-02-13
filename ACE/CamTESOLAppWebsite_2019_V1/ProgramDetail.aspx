<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProgramDetail.aspx.vb" Inherits="ProgramDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0"/>
    <link rel="stylesheet" type="text/css" href="Styles/Program2.1.css" />
    <link rel="Stylesheet" type="text/css" href="/Styles/sp.css" /><link rel="Stylesheet" type="text/css" href="/Styles/sm.css" />
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.min.js"></script>
    <link href="css/camtesol_app.css" rel="stylesheet" />
    <link href="Styles/user_menu.css" rel="stylesheet" />
    <link rel="stylesheet" href="ism/css/my-slider.css" />
    <script src="js/jquery-latest.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/sliderMenu1.2.css" />
    <link rel="stylesheet" href="css/sliderMenuJquery.css" />
    <link rel="stylesheet" type="text/css" href="Styles/popup.css" />
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scriptManagerSchedule"></asp:ScriptManager>
        <div class="top_bar">
            <div id="Div_Breadscrum" style="float: left; display: none;" runat="server"></div>
            <div style="float: left; font-weight: 700;"><a href="#" runat="server" id="hrefBack" visible="true" onserverclick="hrefBack_ServerClick">Back</a></div>
            <div class="wrapper-demo">
                <div id="dd" class="wrapper-dropdown-5" tabindex="1">
                    <div style="position: relative; top: -13px; left: -115px; width: 170px; text-align: right; font-weight: 700;">
                        <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                    </div>
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
                                <img src="https://camtesol.org/Upload_s/Icon/Log out.png" style="float: left;" width="30px" height="30px"><i class="icon-user"></i>Sign Out
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div style="position: fixed; width: 100%; height: 100%; z-index: 991000; display: none; top: 0; left: 0" id="menuPanel" onclick="hideMenu(window.event)"></div>
        <div class="bottom_bar" runat="server" id="bottomMenu">
            <div class="menu_icon">
                <a runat="server" id="hrefHome" href="eace.aspx?homeMenu">
                    <img src="Upload_s/Icon/Home.png" width="30px" height="30px">
                    <p style="color: #333">Home</p>
                </a>
            </div>
            <div class="menu_icon">
                <a runat="server" id="hrefNews">
                    <img src="Upload_s/Icon/News.png" width="30px" height="30px">
                    <p style="color: #333">News</p>
                </a>
            </div>
            <div class="menu_icon">
                <a runat="server" id="hrefProgram">
                    <img src="Upload_s/Icon/Program.png" width="30px" height="30px">
                    <p style="color: #333">Program</p>
                </a>
            </div>
            <div style="clear: both;"></div>
        </div>
        <asp:UpdatePanel runat="server" ID="panelProgram" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:HiddenField runat="server" ID="hidConferenceType" Value="RS" />
                <asp:HiddenField runat="server" ID="hidConfDayActive" Value="0" />
                <asp:HiddenField runat="server" ID="hidTimeBoxActive" Value="-1" />
                <asp:HiddenField runat="server" ID="hidProgramScrollTop" Value="0" />
                <asp:HiddenField runat="server" ID="hidSearch" Value="" />
                <asp:HiddenField runat="server" ID="hidSearchConfDay" Value="0" />
                <asp:HiddenField runat="server" ID="hidSearchConfTime" Value="0" />
                <asp:HiddenField runat="server" ID="hidSearchStream" Value="0" />
                <asp:HiddenField runat="server" ID="hidSearchBookmark" Value="0"/>
                <asp:HiddenField runat="server" ID="hidIsBookmark" Value="0" />
                <asp:HiddenField runat="server" ID="hidSpeakerID" Value="0" />

                <asp:Button runat="server" ID="btnBookmark" style="display: none;" OnClick="btnBookmark_Click"/>
                <asp:Button runat="server" ID="btnSpeakerInfo" style="display: none;" OnClick="btnSpeakerInfo_Click"/>

                <div style="visibility: hidden; position: absolute; top: 4em; bottom: 6em; width: 100%; max-width: 1000px; left: 50%; transform: translateX(-50%); overflow: auto" runat="server" id="mainContainer">                    
                    <div id="divProgramContainer" runat="server" style="width: 100%;"></div>
                </div>
				
				<div class="popupPanel" runat="server" id="popupPanel"></div>

                <div class="popupBox" id="popupBoxSpeakerInfo" runat="server">
                    <div class="popupBody">
                        <div class="popupContent" runat="server" id="popupContentSpeakerInfo"></div>
                    </div>
                    <div class="popupFooter">
                        <div class="popupControlBox">
                            <asp:Button runat="server" ID="btnPopupNoSpeakerInfo" CssClass="popupNo" Text="Close" OnClick="btnPopupNoSpeakerInfo_Click"/>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress runat="server" ID="progressSchedule" AssociatedUpdatePanelID="panelProgram" DisplayAfter="700">
            <ProgressTemplate>
                <div class="popupPanelLoader"></div>
                <div class="loader"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>

    <script type="text/javascript">
        var scrollProgramTimeout = null;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                function fadeIn(id) {
                    $("#popupPanel").css("display", "block");
                    $("#" + id).css("display", "none");
                    $("#" + id).slideDown(500);
                }

                function fadeOut(id) {
                    $("#" + id).css("display", "block");
                    $("#" + id).slideUp(500);
                    $("#popupPanel").css("display", "none");
                }

                $(".bookmarkIcon").click(function () {
                    if ($(this).hasClass("bookmarkIconActive")) {
                        $(this).removeClass("bookmarkIconActive");
                        $("#<%= hidIsBookmark.ClientID%>").val(0);
                    } else {
                        $(this).addClass("bookmarkIconActive");
                        $("#<%= hidIsBookmark.ClientID%>").val(1);
                    }
                    $("#<%= btnBookmark.ClientID%>").click();
                });

                $(".speakerBox").click(function () {
                    $("#<%= hidSpeakerID.ClientID%>").val($(this).attr("data-speakerid"));
                    $("#<%= btnSpeakerInfo.ClientID%>").click();
                });

                $("#<%= btnPopupNoSpeakerInfo.ClientID%>").click(function (e) {
                    e.preventDefault();
                    fadeOut('<%= popupBoxSpeakerInfo.ClientID%>');
                    return false;
                });
            });
        }

        $(".bookmarkIcon").click(function () {
            if ($(this).hasClass("bookmarkIconActive")) {
                $(this).removeClass("bookmarkIconActive");
                $("#<%= hidIsBookmark.ClientID%>").val(0);
                    } else {
                        $(this).addClass("bookmarkIconActive");
                        $("#<%= hidIsBookmark.ClientID%>").val(1);
                    }
            $("#<%= btnBookmark.ClientID%>").click();
        });

        $(".speakerBox").click(function () {
            $("#<%= hidSpeakerID.ClientID%>").val($(this).attr("data-speakerid"));
            $("#<%= btnSpeakerInfo.ClientID%>").click();
        });

        $("#<%= btnPopupNoSpeakerInfo.ClientID%>").click(function (e) {
            e.preventDefault();
            fadeOut('<%= popupBoxSpeakerInfo.ClientID%>');
            return false;
        });

        function fadeIn(id) {
            $("#popupPanel").css("display", "block");
            $("#" + id).css("display", "none");
            $("#" + id).slideDown(500);
        }

        function fadeOut(id) {
            $("#" + id).css("display", "block");
            $("#" + id).slideUp(500);
            $("#popupPanel").css("display", "none");
        }
    </script>
    <script type="text/javascript" src="/Scripts/sp.js"></script>    
    <script type="text/javascript" src="/Scripts/classie.js"></script>
    <script type="text/javascript" src="/Scripts/slideJS.js"></script>
    <script src="js/user_menu.js"></script>
</body>
</html>
