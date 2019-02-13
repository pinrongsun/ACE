<%@ Page Language="VB" AutoEventWireup="false" CodeFile="eace.aspx.vb" Inherits="ACEApp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="stylesheet" href="css/ACEApp_app.css">

    <link href="http://fonts.googleapis.com/css?family=PT+Sans+Narrow" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="ism/css/my-slider.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="ism/js/ism-2.0.1-min.js"></script>

    <link href="css/camtesol_app.css" rel="stylesheet" />
    <link href="css/style_login1.1.css" rel="stylesheet" type="text/css" />
    <style>
        /* do not group these rules */
        *::-webkit-input-placeholder {
            color: red;
        }

        *:-moz-placeholder {
            /* FF 4-18 */
            color: red;
        }

        *::-moz-placeholder {
            /* FF 19+ */
            color: red;
        }

        *:-ms-input-placeholder {
            /* IE 10+ */
            color: red;
        }

        .autocomplete_completionListElement {
            padding: 0px;
            margin: 0px !important;
            background-color: #C6EAE8;
            color: windowtext;
            border: buttonshadow;
            border-width: 1px;
            border-style: solid;
            cursor: 'default';
            overflow: auto;
            height: 200px;
            font-family: Tahoma;
            font-size: 16px;
            text-align: left;
            list-style-type: none;
            width: 100%;
        }
        /* AutoComplete highlighted item */
        .autocomplete_highlightedListItem {
            margin: 0px;
            background-color: #32B6AE;
            color: black;
            padding: 5px;
            font-size: 16px;
            width: 100%;
        }

        /* AutoComplete item */
        .autocomplete_listItem {
            background-color: #C6EAE8;
            color: windowtext;
            padding: 5px;
            line-height: 1em;
            font-size: 16px;
        }

        .step_image {
            width: 670px;
        }

        @media only screen and (max-width:777px) {
            .step_image {
                width: 280px;
            }
        }

        .btnStyle {
            background-color: lightskyblue;
            padding: 5px 20px;
            border-radius: 10px;
            color: black;
            border: none;
        }

        .btnSearchProgram {
            padding: 5px 20px;
            border-radius: 10px;
            margin-bottom: 5px;
            margin-top: 10px;
            background-color: lightblue;
            margin-right: 20px;
        }

        .btnLogin {
            float: right;
            padding: 5px 20px;
            border-radius: 10px;
            margin-top: 10px;
        }

            .btnLogin:hover {
                background-color: lightgrey;
                color: white;
                text-decoration: none;
            }

        .btnStyle:hover {
            background-color: deepskyblue;
            color: white;
            text-decoration: none;
        }

        .blockPanel {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: darkgrey;
            opacity: 0.8;
        }

        .centerPanel {
            position: fixed;
            width: 80%;
            max-width: 700px;
            box-shadow: 0 0 20px lightgrey;
            border-radius: 5px;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: snow;
        }

        .panelHeader, .panelBody, .panelFooter {
            padding: 10px;
            border-bottom: 1px solid lightgrey;
        }

        .panelHeaderTitle {
            padding-left: 30px;
        }

        .panelHeaderControl {
            float: right;
            margin-left: 10px;
            outline: none;
        }

            .panelHeaderControl:hover {
                border-radius: 20px;
                box-shadow: 0 0 10px deepskyblue;
                background-color: lightcyan;
            }

        .panelFooter {
            border-bottom: none;
        }

        .fieldBox {
            padding: 15px;
        }

        .fieldLabel {
            display: inline-block;
            width: 47%;
            text-align: right;
            max-width: 250px;
            margin-right: 5%;
        }

        .fieldTextBox {
            border: 1px solid darkgrey;
            border-radius: 5px;
            padding: 5px 10px;
            outline: 0;
        }

            .fieldTextBox:hover {
                border: 1px solid lightskyblue;
            }

            .fieldTextBox:focus {
                border: 1px solid deepskyblue;
            }

        .noShowUlStyle {
            box-shadow: 0 0 10px darkgrey;
            list-style-type: none;
            width: 90%;
            margin: 20px auto;
            background-color: aliceblue;
        }

            .noShowUlStyle > li {
                margin: 20px 0;
            }

        .noShowTimeGroup {
            display: block;
            text-align: center;
            padding: 20px;
            font-size: large;
            font-weight: bold;
            border-bottom: 1px solid lightgrey;
        }

        .tableRoomStyle {
            display: inline-block;
            margin: 20px;
            box-shadow: 0 0 5px darkgrey;
            vertical-align: top;
            width: 43.5%;
        }

            .tableRoomStyle tbody {
                display: block;
            }

            .tableRoomStyle tr {
                display: block;
                padding: 20px;
            }

        @media screen and (max-width: 778px) {
            .tableRoomStyle {
                width: 90%;
                margin-left: 50%;
                transform: translateX(-50%);
            }
        }

        .messageNotificationBox {
            position: fixed;
            z-index: 1018;
            top: -50px;
            width: 95%;
            max-width: 255px;
            text-align: center;
            left: 50%;
            transform: translateX(-50%);
            padding: 10px;
            box-shadow: 0 3px 17px #c3c3c3;
            background-color: #a0efff;
            border-radius: 10px;
            font-family: monospace;
        }

        .btnViewNewMessage {
            border: none;
            outline: none;
            background-color: transparent;
            font-family: monospace;
            color: #d63b16;
            padding: 0;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        function ClientItemSelected(sender, e) {
            $get("<%=hfCustomerId.ClientID %>").value = e.get_value();

         }


    </script>
    <script type="text/javascript">
        //        Open Popup Form
        function openModal() {
            $("#myModal").modal('show');
        }
        function closeModal() {


            $('#myModal').modal('hide');
            $('body').removeClass('modal-open');
        }

        //        How do I display a <div> table when a link is clicked? (variable-based)
        function toggleAppearance() {
            var dataDiv = document.getElementById("divNoShow");
            if (dataDiv.style.visibility == "hidden") {
                dataDiv.style.visibility = "visible";
            }
            else {
                dataDiv.style.visibility = "hidden";
            }
        }
        function ace_banner_onclick() {

        }


        /////
        function markas_selected(id, email, keyword, searchtype) {

            PageMethods.add_selected(id, email, keyword, searchtype, OnSuccess);


        }
        function OnSuccess(response, userContext, methodName) {
            document.getElementById("div_search_result").innerHTML = response;
            //alert(response);
        }

        function deselected(id, email, keyword, searchtype) {

            PageMethods.delete_selected(id, email, keyword, searchtype, OnSuccessDelete);


        }
        function OnSuccessDelete(response, userContext, methodName) {
            document.getElementById("div_search_result").innerHTML = response;
            //alert(response);
        }

        function showprofile(id, email, keyword, searchtype) {

            PageMethods.show_profile(id, email, keyword, searchtype, OnSuccessProfile);
        }
        function OnSuccessProfile(response, userContext, methodName) {
            document.getElementById("div_popup_enrolment").innerHTML = response;
            document.getElementById("div_header_title").innerHTML = "Speakers Profile";
            openModal();
            //alert(response);
        }
        function showabstract(id, email, keyword, searchtype) {

            PageMethods.show_abstract(id, email, keyword, searchtype, OnSuccessAbstract);
        }
        function OnSuccessAbstract(response, userContext, methodName) {
            document.getElementById("div_popup_enrolment").innerHTML = response;
            document.getElementById("div_header_title").innerHTML = "Abstract";
            openModal();
            //alert(response);
        }
    </script>

    <%--<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">--%>
    <link rel="stylesheet" href="css/Enrol_popup_app.css">
    <script src="js/slideJS.js"></script>
    <link rel="stylesheet" href="css/sliderMenu1.2.css" />
    <link rel="stylesheet" href="css/sliderMenuJquery.css" />
    <link href="Styles/user_menu.css" rel="stylesheet" />
    <script src="js/jquery-latest.min.js" type="text/javascript"></script>
   <%-- <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>--%>
    <script type = "text/javascript">
        var page = 0;
        function loadfeeds() {
            var MenuID = getParameterByName('MenuID');
            if (MenuID == 10) {
                loaddata();
            }
        }

        function loaddata() {

            //alert("page" & page);
            var AndroidID = getParameterByName('user');
            var deviceid = getParameterByName('deviceid');
            var PresenterID = getParameterByName('PresenterID');
            //alert(PresenterID);

            $.ajax({
                type: "POST",
                url: "eace.aspx/LoadFeed",
                data: '{page: ' + page + ', AndroidID:"' + AndroidID + '", deviceid: "' + deviceid + '", PresenterID:"' + PresenterID + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess2,
                failure: function (response) {
                    alert(response.d);

                }
            });
        }
        function OnSuccess2(response) {
            //alert(response.d);

            var divfeed = document.getElementById("divArticle");

            if (page >= 1) {
                var button_pre = document.getElementById("button" + (page - 1));
                button_pre.style.display = "none";
            }
            divfeed.innerHTML += response.d;
            page += 1;

        }

        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, '\\$&');
            var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, ' '));
        }
</script>
</head>


<body style="padding: 0px; margin: 0px" onload="loadfeeds()">
    <div style="position: fixed; width: 100%; height: 100%; opacity: 0.1%; z-index: 991000; display: none;" id="menuPanel" onclick="hideMenu(window.event)"></div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <asp:HiddenField ID="hfCustomerId" runat="server" />
        <div id="container">
            <asp:UpdatePanel runat="server" ID="panelCheckMessage" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="messageNotificationBox" id="messageNotificationBox" runat="server">
                        <span>You have new message.</span>
                        <asp:Button runat="server" ID="btnViewNewMessage" CssClass="btnViewNewMessage" Text="View" OnClick="btnViewNewMessage_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="container_header">
                    <%--Menu Slider--%>
                    <div class="menu-wrap">
                        <%--<div>
					    <img id="Img1" runat="server" src="Upload_s/Icon/Small banner-01.jpg" class="div_logo" onclick="return ace_banner_onclick()"/>
				    </div>--%>

                        <nav class="menu">
						<div id="icon_List" class="icon-list" runat="server">
							<ul>
								<li><a href="index.html" class="active"><i class="glyphicon glyphicon-home" aria-hidden="true"></i> Home</a></li>
								<li><a href="#about" class="scroll"><i class="glyphicon glyphicon-info-sign" aria-hidden="true"></i> About</a></li>
								<li><a href="#services" class="scroll"><i class="glyphicon glyphicon-cog" aria-hidden="true"></i> Services</a></li>
								<li><a href="#portfolio" class="scroll"><i class="glyphicon glyphicon-picture" aria-hidden="true"></i> Portfolio</a></li>
								<li><a href="#team" class="scroll"><i class="glyphicon glyphicon-user" aria-hidden="true"></i> Team</a></li>
								<li><a href="#skills" class="scroll"><i class="glyphicon glyphicon-wrench" aria-hidden="true"></i> Our Skills</a></li>
								<li><a href="#contact" class="scroll"><i class="glyphicon glyphicon-envelope" aria-hidden="true"></i> Contact</a></li>
							</ul>
						</div>
					</nav>
                        <%--<asp:ImageButton runat="server" class="close-button" id="close-button"/>--%>
                    </div>

                    <div class="top_bar">
                        <div id="Div_Breadscrum" style="float: left; display: none;" runat="server">Back</div>
                        <div style="float:left;font-weight:700;"><a href="#" runat="server" id="hrefBack" visible="false">Back</a></div>
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
                    <%--Menu Slider--%>
                </div>
            
            <div id="container_whole" style="margin:auto;">             
                <div style="height: 1px; background-color: #0090CC">
                </div>
                <div id="Div_B" runat="server" style="color: white; padding-top: 10px; padding-bottom: 10px; color: white; margin-left: 0px; background-color: #999999">
                    <table width="100%">
                        <tr>
                            <td align="left"></td>
                            <td align="right" style="padding-right: 20px"></td>
                        </tr>
                    </table>
                </div>
                <div id="container_menu" runat="server">
                    <div id="divHome" style="margin-top: 35px;" runat="server" visible="false">
                        <div style="margin: auto; max-width: 470px; text-align: center;">
                            <div>
                                <img src="Upload_s/Icon/banner.jpg" style="width: 100%;padding:10px;margin-top:-15px;margin-bottom:-15px;">
                            </div>
                            <div>
                                <div class="home_menu">
                                    <a id="hrefAboutCamTESOL" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=12&amp;ArticleID=108&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=1" class="scroll push">
                                        <img src="Upload_s/Icon/About.png" style="width: 100%;display:block;"><div style="clear:both;"></div>
                                        <span style="color: #333">About CamTESOL</span>
                                        </a>
                                </div>
                                <div class="home_menu push">
                                    <a id="hrefRegistration" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=23&amp;ArticleID=106&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=0" class="scroll push">
                                        <img src="Upload_s/Icon/Registration.png" style="width: 100%;display:block;"><span style="color: #333">Registration</span></a>
                                </div>
                                <div class="home_menu push">
                                    <a id="hrefPlenarySpeaker" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=24&amp;ArticleID=109&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=0" class="scroll push">
                                        <img src="Upload_s/Icon/Speaker.png" style="width: 100%;display:block;"><span style="color: #333">Plenary Speakers</span></a>
                                </div>
                                <div style="clear: both;"></div>
                            </div>

                            <div>
                                <div class="home_menu push">
                                    <a id="hrefVenue" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=4&amp;ArticleID=11&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=1" class="scroll">
                                        <img src="Upload_s/Icon/map.png" style="width: 100%;display:block;"><span style="color: #333">Venue</span></a>
                                </div>
                                <div class="home_menu push">
                                    <a id="hrefAccommodation" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=4&amp;ArticleID=11&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=1" class="scroll">
                                        <img src="Upload_s/Icon/Accomodation.png" style="width: 100%;display:block;"><span style="color: #333">Accommodation</span></a>
                                </div>
                                <div class="home_menu push">
                                    <a id="hrefContactUs" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=2&amp;ArticleID=20&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=1" class="scroll">
                                        <img src="Upload_s/Icon/Contact Us.png" style="width: 100%;display:block;"><span style="color: #333">Contact Us</span></a>
                                </div>
                                <div style="clear: both;"></div>
                            </div>
                            <div class="home_menu push">
                                <a id="hrefSponsor" runat="server" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=5&amp;ArticleID=105&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=1" class="scroll">
                                    <img src="Upload_s/Icon/Sponsor.png" style="width: 100%;display:block;"><span style="color: #333">Sponsors and Exhibitors</span></a>
                            </div>
                            <div style="clear: both;"></div>
                        </div>
                    </div>
                    <div id="divArticle" runat="server" style="width: 100%; margin-left: 10px; margin-bottom: 5em; margin-top: 30px;">
                    </div>
                    <iframe id="iframeRegistration" runat="server" style="width: 95%; margin-left: 10px; margin-bottom: 10px; margin-top: 50px;" src="https://camtesol.org/mycamtesol?AppView=Registration&amp;user=_user_" width="95%" height="100%" frameborder="0" visible="false"></iframe>
                    <div id="divNoShow" runat="server"
                        style="width: 100%;">
                        <div style="padding: 10px; margin-top: 40px;">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <div style="margin-top: 40px">
                                        <div class="button_program">
                                            <asp:LinkButton ID="lnkByTitle" runat="server" ForeColor="White">Search by Presentation Title</asp:LinkButton>
                                        </div>
                                        <br />
                                        <div class="button_program">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White">Search by Presentation Stream</asp:LinkButton>
                                        </div>
                                        <br />
                                        <div class="button_program">
                                            <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="White">Search by Presentation Day/Time</asp:LinkButton>
                                        </div>
                                        <br />
                                        <div class="button_program">
                                            <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="White">Search by Presenter</asp:LinkButton>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <div style="background-color: #FFFFFF; padding-top: 10px; padding-bottom: 10px;">
                                        &nbsp; The 13th Annual CamTESOL Conference offers around 350 different parallel 
                                presentations across 21 streams.
                                <br />
                                        <br />
                                        &nbsp;The full presentation program
                                <span style="color: rgb(51, 51, 51); font-family: SEGOEUIL, &quot; helvetica neue&quot; , arial, clean, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                                    <span class="Apple-converted-space">&nbsp;</span>for<span
                                        class="Apple-converted-space">&nbsp;</span></span><strong
                                            style="font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-variant-numeric: inherit; font-weight: 700; font-stretch: inherit; font-size: 14px; line-height: inherit; font-family: SEGOEUIL, &quot; helvetica neue&quot; , arial, clean, sans-serif; vertical-align: baseline; margin: 0px; padding: 0px; color: rgb(51, 51, 51); letter-spacing: normal; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">Research 
                                Symposium</strong> is available to 
                                <span style="color: #ffffff; background-color: #32b6ae; padding: 5px; border-radius: 5px;"><strong><a style="color: #ffffff;" href="https://drive.google.com/file/d/0B43FTKvVdRW8ZW1MZ3BZRTExd1E/view?usp=sharing" target="_blank">download in PDF</a></strong>
                                </span>

                                        <asp:ImageButton ID="imgPDF0" runat="server" Height="30px"
                                            ImageUrl="~/img/pdf-icon.png" />
                                        &nbsp;
                                <br />
                                        <br />
                                        &nbsp;The full presentation program
                                <span style="color: rgb(51, 51, 51); font-family: SEGOEUIL, &quot; helvetica neue&quot; , arial, clean, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                                    <span class="Apple-converted-space">&nbsp;</span>for<span
                                        class="Apple-converted-space">&nbsp;</span></span><strong
                                            style="font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-variant-numeric: inherit; font-weight: 700; font-stretch: inherit; font-size: 14px; line-height: inherit; font-family: SEGOEUIL, &quot; helvetica neue&quot; , arial, clean, sans-serif; vertical-align: baseline; margin: 0px; padding: 0px; color: rgb(51, 51, 51); letter-spacing: normal; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">Main 
                                Conference</strong> is available to
                                <span style="color: #ffffff; background-color: #32b6ae; padding: 5px; border-radius: 5px;">
                                    <strong><a href="https://drive.google.com/file/d/0B43FTKvVdRW8dXBDX25obFNXTFU/view?usp=sharing" target="_blank"
                                        style="color: #ffffff;">download in PDF</a></strong> </span>
                                        <asp:ImageButton ID="imgPDF1" runat="server" Height="30px"
                                            ImageUrl="~/img/pdf-icon.png" />
                                        &nbsp;
                                <br />
                                        <br />
                                        &nbsp;Note: The Program Committee reserves the rights to make necessary change.
                                <br />
                                        <br />
                                        &nbsp;Use the ‘Search’ option below to browse the available presentation topics and 
                                speakers.
                                <br />
                                    </div>
                                    <div style="padding: 10px; border: thin solid #C0C0C0; margin-top: 20px;">
                                        <div style="padding: 10px; font-weight: bold">
                                            Search By:
                                        </div>
                                        <div>
                                            <asp:DropDownList ID="dplSearchField" runat="server" AutoPostBack="True"
                                                CssClass="textbox_program" Width="100%">
                                                <asp:ListItem>Presentation Title</asp:ListItem>
                                                <asp:ListItem>Presentation Steam</asp:ListItem>
                                                <asp:ListItem>Presentation day/time</asp:ListItem>
                                                <asp:ListItem>Presenter</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>


                                        <asp:MultiView ID="MultiView2" runat="server">
                                            <asp:View ID="View44" runat="server">

                                                <div style="margin-top: 20px">
                                                    Please input title keyword:
                                    <div>
                                        <table width="100%">
                                            <tr>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtKeywordTitle" runat="server" placeholder=""
                                                        CssClass="textbox_program" Width="100%" AutoPostBack="True"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                        CompletionInterval="100"
                                                        CompletionListCssClass="autocomplete_completionListElement"
                                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                        CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="10"
                                                        EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="2"
                                                        OnClientItemSelected="ClientItemSelected" ServiceMethod="LoadTitle"
                                                        TargetControlID="txtKeywordTitle">
                                                    </cc1:AutoCompleteExtender>

                                                </td>
                                                <td width="60px" valign="top">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search"
                                                        CssClass="button_program" Style="width: 100%" /></td>
                                            </tr>
                                        </table>

                                    </div>

                                                </div>
                                            </asp:View>
                                            <asp:View ID="View5" runat="server">
                                                <div style="margin-top: 20px">
                                                    Please select stream:
                                    <div>
                                        <table width="100%">
                                            <tr>
                                                <td valign="top">
                                                    <asp:DropDownList ID="dplStream" CssClass="textbox_program" Width="100%"
                                                        runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>

                                    </div>

                                                </div>
                                            </asp:View>
                                            <asp:View ID="View6" runat="server">
                                                <div style="margin-top: 20px">
                                                </div>
                                                <div>


                                                    <table width="100%">
                                                        <tr>
                                                            <td valign="top">Please select day:
                                                            </td>
                                                            <td valign="top">Please select time:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="dplDay" runat="server" AutoPostBack="True"
                                                                    CssClass="textbox_program" Width="90%">
                                                                    <asp:ListItem>Friday</asp:ListItem>
                                                                    <asp:ListItem>Saturday</asp:ListItem>
                                                                    <asp:ListItem>Sunday</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="dplTime" runat="server" AutoPostBack="True"
                                                                    CssClass="textbox_program" Width="90%">
                                                                    <asp:ListItem>Friday</asp:ListItem>
                                                                    <asp:ListItem>Saturday</asp:ListItem>
                                                                    <asp:ListItem>Sunday</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </div>

                                            </asp:View>
                                            <asp:View ID="View7" runat="server">
                                                <div style="margin-top: 20px">
                                                    Please input presenter's name
                                                </div>
                                                <div>
                                                    <table width="100%">
                                                        <tr>
                                                            <td valign="top">

                                                                <%--    <asp:UpdatePanel ID="UpdatePanel4" runat="server">               
                                <ContentTemplate>--%>
                                                                <asp:TextBox ID="txtPresenter" runat="server" CssClass="textbox_program"
                                                                    placeholder="" Width="100%"
                                                                    AutoPostBack="True"></asp:TextBox>
                                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                                    CompletionInterval="100"
                                                                    CompletionListCssClass="autocomplete_completionListElement"
                                                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="10"
                                                                    EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="2"
                                                                    OnClientItemSelected="ClientItemSelected" ServiceMethod="LoadPresenter"
                                                                    TargetControlID="txtPresenter">
                                                                </cc1:AutoCompleteExtender>
                                                                <%--</ContentTemplate>
                           </asp:UpdatePanel>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                            </asp:View>
                                        </asp:MultiView>
                                    </div>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <div style="">
                                        <div class="headertext"
                                            style="margin-top: 10px; width: 100%; float: left; font-weight: 700;">
                                            General Enquiries
                                        </div>

                                    </div>

                                    <div class="headertext" style="float: left;">
                                        Subject:<asp:TextBox ID="txtSubject" runat="server"
                                            CssClass="textbox_program" placeholder="" Width="100%"></asp:TextBox>
                                        <br />
                                        Message:
                                <asp:TextBox ID="txtMessage" runat="server"
                                    CssClass="textbox_program" Height="100px" placeholder=""
                                    TextMode="MultiLine" Width="100%"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblinfoEmail" runat="server"></asp:Label>
                                        <br />

                                        <asp:Button ID="btnSearch0" runat="server" CssClass="button_program"
                                            Style="width: 100%" Text="SEND" />
                                    </div>

                                </asp:View>
                                <asp:View ID="View4" runat="server">
                                    <div>
                                        <div class="headertext"
                                            style="margin-top: 10px; width: 100%; float: left; color: rgb(36, 132, 128); font-weight: 700;">
                                            MY PROFILE
                                        </div>
                                    </div>

                                    <div class="headertext" style="float: left; color: rgb(36, 132, 128);">
                                        Full Name:<asp:TextBox ID="txtFullName" runat="server"
                                            CssClass="textbox_program" placeholder="" Width="100%"></asp:TextBox>
                                        <br />
                                        Email:<br />
                                        &nbsp;<asp:TextBox ID="txtEmailProfile" runat="server"
                                            CssClass="textbox_program" Enabled="False" placeholder="" Width="100%"></asp:TextBox>
                                        <br />
                                        Position:<br />
                                        &nbsp;<asp:TextBox ID="txtPosition" runat="server"
                                            CssClass="textbox_program" placeholder="" Width="100%"></asp:TextBox>
                                        <br />
                                        Employer:<br />
                                        &nbsp;<asp:TextBox ID="txtEmployer" runat="server"
                                            CssClass="textbox_program" placeholder="" Width="100%"></asp:TextBox>
                                        <br />
                                        Country:<br />
                                        &nbsp;<asp:TextBox ID="txtCountry" runat="server"
                                            CssClass="textbox_program" placeholder="" Width="100%"></asp:TextBox>

                                        <br />

                                        Password:<br />
                                        <asp:TextBox ID="txtPasswordProfile" runat="server" CssClass="textbox_program"
                                            Width="100%" TextMode="Password"></asp:TextBox>
                                        <br />
                                        Retype Password:<br />
                                        &nbsp;<asp:TextBox ID="txtConfirmPasswordProfile"
                                            runat="server"
                                            Width="100%" TextMode="Password" CssClass="textbox_program"
                                            ForeColor="Black" Height="50px" />
                                        <br />
                                        <asp:Label ID="lblInfoProfile" runat="server"></asp:Label>
                                        <br />
                                        <asp:Button ID="btnSaveProfile" runat="server" CssClass="button_program"
                                            Style="width: 100%" Text="SAVE" />
                                        &nbsp;
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                            <div id="div_fullprogram" runat="server" style="padding: 10px 10px 10px 0px"
                                visible="False">

                                <asp:LinkButton ID="lnkDownload" runat="server" ForeColor="#1A605C">Download Full Program</asp:LinkButton>
                                <asp:ImageButton ID="imgPDF" runat="server" Height="30px"
                                    ImageUrl="~/img/pdf-icon.png" />
                            </div>
                        </div>

                        <div id="div_search_result" runat="server"></div>

                    </div>

                    <div style="width: 100%; display: none;" id="divmenu" runat="server">

                        <div class="div_menu_with_4">
                            <div class="divprevious_issue_begin">
                                <a href="#">
                                    <div style=''>
                                        <img src="img/Menu/Program.jpg" style="width: 100%" class='magazine-image' />
                                    </div>
                            </div>

                            <div class="divprevious_issue_middle">

                                <a href="#">
                                    <div style=''>
                                        <img src="img/Menu/Enrolment.jpg" style="width: 100%" class='magazine-image' />
                                    </div>
                                </a>

                            </div>
                        </div>

                        <div class="div_menu_with_4">
                            <div class="divprevious_issue_begin">
                                <a href="#">
                                    <div style=''>
                                        <img src="img/Menu/Program.jpg" style="width: 100%" class='magazine-image' />
                                    </div>
                            </div>

                            <div class="divprevious_issue_middle">

                                <a href="#">
                                    <div style=''>
                                        <img src="img/Menu/Enrolment.jpg" style="width: 100%" class='magazine-image' />
                                    </div>
                                </a>

                            </div>
                        </div>

                        <div class="div_menu_with_4">
                            <div class="divprevious_issue_begin">

                                <a href="#">
                                    <div style=''>
                                        <img src="img/Menu/Class-Schedule.jpg" style="width: 100%" class='magazine-image' />
                                    </div>
                                </a>

                            </div>

                            <div class="divprevious_issue_middle">

                                <a href="#">
                                    <div style=''>
                                        <img src="img/Menu/Academic-record.jpg" style="width: 100%" class='magazine-image' />
                                    </div>
                                </a>

                            </div>
                        </div>

                        <div class="div_menu_with_4">
                            <div class="divprevious_issue_begin">

                                <a href="#">
                                    <div style=''>
                                        <img src="img/Menu/Up-coming-event.jpg" style="width: 100%" class='magazine-image' />
                                    </div>
                                </a>

                            </div>

                            <div class="divprevious_issue_middle">

                                <a href="#">
                                    <div style=''>
                                        <img src="img/Menu/Info-Centre.jpg" style="width: 100%" class='magazine-image' />
                                    </div>
                                </a>

                            </div>
                        </div>

                    </div>

                </div>

                <div id="div_change_password" runat="server" class="profile">
                    <div style="margin-left: 15px; margin-top: 15px; margin-bottom: 15px; color: #0090CC; font-size: 22px">
                        Change Password 
                <div style="margin-left: 15px; margin-top: 15px; margin-bottom: 15px; color: #fbfbfb">
                    <div>
                        <table>
                            <tr>
                                <td style="width: 110px">Old Password</td>
                                <td style="width: 8px">:</td>
                                <td>

                                    <asp:TextBox ID="txtOldPassword" runat="server" Width="200" TextMode="Password" class="form-control"></asp:TextBox>


                                </td>
                            </tr>
                        </table>
                    </div>

                    <div style="margin-top: 10px; margin-bottom: 10px">
                        <table>
                            <tr>
                                <td style="width: 110px">New Password</td>
                                <td style="width: 8px">:</td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtNewPassword" runat="server" Width="200" TextMode="Password" class="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Font-Size="12px" ForeColor="Red" ErrorMessage="Minimum 4 characters and at least one number and one character." ValidationExpression="^(?=.*\d)(?=.*[a-zA-Z]).{4,}$" ControlToValidate="txtNewPassword" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>


                                </td>
                            </tr>
                        </table>
                    </div>

                    <div>
                        <table>
                            <tr>
                                <td style="width: 110px">Confirm</td>
                                <td style="width: 8px">:</td>
                                <td>

                                    <asp:TextBox ID="txtRetypePassword" runat="server" Width="200" TextMode="Password" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div style="margin-top: 5px">
                        <asp:Label ID="lblalert_password" runat="server" ForeColor="red" Text=""></asp:Label>
                    </div>

                    <div style="margin-top: 15px">
                        <asp:Button ID="cmdSavePassword" runat="server" Text="Save" Width="80" class="btn btn-success" />
                    </div>
                </div>
                    </div>

                    <div id="container_footer">
                        <table style="width: 100%; color: white">
                            <tr>
                                <td align="center">All right reserved.
                            <asp:HiddenField ID="hdWebsite" runat="server" Value="eace.aspx" />
                                </td>
                            </tr>
                        </table>

                    </div>
                </div>
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header" style="padding: 1em 1em 0em;">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">
                                    <div id="div_header_title" style="font-family: 'Open Sans', sans-serif; font-weight: bold; color: #31958d;">Modal Header</div>
                                </h4>
                            </div>
                            <div class="modal-body" id="div_popup_enrolment" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            <img src="../../../Upload_s/Menu/Enrolment.jpg" style="width: 100%" /></td>
                                        <td>
                                            <img src="../../../Upload_s/Menu/Enrolment.jpg" style="width: 100%" /></td>
                                    </tr>
                                </table>
                            </div>


                        </div>

                    </div>
                </div>

                

            </div>
            <div class="bottom_bar" runat="server" id="bottomMenu">
                    <div class="menu_icon">
                        <%--<a runat="server" id="hrefHome" ><img src="Upload_s/Icon/Accomodation.png" width="20px" height="20px"><br /><span style="top: -5px;position: relative;font-size:small;">Home</span></a>--%>
                        <a runat="server" id="hrefHome">
                            <img src="Upload_s/Icon/Home.png" class="bottom_icon" runat="server" id="imgHome">
                            <p style="color: #333">Home</p>
                        </a>
                    </div>
                    <div class="menu_icon">
                        <%--<a runat="server" id="hrefNews" ><img src="Upload_s/Icon/News.png" width="20px" height="20px"><br /><span style="top: -5px;position: relative;font-size:small;">News</span></a>--%>
                        <a runat="server" id="hrefNews">
                            <img src="Upload_s/Icon/News.png" class="bottom_icon" runat="server" id="imgNews">
                            <p style="color: #333">News</p>
                        </a>
                    </div>
                    <div class="menu_icon">
                        <%--<a runat="server" id="hrefProgram" ><img src="Upload_s/Icon/Program.png" width="20px" height="20px"><br /><span style="top: -5px;position: relative;font-size:small;">Program</span></a>--%>
                        <a runat="server" id="hrefProgram">
                            <img src="Upload_s/Icon/Program.png" class="bottom_icon" id="imgProgram" runat="server">
                            <p style="color: #333">Program</p>
                        </a>
                    </div>
                    <%--<div class="menu_icon">
                     <a runat="server" id="hrefPersonalise" ><img src="Upload_s/Icon/My Profile.png" width="20px" height="20px"><br /><span style="top: -5px;position: relative;font-size:small;">Personalise</span></a>
                    </div>--%>
                    <div style="clear: both;"></div>
                </div>
            <div runat="server" id="blockPanel" class="blockPanel" style="display: none;"></div>
            <div runat="server" id="loginPanel" style="display: none;" class="centerPanel">
                <div class="panelHeader">
                    <asp:ImageButton runat="server" ID="closeLoginPanel" CssClass="panelHeaderControl" ImageUrl="~/img/closeIcon.png" Width="30px" Height="30px" OnClick="closeLoginPanel_Click"></asp:ImageButton>
                    <h4 class="panelHeaderTitle">Log In</h4>

                </div>
                <div class="panelBody">
                    <div class="fieldBox">
                        <label for="txtUsername" class="fieldLabel">Username :</label>
                        <asp:TextBox runat="server" ID="txtUsername" ClientIDMode="Static" CssClass="fieldTextBox"></asp:TextBox>
                    </div>
                    <div class="fieldBox">
                        <label for="txtPassword" class="fieldLabel">Password :</label>
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" ClientIDMode="Static" CssClass="fieldTextBox"></asp:TextBox>
                    </div>
                    <div class="fieldBox" style="text-align: center;">
                        <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="panelFooter">
                    <div style="text-align: center">
                        <asp:Button ID="btnCheckLogin" runat="server" Text="Log In" CssClass="btnStyle" OnClick="btnCheckLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        var checkNewMessageInterval = null;
        var isCheckNewMessage = false;

        function getParameterByName(name, url) {
            if (!url) url = window.location.href.toLowerCase();
            name = name.replace(/[\[\]]/g, "\\$&").toLowerCase();
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';

            return results[2];
        }

        function animateNewMessage() {
            $("#<%= messageNotificationBox.ClientID%>").animate({ top: "10px" }, 600);
        }

        function checkNewMessage() {
            if (!isCheckNewMessage) {
                isCheckNewMessage = true;
                var user = getParameterByName('user');
                var deviceID = getParameterByName('deviceID');
                var presenterID = getParameterByName('presenterID');
                if (user == null || user == '' || deviceID == null || deviceID == '') {
                    clearInterval(checkNewMessageInterval);
                    checkNewMessageInterval = null;
                    return;
                }
                if (presenterID == null || presenterID == '') { presenterID = 0; }
                $.ajax({
                    type: "POST",
                    url: "eace.aspx/checkHasNewMessage",
                    data: "{user: '" + user + "', deviceID: '" + deviceID + "', presenterID: '" + presenterID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == '1') {
                            animateNewMessage();
                            clearInterval(checkNewMessageInterval);
                            checkNewMessageInterval = null;
                        } else if (response.d == '-1') {
                            clearInterval(checkNewMessageInterval);
                            checkNewMessageInterval = null;
                        }
                        isCheckNewMessage = false;
                    },
                    failure: function (response) {
                        clearInterval(checkNewMessageInterval);
                        checkNewMessageInterval = null;
                        isCheckNewMessage = false;
                    },
                    error: function (response) {
                        clearInterval(checkNewMessageInterval);
                        checkNewMessageInterval = null;
                        isCheckNewMessage = false;
                    }
                });
            }
        }

        checkNewMessageInterval = setInterval(checkNewMessage, 5000);
        checkNewMessage();
    </script>

    <script type="text/javascript">
        $(".toggleContent").css("display", "none");
        $(".toggleLink").click(function () {
            $(this).next(".toggleContent").slideToggle();
        });
    </script>
    <script type="text/javascript" src="js/classie.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript" src="js/easyResponsiveTabs.js"></script>
    <script type="text/javascript" src="js/jquery.circlechart.js"></script>
    <script type="text/javascript" src="js/jquery.easy-gallery.js"></script>
    <script type="text/javascript" src="js/jquery.flexslider.js"></script>
    <%--<script type="text/javascript" src="js/main.1.0.js"></script>--%>
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/SmoothScroll.min.js"></script>
    <script src="js/user_menu.js"></script>
    <script src="js/bootstrap.min.js"></script>

</body>
</html>
