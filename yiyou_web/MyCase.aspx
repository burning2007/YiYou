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
        <div>
            <table style="width: 100%; margin: 0; background: none;" cellpadding="0">
                <tr>
                    <td class="size3" style="vertical-align: top; padding-right: 15px;">
                        <nav class="sidebar light">
                            <ul>
                                <li><a href="#" class="fg-main bold bg-main4">全部</a></li>
                                <li><a href="#">病历</a></li>
                                <li><a href="#">检验</a></li>
                                <li><a href="#">影像</a></li>
                                <li><a href="#">其他</a></li>
                            </ul>
                        </nav>
                        <div style="padding-top: 15px;">
                            <button class="bg-mainb fg-white size2" id="addnew"><i class="icon-plus"></i>&nbsp;新增病历</button>
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
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <%--popup dialogs--%>
        <div style="display: none;">
            <div id="new">
                <div class="bg-main5 padding20" style="width: 800px;">
                    <table style="width: 100%; background: none; margin: 0; table-layout: fixed;">
                        <tr>
                            <td>
                                <div class="fg-gray">类型</div>
                                <div>
                                    <div class="input-control select">
                                        <select>
                                            <option>病历</option>
                                            <option>检验</option>
                                            <option>影像</option>
                                            <option>其他</option>
                                        </select>
                                    </div>
                                </div>
                            </td>
                            <td rowspan="4" style="vertical-align: top; padding-left: 20px;">
                                <div class="fg-gray">图片</div>
                                <div>
                                    <div style="padding-bottom: 10px;">
                                        <img src="images/化验单.jpg" style="width: 100%; padding: 4px;" class="bg-white border" />
                                    </div>
                                    <button id="btnUpload" onclick="fnUpload();"><i class="icon-pictures"></i>&nbsp;上传...</button>
                                    <div style="display: none;">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="fg-gray">医院</div>
                                <div>
                                    <div class="input-control select">
                                        <select>
                                            <option>上海市第九人民医院</option>
                                        </select>
                                    </div>
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
                        <button>取消</button>
                    </div>
                </div>
            </div>
            <div id="labtest">
                <div class="bg-main5 padding20" style="width: 800px;">
                    <div style="padding-bottom: 10px;">血红蛋白（HGB）108 g/L，咯为低于正常，可以肯定为“贫血，但仅属轻度（HGB 91~110g/L，属于轻度）。平均红细胞体积（MCV）为 78.8 fl、红细胞平均血红蛋白含量（MCH）为24.9 pg、红细胞平均血红蛋白浓度（MCHC）为317 g/L，以上三项均低于正常，说明是一种“小细胞低色素性贫血”。“小细胞低色素贫血”最常见于“缺铁性贫血”，“缺铁性贫血”最常见的原因是由慢性失血引起，诸如月经过多、痔疮慢性出血、消化道慢性失血等，其次见于铁摄入不足或肠道吸收障碍等，老年人还要警惕消化道肿瘤。</div>
                    <div>
                        <img src="images/化验单.jpg" style="width: 100%; padding: 4px;" class="bg-white border" />
                    </div>

                </div>
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
        <script>
            $("#addnew").on('click', function () {
                $.Dialog({
                    overlay: true,
                    shadow: true,
                    flat: true,
                    onShow: function (_dialog) {
                        var content = $('#new').html();
                        $.Dialog.title("新增病历");
                        $.Dialog.content(content);
                    }
                });
                return false;
            });

            $("#btnlabtest").on('click', function () {
                $.Dialog({
                    overlay: true,
                    shadow: true,
                    flat: true,
                    onShow: function (_dialog) {
                        var content = $('#labtest').html();
                        $.Dialog.title("检验化验 (2015/04/15)");
                        $.Dialog.content(content);
                    }
                });
                return false;
            });

            function fnUpload() {
                $("#FileUpload1").click();
            }

        </script>
    </form>
</body>
</html>
