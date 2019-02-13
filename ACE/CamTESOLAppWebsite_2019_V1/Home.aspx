<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta charset="UTF-8">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="stylesheet" href="css/ACEApp_app.css">

    <link href="http://fonts.googleapis.com/css?family=PT+Sans+Narrow" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="ism/css/my-slider.css"/>
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

    .autocomplete_completionListElement
{
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
.autocomplete_highlightedListItem
{
    margin: 0px;
    background-color: #32B6AE;
    color: black;
    padding: 5px;
    
    font-size: 16px;
    width: 100%;
}

    /* AutoComplete item */
.autocomplete_listItem
{
    background-color: #C6EAE8;
    color: windowtext;
    padding: 5px;
    line-height:1em;
    font-size: 16px;
}

        .step_image{
            width:670px;                      
           
 
    
        }

        @media only screen and (max-width:777px) {
            .step_image{
                width:280px;               
  
            }
        }

        .btnStyle{
            background-color: lightskyblue;
            padding: 5px 20px;
            border-radius: 10px;
            color: black;
            border: none;
        }
        
        .btnSearchProgram{
            
            padding: 5px 20px;
            border-radius: 10px;
            margin-bottom:5px;
            margin-top: 10px;
            background-color: lightblue;
            margin-right: 20px;
        }
        
        .btnLogin{
            float: right;
            padding: 5px 20px;
            border-radius: 10px;
            margin-top: 10px;
        }
        
        .btnLogin:hover{
            background-color: lightgrey;
            color: white;
            text-decoration: none;  
        }
        .btnStyle:hover{
            background-color: deepskyblue;
            color: white;
            text-decoration: none;
        }
        .blockPanel{
            position:fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: darkgrey;
            opacity: 0.8;
        }
        .centerPanel{
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
        .panelHeader, .panelBody, .panelFooter{
            padding: 10px;
            border-bottom: 1px solid lightgrey;
        }
        .panelHeaderTitle{
            padding-left: 30px;
        }
        .panelHeaderControl{
            float: right;
            margin-left: 10px;
            outline: none;
        }
        .panelHeaderControl:hover{
            border-radius: 20px;
            box-shadow: 0 0 10px deepskyblue;
            background-color: lightcyan;
        }
        .panelFooter{
            border-bottom: none;
        }
        .fieldBox{
            padding: 15px;
        }
        .fieldLabel{
            display: inline-block;
            width: 47%;
            text-align: right;
            max-width: 250px;
            margin-right: 5%;
        }
        .fieldTextBox{
            border: 1px solid darkgrey;
            border-radius: 5px;
            padding: 5px 10px;
            outline: 0;
        }
        .fieldTextBox:hover{
            border: 1px solid lightskyblue;
        }
        .fieldTextBox:focus{
            border: 1px solid deepskyblue;
        }
        .noShowUlStyle{
            box-shadow: 0 0 10px darkgrey;
            list-style-type: none;
            width: 90%;
            margin: 20px auto;
            background-color: aliceblue;
        }

        .noShowUlStyle > li{
            margin: 20px 0;
        }
        .noShowTimeGroup{
            display: block;
            text-align: center;
            padding: 20px;
            font-size:large;
            font-weight:bold;
            border-bottom: 1px solid lightgrey;
        }
        .tableRoomStyle{
            display: inline-block;
            margin: 20px;
            box-shadow: 0 0 5px darkgrey;
            vertical-align: top;
            width: 43.5%;
        }
        .tableRoomStyle tbody{
            display: block;
        }
        .tableRoomStyle tr{
            display: block;
            padding: 20px;
        }
        @media screen and (max-width: 778px){
            .tableRoomStyle{
                width: 90%;
                margin-left: 50%;
                transform: translateX(-50%);
            }
        }
		
		.messageNotificationBox{
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

        .btnViewNewMessage{
            border: none;
            outline: none;
            background-color: transparent;
            font-family: monospace;
            color: #d63b16;
            padding: 0;
            cursor: pointer;
        }
    </style>

    <script type = "text/javascript">
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
   <link rel="stylesheet" href="css/Enrol_popup_app.css">
  <script src="js/slideJS.js"></script>   
  <link rel="stylesheet" href="css/sliderMenu1.2.css" />
  <link rel="stylesheet" href="css/sliderMenuJquery.css" />
  <link href="Styles/user_menu.css" rel="stylesheet" />
  <script src="js/jquery-latest.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div id="container_whole">
            <div id="container_header">
                <div class="top_bar">
                    <div id="Div_Breadscrum" style="float:left;" runat="server"></div>
                    <div class="wrapper-demo">
                            <div id="dd" class="wrapper-dropdown-5" tabindex="1">
                                <div class="menu-button" style="color: #fff !important;top: -25px;left: -30px;"></div>
                                <ul class="dropdown">
                                        <li>
                                            <img src="/Upload_s/Icon/My Profile.png" style="float:left;" width="30px" height="30px">
                                            <a runat="server" ><i class="icon-user"></i>Profile</a></li>
                                        <li>
                                            <img src="/Upload_s/Icon/Submission Abstract.png" style="float:left;" width="30px" height="30px">
                                            <a class="icon-user" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=19&amp;ArticleID=68&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=0" class="scroll"><i class="icon-user"></i>My Presentation</a></li>
                                        <li>
                                            <img src="/Upload_s/Icon/Schedule.png" style="float:left;" width="30px" height="30px">
                                            <a class="icon-user" href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=25&amp;ArticleID=110&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=0" class="scroll"><i class="icon-user"></i>My Schedule</a>
                                        </li>
                                        <li>
                                            <img src="/Upload_s/Icon/password.png" style="float:left;border: 1px solid #086aa9;background: #086aa9" width="30px" height="30px">
                                            <a runat="server" ><i class="icon-user"></i>Password</a>
                                        </li>
                                        <li>
                                            <img src="https://camtesol.org/Upload_s/Icon/Log out.png" style="float:left;" width="30px" height="30px">
                                            <a href="http://camtesolapp.acecambodia.org/eace.aspx?MenuID=14&amp;ArticleID=0&amp;user=seanghour.huot@idp.com&amp;deviceid=123&amp;PresenterID=0&amp;Static=1" class="scroll"><i class="icon-user"></i>Sign Out</a>
                                        </li>
                                </ul>
                            </div>
                        </div>
                </div>
            </div>
      </div>    
    </div>
    </form>
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
