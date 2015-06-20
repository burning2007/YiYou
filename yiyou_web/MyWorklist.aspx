<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="MyWorklist.aspx.cs" Inherits="ICUPro.Portal.MyWorklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-main5 padding15">
        <div class="fg-main border-bottom" style="padding-bottom: 5px; margin-bottom: 15px;">
            <span class="large">
                <i class="icon-list"></i>&nbsp;会诊管理</span>
            <div class="place-right fg-main" style="padding-top: 10px;"><i class="icon-info"></i>&nbsp;会诊状态说明</div>
        </div>
        <div>
            <div style="padding-bottom: 5px;">
                <button onclick="refreshGrid('');return false;" class="bg-main fg-white">全部 <span class="badge bg-white fg-main"><asp:Label runat="server" ID="lblStatus_All"></asp:Label></span></button>
                <button onclick="refreshGrid(0);return false;">未提交 <span class="badge bg-grayLight fg-white"><asp:Label runat="server" ID="lblStatus_0"></asp:Label></span></button>
                <button onclick="refreshGrid(1);return false;">已提交 <span class="badge bg-grayLight fg-white"><asp:Label runat="server" ID="lblStatus_1"></asp:Label></span></button>
                <button onclick="refreshGrid(10);return false;">已审核 <span class="badge bg-amber fg-white"><asp:Label runat="server" ID="lblStatus_10"></asp:Label></span></button>
                <button onclick="refreshGrid(11);return false;">已签约 <span class="badge bg-grayLight fg-white"><asp:Label runat="server" ID="lblStatus_11"></asp:Label></span></button>
                <button onclick="refreshGrid(12);return false;">已付款 <span class="badge bg-main fg-white"><asp:Label runat="server" ID="lblStatus_12"></asp:Label></span></button>
                <button onclick="refreshGrid(99);return false;">已完成 <span class="badge bg-mainb fg-white"><asp:Label runat="server" ID="lblStatus_99"></asp:Label></span></button>
                <button onclick="refreshGrid(21);return false;">已拒绝或取消 <span class="badge bg-darkRed fg-white"><asp:Label runat="server" ID="lblStatus_21"></asp:Label></span></button>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnFilter" runat="server" Style="display: none;" OnClick="btnFilter_Click" />
                    <input type="hidden" runat="server" id="hidFilter" />
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                        AutoGenerateColumns="false" Width="100%" PageSize="5" AllowPaging="true" RowStyle-Height="35px" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                        <Columns>
                            <asp:BoundField HeaderText="创建日期" DataField="created_dt" ItemStyle-Width="200px" />
                            <asp:BoundField HeaderText="会诊状态" DataField="StatusText" ItemStyle-Width="200px" />
                            <asp:BoundField HeaderText="会诊项目" DataField="project_name" />
                            <asp:BoundField HeaderText="目的地" DataField="location_name" ItemStyle-Width="200px" />
                            <asp:BoundField HeaderText="会诊医院" DataField="hospital_name" />
                            <asp:BoundField HeaderText="医生" DataField="doctor_name" />
                            <asp:TemplateField HeaderText="操作" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnOperate" Text='<%# Eval("CommandText")%>' guid='<%# Eval("guid")%>' OnClientClick='showApplicationDetail(this);return false;' runat="Server"></asp:LinkButton>
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
                        <input type="hidden" id="hidPageIndex" runat="server" /></div>
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
            document.getElementById('MainContent_hidFilter').value = type;
            $("#MainContent_btnFilter").click();
        }
        function showApplicationDetail(obj) {
            window.location = "MyRequest.aspx?guid=" + obj.guid;
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
