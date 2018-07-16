function toThousands(num, digit) {
    if (num == undefined || num == "" || num == null)
        return "";
    var negative = "";
    var num = (num || 0).toString(), result = '';
    var point = "";
    digit = digit == undefined ? 2 : digit;

    if (num < 0) {
        negative = "-";
        num = num.substring(1);
    }
    if (num.indexOf('.') != -1) {
        point = num.substring(num.indexOf('.') + 1);
        num = num.substring(0, num.indexOf('.'));
    }
    while (num.length > 3) {
        result = ',' + num.slice(-3) + result;
        num = num.slice(0, num.length - 3);
    }
    if (num) { result = num + result; }
    if (point != "") {
        var tmp = parseFloat("0." + point).toFixed(digit);
        result += "." + tmp.substring(2);
    }
    else {
        var tmp2 = "0000000000000000000000000".substring(0, digit);
        result += "." + tmp2;
    }
    if (negative != "") { result = "-" + result; }
    return result;
}

function DateAdd(interval, number, date2) {
    if (date2 == "")
        return "";
    var date = new Date(date2.getFullYear(), date2.getMonth(), date2.getDate(), date2.getHours(), date2.getMinutes(), date2.getSeconds(), date2.getMilliseconds());//为了不改变date2的值
    switch (interval.toLowerCase()) {
        case "y": return new Date(date.setFullYear(date.getFullYear() + number));
        case "m": return new Date(date.setMonth(date.getMonth() + number));
        case "d": return new Date(date.setDate(date.getDate() + number));
        case "w": return new Date(date.setDate(date.getDate() + 7 * number));
        case "h": return new Date(date.setHours(date.getHours() + number));
        case "n": return new Date(date.setMinutes(date.getMinutes() + number));
        case "s": return new Date(date.setSeconds(date.getSeconds() + number));
        case "l": return new Date(date.setMilliseconds(date.getMilliseconds() + number));
    }
}

function DateDiff(interval, date1, date2) {
    if (date1 == "" || date2 == "")
        return "";
    var long = date2.getTime() - date1.getTime(); //相差毫秒
    switch (interval.toLowerCase()) {
        case "y": return parseInt(date2.getFullYear() - date1.getFullYear());
        case "m": return parseInt((date2.getFullYear() - date1.getFullYear()) * 12 + (date2.getMonth() - date1.getMonth()));
        case "d": return parseInt(long / 1000 / 60 / 60 / 24);
        case "w": return parseInt(long / 1000 / 60 / 60 / 24 / 7);
        case "h": return parseInt(long / 1000 / 60 / 60);
        case "n": return parseInt(long / 1000 / 60);
        case "s": return parseInt(long / 1000);
        case "l": return parseInt(long);
    }
}

function changeValidNumber(objValue, isNegative, point) {
    var tmpVal = objValue;
    //得到第一个字符是否为负号
    var t = tmpVal.charAt(0);
    //先把非数字的都替换掉，除了数字和. 
    tmpVal = tmpVal.replace(/[^\d\.]/g, '');
    //必须保证第一个为数字而不是. 
    tmpVal = tmpVal.replace(/^\./g, '');
    //保证只有出现一个.而没有多个. 
    tmpVal = tmpVal.replace(/\.{2,}/g, '.');
    //保证.只出现一次，而不能出现两次以上 
    tmpVal = tmpVal.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
    // 开头多余2个0，只保留一个 000.5 => 0.5
    tmpVal = tmpVal.replace(/^(0{2,})/, "0");

    if (point != undefined && !isNaN(point) && point > 0) {
        var ind = tmpVal.indexOf(".");
        if (ind != -1) {
            point = parseInt(point);
            tmpVal = tmpVal.substring(0, ind + 1 + point);
        }
    }

    //如果第一位是负号，则允许添加
    if (t == '-' && isNegative)
        tmpVal = '-' + tmpVal;
    return tmpVal;
}
$(function () {
    $(document).on("keyup blur", ".onlyPointNum", function (e) {
        var negative = $(this).attr("negative") == undefined ? true : $(this).attr("negative") == "1";
        var point = $(this).attr("point") == undefined ? "2" : $(this).attr("point");
        //console.log(negative + "  " + point)
        $(this).val(changeValidNumber($(this).val(), negative, point));
    });
});

// 日期控件 不能选时间的
jQuery(function ($) {
    $.datepicker.regional['zh-CN'] = {
        closeText: '关闭',
        prevText: '&#x3c;上月',
        nextText: '下月&#x3e;',
        currentText: '今天',
        monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
            '七月', '八月', '九月', '十月', '十一月', '十二月'],
        monthNamesShort: ['一', '二', '三', '四', '五', '六',
            '七', '八', '九', '十', '十一', '十二'],
        dayNames: ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
        dayNamesShort: ['周日', '周一', '周二', '周三', '周四', '周五', '周六'],
        dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
        weekHeader: '周',
        dateFormat: 'yy-mm-dd H:i',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: true,
        yearSuffix: '年'
    };
    $.datepicker.setDefaults($.datepicker.regional['zh-CN']);
});

// 日期时间控件 可以带时间
// modal.initDate("startdate","enddate");
var modal = (function () {
    var initDate = function (startDateTimeId, endDateTimeId) {
        var startDate;
        var endDate;
        startDateTimeId = "#" + startDateTimeId;
        endDateTimeId = "#" + endDateTimeId;
        $(startDateTimeId).datetimepicker({
            format: 'Y-m-d H:m',
            minDate: 0,
            onChangeDateTime: function (dp, $input) {
                startDate = $(startDateTimeId).val();
            },
            onClose: function (current_time, $input) {
                if (startDate > endDate) {
                    $(startDateTimeId).val(endDate);
                    startDate = endDate;
                }
            }
        });
        $(endDateTimeId).datetimepicker({
            format: 'Y-m-d H:m',
            onClose: function (current_time, $input) {
                endDate = $(endDateTimeId).val();
                if (startDate > endDate) {
                    $(endDateTimeId).val(startDate);
                    endDate = startDate;
                }
            }
        });
    };
    return {
        initDate: initDate
    };
})();