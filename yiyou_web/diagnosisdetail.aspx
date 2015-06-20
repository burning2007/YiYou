<%@ Page Title="会诊详细信息" Language="C#" MasterPageFile="~/main2.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-main5 padding15">
        <div class="fg-main border-bottom" style="padding-bottom: 5px; margin-bottom: 15px;">
            <span class="large">
                <i class="icon-newspaper"></i>&nbsp;会诊详细信息</span>
            <div class="place-right fg-main" style="padding-top: 0px;">
                <button>返回会诊列表</button>
            </div>
        </div>
        <div>
            <div>
                <button class="fg-white bg-main">基本信息</button>
                <button onclick="window.location='diagnosisdetail1.aspx';return false;">病历</button>
                <button onclick="window.location='diagnosisdetail2.aspx';return false;">会诊结果</button>
                <button onclick="window.location='diagnosisdetail3.aspx';return false;">合同</button>
            </div>
            <div class="border padding15">
                <table style="width: 100%; background: none; margin: 0; table-layout: fixed;">
                    <tr>
                        <td class="size3" style="vertical-align: top;">
                            <div class="fg-gray">会诊项目</div>
                            <div class="fg-main large">
                                帕金森氏病诊断
                            </div>
                            <div class="fg-gray" style="padding-top: 20px;">申请人</div>
                            <div class="fg-main">
                                张三
                            </div>
                            <div class="fg-gray" style="padding-top: 20px;">当前状态</div>
                            <div class="fg-main">已完成</div>
                            <div class="fg-gray" style="padding-top: 20px;">提交时间</div>
                            <div class="fg-main">2015/04/20 09:00</div>
                            <div class="fg-gray" style="padding-top: 20px;">审核时间</div>
                            <div class="fg-main">2015/04/20 15:30</div>
                            <div class="fg-gray" style="padding-top: 20px;">签约时间</div>
                            <div class="fg-main">2015/04/21 12:15</div>
                            <div class="fg-gray" style="padding-top: 20px;">付款时间</div>
                            <div class="fg-main">2015/04/22 10:39</div>
                            <div class="fg-gray" style="padding-top: 20px;">递交时间</div>
                            <div class="fg-main">2015/04/22 07:50</div>
                            <div class="fg-gray" style="padding-top: 20px;">完成时间</div>
                            <div class="fg-main">2015/04/23 09:00</div>
                        </td>
                        <td style="vertical-align: top; padding-left: 20px;">
                            <div>
                                <table style="width: 100%; margin: 0; background: none; table-layout: fixed;" cellpadding="0">
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <div class="fg-gray" style="">会诊目的地和医院</div>
                                            <div class="fg-main">
                                                (新加坡)约翰霍普金斯新加坡国际医疗中心
                                            </div>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <div class="fg-gray" style="padding-top: 0px;">会诊医生</div>
                                            <div class="fg-main">
                                                Alex Y. Chang (医学博士,医学主任，教授)
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="fg-gray" style="padding-top: 20px;">
                                当地诊断意见
                            </div>
                            <div style="margin-top: 0px; box-shadow: #ccc 3px 3px 6px;" class="border padding20 bg-white">
                                <div class="text-right" style="padding-bottom: 10px;">
                                    <button class="bg-main fg-white">中文</button>
                                    <button class="">英文</button>
                                </div>
                                <p>诊断帕金森综合征首先要存在运动减少，即随意运动在始动时缓慢，重复性动作的运动速度及幅度逐渐降低；同时至少具有以下一个症状：A 肌肉僵直；B.静止性震颤（4－6Hz）；C.直立不稳（非原发性视觉，前庭功能，小脑及本体感觉功能障碍造成）。诊断原发性帕金森病需先除外可能造成类似症状的各种继发性病因；诊断依赖于临床特点、病程和治疗反应，即具有帕金森病临床三联征（震颤、运动迟缓和僵直）中的至少两项以及对于多巴胺能治疗效果显著。在疾病早期即出现突出的语言和步态障碍，姿势不稳，中轴肌张力明显高于四肢，无静止性震颤，突出的自主神经功能障碍，对左旋多巴无反应或疗效不持续均提示帕金森叠加综合征的可能。</p>
                                <p>具有帕金森病临床三联征（震颤、运动迟缓和僵直）中的至少两项以及对于多巴胺能治疗效果显著。在疾病早期即出现突出的语言和步态障碍，姿势不稳，中轴肌张力明显高于四肢，无静止性震颤，突出的自主神经功能障碍，对左旋多巴无反应或疗效不持续均提示帕金森叠加综合征的可能。</p>
                                <p class="fg-main">
                                    <br />
                                    上海市第九人民医院
                                    <br />
                                    2015/04/17 
                                </p>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="padding-top: 15px; margin-top: 15px;" class="border-top">
                                <button class="bg-main fg-white size2"><i class="icon-pencil"></i>&nbsp;编辑</button>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%--popup dialogs--%>
    <div style="display: none;">
        <div id="report">
            <div class="bg-main5 padding20" style="width: 800px;">
                <div></div>
                <div style="padding-top: 20px; margin-top: 20px;" class="border-top">
                    <button class="bg-main fg-white"><i class="icon-printer"></i>&nbsp;打印</button>
                    <button class="bg-main fg-white"><i class="icon-download"></i>&nbsp;下载</button>
                    <button>关闭</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ActionHolder" runat="server">
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

    </script>
</asp:Content>
