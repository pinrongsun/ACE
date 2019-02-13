<%@ Page Language="VB" AutoEventWireup="false" CodeFile="nametag.aspx.vb" Inherits="nametag" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nametag</title>
     <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        //this script will get the date selected from the given calendarextender (ie: "sender") and append the
        //current time to it.
        function AppendTime(sender, args) {
            var selectedDate = new Date();
            selectedDate = sender.get_selectedDate();
            var now = new Date();
            sender.get_element().value = selectedDate.format("dd/MM/yyyy") + " " + now.format("HH:mm:ss");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div  style="text-align:center;">
    <div style="max-width:600px;margin:auto;background-color: #e3e3e3;padding: 10px;">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">

            
        <table width="100%">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="120" align="left">Registration No.</td>
                <td align="center" width="15">:</td>
                <td>
                    <asp:TextBox ID="txtRegNo" CssClass="form input-sm" placeholder="ex.: 0001 (Then Enter)" runat="server" Width="100%" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120">&nbsp;</td>
                <td align="center" width="15">&nbsp;</td>
                <td align="left">
                    <asp:Label ID="lblNotice" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            </table>
        <div id="div_detail" runat="server" visible="false">
            <table width="100%">
            <tr>
                <td width="120" align="left">Family Name</td>
                <td align="center" width="15">:</td>
                <td>
                    <asp:TextBox ID="txtFamilyName" CssClass="form input-sm" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">Given Name</td>
                <td align="center">:</td>
                <td>
                    <asp:TextBox ID="txtGivenName" CssClass="form input-sm" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">Position</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtPosition" CssClass="form input-sm" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">Workplace</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtWorkplace" CssClass="form input-sm" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            </table>
        </div>

        <div id="div_more" runat="server" visible="false">
            <table width="100%">
            <tr>
                <td width="120" align="left">Dietary</td>
                <td align="center" width="15">:</td>
                <td align="left">
                    <asp:RadioButton ID="rdoStandard" runat="server" GroupName="Dietarys" Text="Standard" />
                    <asp:RadioButton ID="rdoHalal" runat="server" GroupName="Dietarys" Text="Halal" />
                    <asp:RadioButton ID="rdoVegetarian" runat="server" GroupName="Dietarys" Text="Vegetarian" />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
            </tr>
                <tr>
                    <td align="left" width="120">Email</td>
                    <td align="center" width="15">:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form input-sm" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="left">Phone</td>
                    <td align="center" width="15">:</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form input-sm" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="left">Nationality</td>
                    <td align="center" width="15">:</td>
                    <td align="left">
                        <cc1:ComboBox ID="dplNationality" runat="server" AutoCompleteMode="SuggestAppend" CssClass="input-group-sm" Width="100%">
                            <asp:ListItem></asp:ListItem>
                        </cc1:ComboBox>
                    </td>
                </tr>
            <tr>
                <td align="left">Country of
                    <br />
                    Residence</td>
                <td>:</td>
                <td align="left" style="padding-top: 10px; padding-bottom: 10px">
                    <cc1:ComboBox ID="dplCountry" runat="server" AutoCompleteMode="SuggestAppend" CssClass="input-group-sm" Width="100%">
                        <asp:ListItem></asp:ListItem>
                    </cc1:ComboBox>
                </td>
            </tr>
                <tr>
                    <td align="left">Certificate Type</td>
                    <td>:</td>
                    <td align="left">
                        <table>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoHard" runat="server" GroupName="CertificateType" Text="Hard Copy" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdoSoft" runat="server" GroupName="CertificateType" Text="Soft Copy" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            <tr>
                <td align="left">Participant Type</td>
                <td>:</td>
                <td align="left" >
                    <cc1:ComboBox ID="dplParticipantType" runat="server" AutoCompleteMode="SuggestAppend" CssClass="input-group-sm" Width="100%">
                        <asp:ListItem>Participant</asp:ListItem>
                        <asp:ListItem>Presenter</asp:ListItem>
                        <asp:ListItem>Convention Crew</asp:ListItem>
                        <asp:ListItem>Volunteer</asp:ListItem>
                        <asp:ListItem>IELTS 6.5 Recipient</asp:ListItem>
                        <asp:ListItem>IELTS Sponsored Delegates</asp:ListItem>
                        <asp:ListItem>Media</asp:ListItem>
                        <asp:ListItem>Exhibitor</asp:ListItem>
                        <asp:ListItem>VIP</asp:ListItem>
                    </cc1:ComboBox>
                </td>
            </tr>
            <tr>
                <td align="left">Registered</td>
                <td>:</td>
                <td align="left" style="padding-top: 10px; padding-bottom: 10px">
                    <asp:Panel ID="pnRegistration" runat="server" Enabled="false">
                        <table>
                            <tr>
                                <td align="center" colspan="2" style="padding: 5px; font-weight: bold">Friday</td>
                                <td align="center" style="padding: 5px; font-weight: bold">Saturday</td>
                                <td align="center" style="padding: 5px; font-weight: bold">Sunday</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkRS" runat="server" Text="Research Symposuim" />
                                </td>
                                <td>&nbsp;</td>
                                <td align="center">
                                    <asp:CheckBox ID="chkSat" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkSun" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkLeadership" runat="server" Text="Leadship Forum" />
                                </td>
                                <td>&nbsp;</td>
                                <td align="center" colspan="2" rowspan="2">
                                    <table>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:CheckBox ID="chkPaid" runat="server" AutoPostBack="True" Text="Paid" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPaidDate" runat="server" AutoPostBack="True" CssClass="form input-sm" Width="140px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="txtAttendanceDate_CalendarExtender" runat="server" DaysModeTitleFormat="yyyy'/'MM" Enabled="True" Format="dd'/'MM'/'yyyy" OnClientDateSelectionChanged="AppendTime" TargetControlID="txtPaidDate" TodaysDateFormat="yyyy'/'MM'/'dd">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td align="left" colspan="2">
                                                            <asp:CheckBox ID="chkPrinted" runat="server" AutoPostBack="True" Text="Nametag Printed" />
                                                            &nbsp;<asp:CheckBox ID="chkDeleted" runat="server" AutoPostBack="True" Text="Deleted" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkDinner" runat="server" Text="Dinner" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <asp:LinkButton ID="lnkAttendance" runat="server" Visible="False">Attendance Management</asp:LinkButton>
                    <asp:LinkButton ID="lnkAdmin" runat="server" Visible="False">Admin</asp:LinkButton>
                </td>

        </table>
        </div>
                <div style="text-align:center; padding-top: 10px;">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Update and Print" Visible="False" />
                </div>
                </asp:View>
            <asp:View ID="View2" runat="server">

                <table>
                    <tr>
                        <td align="left">User:</td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form input-sm" placeholder="" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password:</td>
                        <td>
                            <asp:TextBox ID="txtAdminPassword" runat="server" CssClass="form input-sm" placeholder="" Width="200px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblpasswordNotice" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAdmin" runat="server" CssClass="btn btn-success" Text="Submit" />
                            &nbsp;<asp:Button ID="btnSubmit1" runat="server" CssClass="btn btn-default" Text="Back" />
                        </td>
                    </tr>
                </table>

            </asp:View>
            <asp:View ID="View3" runat="server">
                <div>Attendance</div>
                <div align="left">
                    <table>
                        <tr>
                            <td align="center" colspan="2" style="padding: 5px; font-weight: bold">Friday</td>
                            <td align="center" style="padding: 5px; font-weight: bold">Saturday</td>
                            <td align="center" style="padding: 5px; font-weight: bold">Sunday</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkRS0" runat="server" Text="Research Symposuim" AutoPostBack="True" />
                                <br />
                                <asp:TextBox ID="txtRS0" runat="server" AutoPostBack="True" CssClass="form input-sm" Width="150px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtRS0_CalendarExtender" runat="server" DaysModeTitleFormat="yyyy'/'MM" Enabled="True" Format="dd'/'MM'/'yyyy" TargetControlID="txtRS0" TodaysDateFormat="yyyy'/'MM'/'dd"  OnClientDateSelectionChanged="AppendTime">
                                </cc1:CalendarExtender>
                                <br />
                            </td>
                            <td>&nbsp;</td>
                            <td align="center">
                                <asp:CheckBox ID="chkSat0" runat="server" AutoPostBack="True" />
                                <br />
                                <asp:TextBox ID="txtSat0" runat="server" AutoPostBack="True" CssClass="form input-sm" Width="150px" ></asp:TextBox>
                                <cc1:CalendarExtender ID="txtSat0_CalendarExtender" runat="server" DaysModeTitleFormat="yyyy'/'MM" Enabled="True" Format="dd'/'MM'/'yyyy" TargetControlID="txtSat0" TodaysDateFormat="yyyy'/'MM'/'dd"  OnClientDateSelectionChanged="AppendTime">
                                </cc1:CalendarExtender>
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="chkSun0" runat="server" AutoPostBack="True" />
                                <br />
                                <asp:TextBox ID="txtSun0" runat="server" AutoPostBack="True" CssClass="form input-sm" Width="150px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtSun0_CalendarExtender" runat="server" DaysModeTitleFormat="yyyy'/'MM" Enabled="True" Format="dd'/'MM'/'yyyy" TargetControlID="txtSun0" TodaysDateFormat="yyyy'/'MM'/'dd"  OnClientDateSelectionChanged="AppendTime">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkLeadership0" runat="server" Text="Leadship Forum" AutoPostBack="True" />
                                <br />
                                <asp:TextBox ID="txtLeadership0" runat="server" AutoPostBack="True" CssClass="form input-sm" Width="150px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtLeadership0_CalendarExtender" runat="server" DaysModeTitleFormat="yyyy'/'MM" Enabled="True" Format="dd'/'MM'/'yyyy" TargetControlID="txtLeadership0" TodaysDateFormat="yyyy'/'MM'/'dd"  OnClientDateSelectionChanged="AppendTime">
                                </cc1:CalendarExtender>
                            </td>
                            <td>&nbsp;</td>
                            <td align="center">&nbsp;</td>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkProvincialTeacher0" runat="server" Text="Provincial Teacher" AutoPostBack="True" />
                                <br />
                                <asp:TextBox ID="txtProvincialTeacher0" runat="server" AutoPostBack="True" CssClass="form input-sm" Width="150px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtProvincialTeacher0_CalendarExtender" runat="server" DaysModeTitleFormat="yyyy'/'MM" Enabled="True" Format="dd'/'MM'/'yyyy" TargetControlID="txtProvincialTeacher0" TodaysDateFormat="yyyy'/'MM'/'dd"  OnClientDateSelectionChanged="AppendTime">
                                </cc1:CalendarExtender>
                            </td>
                            <td>&nbsp;</td>
                            <td align="center">&nbsp;</td>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkDinner0" runat="server" Text="Dinner" AutoPostBack="True" />
                                <br />
                                <asp:TextBox ID="txtDinner0" runat="server" AutoPostBack="True" CssClass="form input-sm" Width="150px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDinner0_CalendarExtender" runat="server" DaysModeTitleFormat="yyyy'/'MM" Enabled="True" Format="dd'/'MM'/'yyyy" TargetControlID="txtDinner0" TodaysDateFormat="yyyy'/'MM'/'dd"  OnClientDateSelectionChanged="AppendTime">
                                </cc1:CalendarExtender>
                            </td>
                            <td>&nbsp;</td>
                            <td align="center">&nbsp;</td>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkTour0" runat="server" AutoPostBack="True" Text="Tour" />
                                <br />
                                <asp:TextBox ID="txtTour0" runat="server" AutoPostBack="True" CssClass="form input-sm" Width="150px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtTour0_CalendarExtender" runat="server" DaysModeTitleFormat="yyyy'/'MM" Enabled="True" Format="dd'/'MM'/'yyyy" TargetControlID="txtTour0" TodaysDateFormat="yyyy'/'MM'/'dd"   OnClientDateSelectionChanged="AppendTime">
                                </cc1:CalendarExtender>
                            </td>
                            <td>&nbsp;</td>
                            <td align="center">&nbsp;</td>
                            <td align="center">&nbsp;</td>
                        </tr>
                    </table>
                </div>
                <div align="left">
                    <br />
                    <asp:Button ID="btnSubmit2" runat="server" CssClass="btn btn-default" Text="Back" />
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
    </div>
    </form>
</body>
</html>
