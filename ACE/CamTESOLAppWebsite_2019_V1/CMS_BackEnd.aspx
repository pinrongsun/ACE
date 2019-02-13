<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CMS_BackEnd.aspx.vb" Inherits="CMS_BackEnd" validateRequest="false" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>



    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700' rel='stylesheet' type='text/css'>

	<link rel="stylesheet" href="css/popup/reset.css">
	<link rel="stylesheet" href="css/popup/style.css"> 
	<script src="js/popup/modernizr.js"></script> 



    <link rel="stylesheet" href="css/styles_flatjquery -CMS.css">
    <script src="js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="js/script_flatjquery.js"></script>
    

    <script src="tinymce/tinymce.min.js"></script>
    <script type="text/javascript">
        tinymce.init({
            selector: ".mcetiny",
            theme: "modern",
            plugins: [
                "advlist autolink autosave link image lists charmap print preview hr anchor pagebreak spellchecker",
                "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
                "table contextmenu directionality emoticons template textcolor paste fullpage textcolor colorpicker textpattern"
            ],
            toolbar1: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | styleselect formatselect fontselect fontsizeselect",
            toolbar2: "table | print preview media | forecolor backcolor emoticons | fullscreen | code",

            menubar: false,
            toolbar_items_size: 'small',
            image_advtab: true,
            templates: [
                { title: 'Test template 1', content: 'Test 1' },
                { title: 'Test template 2', content: 'Test 2' }
            ]
        });
</script> 


    <style type="text/css">

        #div_middle_banner{
            margin-left:15px
        }

        .image_upload{
            padding-left:15px;
        }

    /*.myButton {
	-moz-box-shadow: 0px 1px 0px 0px #1c1b18;
	-webkit-box-shadow: 0px 1px 0px 0px #1c1b18;
	box-shadow: 0px 1px 0px 0px #1c1b18;
	background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #eae0c2), color-stop(1, #ccc2a6));
	background:-moz-linear-gradient(top, #eae0c2 5%, #ccc2a6 100%);
	background:-webkit-linear-gradient(top, #eae0c2 5%, #ccc2a6 100%);
	background:-o-linear-gradient(top, #eae0c2 5%, #ccc2a6 100%);
	background:-ms-linear-gradient(top, #eae0c2 5%, #ccc2a6 100%);
	background:linear-gradient(to bottom, #eae0c2 5%, #ccc2a6 100%);
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#eae0c2', endColorstr='#ccc2a6',GradientType=0);
	background-color:#eae0c2;
	-moz-border-radius:15px;
	-webkit-border-radius:15px;
	border-radius:5px;
	border:1px solid #333029;
	display:inline-block;
	cursor:pointer;
	color:#505739;
	font-family:Arial;
	font-size:14px;
	font-weight:bold;
	padding:6px 16px;
	text-decoration:none;
	text-shadow:0px 1px 0px #ffffff;
}
.myButton:hover {
	background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #ccc2a6), color-stop(1, #eae0c2));
	background:-moz-linear-gradient(top, #ccc2a6 5%, #eae0c2 100%);
	background:-webkit-linear-gradient(top, #ccc2a6 5%, #eae0c2 100%);
	background:-o-linear-gradient(top, #ccc2a6 5%, #eae0c2 100%);
	background:-ms-linear-gradient(top, #ccc2a6 5%, #eae0c2 100%);
	background:linear-gradient(to bottom, #ccc2a6 5%, #eae0c2 100%);
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#ccc2a6', endColorstr='#eae0c2',GradientType=0);
	background-color:#ccc2a6;
}
.myButton:active {
	position:relative;
	top:1px;
}*/


.myButton {
	-moz-box-shadow: 0px 1px 0px 0px #1c1b18;
	-webkit-box-shadow: 0px 1px 0px 0px #1c1b18;
	box-shadow: 0px 1px 0px 0px #1c1b18;
	background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #fffcf0), color-stop(1, #c4bfb0));
	background:-moz-linear-gradient(top, #fffcf0 5%, #c4bfb0 100%);
	background:-webkit-linear-gradient(top, #fffcf0 5%, #c4bfb0 100%);
	background:-o-linear-gradient(top, #fffcf0 5%, #c4bfb0 100%);
	background:-ms-linear-gradient(top, #fffcf0 5%, #c4bfb0 100%);
	background:linear-gradient(to bottom, #fffcf0 5%, #c4bfb0 100%);
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#fffcf0', endColorstr='#c4bfb0',GradientType=0);
	background-color:#fffcf0;
	-moz-border-radius:5px;
	-webkit-border-radius:5px;
	border-radius:5px;
	border:1px solid #333029;
	display:inline-block;
	cursor:pointer;
	color:#505739;
	font-family:Arial;
	font-size:14px;
	font-weight:bold;
	padding:6px 16px;
	text-decoration:none;
	text-shadow:0px 0px 0px #ffffff;
}
.myButton:hover {
	background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #c4bfb0), color-stop(1, #fffcf0));
	background:-moz-linear-gradient(top, #c4bfb0 5%, #fffcf0 100%);
	background:-webkit-linear-gradient(top, #c4bfb0 5%, #fffcf0 100%);
	background:-o-linear-gradient(top, #c4bfb0 5%, #fffcf0 100%);
	background:-ms-linear-gradient(top, #c4bfb0 5%, #fffcf0 100%);
	background:linear-gradient(to bottom, #c4bfb0 5%, #fffcf0 100%);
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#c4bfb0', endColorstr='#fffcf0',GradientType=0);
	background-color:#c4bfb0;
}
.myButton:active {
	position:relative;
	top:1px;
}






        a:link {
    text-decoration: none;
}

a:visited {
    text-decoration: none;
}

a:hover {
    text-decoration: underline;
}

a:active {
    text-decoration: underline;
}   

        #container{
            max-width:2000px;
            width:100%;
            margin-left:auto;
            margin-right:auto;
        }

        #container_whole{
            max-width:1200px;
            width:100%;
            margin-left:auto;
            margin-right:auto;
            background-color:#f7fcff;
            border-radius:9px;
         
        }

        #container2{
            max-width:1200px;
            width:100%;
            margin-left:auto;
            margin-right:auto;
            /*border:1px solid #dddddd;*/
            
        }

        #container_top{
            max-width:1200px;
            width:100%;
            margin-left:auto;
            margin-right:auto;
        }

        #container_top_title{
            max-width:1200px;
            width:100%;
            background-color:#606060;
            height:30px;
            color:white;
            border:1px solid;
            border-radius:10px 10px 0px 0px;
        }

        #container_top_menu{
            max-width:1200px;
            width:100%;
        }

        #container_middle{
            max-width:1200px;
            width:100%;
            margin-left:auto;
            margin-right:auto;

        }

        #container_middle_content{
            width:100%;
            margin-top:20px;
            margin-bottom:20px;
            margin-left:20px
        }

        #container_middle_menudetail{
            margin-left:20px;
            
        }

        #container_middle_contentdetail{
            margin-left:20px;
        }

        #container_middle_media{
            margin-left:20px;
        }

        #container_bottom{
            max-width:1200px;
            width:100%;
            margin-left:auto;
            margin-right:auto;
        }

    </style>

</head>
<body style="background-image:url(img/sos.png);background-repeat:repeat">
    <form id="form1" runat="server">
    <div id="container">
        <div id="container_whole">
        <div id="container_top">
            <div id="container_top_title">
                <table style="width:100%;height:100%;color:#dddddd">
                    <tr valign="top">
                        <td><div style="margin-left:20px">Administrator</div></td>
                    </tr>
                </table>
            </div>
        </div>

        <div id="container2">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                        </asp:ScriptManager>
            <div id="container_top_menu">
                <div id="cssmenu" runat="server" style="background-color:#f7fcff">
                        <ul>
                           <%--<li><a href='#'>Site</a></li>--%>
                           <%--<li class=''><a href='#'>Users</a></li>--%>
                              
                           
                           <li><a href='CMS_BackEnd.aspx?type=menu'>Menu Manager</a>
                               
                           </li>
                           <li><a href='CMS_BackEnd.aspx?type=content'>Content Manager</a></li>
                            <li><a href='CMS_BackEnd.aspx?type=media'>Media Manager</a>
                          
                            </li>
                            <li><a href='CMS_BackEnd.aspx?type=noShow'>No Show</a></li>
                            <%--<li><a href='CMS_BackEnd.aspx?type=component'>Component</a></li>--%>
                                   
                            
                            <%--<li></li>--%>
                        </ul>
                    </div>
            </div>

            <div id="container_middle">
            <div id="container__content" runat ="server">
                <table style="width:100%">
                    <tr>
                        <td style="width:80%">
                            <div id="container_middle_content" runat="server">

                            </div>
                        </td>

                        <td style="width:20%;padding-top:65px;padding-left:20px" valign="top">
                             <asp:Button CssClass="myButton" ID="cmdNew_Item" runat="server" Text="New" Width="120px" />
                        </td>
                    </tr>

                </table>
            </div>

            <div id="container_middle_menudetail" runat="server" visible="false">
                <table style="width:100%;height:100%;margin-top:20px;margin-bottom:20px">
                    <tr>
                        <td style="width:80%">
                            <table>
                                <tr>
                                    <td style="border-bottom:1px solid #dddddd">Menu Detail</td>
                                </tr>

                                <tr valign="middle">
                                    <td style="padding-top:5px">
                                        <table>
                                <tr>
                                    <td style="width:120px">Title</td>
                                    <td style="width:30px">:</td>
                                    <td > 
                                        <asp:TextBox ID="txtMenuTitle" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                                    </td>
                                </tr>

                                <tr valign="middle">
                                    <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Title Khmer</td>
                                    <td style="width:30px">:</td>
                                    <td > 
                                        <asp:TextBox ID="txtMenuTitle_KH" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                                </tr>

                                <tr>
                                    <td style="padding-top:5px">
                                        <table>
                                            <tr>
                                                <td style="width:120px">Link Article</td>
                                                <td style="width:30px">:</td>
                                                <td> 
                                                    <asp:TextBox ID="txtArticle" runat="server" Width="300px"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <a href="#0" class="cd-popup-trigger">
                                                    <asp:Button ID="cmdSelectArticle" runat="server" Text="Select Article3" />
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding-top:5px">
                                        <table>
                                            <tr>
                                                <td style="width:120px">Visible</td>
                                                <td style="width:30px">:</td>
                                                <td> 
                                                    <asp:DropDownList ID="cboVisible" runat="server" Width="100px">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                     <td style="padding-top:5px">
                                        <table>
                                            <tr>
                                                <td style="width:120px">Parent</td>
                                                <td style="width:30px">:</td>
                                                <td> 
                                                    <asp:DropDownList ID="cboParent" runat="server" Width="200px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding-top:5px">
                                        <table>
                                            <tr>
                                                <td style="width:120px">Ordering</td>
                                                <td style="width:30px">:</td>
                                                <td> 
                                                    <asp:TextBox ID="txtOrdering" runat="server" Width="95px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr style="display:none">
                                    <td style="padding-top:5px">
                                        <table>
                                            <tr>
                                                <td style="width:120px">Menu Top</td>
                                                <td style="width:30px">:</td>
                                                <td> 
                                                    <asp:DropDownList ID="cboMenutop" runat="server" Width="100px">
                                                        <asp:ListItem>No</asp:ListItem>
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Image</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtImage_Menu" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="cmdSelectImage_Menu" runat="server" Text="Select Image" />
                                    </td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                    
                    <tr id="div_Image_Menu" runat="server" visible="false">
                                    <td>

                                         <div style="margin-top:20px">
                                            <table>
                                                <tr>
                                                    <td>Select Folder:</td>
                                                    <td>
                                                        <asp:DropDownList ID="cboFolder_Menu" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>

                            <div style="margin-top:20px;margin-bottom:20px">
                                    <asp:FileUpload ID="FileUpload_Menu" runat="server" />
                                    <asp:Button ID="Button10" runat="server" Text="Upload" OnClick="UploadFile_Menu" />
                                    <div style="margin-top:20px;overflow:scroll;height:300px;width:510px">
                                    <asp:GridView ID="grdMenu" runat="server" AutoGenerateColumns="false" GridLines="none" EmptyDataText = "No files uploaded" AllowPaging="False" PageSize="10" AutoGenerateSelectButton="True" >
                            <AlternatingRowStyle BackColor="#EFF3FB" BorderStyle="None" />
                            <Columns>
                                <asp:BoundField DataField="Text" HeaderText="File Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="white" HeaderStyle-Height="30px" ItemStyle-CssClass="image_upload" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile" Width="100px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" BorderStyle="None" BorderColor="White" />
                            <PagerStyle BorderStyle="None" />
                            <RowStyle BorderColor="White" BorderStyle="None" Height="30px" />
                        </asp:GridView>
                        </div>
                    </div>

                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding-top:5px">
                                        <table>
                                            <tr>
                                                <td style="width:120px">ID</td>
                                                <td style="width:30px">:</td>
                                                <td> 
                                                    <asp:TextBox ID="txtMenuID" runat="server" Width="95px" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="lblResult" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </td>

                        <td valign="top" style="padding-top:50px">
                            <table>

                                <tr>
                                    <td>
                                        <asp:Button ID="cmdNew" CssClass="myButton" runat="server" Text="New" Width="100px" />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Button ID="cmdSave" CssClass="myButton" runat="server" Text="Save" Width="100px" />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Button ID="cmdDelete" CssClass="myButton" runat="server" Text="Delete" Width="100px" />
                                    </td>

                                    
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="cmdClose" CssClass="myButton" runat="server" Text="Close" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:HiddenField ID="hdArticleID" runat="server" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>


                </table>
                
            </div>


            <div id="container_middle_contentdetail" runat="server">

                <table style="width:100%;margin-top:20px;margin-bottom:20px">
                    <tr>
                        <td style="width:80%">
                            <table>
                                <tr>
                                    <td style="border-bottom:1px solid #dddddd">Content Detail</td>
                                </tr>

                    <tr valign="middle">
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Title</td>
                                    <td style="width:30px">:</td>
                                    <td > 
                                        <asp:TextBox ID="txtArticleTitle" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>

                    <tr valign="middle">
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Title Khmer</td>
                                    <td style="width:30px">:</td>
                                    <td > 
                                        <asp:TextBox ID="txtArticle_Title_KH" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Breadcrum</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtArticle_Breadcrum" runat="server" Width="300px"></asp:TextBox>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Breadcrum Khmer</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtArticle_Breadcrum_KH" runat="server" Width="300px"></asp:TextBox>

                                    </td>
                                  
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Visible</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:DropDownList ID="cboArticle_Visible" runat="server" Width="100px">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                         <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Content</td>
                                    <td style="width:30px">:</td>
                                    <td>
                                         
                                       <asp:TextBox ID="Editor_ArticleContent" CssClass="mcetiny" runat="server" Text="" />


                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Content Khmer</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                       <asp:TextBox ID="Editor_ArticleContent_KH" CssClass="mcetiny" runat="server" Text="" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Article ID</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtArticleID" runat="server" Width="95px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table>
                                            <tr>
                                                <td>
                                                    Feed ID</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:MultiView ID="MultiView1" runat="server">
                                                        <asp:View ID="View1" runat="server">
                                                            <asp:TextBox ID="txtFeedID" runat="server" Width="95px"></asp:TextBox>
                                                            <asp:Button ID="Button11" runat="server" Text="View Feed" />
                                                        </asp:View>
                                                        <asp:View ID="View2" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        Feed ID:</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFeedID0" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Feed Title:</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFeedTitle" runat="server" Width="150px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Post Date:</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFeedPostDate" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Created By:</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFeedCreatedBy" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        <asp:Button ID="Button13" runat="server" Text="Save" />
                                                                        <asp:Button ID="Button12" runat="server" Text="Delete" />
                                                                        <asp:Button ID="Button14" runat="server" Text="Back" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                    </asp:MultiView>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    
                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Image Share</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtImageShare_SubContent" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="cmdSelectImage_subContent" runat="server" Text="Select Image" />
                                    </td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                    
                    <tr id="div_imageshare_subcontent" runat="server" visible="false">
                                    <td>

                                         <div style="margin-top:20px">
                                            <table>
                                                <tr>
                                                    <td>Select Folder:</td>
                                                    <td>
                                                        <asp:DropDownList ID="cboFolder_Subcontent" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>

                            <div style="margin-top:20px;margin-bottom:20px">
                                    <asp:FileUpload ID="FileUpload3" runat="server" />
                                    <asp:Button ID="Button3" runat="server" Text="Upload" OnClick="UploadFile3" />
                                    <div style="margin-top:20px;overflow:scroll;height:300px;width:510px">
                                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" GridLines="none" EmptyDataText = "No files uploaded" AllowPaging="False" PageSize="10" AutoGenerateSelectButton="True" >
                            <AlternatingRowStyle BackColor="#EFF3FB" BorderStyle="None" />
                            <Columns>
                                <asp:BoundField DataField="Text" HeaderText="File Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="white" HeaderStyle-Height="30px" ItemStyle-CssClass="image_upload" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile" Width="100px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" BorderStyle="None" BorderColor="White" />
                            <PagerStyle BorderStyle="None" />
                            <RowStyle BorderColor="White" BorderStyle="None" Height="30px" />
                        </asp:GridView>
                        </div>
                    </div>

                                    </td>
                                </tr>


                    <tr>
                        <td>
                            <asp:Label ID="lblResult_Article" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>

                </table>
                        </td>

                        <td valign="top" style="width:20%;padding-top:50px">
                            <table style="margin-left:20px">

                                <tr>
                                    <td>
                                        <asp:Button ID="cmdNewArticle" CssClass="myButton" runat="server" Text="New" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="cmdSave_Article" CssClass="myButton" runat="server" Text="Save" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="cmdDelete_Article" CssClass="myButton" runat="server" Text="Delete" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="cmdClose_Article" CssClass="myButton" runat="server" Text="Close" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:HiddenField ID="HiddenField1" runat="server" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>

                
            </div>

            <div id="container_middle_media" runat="server">

            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                                                        
               
<%--    <h2>
        A Simple Filebrowser (VB)
    </h2>
    
    <uc1:FileGridVB ID="FileGridVB1" HomeFolder="~/Uploads" runat="server" PageSize="10" />--%>

                <div style="margin-top:20px">
            <table>
                <tr>
                    <td>Select Folder:</td>
                    <td>
                        <asp:DropDownList ID="cboFolder" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>


                <div style="margin-top:20px;margin-bottom:20px">


                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadFile" />
                <div style="margin-top:20px;overflow:scroll;height:300px;width:510px">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" GridLines="none" EmptyDataText = "No files uploaded" AllowPaging="False" PageSize="15" >
        <AlternatingRowStyle BackColor="#EFF3FB" BorderStyle="None" />
        <Columns>
            <asp:BoundField DataField="Text" HeaderText="File Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="white" HeaderStyle-Height="30px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile" Width="100px"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#507CD1" BorderStyle="None" BorderColor="White" />
        <PagerStyle BorderStyle="None" />
        <RowStyle BorderColor="White" BorderStyle="None" Height="30px" />
    </asp:GridView>
                </div>
        </div>


            <%--    </ContentTemplate>
            </asp:UpdatePanel>--%>

        </div>



            

            <div id="div_middle_photogallery" runat="server" style="margin-left:20px">
                <div>
                    <table style="width:100%;margin-top:20px;margin-bottom:20px">
                    <tr>
                        <td style="width:80%">
                            <table>
                                <tr>
                                    <td style="border-bottom:1px solid #dddddd">Photo Gallery</td>
                                </tr>

                    <tr valign="middle">
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Title</td>
                                    <td style="width:30px">:</td>
                                    <td > 
                                        <asp:TextBox ID="txtTitle_PhotoGallery" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>
                    
                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Image</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtImage_PhotoGallery" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="cmdImage_PhotoGallery" runat="server" Text="Select Image" />
                                    </td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                    
                    <tr id="div_image_photogallery" runat="server" visible="false">
                                    <td>

                                         <div style="margin-top:20px">
                                            <table>
                                                <tr>
                                                    <td>Select Folder:</td>
                                                    <td>
                                                        <asp:DropDownList ID="cboFolder_PhotoGallery" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>

                            <div style="margin-top:20px;margin-bottom:20px">
                                    <asp:FileUpload ID="FileUpload8" runat="server" />
                                    <asp:Button ID="Button4" runat="server" Text="Upload" OnClick="UploadFile8" />
                                    <div style="margin-top:20px;overflow:scroll;height:300px;width:510px">
                                    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false" GridLines="none" EmptyDataText = "No files uploaded" AllowPaging="false" PageSize="10" AutoGenerateSelectButton="True" >
                            <AlternatingRowStyle BackColor="#EFF3FB" BorderStyle="None" />
                            <Columns>
                                <asp:BoundField DataField="Text" HeaderText="File Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="white" HeaderStyle-Height="30px" ItemStyle-CssClass="image_upload" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile" Width="100px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" BorderStyle="None" BorderColor="White" />
                            <PagerStyle BorderStyle="None" />
                            <RowStyle BorderColor="White" BorderStyle="None" Height="30px" />
                        </asp:GridView>
                        </div>
                    </div>

                                    </td>
                                </tr>

                    <tr valign="middle">
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Ordering</td>
                                    <td style="width:30px">:</td>
                                    <td > 
                                        <asp:TextBox ID="txtOrdering_PhotoGallery" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Visible</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:DropDownList ID="cboVisible_PhotoGallery" runat="server" Width="100px">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                         <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Description</td>
                                    <td style="width:30px">:</td>
                                    <td>
                                         
                                       <asp:TextBox ID="txtDescription"  runat="server" Text="" Width="300px" />


                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Link ReadMore</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtLinkReadMore_PhotoGallery" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <a href="#0" class="cd-popup-trigger">
                                        <asp:Button ID="Button5" runat="server" Text="Select Article" />
                                        </a>
                                    </td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Group Photo</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:DropDownList ID="cboGroupPhotoGallery" runat="server" Width="100px">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList><asp:HiddenField ID="hdGroupPhotoID" runat="server" />
                                        <asp:HiddenField ID="hdArticleID_PhotoGallery" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Photo ID</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtPhotoGalleryID" runat="server" Width="95px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    
                    


                    <tr>
                        <td>
                            <asp:Label ID="lblResult_PhotoGallery" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>

                </table>
                        </td>

                        <td valign="top" style="width:20%;padding-top:50px">
                            <table style="margin-left:20px">

                                <tr>
                                    <td>
                                        <asp:Button ID="Button6" CssClass="myButton" runat="server" Text="New" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="cmdSave_PhotoGallery" CssClass="myButton" runat="server" Text="Save" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="Button8" CssClass="myButton" runat="server" Text="Delete" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="Button9" CssClass="myButton" runat="server" Text="Close" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:HiddenField ID="HiddenField2" runat="server" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
            </div>


            <div id="div_middle_groupphoto" runat="server" style="margin-left:20px">
                <div>
                    <table style="width:100%;margin-top:20px;margin-bottom:20px">
                    <tr>
                        <td style="width:80%">
                            <table>
                                <tr>
                                    <td style="border-bottom:1px solid #dddddd">Group Photo Gallery</td>
                                </tr>

                    <tr valign="middle">
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Title</td>
                                    <td style="width:30px">:</td>
                                    <td > 
                                        <asp:TextBox ID="txtTitle_GroupPhoto" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>
                    
                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Image</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtImage_GroupPhoto" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="cmdSelectImage_GroupPhoto" runat="server" Text="Select Image" />
                                    </td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                    
                    <tr id="div_Image_GroupPhoto" runat="server" visible="false">
                                    <td>

                                         <div style="margin-top:20px">
                                            <table>
                                                <tr>
                                                    <td>Select Folder:</td>
                                                    <td>
                                                        <asp:DropDownList ID="cboFolder_GroupPhoto" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>

                            <div style="margin-top:20px;margin-bottom:20px">
                                    <asp:FileUpload ID="FileUpload9" runat="server" />
                                    <asp:Button ID="Button7" runat="server" Text="Upload" OnClick="UploadFile9" />
                                    <div style="margin-top:20px;overflow:scroll;height:300px;width:510px">
                                    <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false" GridLines="none" EmptyDataText = "No files uploaded" AllowPaging="false" PageSize="10" AutoGenerateSelectButton="True" >
                            <AlternatingRowStyle BackColor="#EFF3FB" BorderStyle="None" />
                            <Columns>
                                <asp:BoundField DataField="Text" HeaderText="File Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="white" HeaderStyle-Height="30px" ItemStyle-CssClass="image_upload" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile" Width="100px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" BorderStyle="None" BorderColor="White" />
                            <PagerStyle BorderStyle="None" />
                            <RowStyle BorderColor="White" BorderStyle="None" Height="30px" />
                        </asp:GridView>
                        </div>
                    </div>

                                    </td>
                                </tr>

                    <tr valign="middle">
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Ordering</td>
                                    <td style="width:30px">:</td>
                                    <td > 
                                        <asp:TextBox ID="txtOrdering_GroupPhoto" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Visible</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:DropDownList ID="cboVisible_GroupPhoto" runat="server" Width="100px">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-top:5px">
                            <table>
                                <tr>
                                    <td style="width:120px">Photo ID</td>
                                    <td style="width:30px">:</td>
                                    <td> 
                                        <asp:TextBox ID="txtGroupPhotoID" runat="server" Width="95px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    
                    


                    <tr>
                        <td>
                            <asp:Label ID="lblResult_GroupPhoto" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>

                </table>
                        </td>

                        <td valign="top" style="width:20%;padding-top:50px">
                            <table style="margin-left:20px">

                                <tr>
                                    <td>
                                        <asp:Button ID="cmdNew_GroupPhoto" CssClass="myButton" runat="server" Text="New" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="cmdSave_GroupPhoto" CssClass="myButton" runat="server" Text="Save" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="cmdDelete_GroupPhoto" CssClass="myButton" runat="server" Text="Delete" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="cmdClose_GroupPhoto" CssClass="myButton" runat="server" Text="Close" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:HiddenField ID="HiddenField5" runat="server" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
            </div>


            <div id="noShowContent" runat="server" style="margin-left: 20px;">
                <table style="width:100%;margin-top:20px;margin-bottom:20px">
                    <tbody>
                        <tr>
                            <td style="width: 80%;">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="border-bottom:1px solid #dddddd">No Show</td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top:5px">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td style="width:120px">Code</td>
                                                            <td style="width:30px">:</td>
                                                            <td>
                                                                <input type="text" id="txtMainFocusCode" runat="server" style="width:300px;" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding-top: 5px">
                                                <asp:GridView ID="lstNoShow" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" Width="100%" AllowSorting="True">
                                                    <columns>
                                                        <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <%# Eval("MainFocusCode")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Room" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <%# Eval("Room")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Title">
                                                            <ItemTemplate>
                                                                <%# Eval("Title")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <%# Eval("Date")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Headertext="Time" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <%# Eval("Time")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td valign="top" style="width:20%;padding-top:50px">
                            <table style="margin-left:20px">

                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddNoShow" CssClass="myButton" runat="server" Text="Add" Width="100px" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnRemoveNoShow" CssClass="myButton" runat="server" Text="Remove" Width="100px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>

            <div id="container_bottom">
                <div style="width:100%;height:10px;background-color:#606060;border-radius:0px 0px 10px 10px">
          
<div class="cd-popup" role="alert">
	<div id="popup_select_article" class="cd-popup-container">
		
        <div style="width:1000px;height:500px;margin-left:20px;padding-top:20px"> 
            <div style="height:480px;overflow:scroll;width:800px">

            
            <asp:GridView ID="GridView1" BorderStyle="Solid" BorderWidth="1" HeaderStyle-Height="30px" RowStyle-Height="30px" BorderColor="Control" runat="server" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ArticleID" DataSourceID="SqlArticle" AutoGenerateSelectButton="True" AllowPaging="false" PageSize="13">
                <AlternatingRowStyle BackColor="#F3F3F3" BorderStyle="None" />
                <Columns>
                    <asp:BoundField DataField="ArticleID" HeaderText="ID" HeaderStyle-Width="80px" InsertVisible="False" ReadOnly="True" SortExpression="ArticleID" ControlStyle-Width="50px" HeaderStyle-BorderColor="#333333" >
<ControlStyle Width="50px"></ControlStyle>

<HeaderStyle BorderColor="#333333"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ArticleTitle" HeaderText="ArticleTitle" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" SortExpression="ArticleTitle" HeaderStyle-Width="300px" HeaderStyle-BorderColor="#333333" >
<HeaderStyle BorderColor="#333333" Width="300px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ArticleTitle_KH" HeaderText="ArticleTitle_KH" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" SortExpression="ArticleTitle_KH" HeaderStyle-Width="300px" HeaderStyle-BorderColor="#333333" >
<HeaderStyle BorderColor="#333333" Width="300px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="Visible" HeaderText="Visible" SortExpression="Visible" HeaderStyle-Width="80px" HeaderStyle-BorderColor="#333333" >
<HeaderStyle BorderColor="#333333" Width="80px"></HeaderStyle>
                    </asp:CheckBoxField>
                </Columns>

                <EditRowStyle BorderStyle="None" />

                <HeaderStyle BackColor="#0099FF" ForeColor="White" />
                <FooterStyle BorderStyle="Solid" BorderColor="Black" />

                

            </asp:GridView>
            
            
            </div>
        </div>
    

		<a href="#0" class="cd-popup-close img-replace">Close</a>
		
	</div>
</div>


<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
<script src="js/popup/main.js"></script> <!-- Resource jQuery -->
                </div>
            </div>

        </div>
        </div>
    </div>


         <script>
             jQuery(document).ready(function ($) {
                 //$(window).load(function () {
                 $('#slider11').nivoSlider({
                     effect: 'random',
                     directionNavHide: false,
                     pauseOnHover: true,
                     captionOpacity: 1,
                     prevText: '<',
                     nextText: '>'
                 });

                 $('#slider12').nivoSlider({
                     effect: 'random',
                     directionNavHide: false,
                     pauseOnHover: true,
                     captionOpacity: 1,
                     prevText: '<',
                     nextText: '>'
                 });

                 $('#slider13').nivoSlider({
                     effect: 'random',
                     directionNavHide: false,
                     pauseOnHover: true,
                     captionOpacity: 1,
                     prevText: '<',
                     nextText: '>'
                 });
             });

             jQuery(document).ready(function ($) {

                 var options = {
                     $FillMode: 2,                                       //[Optional] The way to fill image in slide, 0 stretch, 1 contain (keep aspect ratio and put all inside slide), 2 cover (keep aspect ratio and cover whole slide), 4 actual size, 5 contain for large image, actual size for small image, default value is 0
                     $AutoPlay: true,                                    //[Optional] Whether to auto play, to enable slideshow, this option must be set to true, default value is false
                     $AutoPlayInterval: 4000,                            //[Optional] Interval (in milliseconds) to go for next slide since the previous stopped if the slider is auto playing, default value is 3000
                     $PauseOnHover: 1,                                   //[Optional] Whether to pause when mouse over if a slider is auto playing, 0 no pause, 1 pause for desktop, 2 pause for touch device, 3 pause for desktop and touch device, 4 freeze for desktop, 8 freeze for touch device, 12 freeze for desktop and touch device, default value is 1

                     $ArrowKeyNavigation: true,   			            //[Optional] Allows keyboard (arrow key) navigation or not, default value is false
                     $SlideEasing: $JssorEasing$.$EaseOutQuint,          //[Optional] Specifies easing for right to left animation, default value is $JssorEasing$.$EaseOutQuad
                     $SlideDuration: 800,                               //[Optional] Specifies default duration (swipe) for slide in milliseconds, default value is 500
                     $MinDragOffsetToSlide: 20,                          //[Optional] Minimum drag offset to trigger slide , default value is 20
                     //$SlideWidth: 600,                                 //[Optional] Width of every slide in pixels, default value is width of 'slides' container
                     //$SlideHeight: 300,                                //[Optional] Height of every slide in pixels, default value is height of 'slides' container
                     $SlideSpacing: 0, 					                //[Optional] Space between each slide in pixels, default value is 0
                     $DisplayPieces: 1,                                  //[Optional] Number of pieces to display (the slideshow would be disabled if the value is set to greater than 1), the default value is 1
                     $ParkingPosition: 0,                                //[Optional] The offset position to park slide (this options applys only when slideshow disabled), default value is 0.
                     $UISearchMode: 1,                                   //[Optional] The way (0 parellel, 1 recursive, default value is 1) to search UI components (slides container, loading screen, navigator container, arrow navigator container, thumbnail navigator container etc).
                     $PlayOrientation: 1,                                //[Optional] Orientation to play slide (for auto play, navigation), 1 horizental, 2 vertical, 5 horizental reverse, 6 vertical reverse, default value is 1
                     $DragOrientation: 1,                                //[Optional] Orientation to drag slide, 0 no drag, 1 horizental, 2 vertical, 3 either, default value is 1 (Note that the $DragOrientation should be the same as $PlayOrientation when $DisplayPieces is greater than 1, or parking position is not 0)

                     $BulletNavigatorOptions: {                          //[Optional] Options to specify and enable navigator or not
                         $Class: $JssorBulletNavigator$,                 //[Required] Class to create navigator instance
                         $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                         $AutoCenter: 1,                                 //[Optional] Auto center navigator in parent container, 0 None, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                         $Steps: 1,                                      //[Optional] Steps to go for each navigation request, default value is 1
                         $Lanes: 1,                                      //[Optional] Specify lanes to arrange items, default value is 1
                         $SpacingX: 8,                                   //[Optional] Horizontal space between each item in pixel, default value is 0
                         $SpacingY: 8,                                   //[Optional] Vertical space between each item in pixel, default value is 0
                         $Orientation: 1,                                //[Optional] The orientation of the navigator, 1 horizontal, 2 vertical, default value is 1
                         $Scale: false                                   //Scales bullets navigator or not while slider scale
                     },

                     $ArrowNavigatorOptions: {                           //[Optional] Options to specify and enable arrow navigator or not
                         $Class: $JssorArrowNavigator$,                  //[Requried] Class to create arrow navigator instance
                         $ChanceToShow: 1,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                         $AutoCenter: 2,                                 //[Optional] Auto center arrows in parent container, 0 No, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                         $Steps: 1                                       //[Optional] Steps to go for each navigation request, default value is 1
                     }
                 };

                 //Make the element 'slider1_container' visible before initialize jssor slider.
                 $("#slider1_container").css("display", "block");
                 var jssor_slider1 = new $JssorSlider$("slider1_container", options);

                 //responsive code begin
                 //you can remove responsive code if you don't want the slider scales while window resizes
                 function ScaleSlider() {
                     var bodyWidth = document.body.clientWidth;
                     if (bodyWidth)
                         jssor_slider1.$ScaleWidth(Math.min(bodyWidth, 1920));
                     else
                         window.setTimeout(ScaleSlider, 30);
                 }
                 ScaleSlider();

                 $(window).bind("load", ScaleSlider);
                 $(window).bind("resize", ScaleSlider);
                 $(window).bind("orientationchange", ScaleSlider);
                 //responsive code end


             });
                </script>


    </form>
</body>
</html>
