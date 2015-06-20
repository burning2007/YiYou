<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="MyRequest.aspx.cs" Inherits="ICUPro.Portal.MyRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-main5 padding15">
        <div class="fg-main large" style="padding-bottom: 10px;"><i class="icon-new"></i>&nbsp;申请会诊</div>
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <table style="width: 100%; background: none; margin: 0; table-layout: fixed;">
                        <tr>
                            <td class="size6" style="vertical-align: top;">
                                <div class="fg-gray">会诊项目</div>
                                <div>
                                    <div class="input-control select">
                                        <asp:DropDownList ID="ddlProject" runat="server" DataTextField="name" DataValueField="guid"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="fg-gray">目的地</div>
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlLocation" runat="server" DataTextField="name" DataValueField="guid" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="fg-gray">医院</div>
                                <div>
                                    <div class="input-control select">
                                        <asp:DropDownList ID="ddlHospital" runat="server" DataTextField="name" DataValueField="guid" AutoPostBack="true" OnSelectedIndexChanged="ddlHospital_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="fg-gray">医生</div>
                                <div>
                                    <div class="input-control select">
                                        <asp:DropDownList ID="ddlDoctor" runat="server" DataTextField="name" DataValueField="guid"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="fg-gray">当前状态</div>
                                <div class="fg-main">
                                    <asp:Label runat="server" ID="lblStatus"></asp:Label><input type="hidden" runat="server" id="hidStatus" />
                                </div>
                            </td>
                            <td style="vertical-align: top; padding-left: 20px;">
                                <div class="fg-gray">当地诊断医院</div>
                                <div>
                                    <div class="input-control">
                                        <asp:TextBox ID="txtLocalHospital" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="fg-gray">当地诊断</div>
                                <div>
                                    <div class="input-control textarea" style="margin: 0;">
                                        <asp:TextBox ID="txtLocalDiagnosis" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div style="padding-top: 20px; margin-top: 20px;" class="border-top">
                        <button class="bg-main fg-white size2 btnSave" onclick="$('#MainContent_btnSave').click();return false;"><i class="icon-floppy"></i>&nbsp;保存</button>
                        <button class="bg-mainb fg-white size2 btnSubmit" onclick="$('#MainContent_btnSubmit').click();return false;"><i class="icon-checkmark"></i>&nbsp;提交申请</button>
                        <button onclick="window.location = 'MyWorklist.aspx';return false;">取消</button>
                        <asp:Button ID="btnSave" runat="server" Style="display: none" OnClick="btnSave_Click" />
                        <asp:Button ID="btnSubmit" runat="server" Style="display: none" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Style="display: none" OnClick="btnCancel_Click" />
                    </div>
                    <asp:Label runat="server" ID="lblErrorMsg" ForeColor="Red"></asp:Label>
                    <input type="hidden" runat="server" id="hidGUID" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ActionHolder" runat="server">
     <script>
         // Highlight the menu
         $(".icon-new").parent().addClass("fg-main bg-main5");
    </script>
    <script type="text/javascript">
        var _status = $("#MainContent_hidStatus").val();
        //alert($("#MainContent_hidStatus").val());
        if (_status == "1") {
            // 已提交
            $(".btnSave").hide();
            $(".btnSubmit").hide();
        }
    </script>
</asp:Content>

