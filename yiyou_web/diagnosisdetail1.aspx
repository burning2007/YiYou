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
                <button onclick="window.location='diagnosisdetail.aspx';return false;">基本信息</button>
                <button onclick="window.location='diagnosisdetail1.aspx';return false;"  class="fg-white bg-main">病历</button>
                <button onclick="window.location='diagnosisdetail2.aspx';return false;">会诊结果</button>
                <button onclick="window.location='diagnosisdetail3.aspx';return false;">合同</button>
            </div>
            <div class="border padding15">
                <table style="width: 100%; margin: 0; background: none;" cellpadding="0">
                    <tr>
                        <td class="size3" style="vertical-align: top; padding-right: 15px;">
                            <nav class="sidebar light">
                                <ul>
                                    <li><a href="#" class="fg-main bold bg-main4">全部</a></li>
                                    <li><a href="#">基本信息</a></li>
                                    <li><a href="#">当地诊断</a></li>
                                    <li><a href="#">既往病史</a></li>
                                    <li><a href="#">检验化验</a></li>
                                    <li><a href="#">医学影象</a></li>
                                    <li><a href="#">家族病史</a></li>
                                    <li><a href="#">随访</a></li>
                                </ul>
                            </nav>
                            <div style="padding-top: 15px;">
                                <button class="bg-mainb fg-white size2" id="addnew"><i class="icon-plus"></i>&nbsp;新增病历</button>
                            </div>
                        </td>
                        <td style="vertical-align: top;" class="">
                            <div class="fg-gray"><b>基本信息</b></div>
                            <div>
                                <table style="width: 100%; margin: 0; table-layout: fixed;" class="table bordered">
                                    <tr>
                                        <td>
                                            <div class="fg-main small">姓名</div>
                                            <div class="fg-gray" style="padding-top: 5px;">张三</div>
                                        </td>
                                        <td>
                                            <div class="fg-main small">性别</div>
                                            <div class="fg-gray" style="padding-top: 5px;">男</div>
                                        </td>
                                        <td>
                                            <div class="fg-main small">年龄</div>
                                            <div class="fg-gray" style="padding-top: 5px;">66岁</div>
                                        </td>
                                        <td>
                                            <div class="fg-main small">国籍</div>
                                            <div class="fg-gray" style="padding-top: 5px;">中国</div>
                                        </td>
                                        <td>
                                            <div class="fg-main small">婚姻状态</div>
                                            <div class="fg-gray" style="padding-top: 5px;">已婚</div>
                                        </td>
                                        <td rowspan="4" class="size3">
                                            <div class="fg-main small">照片</div>
                                            <div class="fg-gray" style="padding-top: 5px;">
                                                <img src="images/patient.jpg" style="width: 100%;" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="fg-main small">身高</div>
                                            <div class="fg-gray" style="padding-top: 5px;">172cm</div>
                                        </td>
                                        <td>
                                            <div class="fg-main small">体重</div>
                                            <div class="fg-gray" style="padding-top: 5px;">63kg</div>
                                        </td>
                                        <td colspan="3">
                                            <div class="fg-main small">身份证号</div>
                                            <div class="fg-gray" style="padding-top: 5px;">123456196012010001</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="fg-main small">联系电话</div>
                                            <div class="fg-gray" style="padding-top: 5px;">13912345678</div>
                                        </td>
                                        <td colspan="3">
                                            <div class="fg-main small">联系地址</div>
                                            <div class="fg-gray" style="padding-top: 5px;">上海市杨浦区提篮桥路22号1单元502室</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <div class="fg-main small">过敏</div>
                                            <div style="padding-top: 5px;">
                                                <span class="label fg-white bg-red">青霉素</span>
                                                <span class="label fg-white bg-red">牛奶</span>
                                                <span class="label fg-white bg-red">花粉</span>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="fg-gray" style="padding-top: 30px;">
                                <b>医学影像</b>
                                <div class="place-right fg-main">2015/04/22</div>
                            </div>
                            <div>
                                <table style="width: 100%; margin: 0;" class="table bordered">
                                    <tr>
                                        <td>诊断帕金森综合征首先要存在运动减少，即随意运动在始动时缓慢，重复性动作的运动速度及幅度逐渐降低；同时至少具有以下一个症状：A 肌肉僵直；B.静止性震颤（4－6Hz）；C.直立不稳（非原发性视觉，前庭功能，小脑及本体感觉功能障碍造成）。诊断原发性帕金森病需先除外可能造成类似症状的各种继发性病因；诊断依赖于临床特点、病程和治疗反应，即具有帕金森病临床三联征（震颤、运动迟缓和僵直）中的至少两项以及对于多巴胺能治疗效果显著。在疾病早期即出现突出的语言和步态障碍，姿势不稳，中轴肌张力明显高于四肢，无静止性震颤，突出的自主神经功能障碍，对左旋多巴无反应或疗效不持续均提示帕金森叠加综合征的可能。</td>
                                        <td class="size3">
                                            <img src="images/head.jpg" style="width: 100%;" /></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="fg-gray" style="padding-top: 30px;">
                                <b>检验化验</b>
                                <div class="place-right fg-main">2015/04/15</div>
                            </div>
                            <div id="btnlabtest" style="cursor: pointer;">
                                <table style="width: 100%; margin: 0;" class="table bordered">
                                    <tr>
                                        <td>血红蛋白（HGB）108 g/L，咯为低于正常，可以肯定为“贫血，但仅属轻度（HGB 91~110g/L，属于轻度）。平均红细胞体积（MCV）为 78.8 fl、红细胞平均血红蛋白含量（MCH）为24.9 pg、红细胞平均血红蛋白浓度（MCHC）为317 g/L，以上三项均低于正常，说明是一种“小细胞低色素性贫血”。“小细胞低色素贫血”最常见于“缺铁性贫血”，“缺铁性贫血”最常见的原因是由慢性失血引起，诸如月经过多、痔疮慢性出血、消化道慢性失血等，其次见于铁摄入不足或肠道吸收障碍等，老年人还要警惕消化道肿瘤。</td>
                                        <td class="size3">
                                            <img src="images/化验单.jpg" style="width: 100%;" /></td>
                                    </tr>
                                </table>
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
