<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCase.aspx.cs" Inherits="ICUPro.Portal.MyCase" %>

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
    <form id="Form1" runat="server">
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

        <div id="divBaseContent">
            <table style="width: 100%; margin: 0; background: none;">
                <tr>
                    <td class="size3" style="vertical-align: top; padding-right: 15px;">
                        <nav class="sidebar light">
                            <ul>
                                <li><a href="#" onclick="filterEMRList();">全部</a></li>
                                <asp:Repeater ID="rptEMRType" runat="server">
                                    <ItemTemplate>
                                        <li><a href="#" onclick="filterEMRList('<%#Eval("guid")%>');"><%#Eval("name")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </nav>
                        <div style="padding-top: 15px;">
                            <button class="bg-mainb fg-white size2" id="addnew" onclick="createNewEMR();return false;"><i class="icon-plus"></i>&nbsp;新增病历</button>
                        </div>
                    </td>
                    <td style="vertical-align: top;" class="">
                        <div class="fg-gray"><b>基本信息</b></div>
                        <div>
                            <table style="width: 100%; margin: 0; table-layout: fixed;" class="table bordered">
                                <tr>
                                    <td>
                                        <div class="fg-main small">姓名</div>
                                        <div class="fg-gray" style="padding-top: 5px;">
                                            <asp:TextBox runat="server" ID="txtName" ReadOnly="true" BorderStyle="None"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="fg-main small">性别</div>
                                        <div class="fg-gray" style="padding-top: 5px;">
                                            <asp:TextBox runat="server" ID="txtGender" ReadOnly="true" BorderStyle="None"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="fg-main small">生日</div>
                                        <div class="fg-gray" style="padding-top: 5px;">
                                            <asp:TextBox runat="server" ID="txtAge" ReadOnly="true" BorderStyle="None"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="height: 800px; overflow-y: scroll;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptList" runat="server">
                                        <ItemTemplate>
                                            <div class="fg-gray" style="padding-top: 30px;">
                                                <b><%#Eval("type_name")%></b>
                                                <div class="place-right fg-main"><%#Eval("created_dt")%></div>
                                            </div>
                                            <div>
                                                <table style="width: 100%; margin: 0;" class="table bordered">
                                                    <tr>
                                                        <td><%#Eval("content")%></td>
                                                        <td class="size3"><%#Eval("imgthumbnail")%></td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <%--Popup Dialog--%>
        <div id="divNewContent" style="display: none;">
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
                                <asp:Button ID="btnUploadEMR" runat="server" OnClientClick="if(!checkImage()) return false;" OnClick="btnUploadEMR_Click" Text="上传..." />
                                <input type="hidden" id="hidEMRImageURL" runat="server" />
                            </div>
                            <div id="divImgContainer" style="width: 200px; height: 200px;">
                                <asp:Literal ID="litEMRImg" runat="server"></asp:Literal>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="fg-gray">内容</div>
                            <div>
                                <div class="input-control textarea" style="">
                                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="fg-gray">翻译</div>
                            <div>
                                <div class="input-control textarea" style="margin: 0;">
                                    <asp:TextBox ID="txtContent_t" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="padding-top: 20px; margin-top: 20px;" class="border-top">
                    <button class="bg-main fg-white size2" onclick="saveNewEMR();return false;"><i class="icon-floppy"></i>&nbsp;保存</button>
                    <button>取消</button>
                    <div style="display: none;">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="bg-main fg-white size2" Text="保存" />
                    </div>
                </div>
            </div>
        </div>
        <div style="display: none">
            <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" />
            <input type="hidden" id="hidFilterType" runat="server" />
            <input type="hidden" id="hidPatientGUID" runat="server" />
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
        <script>
            //$("#addnew").on('click', function () {
            //    var dialogUrl = "MeasurementCalibration.aspx";
            //    var windowParameter = "dialogWidth=850px;dialogHeight=550px";
            //    window.showModalDialog("NewEMRContent.aspx?guid=", "", windowParameter);
            //});
            //$("#addnew").on('click', function () {
            //    $.Dialog({
            //        overlay: true,
            //        shadow: true,
            //        flat: true,
            //        onShow: function (_dialog) {
            //            var content = $('#divNewContent').html();
            //            $.Dialog.title("新增病历");
            //            $.Dialog.content(content);
            //        }
            //    });
            //    return false;
            //});
            function createNewEMR() {
                $("#divBaseContent").hide();
                $("#divNewContent").show();
            }
            function checkImage() {
                if ($("#FileUpload_EMR").val() == "") {
                    alert("请选择图片！");
                    return false;
                }
                return true;
            }
            function saveNewEMR() {
                if ($("#txtContent").val() == "") {
                    alert("内容不能为空");
                    return false;
                }
                document.getElementById('btnSave').click();
            }

            function filterEMRList(type) {
                // Highlight the menu
                $(".sidebar a").removeClass("fg-main bold bg-main4");
                $(this).addClass("fg-main bold bg-main4");

                $("#hidFilterType").val(type);
                //alert($("#hidFilterType").val());
                document.getElementById('btnFilter').click();
            }

        </script>
    </form>
</body>
</html>
