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
                <button onclick="refreshGrid('');return false;" class="bg-main fg-white">全部 <span class="badge bg-white fg-main"><asp:Label runat="server" ID="lblStatus_All"></asp:Label></span></button>
                <button onclick="refreshGrid(0);return false;">未提交 <span class="badge bg-grayLight fg-white"><asp:Label runat="server" ID="lblStatus_0"></asp:Label></span></button>
                <button onclick="refreshGrid(1);return false;">已提交 <span class="badge bg-amber fg-white"><asp:Label runat="server" ID="lblStatus_1"></asp:Label></span></button>
                <button onclick="refreshGrid(2);return false;">已接受 <span class="badge bg-main fg-white"><asp:Label runat="server" ID="lblStatus_2"></asp:Label></span></button>
                <button onclick="refreshGrid(3);return false;">已付初审费 <span class="badge bg-mainb fg-white"><asp:Label runat="server" ID="lblStatus_3"></asp:Label></span></button>
                <button onclick="refreshGrid(4);return false;">初审中 <span class="badge bg-grayLight fg-white"><asp:Label runat="server" ID="lblStatus_4"></asp:Label></span></button>
                <button onclick="refreshGrid(5);return false;">已初审 <span class="badge bg-amber fg-white"><asp:Label runat="server" ID="lblStatus_5"></asp:Label></span></button>
                <button onclick="refreshGrid(6);return false;">已付会诊费 <span class="badge bg-main fg-white"><asp:Label runat="server" ID="lblStatus_6"></asp:Label></span></button>
                <button onclick="refreshGrid(7);return false;">会诊中 <span class="badge bg-grayLight fg-white"><asp:Label runat="server" ID="lblStatus_7"></asp:Label></span></button>
                <button onclick="refreshGrid(8);return false;">已出结论 <span class="badge bg-amber fg-white"><asp:Label runat="server" ID="lblStatus_8"></asp:Label></span></button>
                <button onclick="refreshGrid(9);return false;">已翻译 <span class="badge bg-main fg-white"><asp:Label runat="server" ID="lblStatus_9"></asp:Label></span></button>
                <button onclick="refreshGrid(99);return false;">已完成 <span class="badge bg-mainb fg-white"><asp:Label runat="server" ID="lblStatus_99"></asp:Label></span></button>
                <button onclick="refreshGrid(100);return false;">已拒绝 <span class="badge bg-darkRed fg-white"><asp:Label runat="server" ID="lblStatus_100"></asp:Label></span></button>
            </div>
           <%-- <div id="divNavigation" style="padding-bottom: 5px;">
                <div class="input-control">
                    会诊状态&nbsp;：&nbsp;
                    <asp:DropDownList ID="ddlApplicationStatus" runat="server" >
                        <asp:ListItem Value="国内">国内</asp:ListItem>
                        <asp:ListItem Value="国外">国外</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>--%>
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
                            <asp:BoundField HeaderText="创建日期" DataField="created_dt" ItemStyle-Width="200px" />
                            <asp:BoundField HeaderText="会诊状态" DataField="StatusText" ItemStyle-Width="120px" />
                            <asp:BoundField HeaderText="会诊医院数量" DataField="HospitalCount" ItemStyle-Width="100px" />
                            <%--<asp:BoundField HeaderText="会诊项目" DataField="project_name" />--%>
                            <asp:BoundField HeaderText="姓名" DataField="name" ItemStyle-Width="120px" />
                            <asp:BoundField HeaderText="性别" DataField="gendertext"  ItemStyle-Width="120px"/>
                            <asp:BoundField HeaderText="目的地" DataField="location_name" ItemStyle-Width="200px" />
                            <%--  <asp:BoundField HeaderText="会诊医院" DataField="hospital_name" />
                            <asp:BoundField HeaderText="医生" DataField="doctor_name" />--%>
                            <asp:TemplateField HeaderText="操作" ItemStyle-Width="230px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnOperate" class="bg-main fg-white" Text='<%# Eval("CommandText")%>' guid='<%# Eval("guid")%>' OnClientClick='showApplicationDetail(this);return false;' runat="Server"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnSupplement" class="bg-main fg-white" runat="server" Text="补充资料" > </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" class="bg-main fg-white" runat="server" Text="进展" > </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" class="bg-main fg-white" runat="server" Text="购买" > </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" class="bg-main fg-white" runat="server" Text="档案" > </asp:LinkButton>
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
            var curSpanNavigation = '#MainContent_';
            if (type == '' && type !='0') {
                curSpanNavigation += 'lblStatus_All';
            }
            else
                curSpanNavigation += 'lblStatus_' + type;

            var spanNavigations = $('#divNavigation [id*="lblStatus_"]');
            
            for (var i = 0; i < spanNavigations.length; i++) {
                var spanId = '#' + spanNavigations[i].id;
               
                $(spanId).parent().parent().removeClass('bg-main');
            }

            $(curSpanNavigation).parent().parent().addClass('bg-main');
            
            $("#MainContent_btnFilter").click();
        }
        function showApplicationDetail(obj) { 
            var uid = $('#' + obj.id).attr('guid')
            window.location = "MyRequest.aspx?guid=" + uid;
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
