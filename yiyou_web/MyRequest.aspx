<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="MyRequest.aspx.cs" Inherits="ICUPro.Portal.MyRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .highlightTabMenu
        {
            background-color: orange;
        }
    </style>
    <div class="bg-main5 padding15">
        <div style="height: 40px;" class="subTabMenu">
            <div id="menu1" onclick="chgtab(1);" class="fg-main highlightTabMenu" style="padding: 10px; float: left; cursor: hand; border: 1px solid grey;">
                &nbsp;申请会诊
            </div>
            <div id="menu2" onclick="chgtab(2);" class="fg-main" style="padding: 10px; float: left; cursor: hand; border-right: 1px solid grey; border-top: 1px solid grey; border-bottom: 1px solid grey;">
                &nbsp;患者病历
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
                            <asp:Button ID="btnUploadPurpose" runat="server" OnClientClick="if(!checkImage()) return false;" OnClick="btnUploadPurpose_Click" Text="上传..." />
                        </div>
                        <div id="divImgContainer" style="width: 200px; height: 200px;">
                            <asp:Literal ID="litPurposeImg" runat="server"></asp:Literal>
                        </div>
                    </td>
                    <td class="size6" style="vertical-align: top; padding-left: 20px;">
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
            <input type="hidden" runat="server" id="hidUserGUID" />
            <input type="hidden" runat="server" id="hidPurposeImgGUID" />
            <input type="hidden" runat="server" id="hidPurposeImg" />
        </div>
        <div id="panel2" class="pagetab" style="padding-top: 15px; border: 1px solid grey; display: none;">
            <div class="bg-main5 padding15">
                <div>
                    <iframe id="iframeEMR" src="MyCase.aspx" frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes" width="100%" height="1000"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ActionHolder" runat="server">
    <script>
        // Highlight the menu
        $(".icon-new").parent().addClass("fg-main bg-main5");

        // Check if user selected image before upload
        function checkImage() {
            if ($("#MainContent_FileUpload_Purpose").val() == "") {
                alert("请选择图片！");
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function chgtab(index) {
            // css
            $(".subTabMenu .fg-main").removeClass("highlightTabMenu");
            $("#menu" + index).addClass("highlightTabMenu");

            $(".pagetab").hide();
            $("#panel" + index).show();
            if (index == 2) {
                // if view/edit EMR, should pass through the UserGUID and PatientName
                // **** WARNING ***
                // The patient_guid is useless, because the user can change the patientName at anytime, and the new
                // PatientName will be treated as the new patient under the user, and the previous one will not be deleted.
                // So we should use the userGUID and PatientName to manage the EMR List
                var userGUID = $("#MainContent_hidUserGUID").val();
                var patientName = $("#MainContent_txtPatientName").val();
                var gender = $("#MainContent_ddlGender").find("option:selected").text();
                var genderType = $("#MainContent_ddlGender").val();
                var dob = $("#MainContent_txtDOB").val();
                var url = "MyCase.aspx?userid=" + userGUID
                    + "&patname=" + escape(patientName)
                    + "&gender=" + escape(gender)
                    + "&genderType=" + escape(genderType)
                    + "&dob=" + escape(dob);
                //alert(url);
                document.getElementById("iframeEMR").src = url;
            }
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

