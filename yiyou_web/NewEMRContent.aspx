<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEMRContent.aspx.cs" Inherits="ICUPro.Portal.NewEMRContent" %>

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
    <title><%: Page.Title %> - 虹桥医游网
    </title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" />

</head>
<body class="metro">
    <form id="form1" runat="server">
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
        <div class="bg-main5 padding20" style="width: 800px;">
            <table style="width: 100%; background: none; margin: 0; table-layout: fixed;">
                <tr>
                    <td>
                        <div class="fg-gray">类型</div>
                        <div>
                            <div class="input-control select">
                                <asp:DropDownList ID="ddlEMRType" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </td>
                    <td rowspan="3" style="vertical-align: top; padding-left: 20px;">
                        <div class="fg-gray">图片</div>
                        <div>
                            <asp:FileUpload ID="FileUpload_EMR" runat="server" />
                            <asp:Button ID="btnUploadEMR" runat="server" OnClick="btnUploadEMR_Click" Text="上传..." />
                        </div>
                        <div style="padding-bottom: 10px;">
                            <asp:Literal ID="litEMRImg" runat="server"></asp:Literal>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="fg-gray">内容</div>
                        <div>
                            <div class="input-control textarea" style="">
                                <textarea></textarea>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="fg-gray">翻译</div>
                        <div>
                            <div class="input-control textarea" style="margin: 0;">
                                <textarea></textarea>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <div style="padding-top: 20px; margin-top: 20px;" class="border-top">
                <button class="bg-main fg-white size2"><i class="icon-floppy"></i>&nbsp;保存</button>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="bg-main fg-white size2" Text="保存" />
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
