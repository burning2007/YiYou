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
                <button onclick="window.location='diagnosisdetail1.aspx';return false;">病历</button>
                <button onclick="window.location='diagnosisdetail2.aspx';return false;">会诊结果</button>
                <button onclick="window.location='diagnosisdetail3.aspx';return false;"  class="fg-white bg-main">合同</button>
            </div>
            <div class="border padding15">
                <div style="box-shadow: #ccc 3px 3px 6px;" class="border padding20 bg-white">
                    <div style="height: 480px; overflow-y: scroll;">
                        本终端用户许可协议（“EULA”）构成被许可人（“您”）与Lawspirit技术爱尔兰有限公司（“LAWSPIRIT”）之间关于LAWSPIRIT 软件产品、某些第三方软件产品*及相关媒体、材料与文件（“产品”）的法律协议。通过安装产品或将其保留超过十（10）日，您同意受本EULA约束。假如您不同意这些条款与条件，您不得使用该产品，并且您必须在收到后十（10）个日历日内归还尚未使用的产品以获得任何已付产品使用费的足额退款。有关退货事宜，请与您的产品供给商或售货商接洽。假如您直接从LAWSPIRIT获得产品，请参阅LAWSPIRIT网站“www.lawspirit.com”或与当地 LAWSPIRIT销售办事处接洽有关退货事宜。假如LAWSPIRIT向您提供本EULA项下提供的任何产品的更新，您同意在合理的时间内销毁先前版本产品，并且仅使用产品的更新版本。 
   <br />
                        签订本EULA的人声明并保证，他被授权代表其雇主作为被许可人签订一项具有约束力的协议。
                        <br />

                        *本EULA适用于由Lawspirit或其转售商供给的、但其包装中未附另外终端用户许可协议的Lawspirit软件产品及任何第三方软件程序（如EMC软件产品）（Lawspirit软件产品及所述第三方软件程序在本协议中合称“产品”）。
                        <br />

                        1. 软件许可 除本节1所规定的有限使用权外，Lawspirit及其许可人（“许可 人”）应拥有对产品及其任何复制品的所有权利、权属及权益。产品的任何更新、增补、校正或故障的修补将受本EULA条款的管辖。
                        <br />

                        1.1 您承认根据本EULA协议，您只拥有非排他性的及有限的权利，在由 Lawspirit或其授权的经销商或转售商出售给您的单一ftServer系统及适用的外围设备（包括但不限于存储设备）（合称“系统”）上使用产品的目标代码版本。您可以为存档或备份的目的以目标代码的形式制作产品的一份复制品。您不得除掉或遮掩产品所包含的任何专有权利标记、限制权利图注（如下文第 1.4节所定义）或其他标记（统称“标记”）。您必须在产品的所有复制品中包含所有标记。您不得对产品进行反向工程、反编译或反汇编，或试图获得对产品原码的访问权，但适用法律明文准许除外，并且只能在适用法律明文准许的范围之内，并且假如适用法律准许约定放弃该权利，您谨此放弃这样做的权利。
                        <br />

                        1.2 假如您未违反本EULA项下您的任何责任或义务，您可以永久转让本 EULA项下的产品及所有权利，仅作为一次性销售或转让系统（产品安装其上）的一部分，并且只能转让给同意受本EULA所规定的所有条款与条件约束的受让人。进行该转让时，您同意您将（1）转让系统的所有产品，（2）不保留产品的任何复制品，及（3）向您的受让人转让本EULA项下所有权利并让与本 EULA项下的所有义务。未经 Lawspirit事先书面同意，您不得以其他方式转让或让与产品或本EULA 和/或本协议项下的任何权利或义务。
                        <br />

                        1.3 假如您未支付任何有关的许可费或其他收费，Lawspirit在不损害任何其他权利的情况下，有权终止本EULA并拒绝装运任何产品。假如您违反本 EULA项下您的任何实质义务，您在本EULA项下的权利将自动终止。本EULA因任何原因终止之后，您将在该终止后立即向Lawspirit或其指定人归还，或（假如Lawspirit指示您这样做的话）销毁产品的所有复制品。<br />

                        1.4 产品包括完全由私人经费开发、通常为非政府目的使用并许可给公众的商用计算机软件。提供给美国政府的所有软件均按FAR， 48 CFR 52.227-14（1987年6月）或DFAR 48 CFR 252.227-7013（1988年10 月）（如适用）所规定的、在附有“有限权利”的情况下提供。未明确授予的一切权利均为保留权利。<br />

                        2. 保密您承认产品包含Lawspirit及其许可人的商业秘密及专有信息与资料（“保密信息”）。您同意不向任何第三方披露该保密信息。在不限制上述条款的条件下，您同意起码将以对待您自己同等重要的保密信息同样的谨慎对待保密信息，但在任何情况下您均将以合理的谨慎对待该保密信息。虽有上述规定，但对下述任何保密信息您均无任何责任：（1）当保密信息披露时已为公众所知或并非由于您的过错已进入公众领域，（2）当披露时，您是在未有限制的情况下知悉保密信息，（3）在未使用或未参考任何保密信息的情况下，由您独立开发的保密信息，或（4）依据法院、行政机构或其他政府部门的有效命令或要求披露的保密信息，但条件是您将及时向 Lawspirit提供该要求或命令的通知，以使Lawspirit及其许可人能寻求保护令或以其他方式防止或限制该披露。
                        <br />

                        3. 侵权赔偿
                        <br />

                        3.1 Lawspirit将抗辩对您提起的、指控产品侵犯了您所在司法管辖地的某项专利或版权的任何索赔，并将赔偿您在最终裁定中所受的所有损害和费用，但条件是及时以书面形式将索赔通知Lawspirit，并且在该索赔的抗辩和/或和解中给予Lawspirit充分授权、信息及协助，该抗辩和/或和解将完全在 Lawspirit的控制之下。假如发生索赔，或按Lawspirit意见可能发生索赔，您同意答应Lawspirit（完全由其自主决定并承担费用），（1）为您获得继续使用产品的权利，或（2）更换或修改产品以使其不侵权。假如完全按Lawspirit自主判定，上述任何一种办法均不具商业实用性， Lawspirit可终止本许可，去除产品并在考虑普遍接受的会计惯例的情况下，按产品使用期限平均每年数额折旧或摊提后向您退还产品使用费。<br />

                        3.2 对于基于或由于下述各项而发生的任何索赔，无论Lawspirit、其联属公司、子公司或许可人均无任何责任：（1）产品与（a）任何微软或其他第三方软件程序组合、操作或使用，（b）与并非由Lawspirit供给的任何设备、装置或软件组合、操作或使用，或（2）任何产品的更改或修改。在法律准许的最大限度内，本节阐述了Lawspirit、其联属公司、子公司及许可人的全部责任，以及就任何侵权索赔，您能获得的唯一补救。
                        <br />

                        4. 有限保证
                        <br />

                        Lawspirit保证在收到日期后三十（30）日内包含各产品的媒体在材料和工艺方面均无缺陷。对于该缺陷产品媒体，Lawspirit的唯一责任以及您的全部补救是免费更换缺陷媒体。您可从您的产品供给商或售货商或Lawspirit网站“www.lawspirit.com”获得有关报告保证缺陷的信息。
                        <br />

                        information for reporting warranty defects
                        <br />

                        4.2 Lawspirit不声明或保证产品会无中断或无差错地运作。此项保证不适用于因下述原因造成的缺陷：（1）未经Lawspirit事先书面批准对产品作出的改动或修改，（2）事故、疏忽、误用或滥用，或（3）暴露在 Lawspirit提供的环境、电源及操作规格范围以外的条件之下。 
                    </div>
                </div>
                <div style="padding-top: 20px;">
                    <button class="bg-main fg-white size2"><i class="icon-pencil"></i>&nbsp;编辑</button>
                    <%--<button>取消</button>--%>
                    <div class="place-right">
                        <button>打印</button>
                        <button>下载</button>
                    </div>
                </div>
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
