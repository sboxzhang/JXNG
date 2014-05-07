Evlon = {};
Evlon.MaskDiv = function() {
    var div = window.document.createElement("DIV");
    div.style.position = "absolute";
    div.style.top = "0px";
    div.style.left = "0px";
    div.style.width = '100%'; //document.body.scrollWidth + 'px';
    div.style.height = '100%'; //document.body.scrollHeight + 'px';
    div.style.backgroundColor = "white";
    div.style.zIndex = 999;
    div.style.filter = "Alpha(style=0,opacity=50)";
    div.style.opacity = "0.50";
    this.divMask = div;

    div = window.document.createElement("DIV");
    div.style.position = "absolute";
    div.style.top = "0px";
    div.style.left = "0px";
    div.style.width = '100%'; //document.body.scrollWidth + 'px';
    div.style.height = '100%'; //document.body.scrollHeight + 'px';
    div.style.zIndex = 1000;

    this.divTooltip = div;

    this.show = function() {
        //创建半透明DIV
        window.__maskDiv__ = document.body.insertAdjacentElement('afterBegin', this.divMask);

        //创建提示DIV
        window.__maskDivText__ = document.body.insertAdjacentElement('afterBegin', this.divTooltip);
        window.__maskDivText__.innerHTML = "<table style='border-collapse:collapse;border-width:0px;width:100%;height:100%;'0><tr height='38%'><td></td></tr><tr><td align='center' valign='top'>" +
                    "<table style='border-collapse:collapse;border:solid 1px #edf5ff;'><tr><td align='right'></td>" +
                    "<td align='center'><span style = 'filter:alpha(opacity=100);font-size:20px'>提交中<br/>请稍候........</span></td></tr></table>" +
                    "</td></tr></table>";

    }

    this.hide = function() {
        if (window.__maskDiv__ != null) {
            document.body.removeChild(window.__maskDiv__);
            window.__maskDiv__ = null;
        }
        if (window.__maskDivText__ != null) {
            window.__maskDivText__.innerHTML = '';
            document.body.removeChild(window.__maskDivText__);
            window.__maskDivText__ = null;
        }
    }
}

Evlon.MaskDiv.Instance = new Evlon.MaskDiv();

window.showModalDialogMask = function(sURL, vArguments, sFeatures) {
    var sign = window.showModalDialog(sURL, vArguments, sFeatures);
    if (sign != "" && sign != null) {
        //创建半透明DIV
        Evlon.MaskDiv.Instance.show();

    }

    return null;
    //return sign;
}