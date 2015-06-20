<!DOCTYPE html>

<html lang="zh">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Use the standalone mode to look more like a native application on iOS -->
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <!-- Minimize the status bar that is displayed at the top of the screen on iOS -->
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <title>虹桥医游网 远程会诊平台 登录</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" />

</head>
<body class="metro" style="height: 100%; overflow: hidden; background-image: url('images/neurologist.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center;">
    <form id="Form1" runat="server" style="height: 100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <div style="width: 100%; height: 100%;">
            <div class="bg-white" style="position: absolute; top: 50%; left: 50%; margin-top: -180px; margin-left: -320px; width: 640px; height: 360px; opacity: 1; box-shadow: #aaa 4px 4px 8px;">
                <div class="padding20 bg-main fg-white" style="padding-left: 30px;">
                    <div style="opacity: 0.6;">Tele-Medicine Platform</div>
                    <span style="font-size: 32px;">远程会诊平台</span>
                </div>
                <table style="width: 100%; margin: 0; background: none;">
                    <tr>
                        <td class="text-center" style="padding-top: 30px;">
                            <img src="images/yiyou_logo.png" width="240" />
                        </td>
                        <td class="size4" style="padding-left: 20px;">
                            <div style="padding-top: 40px;">
                                <div class="input-control text size3" style="margin-bottom: 0px;">
                                    <input type="text" placeholder="用户名" />
                                    <button class="btn-clear"></button>
                                </div>
                            </div>
                            <div style="padding-top: 10px;">
                                <div class="input-control text size3" style="margin-bottom: 0px;">
                                    <input type="password" placeholder="密码" />
                                    <button class="btn-clear"></button>
                                </div>
                            </div>
                            <div style="padding-top: 30px;">
                                <button class="bg-mainb fg-white size2 icon-locked">&nbsp;登录</button>
                            </div>
                            <div class="input-control checkbox fg-gray" style="padding-top: 10px;">
                                <label>
                                    <input type="checkbox" checked="checked" />
                                    <span class="check"></span>
                                    保持登录状态
                                </label>
                            </div>
                        </td>
                    </tr>
                </table>
                <%--<div class="text-right fg-gray" style="padding-right: 10px;">&copy; Meehealth 米健医疗</div>--%>
            </div>
        </div>
        <!-- Load JavaScript Libraries -->
        <script src="Scripts/jquery/jquery-1.11.0.min.js"></script>
        <script src="Scripts/jquery/jquery-ui-1.10.4.min.js"></script>
        <script src="Scripts/jquery/jquery.widget.min.js"></script>
        <script src="Scripts/jquery/jquery.mousewheel.js"></script>
        <!-- Metro UI CSS JavaScript plugins -->
        <script src="Scripts/load-metro.js"></script>
        <!-- Mustache -->
        <script src="Scripts/mustache/mustache.js"></script>
        <!-- JSON -->
        <script src="Scripts/json/json2.js"></script>
        <!-- Chart -->
        <script src="Scripts/chart/Highstock-1.3.10/js/highstock.src.js"></script>
        <script src="Scripts/chart/Highstock-1.3.10/js/modules/exporting.js"></script>

        <!-- Custom Javascript -->
        <script src="Scripts/main.js"></script>
    </form>
</body>
</html>


