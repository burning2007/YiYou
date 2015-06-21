<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="MyRequest.aspx.cs" Inherits="ICUPro.Portal.MyRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-main5 padding15">
        <div style="height: 40px;">
            <div onclick="chgtab(1);" class="fg-main" style="padding: 10px; float: left; cursor: hand; border: 1px solid grey;">
                <i class="icon-new"></i>&nbsp;申请会诊
            </div>
            <div onclick="chgtab(2);" class="fg-main" style="padding: 10px; float: left; cursor: hand; border-right: 1px solid grey; border-top: 1px solid grey; border-bottom: 1px solid grey;">
                <i class="icon-folder"></i>&nbsp;患者病历
            </div>
        </div>
        <div id="panel1" style="padding: 15px 15px 15px 15px; border: 1px solid grey;" class="pagetab">
            <table style="width: 100%; background: none; margin: 0;">
                <tr>
                    <td class="size6" style="vertical-align: top;">
                        <div class="fg-gray">账号</div>
                        <div>
                            <div class="input-control">
                                <asp:TextBox ID="txtName" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fg-gray">手机号</div>
                        <div>
                            <div class="input-control">
                                <asp:TextBox ID="txtMobile" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fg-gray">邮箱</div>
                        <div>
                            <div class="input-control">
                                <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fg-gray">患者姓名</div>
                        <div>
                            <div class="input-control">
                                <asp:TextBox ID="txtPatientName" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqPatientName" runat="server" ControlToValidate="txtPatientName" SetFocusOnError="true" Display="None" ErrorMessage="请输入患者姓名"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="fg-gray">患者性别</div>
                        <div>
                            <div class="input-control select">
                                <asp:DropDownList ID="ddlGender" runat="server">
                                    <asp:ListItem Value="0">未知</asp:ListItem>
                                    <asp:ListItem Value="1">女</asp:ListItem>
                                    <asp:ListItem Value="2">男</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="fg-gray">患者生日</div>
                        <div>
                            <div class="input-control">
                                <asp:TextBox ID="txtDOB" runat="server" Text="1987-3-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fg-gray">会诊目的</div>
                        <div>
                            <div class="input-control textarea">
                                <asp:TextBox ID="txtApplicationPurpose" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApplicationPurpose" SetFocusOnError="true" Display="None" ErrorMessage="请输入会诊目的"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div>
                            <asp:FileUpload ID="FileUpload_Purpose" runat="server" />
                            <asp:Button ID="btnUploadPurpose" runat="server" OnClick="btnUploadPurpose_Click" Text="上传..." />
                        </div>
                        <div id="divImgContainer">
                            <asp:Literal ID="litPurposeImg" runat="server"></asp:Literal>
                        </div>
                    </td>
                    <td class="size6" style="vertical-align: top; padding-left: 20px;">
                        <div class="fg-gray"><a href="#">既往病史</a> <span style="text-align: right; margin-right: 10px">点击这里编辑既往病史</span></div>
                        <div class="fg-gray">目的地类型</div>
                        <div>
                            <div class="input-control select">
                                <asp:DropDownList ID="ddlLocalType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalType_SelectedIndexChanged">
                                    <asp:ListItem Value="1">国内</asp:ListItem>
                                    <asp:ListItem Value="2">国外</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="fg-gray">会诊医院数量</div>
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlHospitalCount" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHospitalCount_SelectedIndexChanged">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3" Selected="True">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--This panel will create the Hospital and Doctor group based on the dropdown selection value--%>
                        <asp:Panel ID="panDoctorGroup" runat="server"></asp:Panel>                       
                    </td>
                </tr>
            </table>
            <div style="padding-top: 20px; margin-top: 20px;" class="border-top">
                <button style="display: none;" class="bg-main fg-white size2 btnSave" onclick="$('#MainContent_btnSave').click();return false;"><i class="icon-floppy"></i>&nbsp;保存</button>
                <button class="bg-mainb fg-white size2 btnSubmit" onclick="$('#MainContent_btnSubmit').click();return false;"><i class="icon-checkmark"></i>&nbsp;提交申请</button>
                <button style="display: none;" onclick="window.location = 'MyWorklist.aspx';return false;">取消</button>
                <asp:Button ID="btnSave" runat="server" Style="display: none" OnClick="btnSave_Click" />
                <asp:Button ID="btnSubmit" runat="server" Style="display: none" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Style="display: none" OnClick="btnCancel_Click" />
                <span>当前状态 :
                            <asp:Label runat="server" ID="lblStatus"></asp:Label></span>
            </div>
            <div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                    ShowMessageBox="True" />
            </div>
            <asp:Label runat="server" ID="lblErrorMsg" ForeColor="Red"></asp:Label>
            <input type="hidden" runat="server" id="hidGUID" />

            <div style="display: none;">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
        </div>
        <div id="panel2" class="pagetab" style="padding-top: 15px; border: 1px solid grey; display: none;">
            <div class="bg-main5 padding15">
                <div class="fg-main border-bottom large" style="padding-bottom: 5px; margin-bottom: 15px;">
                    <i class="icon-folder"></i>&nbsp;我的病历
                </div>
                <div>
                    <iframe src="MyCase.aspx" frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes" width="100%" height="1000"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ActionHolder" runat="server">
    <script>
        // Highlight the menu
        $(".icon-new").parent().addClass("fg-main bg-main5");
    </script>
    <script type="text/javascript">
        function chgtab(index) {
            $(".pagetab").hide();
            $("#panel" + index).show();
        }

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

