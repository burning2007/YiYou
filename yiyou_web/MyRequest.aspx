﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="MyRequest.aspx.cs" Inherits="ICUPro.Portal.MyRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-main5 padding15">
        <div class="fg-main large" style="padding-bottom: 10px;"><i class="icon-new"></i>&nbsp;申请会诊</div>
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <table style="width: 100%; background: none; margin: 0; table-layout: fixed;">
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
                                <div class="fg-gray">患者年龄</div>
                                <div>
                                    <div class="input-control">
                                        <asp:TextBox ID="txtPatientAge" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="fg-gray">会诊目的</div>
                                <div>
                                    <div class="input-control textarea">
                                        <asp:TextBox ID="txtApplicationPurpose" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                    </div>
                                </div>  
                                <div>
                                    <button id="btnUpload" onclick="fnUpload();"><i class="icon-pictures"></i>&nbsp;上传...</button>                                   
                                </div>                              
                                
                            </td>
                            <td class="size6" style="vertical-align: top; padding-left: 20px;">
                                <div class="fg-gray"><a href="#">既往病史</a> <span style="text-align:right; margin-right:10px">点击这里编辑既往病史</span></div>                                
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
                                    <asp:DropDownList ID="ddlHospitalCount" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHospitalCount_SelectedIndexChanged" >
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3" Selected="True">3</asp:ListItem>
                                        <asp:ListItem Value="4">4</asp:ListItem>
                                        <asp:ListItem Value="5">5</asp:ListItem>
                                    </asp:DropDownList>
                                </div>                               
                                <asp:Panel ID="panDoctorGroup" runat="server"></asp:Panel>  
                                <div class="fg-gray">当地诊断医院</div>
                                <div>
                                    <div class="input-control">
                                        <asp:TextBox ID="txtLocalHospital" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                               
                                <div class="fg-gray" style="display:none;">当地诊断医院翻译</div>
                                <div style="display:none;">
                                    <div class="input-control">
                                        <asp:TextBox ID="txtLocalHospitalT" runat="server" Width="100%"></asp:TextBox>
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
                        <span>当前状态 : <asp:Label runat="server" ID="lblStatus"></asp:Label><input type="hidden" runat="server" id="Hidden1" /></span>
                    </div>
                    <asp:Label runat="server" ID="lblErrorMsg" ForeColor="Red"></asp:Label>
                    <input type="hidden" runat="server" id="hidGUID" />
                </ContentTemplate>
                <Triggers>

                </Triggers>
            </asp:UpdatePanel>
             <div style="display:none;">
                <asp:FileUpload ID="FileUpload1" runat="server" />                                   
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
        var _status = $("#MainContent_hidStatus").val();
        //alert($("#MainContent_hidStatus").val());
        if (_status == "1") {
            // 已提交
            $(".btnSave").hide();
            $(".btnSubmit").hide();
        }

        function fnUpload() {
            $("#MainContent_FileUpload1").click();
        }
    </script>
</asp:Content>

