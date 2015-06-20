<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="MyEMR_New.aspx.cs" Inherits="ICUPro.Portal.MyEMR_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-main5 padding15">
        <div class="fg-main border-bottom large" style="padding-bottom: 5px; margin-bottom: 15px;">
            <i class="icon-folder"></i>&nbsp;我的病历
        </div>
        <div>
            <iframe src="MyCase.aspx"  frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes" width="100%" height="1000"></iframe>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ActionHolder" runat="server">
    <script>
        // Highlight the menu
        $(".icon-folder").parent().addClass("fg-main bg-main5");
    </script>
</asp:Content>
