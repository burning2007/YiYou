<%@ Page Title="申请会诊" Language="C#" MasterPageFile="~/main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-main5 padding15">
        <div class="fg-main large" style="padding-bottom: 10px;"><i class="icon-new"></i>&nbsp;申请会诊</div>
        <div>
            <table style="width: 100%; background: none; margin: 0; table-layout: fixed;">
                <tr>
                    <td class="size6" style="vertical-align: top;">
                        <div class="fg-gray">会诊项目</div>
                        <div>
                            <div class="input-control select">
                                <select>
                                    <option>帕金森氏病诊断</option>
                                </select>
                            </div>
                        </div>
                        <div class="fg-gray">目的地</div>
                        <div class="input-control select">
                            <select>
                                <option>美国</option>
                            </select>
                        </div>
                        <div class="fg-gray">医院</div>
                        <div>
                            <div class="input-control select">
                                <select>
                                    <option>西雅图格雷斯医院</option>
                                </select>
                            </div>
                        </div>
                        <div class="fg-gray">医生</div>
                        <div>
                            <div class="input-control select">
                                <select>
                                    <option>格雷</option>
                                </select>
                            </div>
                        </div>
                        <div class="fg-gray">当前状态</div>
                        <div class="fg-main">未提交</div>
                    </td>
                    <td style="vertical-align: top; padding-left: 20px;">
                        <div class="fg-gray">当地诊断医院</div>
                        <div>
                            <div class="input-control select">
                                <select>
                                    <option>上海市第九人民医院</option>
                                </select>
                            </div>
                        </div>
                        <div class="fg-gray">当地诊断</div>
                        <div>
                            <div class="input-control textarea" style="margin: 0;">
                                <textarea rows="16"></textarea>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <div style="padding-top: 20px; margin-top: 20px;" class="border-top">
                <button class="bg-main fg-white size2"><i class="icon-floppy"></i>&nbsp;保存</button>
                <button class="bg-mainb fg-white size2"><i class="icon-checkmark"></i>&nbsp;提交申请</button>
                <button>取消</button>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ActionHolder" runat="server">
</asp:Content>
