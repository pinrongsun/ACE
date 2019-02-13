<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProgramMonitor1.aspx.vb" Inherits="Program" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" />
    <link rel="stylesheet" type="text/css" href="Styles/Program2.1.css" />
    <link rel="Stylesheet" type="text/css" href="/Styles/sp.css" />
    <link rel="Stylesheet" type="text/css" href="/Styles/sm.css" />
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.min.js"></script>
    <link href="css/camtesol_app.css" rel="stylesheet" />
    <link href="Styles/user_menu.css" rel="stylesheet" />
    <link rel="stylesheet" href="ism/css/my-slider.css" />
    <script src="js/jquery-latest.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/sliderMenu1.2.css" />
    <link rel="stylesheet" href="css/sliderMenuJquery.css" />
    <link rel="stylesheet" type="text/css" href="Styles/popup.css" />
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" />
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
                    <%--<img src="Upload_s/Icon/Home.png" width="30px" height="30px" >--%>
                    <asp:Image runat="server" ImageUrl="Upload_s/Icon/Home.png" ID="imgHome" Width="30px" Height="30px" />
                    <p style="color: #333">Home</p>
                </a>
            </div>
            <div class="menu_icon">
                <a runat="server" id="hrefNews">
                    <%--<img src="Upload_s/Icon/News.png" width="30px" height="30px" >--%>
                    <asp:Image runat="server" ImageUrl="Upload_s/Icon/News.png" ID="imgNews" Width="30px" Height="30px" />
                    <p style="color: #333">News</p>
                </a>
            </div>
            <div class="menu_icon">
                <a runat="server" id="hrefProgram">
                    <%--<img src="Upload_s/Icon/Program.png" width="30px" height="30px" >--%>
                    <asp:Image runat="server" ImageUrl="Upload_s/Icon/Program.png" ID="imgProgram" Width="30px" Height="30px" />
                    <p style="color: #333">Program</p>
                </a>
            </div>
            <div style="clear: both;"></div>
        </div>
        <asp:UpdatePanel runat="server" ID="panelProgram" UpdateMode="Conditional">
            <ContentTemplate>
                <br/>
                <br/>
                <br/>

                <div id="divAllProgramByTime" style="left: 0%" runat="server">
                   <%-- <div class="programTimeBox" data-no="0">
                        <p class="programTime"><span class="timeIcon"></span><span class="timeValue">09:45-10:15</span></p>
                        <div class="programBoxLink" style="display: block;">--%>
                            <div class="programBox" data-programid="8531" data-sessionid="1">
                                <span class="programRoom"><span class="locationIcon"></span>
                                    <span class="locationValue">A301</span>
                                </span>
                                <p class="programTitle">Title: Teachers as Learners in a learner-centered materials writing project</p>
                                <p class="programFocusArea">Stream: Curriculum and Materials Development (CMD)</p>
                                <p class="programSpeaker">Speaker(s): SEMBEL Jacquelinda Sandra</p>
                            </div>
                            <div class="programBox" data-programid="8531" data-sessionid="1">
                                <span class="pull-right" style="color: red"> Cancelled</span>
                                <span class="programRoom"><span class="locationIcon"></span>
                                    <span class="locationValue">A301</span>
                                </span>
                                <p class="programTitle">Title: Teachers as Learners in a learner-centered materials writing project</p>
                                <p class="programFocusArea">Stream: Curriculum and Materials Development (CMD)</p>
                                <p class="programSpeaker">Speaker(s): SEMBEL Jacquelinda Sandra</p>
                            </div>

                     <%--   </div>
                    </div>--%>


                </div>




                <asp:MultiView  runat="server" ID="mulViewMain" ActiveViewIndex="0">


                    <asp:View runat="server" ID="viewMain">
                        <asp:HiddenField runat="server" ID="hidConferenceType" Value="RS" />
                        <div style="position: absolute; top: 4em; bottom: 6em; width: 100%; overflow: auto">
                            <div style="max-width: 1000px; margin: auto;">
                                <div class="divConferenceTypeBox" data-conferencetype="RS">
                                    <span class="conferenceTypeText">Research Symposium</span>
                                    <span style="float: right; padding: 7px; border-radius: 7px; color: #2189c8; font-size: small; font-weight: 700;">View <span class="fa fa-eye fa-fw"></span></span>
                                    <p style="margin-top: 24px;"><span class="timeIcon"></span>15 February 2019</p>
                                    <p style="line-height: 30px;"><span class="locationIcon" style="width: 25px; height: 25px;"></span>Institute of Technology of Cambodia, Phnom Penh, Cambodia</p>
                                    <%--<p><span style="float: right; padding: 7px; border-radius: 7px; color: white; background-color: #2189c8">View</span></p>--%>
                                    <div style="clear: both"></div>
                                </div>
                                <div class="divConferenceTypeBox" data-conferencetype="WR">
                                    <span class="conferenceTypeText">Offical Opening Ceremony /Welcome Reception</span>
                                    <span style="float: right; padding: 7px; border-radius: 7px; color: #2189c8; font-size: small; font-weight: 700;">View <span class="fa fa-eye fa-fw"></span></span>
                                    <p style="margin-top: 24px;"><span class="timeIcon"></span>15 February 2019</p>
                                    <p style="line-height: 30px;"><span class="locationIcon" style="width: 25px; height: 25px;"></span>Institute of Technology of Cambodia, Phnom Penh, Cambodia</p>
                                    <%--<p><span style="float: right; padding: 7px; border-radius: 7px; color: white; background-color: #2189c8">View</span></p>--%>
                                    <div style="clear: both"></div>
                                </div>
                                <div class="divConferenceTypeBox" data-conferencetype="MC">
                                    <span class="conferenceTypeText">Main Conference</span>
                                    <span style="float: right; padding: 7px; border-radius: 7px; color: #2189c8; font-size: small; font-weight: 700;">View <span class="fa fa-eye fa-fw"></span></span>
                                    <p style="margin-top: 24px;"><span class="timeIcon"></span>16-17 February 2019</p>
                                    <p style="line-height: 30px;"><span class="locationIcon" style="width: 25px; height: 25px;"></span>Institute of Technology of Cambodia, Phnom Penh, Cambodia</p>
                                    <%--<p><span style="float: right; padding: 7px; border-radius: 7px; color: white; background-color: #2189c8">View</span></p>--%>
                                    <div style="clear: both"></div>
                                </div>
                                <asp:Button runat="server" ID="btnConferenceType" Style="display: none;" OnClick="btnConferenceType_Click" />
                            </div>
                        </div>
                    </asp:View>
                    <asp:View runat="server" ID="viewProgram">
                        <asp:HiddenField runat="server" ID="hidPopupBoxSearch" Value="0" />
                        <asp:HiddenField runat="server" ID="hidPopupPostBack" Value="0" />
                        <asp:HiddenField runat="server" ID="hidConfDayActive" Value="0" />
                        <asp:HiddenField runat="server" ID="hidPresentationID" Value="0" />
                        <asp:HiddenField runat="server" ID="hidSessionID" Value="0" />
                        <asp:HiddenField runat="server" ID="hidIsBookmark" Value="0" />
                        <asp:HiddenField runat="server" ID="hidTimeBoxActive" Value="-1" />
                        <asp:HiddenField runat="server" ID="hidProgramContainerVPos" Value="0" />
                        <asp:HiddenField runat="server" ID="hidReload" Value="0" />

                        <asp:Button runat="server" ID="btnBookmark" OnClick="btnBookmark_Click" Style="display: none;" />
                        <asp:Button runat="server" ID="btnProgramDetail" OnClick="btnProgramDetail_Click" Style="display: none;" />
                        <asp:Button runat="server" ID="btnReload" Style="display: none;" />

                        <div style="max-width: 1000px; margin: auto; visibility: hidden; position: absolute; top: 4em; bottom: 6em; width: 100%; max-width: 1000px; left: 50%; transform: translateX(-50%); overflow: auto" runat="server" id="mainContainer">
                            <div style="background-color: #2189c8; position: absolute; z-index: 2; top: 0; width: 100%; box-shadow: 0 3px 20px #c5c5c5;">
                                <asp:LinkButton runat="server" ID="lnkFriday" Text="Friday 15 Feb" Style="width: 90px; margin-left: 0px;" CssClass="dateBoxHeader dateBoxHeaderActive" OnClick="lnkFriday_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkSaturday" Style="width: 90px;" Text="Saturday 16 Feb" CssClass="dateBoxHeader" OnClick="lnkSaturday_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkSunday" Style="width: 90px;" Text="Sunday 17 Feb" CssClass="dateBoxHeader" OnClick="lnkSunday_Click"></asp:LinkButton>
                            </div>

                            <div class="searchBox">
                                <img src="img/search1.1.png" class='searchIcon' />
                                <img src="img/reload.png" class='reloadIcon' />
                            </div>

                            <div id="divProgramContainer" runat="server" style="position: absolute; width: 100%; max-width: 1000px; top: 85px; bottom: 0; overflow-x: auto;"></div>
                        </div>

                        <div class="popupPanel" runat="server" id="popupPanel"></div>

                        <div class="popupBox" id="popupBoxInfo" runat="server">
                            <asp:Button runat="server" ID="btnPopupInfoClose" Style="float: right; margin: 0; border-radius: 0;" CssClass="popupNo" Text="X" OnClick="btnPopupInfo_Click" />
                            <div class="popupHeader">
                                <div style="clear: both"></div>
                                <span class="popupTitle" runat="server" id="popupTitleInfo">Title</span>
                            </div>
                            <div class="popupBody">
                                <p class="popupContent" runat="server" id="popupContentInfo"></p>
                            </div>
                            <div class="popupFooter">
                                <div class="popupControlBox">
                                    <asp:Button runat="server" ID="btnPopupInfo" Style="display: block; width: 100%; margin: 0; border-radius: 0; padding: 20px;" CssClass="popupNo" Text="Close" OnClick="btnPopupInfo_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="popupBox" id="popupBoxSearch" runat="server">
                            <div class="popupHeader">
                                <span class="popupTitle" runat="server" id="popupTitleSearch">Search</span>
                            </div>
                            <div class="popupBody">
                                <div class="fieldBox" style="display: block;">
                                    <label for="txtSearch" class="fieldLabelBlock">Search:</label>
                                    <asp:TextBox runat="server" ID="txtSearch" CssClass="controlBlock" placeholder="Keyword: Topic, Speaker"></asp:TextBox>
                                </div>
                                <div class="fieldBox" style="display: block;">
                                    <label for="ddlConfday" class="fieldLabelBlock">Date:</label>
                                    <asp:DropDownList runat="server" ID="ddlConfDay" CssClass="controlBlock" OnSelectedIndexChanged="ddlConfDay_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="fieldBox" style="display: block;">
                                    <label for="ddlConfTime" class="fieldLabelBlock">Time:</label>
                                    <asp:DropDownList runat="server" ID="ddlConfTime" CssClass="controlBlock"></asp:DropDownList>
                                </div>
                                <div class="fieldBox" style="display: block;">
                                    <label for="ddlStream" class="fieldLabelBlock">Stream:</label>
                                    <asp:DropDownList runat="server" ID="ddlStream" CssClass="controlBlock"></asp:DropDownList>
                                </div>
                                <div class="fieldBox" style="display: block;">
                                    <asp:CheckBox runat="server" ID="chkOnlyBookmark" Text="Show Only Bookmark" TextAlign="Left" CssClass="chkRight" />
                                </div>
                            </div>
                            <div class="popupFooter">
                                <div class="popupControlBox">
                                    <asp:Button runat="server" ID="btnPopupNoSearch" CssClass="popupNo" Text="Cancel" OnClick="btnPopupNoSearch_Click" />
                                    <asp:Button runat="server" ID="btnPopupYesSearch" CssClass="popupYes" Text="Search" OnClick="btnPopupYesSearch_Click" />
                                </div>
                            </div>
                        </div>

                    </asp:View>
                </asp:MultiView>

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
        var isClick = false;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                function fadeIn(id) {
                    $("#popupPanel").css("display", "block");
                    $("#" + id).css("display", "none");
                    $("#" + id).fadeIn();
                }

                function fadeOut(id) {
                    $("#" + id).css("display", "block");
                    $("#" + id).fadeOut();
                    $("#popupPanel").css("display", "none");
                }

                $(".searchIcon").click(function () {
                    $("#<%= hidPopupBoxSearch.ClientID%>").val("1");
                    fadeIn('<%= popupBoxSearch.ClientID%>');
                });

                $(".reloadIcon").click(function () {
                    $("#<%= hidReload.ClientID%>").val("1");
                    $("#<%= btnReload.ClientID%>").click();
                });

                $("#<%= btnPopupNoSearch.ClientID%>").click(function (e) {
                    if ($("#<%= hidPopupPostBack.ClientID%>").val() == "0") {
                        e.preventDefault();
                        $("#<%= hidPopupBoxSearch.ClientID%>").val("0");
                        fadeOut('<%= popupBoxSearch.ClientID%>');
                        return false;
                    }
                });

                $("#<%= btnPopupYesSearch.ClientID%>").click(function (e) {
                    $("#<%= hidPopupBoxSearch.ClientID%>").val("0");
                });

                function scrollAnimateProgram(confDay) {
                    $("#<%= divProgramContainer.ClientID%>").animate({ scrollLeft: confDay * $("#<%= divProgramContainer.ClientID%>").width() });
                }

                function scrollProgram(confDay) {
                    var divProgramContainer = $("#<%= divProgramContainer.ClientID%>");
                    if (divProgramContainer.length > 0) {
                        divProgramContainer.scrollLeft(confDay * divProgramContainer.width());
                    }
                }

                $("#<%= lnkFriday.ClientID%>").click(function (e) {
                    if (!isClick) {
                        isClick = true;
                        $(".dateBoxHeaderActive").removeClass("dateBoxHeaderActive");
                        $(this).addClass("dateBoxHeaderActive");
                        $("#<%= hidConfDayActive.ClientID%>").val(0);
                        scrollAnimateProgram(0);
                        $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(0).scrollTop());
                        e.preventDefault();
                        isClick = false;
                        return false;
                    }
                });

                $("#<%= lnkSaturday.ClientID%>").click(function (e) {
                    if (!isClick) {
                        isClick = true;
                        $(".dateBoxHeaderActive").removeClass("dateBoxHeaderActive");
                        $(this).addClass("dateBoxHeaderActive");
                        $("#<%= hidConfDayActive.ClientID%>").val(0);
                        scrollAnimateProgram(0);
                        $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(0).scrollTop());
                        e.preventDefault();
                        isClick = false;
                        return false;
                    }
                });

                $("#<%= lnkSunday.ClientID%>").click(function (e) {
                    if (!isClick) {
                        isClick = true;
                        $(".dateBoxHeaderActive").removeClass("dateBoxHeaderActive");
                        $(this).addClass("dateBoxHeaderActive");
                        $("#<%= hidConfDayActive.ClientID%>").val(1);
                        scrollAnimateProgram(1);
                        $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(1).scrollTop());
                        e.preventDefault();
                        isClick = false;
                        return false;
                    }
                });

                $(window).resize(function () {
                    var index = $(".dateBoxHeaderActive").index(".dateBoxHeader");
                    $("#<%= hidConfDayActive.ClientID%>").val(index);
                    $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(index).scrollTop());
                    scrollProgram(index);
                });

                $("#<%= divProgramContainer.ClientID%>").scroll(function () {
                    clearTimeout(scrollProgramTimeout);
                    scrollProgramTimeout = setTimeout(function () {
                        var scrollContainer = $("#<%= divProgramContainer.ClientID%>");
                        var scrollLeft = scrollContainer.scrollLeft();
                        var scrollAreaWidth = scrollContainer.width();
                        var scrollAreaNo = 0;

                        if (scrollLeft >= (scrollAreaWidth * 2) - (scrollAreaWidth / 2)) {
                            scrollAreaNo = 2;
                        } else if (scrollLeft >= (scrollAreaWidth) - (scrollAreaWidth / 2)) {
                            scrollAreaNo = 1;
                        }
                        $(".dateBoxHeaderActive").removeClass("dateBoxHeaderActive");
                        $(".dateBoxHeader").eq(scrollAreaNo).addClass("dateBoxHeaderActive");
                        $("#<%= hidConfDayActive.ClientID%>").val(scrollAreaNo);
                        $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(scrollAreaNo).scrollTop());
                        scrollAnimateProgram(scrollAreaNo);
                    }, 150);
                });

                $(".programTime").click(function () {
                    if ($(this).next(".programBoxLink").css("display") == "none") {
                        $("#<%= hidTimeBoxActive.ClientID%>").val($(this).closest(".programTimeBox").attr("data-no"));
                        $(".programContainer").eq($("#<%= hidConfDayActive.ClientID%>").val()).find(".programBoxLink").css("display", "none");
                        $(this).next(".programBoxLink").slideDown();
                    } else {
                        $("#<%= hidTimeBoxActive.ClientID%>").val(-1);
                        $(this).next(".programBoxLink").slideUp();
                    }
                });

                function timeBoxActive(confDayNo, timeBoxIndex) {
                    $(".programContainer").eq(confDayNo).children(".programTimeBox[data-no=" + timeBoxIndex + "]").children(".programBoxLink").css("display", "block");
                }

                $(".programContainer").scroll(function () {
                    $("#<%= hidProgramContainerVPos.ClientID%>").val($(this).scrollTop());
                });

                function setScrollPos() {
                    $(".programContainer").eq($("#<%= hidConfDayActive.ClientID%>").val()).scrollTop($("#<%= hidProgramContainerVPos.ClientID%>").val());
                }

                $(".programBox").click(function () {
                    $("#<%= hidPresentationID.ClientID%>").val($(this).attr("data-programid"));
                    $("#<%= hidSessionID.ClientID%>").val($(this).attr("data-sessionid"));
                    $("#<%= hidTimeBoxActive.ClientID%>").val($(this).closest(".programTimeBox").attr("data-no"));
                    $("#<%= btnProgramDetail.ClientID%>").click();
                });

                $(".divConferenceTypeBox").click(function () {
                    $("#<%= hidConferenceType.ClientID%>").val($(this).attr("data-conferenceType"));
                    $("#<%= btnConferenceType.ClientID%>").click();
                });
            });
        }

        function fadeIn(id) {
            $("#popupPanel").css("display", "block");
            $("#" + id).css("display", "none");
            $("#" + id).fadeIn();
        }

        function fadeOut(id) {
            $("#" + id).css("display", "block");
            $("#" + id).fadeOut();
            $("#popupPanel").css("display", "none");
        }

        $(".searchIcon").click(function () {
            $("#<%= hidPopupBoxSearch.ClientID%>").val("1");
            fadeIn('<%= popupBoxSearch.ClientID%>');
        });

        $(".reloadIcon").click(function () {
            $("#<%= hidReload.ClientID%>").val("1");
            $("#<%= btnReload.ClientID%>").click();
        });

        $("#<%= btnPopupNoSearch.ClientID%>").click(function (e) {
            if ($("#<%= hidPopupPostBack.ClientID%>").val() == "0") {
                e.preventDefault();
                $("#<%= hidPopupBoxSearch.ClientID%>").val("0");
                fadeOut('<%= popupBoxSearch.ClientID%>');
                return false;
            }
        });

        $("#<%= btnPopupYesSearch.ClientID%>").click(function (e) {
            $("#<%= hidPopupBoxSearch.ClientID%>").val("0");
        });

        function scrollAnimateProgram(confDay) {
            $("#<%= divProgramContainer.ClientID%>").animate({ scrollLeft: confDay * $("#<%= divProgramContainer.ClientID%>").width() });
        }

        function scrollProgram(confDay) {
            var divProgramContainer = $("#<%= divProgramContainer.ClientID%>");
            if (divProgramContainer.length > 0) {
                divProgramContainer.scrollLeft(confDay * divProgramContainer.width());
            }
        }

        $("#<%= lnkFriday.ClientID%>").click(function (e) {
            if (!isClick) {
                isClick = true;
                $(".dateBoxHeaderActive").removeClass("dateBoxHeaderActive");
                $(this).addClass("dateBoxHeaderActive");
                $("#<%= hidConfDayActive.ClientID%>").val(0);
                scrollAnimateProgram(0);
                $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(0).scrollTop());
                e.preventDefault();
                isClick = false;
                return false;
            }
        });

        $("#<%= lnkSaturday.ClientID%>").click(function (e) {
            if (!isClick) {
                isClick = true;
                $(".dateBoxHeaderActive").removeClass("dateBoxHeaderActive");
                $(this).addClass("dateBoxHeaderActive");
                $("#<%= hidConfDayActive.ClientID%>").val(0);
                scrollAnimateProgram(0);
                $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(0).scrollTop());
                e.preventDefault();
                isClick = false;
                return false;
            }
        });

        $("#<%= lnkSunday.ClientID%>").click(function (e) {
            if (!isClick) {
                isClick = true;
                $(".dateBoxHeaderActive").removeClass("dateBoxHeaderActive");
                $(this).addClass("dateBoxHeaderActive");
                $("#<%= hidConfDayActive.ClientID%>").val(1);
                scrollAnimateProgram(1);
                $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(1).scrollTop());
                e.preventDefault();
                isClick = false;
                return false;
            }
        });

        $(window).resize(function () {
            var index = $(".dateBoxHeaderActive").index(".dateBoxHeader");
            $("#<%= hidConfDayActive.ClientID%>").val(index);
            $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(index).scrollTop());
            scrollProgram(index);
        });

        $("#<%= divProgramContainer.ClientID%>").scroll(function () {
            clearTimeout(scrollProgramTimeout);
            scrollProgramTimeout = setTimeout(function () {
                var scrollContainer = $("#<%= divProgramContainer.ClientID%>");
                var scrollLeft = scrollContainer.scrollLeft();
                var scrollAreaWidth = scrollContainer.width();
                var scrollAreaNo = 0;

                if (scrollLeft >= (scrollAreaWidth * 2) - (scrollAreaWidth / 2)) {
                    scrollAreaNo = 2;
                } else if (scrollLeft >= (scrollAreaWidth) - (scrollAreaWidth / 2)) {
                    scrollAreaNo = 1;
                }
                $(".dateBoxHeaderActive").removeClass("dateBoxHeaderActive");
                $(".dateBoxHeader").eq(scrollAreaNo).addClass("dateBoxHeaderActive");
                $("#<%= hidConfDayActive.ClientID%>").val(scrollAreaNo);
                $("#<%= hidProgramContainerVPos.ClientID%>").val($(".programContainer").eq(scrollAreaNo).scrollTop());
                scrollAnimateProgram(scrollAreaNo);
            }, 150);
        });

        $(".programTime").click(function () {
            if ($(this).next(".programBoxLink").css("display") == "none") {
                $("#<%= hidTimeBoxActive.ClientID%>").val($(this).closest(".programTimeBox").attr("data-no"));
                $(".programContainer").eq($("#<%= hidConfDayActive.ClientID%>").val()).find(".programBoxLink").css("display", "none");
                $(this).next(".programBoxLink").slideDown();
            } else {
                $("#<%= hidTimeBoxActive.ClientID%>").val(-1);
                $(this).next(".programBoxLink").slideUp();
            }
        });

        function getQueryStr(param) {
            var value = "", qSplit;
            var query = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < query.length; i++) {
                qSplit = query[i].split('=');
                if (qSplit[0].toLowerCase() == param.toLowerCase()) {
                    value = query[i].slice(query[i].indexOf('=') + 1); break;
                }
            }
            return value;
        }
        function bookmarkClick(self, e) {
            var pid = $(self).parent().attr("data-programid");
            var uid = getQueryStr("UserID");
            $("#<%= hidPresentationID.ClientID%>").val(pid);
            $("#<%= hidTimeBoxActive.ClientID%>").val($(self).closest(".programTimeBox").attr("data-no"));
            if ($(self).hasClass("bookmarkIconActive")) {
                $("#<%= hidIsBookmark.ClientID%>").val(0);
                $(self).removeClass("bookmarkIconActive");
            } else {
                $("#<%= hidIsBookmark.ClientID%>").val(1);
                $(self).addClass("bookmarkIconActive");
            }
            $.ajax({
                type: "POST",
                url: "/ProgramAsyn.asmx/bookmark",
                data: "{pID: '" + pid + "', uID: '" + uid + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                },
                failure: function (response) {
                    $("#<%= btnBookmark.ClientID%>").click();
                },
                error: function (response) {
                    $("#<%= btnBookmark.ClientID%>").click();
                }
            });
            e.stopPropagation();
        }

        function timeBoxActive(confDayNo, timeBoxIndex) {
            $(".programContainer").eq(confDayNo).children(".programTimeBox[data-no=" + timeBoxIndex + "]").children(".programBoxLink").css("display", "block");
        }

        $(".programContainer").scroll(function () {
            $("#<%= hidProgramContainerVPos.ClientID%>").val($(this).scrollTop());
        });

        function setScrollPos() {
            $(".programContainer").eq($("#<%= hidConfDayActive.ClientID%>").val()).scrollTop($("#<%= hidProgramContainerVPos.ClientID%>").val());
        }

        $(".programBox").click(function () {
            $("#<%= hidPresentationID.ClientID%>").val($(this).attr("data-programid"));
            $("#<%= hidSessionID.ClientID%>").val($(this).attr("data-sessionid"));
            $("#<%= hidTimeBoxActive.ClientID%>").val($(this).closest(".programTimeBox").attr("data-no"));
            $("#<%= btnProgramDetail.ClientID%>").click();
        });

        $(".divConferenceTypeBox").click(function () {
            $("#<%= hidConferenceType.ClientID%>").val($(this).attr("data-conferenceType"));
            $("#<%= btnConferenceType.ClientID%>").click();
        });
    </script>
    <script type="text/javascript" src="/Scripts/sp.js"></script>
    <script type="text/javascript" src="/Scripts/classie.js"></script>
    <script type="text/javascript" src="/Scripts/slideJS.js"></script>
    <script src="js/user_menu.js"></script>
</body>
</html>
