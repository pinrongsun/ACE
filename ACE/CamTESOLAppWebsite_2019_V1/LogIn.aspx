<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LogIn.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log in</title>
     <meta name="viewport" content="initial-scale=1, maximum-scale=1">

       <link rel="stylesheet" href="css/style_login.css">
    </head>
<body>
    <form id="form1" runat="server">
    <div>
   


<!--
  Below we include the Login Button social plugin. This button uses
  the JavaScript SDK to present a graphical Login button that triggers
  the FB.login() function when clicked.
-->



<div class="login-page">
 <div style="width: 100%">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Banner2017_Resized.jpg" 
                Width="100%" />
        </div>

  <div class="form">
   
    <div class="login-form">
        
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            <div>
                <asp:Label ID="lblVerify" runat="server"></asp:Label>
                </div>
             <asp:TextBox ID="txtusername" runat="server" placeholder="email"></asp:TextBox>
    <asp:TextBox ID="txtpassword" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
     

    <asp:Button ID="btnLogin" runat="server" Text="login" CssClass="button" />
      <p class="message">Not registered? 
          <asp:LinkButton ID="LinkButton1" runat="server">Create an account</asp:LinkButton></p>
                <p class="message">
                    <asp:LinkButton ID="LinkButton4" runat="server" 
                        onclientclick="statusChangeCallback(response)"></asp:LinkButton>
                </p>
                <p class="message">
                    <asp:LinkButton ID="LinkButton6" runat="server" >Forget password</asp:LinkButton>
                </p>
      <div style="height: 15px"></div>
      <div onclick="getRedirectURI()" id="fbLoginLink" style="display:none"><img id="Img1" alt="facebook" runat="server" src="~/img/Menu/fb.png" style="width: 40px; height: 40px; vertical-align: middle;" /><a>Log In</a></div>

      <fb:login-button scope="public_profile,email" onlogin="checkLoginState()" style="display:none;">
      

</fb:login-button>
      <div id="status"></div>
    </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
             
             <div class="login-form">
            
            <asp:TextBox ID="txtfullname" runat="server" placeholder="full name"></asp:TextBox>
            <asp:TextBox ID="txtemail" runat="server" placeholder="email"></asp:TextBox>
            <asp:TextBox ID="txtretype" runat="server" placeholder="retype email"></asp:TextBox>
            <asp:TextBox ID="txtpassword_create" runat="server" placeholder="your password" 
                     TextMode="Password">fdafsds</asp:TextBox>
                <asp:DropDownList ID="dplCountry" placeholder="country" runat="server" 
                     Width="100%" CssClass="dropdown" Visible="False">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Cambodia</asp:ListItem>
                    <asp:ListItem>Vietname</asp:ListItem>
                    <asp:ListItem>Thailand</asp:ListItem>
                    <asp:ListItem>China</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
                <div style="height: 15px"></div>
      <asp:Button ID="Button1" runat="server" Text="Create" CssClass="button" />
      <div>
          <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
          
      </div>
      <p class="message">Already registered? 
          <asp:LinkButton ID="LinkButton3" runat="server">Sign in</asp:LinkButton>
                 </p>
    </div>
            
           
            </asp:View>
      <asp:View ID="View3" runat="server">
      
      <div class="text1" align="left">
          
          <asp:LinkButton ID="LinkButton5" runat="server" CssClass="message2">Back</asp:LinkButton>
          <br />
          <br />
          Welcome to CamTESOL Application.
          <br />
          <br />
          To activate your account, please check your inbox and then click on activate 
          link.<br />
          <br />
          </div>
          
      </asp:View>
       <asp:View ID="View4" runat="server">
      <div class="text1">
          Welcome to CamTESOL Application. Your account is activated, now you are ready to 
          log in.</div>
      </asp:View>
      <asp:View ID="View5" runat="server">
          <asp:Panel ID="Panel4" runat="server" BorderStyle="None">
          <div class="login-form">
              <table>
                  <tr>
                      <td align="left" style="padding-left: 10px;">
                          <asp:LinkButton ID="lnkExisting0" runat="server" CausesValidation="False" 
                              CssClass="message2">Back</asp:LinkButton>
                      </td>
                  </tr>
                  <tr>
                      <td align="left" class="text1">
                          To get your password, please supply 
                          your email address here:</td>
                  </tr>
                  <tr>
                      <td align="left">
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                              ControlToValidate="txtEmail_Password" Display="Dynamic" ErrorMessage="Invalid!" 
                              ForeColor="Red" 
                              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*|NA"></asp:RegularExpressionValidator>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                              ControlToValidate="txtEmail_Password" Display="Dynamic" 
                              ErrorMessage="RequiredFieldValidator" ForeColor="Red">Reqired!</asp:RequiredFieldValidator>
                        
                          <asp:TextBox ID="txtEmail_Password" runat="server" placeholder="email" ></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td align="center">
                          <div style="text-align: center">
                              <table width="100%">
                                  <tr>
                                      <td style="padding: 10px" valign="middle">
                                          <asp:Button ID="btnResetPassword" runat="server" CssClass="button" 
                                              Text="Submit" />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="left" style="padding: 10px" valign="middle">
                                          <asp:Label ID="lblNoteForgetPassword" runat="server" Font-Names="verdana" 
                                              Font-Size="9pt" ForeColor="Red"></asp:Label>
                                      </td>
                                  </tr>
                              </table>
                          </div>
                      </td>
                  </tr>
              </table>
            </div>
          </asp:Panel>
      </asp:View>
      <asp:View ID="View6" runat="server">

          <table>
              <tr>
                  <td align="left">
                      Check Your Email</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td align="center">
                      <div style="text-align: center">
                          <table>
                              <tr>
                                  <td style="padding: 5px">
                                      &nbsp;</td>
                                  <td align="left" class="text1" 
                                      style="padding: 10px; font-family: verdana, Geneva, Tahoma, sans-serif;" 
                                      valign="middle">
                                      Your password has been sent to your email. Please check your email.
                                  </td>
                              </tr>
                              <tr>
                                  <td style="padding: 5px">
                                      &nbsp;</td>
                                  <td style="padding: 10px" valign="middle">
                                      <asp:LinkButton ID="LinkButton7" runat="server" CssClass="message2">Sign in</asp:LinkButton>
                                  </td>
                              </tr>
                          </table>
                      </div>
                  </td>
              </tr>
          </table>

      </asp:View>
      <asp:View ID="View7" runat="server">

          <table>
              <tr>
                  <td align="left" style="padding-left: 10px;">
                      <asp:LinkButton ID="lnkExisting1" runat="server" CausesValidation="False" 
                          CssClass="message2">Back</asp:LinkButton>
                  </td>
              </tr>
              <tr>
                  <td align="left" class="text1">
                      Your account is not activated yet.
                      <br />
                      <br />
                      Please check your inbox to get your activation code.</td>
              </tr>
              <tr>
                  <td align="left">
                      <asp:TextBox ID="txtActivatecode" runat="server" placeholder="Activate Code"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td align="center">
                      <div style="text-align: center">
                          <table width="100%">
                              <tr>
                                  <td style="padding: 10px" valign="middle">
                                      <asp:Button ID="btnActivateAccount" runat="server" CssClass="button" 
                                          Text="Submit" />
                                  </td>
                              </tr>
                              <tr>
                                  <td align="left" style="padding: 10px" valign="middle">
                                      <asp:Label ID="lblInfoActivation" runat="server" Font-Names="verdana" 
                                          Font-Size="9pt" ForeColor="Red"></asp:Label>
                                  </td>
                              </tr>
                          </table>
                      </div>
                  </td>
              </tr>
          </table>

      </asp:View>
        </asp:MultiView>
   
  </div>
</div>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

    <script src="js/index_login.js"></script>
    <script type="text/javascript">
       
        $("#fbLoginLink").click(function (e) {
            function statusChangeCallback(response) {
                console.log('statusChangeCallback');
                console.log(response);
                // The response object is returned with a status field that lets the
                // app know the current login status of the person.
                // Full docs on the response object can be found in the documentation
                // for FB.getLoginStatus().
                var uri = encodeURI('http://camtesolapp.acecambodia.org');

                if (response.status === 'connected') {
                    // Logged into your app and Facebook.
                    //window.location.href = uri;
                    FB.api('/me',
                      function (response) {
                          window.location.href = encodeURI(uri + "/eace.aspx?user=" + response.name);
                      }
                    );
                    //testAPI();
                } else if (response.status === 'not_authorized') {
                      // The person is logged into Facebook, but not your app.
                
                    window.location = encodeURI("https://www.facebook.com/dialog/oauth?client_id=1155534924563275&redirect_uri=" + uri + "&response_type=token");
                
                } else {
                    // The person is not logged into Facebook, so we're not sure if
                    // they are logged into this app or not.
                
                    window.location = encodeURI("https://www.facebook.com/dialog/oauth?client_id=1155534924563275&redirect_uri=" + uri + "&response_type=token");
                
                }
            }

            // This function is called when someone finishes with the Login
            // Button.  See the onlogin handler attached to it in the sample
            // code below.
        
            function checkLoginState() {
                FB.getLoginStatus(function (response) {
                    statusChangeCallback(response);
                });
            }

            function getRedirectURI() {
                var uri = encodeURI('http://camtesolapp.acecambodia.org');
                window.location = encodeURI("https://www.facebook.com/dialog/oauth?client_id=1155534924563275&redirect_uri=" + uri + "&response_type=token&scope=public_profile,email");
            }

            function loginfb() {
                FB.getLoginStatus(function (response) {
                    statusChangeCallback(response);
                });
            }

            window.fbAsyncInit = function () {
                FB.init({
                    appId: '1155534924563275',
                    cookie: true,  // enable cookies to allow the server to access 
                    // the session
                    xfbml: true,  // parse social plugins on this page
                    version: 'v2.6' // use graph api version 2.8
                });

                checkLoginState();
            };

            (function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id)) { return; }
                js = d.createElement(s); js.id = id;
                js.src = "//connect.facebook.net/en_US/sdk.js";
                fjs.parentNode.insertBefore(js, fjs);
            } (document, 'script', 'facebook-jssdk'));

            function testAPI() {
                console.log('Welcome!  Fetching your information.... ');
                FB.api('/me', { locale: 'en_US', fields: 'name, email' },
                  function (response) {
                      alert(response.email);
                  }
                );
              }
          });

    function getQueryString(symbol) {
        
        var url = window.location.href;

        var queryString;

        queryString = url.substring(url.indexOf(symbol) + 1);


        var queryParam = queryString.split("&");
        var queryName;
        var queryVal;
        var query = {};

        for (var i = 0; i < queryParam.length; i++) {
            queryName = queryParam[i].substring(0, queryParam[i].indexOf("="));
            queryVal = queryParam[i].substring(queryParam[i].indexOf("=") + 1);

            query[queryName] = queryVal;

        }

        return query;
    }
    var query = getQueryString("#");
    for (var key in query) {
        if (key == "access_token") {
            $("#fbLoginLink").click();
            break;
        }
    }
</script>
    </div>
    </form>
</body>
</html>
