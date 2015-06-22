<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="MyWorklist.aspx.cs" Inherits="ICUPro.Portal.MyWorklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-main5 padding15">
        <div class="fg-main border-bottom" style="padding-bottom: 5px; margin-bottom: 15px;">
            <span class="large">
                <i class="icon-list"></i>&nbsp;会诊管理</span>
            <div class="place-right fg-main" style="padding-top: 10px;"><i class="icon-info"></i>&nbsp;会诊状态说明</div>
        </div>
        <div>
            <div id="divNavigation" style="padding-bottom: 5px;">
                <button onclick="refreshGrid('0');return false;" class="bg-main">
                    全部 <span class="badge bg-white fg-main">
                        <asp:Label runat="server" ID="lblStatus_0"></asp:Label></span></button>
                <button onclick="refreshGrid('1');return false;">
                    待处理 <span class="badge bg-grayLight fg-white">
                        <asp:Label runat="server" ID="lblStatus_1"></asp:Label></span></button>
                <button onclick="refreshGrid('2');return false;">
                    已完成 <span class="badge bg-mainb fg-white">
                        <asp:Label runat="server" ID="lblStatus_2"></asp:Label></span></button>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnFilter" runat="server" Style="display: none;" OnClick="btnFilter_Click" />
                    <input type="hidden" runat="server" id="hidFilter" />
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                        AutoGenerateColumns="false" Width="100%" PageSize="10" AllowPaging="true" RowStyle-Height="35px" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                        <Columns>
                            <asp:BoundField HeaderText="创建日期" DataField="created_dt" ItemStyle-Width="120px" />
                            <asp:BoundField HeaderText="会诊状态" DataField="StatusText" ItemStyle-Width="100px" />
                            <asp:BoundField HeaderText="患者姓名" DataField="name" ItemStyle-Width="100px" />
                            <asp:BoundField HeaderText="会诊目的" DataField="purpose" ItemStyle-Width="400px" ItemStyle-Wrap="true" />
                            <asp:BoundField HeaderText="会诊医院" DataField="hospitalList" ItemStyle-Width="200px" ItemStyle-Wrap="true" />
                            <asp:TemplateField HeaderText="操作" ItemStyle-Width="230px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnOperate" class="bg-main fg-white" Text='<%# Eval("CommandText")%>' guid='<%# Eval("guid")%>' OnClientClick='showApplicationDetail(this);return false;' runat="Server"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnSupplement" class="bg-main fg-white" runat="server" Text="补充资料" patient_guid='<%# Eval("patient_guid")%>' OnClientClick='addEMRContent(this);return false;' > </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" class="bg-main fg-white" runat="server" Text="进展" guid='<%# Eval("guid")%>' OnClientClick='return false;' > </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" class="bg-main fg-white" runat="server" Text="购买" guid='<%# Eval("guid")%>' OnClientClick='return false;' > </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" class="bg-main fg-white" runat="server" Text="档案" patient_guid='<%# Eval("patient_guid")%>' OnClientClick='viewEMRContent(this);return false;' > </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div class="pagination" style="margin-bottom: 50px; padding-top: 10px;">
                                <ul>
                                    <li class="first"><a onclick="$('#MainContent_GridView1_btnFirstPage').click();"><i class="icon-first-2"></i></a></li>
                                    <li class="prev"><a onclick="$('#MainContent_GridView1_btnPrevPage').click();"><i class="icon-previous"></i></a></li>
                                    <asp:Literal ID="litPagerIndexList" runat="server"></asp:Literal>
                                    <li class="next"><a onclick="$('#MainContent_GridView1_btnNextPage').click();"><i class="icon-next"></i></a></li>
                                    <li class="last"><a onclick="$('#MainContent_GridView1_btnLastPage').click();"><i class="icon-last-2"></i></a></li>
                                </ul>
                            </div>
                            <asp:Button ID="btnFirstPage" runat="server" Style="display: none;" CommandName="PageIndexPage" CommandArgument="First" />
                            <asp:Button ID="btnPrevPage" runat="server" Style="display: none;" CommandName="PageIndexPage" CommandArgument="Prev" />
                            <asp:Button ID="btnNextPage" runat="server" Style="display: none;" CommandName="PageIndexPage" CommandArgument="Next" />
                            <asp:Button ID="btnLastPage" runat="server" Style="display: none;" CommandName="PageIndexPage" CommandArgument="Last" />
                            <asp:Button ID="btnGotoPage" runat="server" Style="display: none;" CommandName="PageIndexPage" CommandArgument="Goto" />
                        </PagerTemplate>
                    </asp:GridView>
                    <div>
                        <input type="hidden" id="hidPageIndex" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ActionHolder" runat="server">
    <script>
        // Highlight the menu
        $(".icon-list").parent().addClass("fg-main bg-main5");
    </script>
    <script>
        function refreshGrid(type) {
            // This is only a indicator, not the ApplicationStatus, the Status should be coded in the behind
            document.getElementById('MainContent_hidFilter').value = type;
            // Find the clicked button and accordly label
            var curSpanNavigation = '#MainContent_' + 'lblStatus_' + type;
            var spanNavigations = $('#divNavigation [id*="lblStatus_"]');
            // Remove highlight css first
            for (var i = 0; i < spanNavigations.length; i++) {
                var spanId = '#' + spanNavigations[i].id;
                $(spanId).parent().parent().removeClass('bg-main');
            }
            // Add the new button as highlight
            $(curSpanNavigation).parent().parent().addClass('bg-main');

            $("#MainContent_btnFilter").click();
        }
        function showApplicationDetail(obj) {
            var uid = $('#' + obj.id).attr('guid')
            window.location = "MyRequest.aspx?guid=" + uid;
        }
        function addEMRContent(obj) {
            var uid = $('#' + obj.id).attr('patient_guid')
            window.location = "MyEMR_New.aspx?type=new&guid=" + uid;
        }
        function viewEMRContent(obj) {
            var uid = $('#' + obj.id).attr('patient_guid')
            window.location = "MyEMR_New.aspx?type=view&guid=" + uid;
        }
    </script>
    <script>
        $("#viewreport").on('click', function () {
            $.Dialog({
                overlay: true,
                shadow: true,
                flat: true,
                onShow: function (_dialog) {
                    var content = $('#report').html();
                    $.Dialog.title("会诊详细信息");
                    $.Dialog.content(content);
                }
            });
            return false;
        });

        $("#viewcontract").on('click', function () {
            $.Dialog({
                overlay: true,
                shadow: true,
                flat: true,
                onShow: function (_dialog) {
                    var content = $('#contract').html();
                    $.Dialog.title("合同签约");
                    $.Dialog.content(content);
                }
            });
            return false;
        });

    </script>
</asp:Content>
