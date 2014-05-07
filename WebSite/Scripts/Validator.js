//
//功能:表单验证插件
//
(function($) {
    $.extend({
		//验证方法
		Validator : function(validXmlPath,formName){
			var flag = 0;
			var warning = "";
			var forms = "";
			var validXml = $.getXML(validXmlPath);
			if(formName != void 0){
				forms = $("form[name='"+formName+"']",validXml);
			}else{
				forms = $("form",validXml);
			}
			$(forms).each(function(){
				var form = $(this);
				var warnType = form.attr("warnType");
				if(warnType == "" || warnType == null){warnType="follow"};
				form.find("item").each(function() {
	            	var item = $(this);
	            	var tag = item.attr("tag");
					var fieldName = item.attr("fieldName");
					if(fieldName.isEmpty){warnType="follow"};
	            	var type = item.attr("type");
	            	var require = item.attr("require");
					item.children("rule").each(function(){
						var rule = $(this);
						var name = rule.attr("name");
						var mini = 0;
						var maxi = 0;
						var warn = rule.attr("warn");
						if (warn == undefined ) { warn = $.mssg[name] }
						var to = rule.attr("to");
						var toValue = rule.attr("toValue");
						var toObject = rule.attr("toObject");
						var operator = rule.attr("operator");
						var regexp = rule.attr("regexp");
						if(rule.attr("min")){
							mini = parseInt(rule.attr("min"));
						}
						if(rule.attr("max")){
							maxi = parseInt(rule.attr("max"));
						}
						if(!mini.isEmpty && !maxi.isEmpty){
							warn = warn.format(mini, maxi);
			            }
			            /*****/
						var object = $(":" + type + "[id$='" + tag + "']");
						/*****/
						object.attr({"dataType":name,"min":mini,"max":maxi,"require":require,"regexp":regexp,"to":to,"toValue":toValue,"operator":operator,"toObject":toObject});
						if(warnType == "follow"){
							object.next().filter("span").remove();
							//object.removeClass().addClass("formStyle");
							if(!$.isValidator(object)){
								if(type=="checkbox" || type=="radio"){
									$(object[object.length-1]).parent().append("<span class='validInfo'>"+warn+"</span>");
								}else{
									object.after("<span class='validInfo'>"+warn+"</span>");
								}
								//object.removeClass().addClass("formValid");
								flag++;
								return false;
							}
						}else if(warnType == "dialog"){
							object.removeClass().addClass("formStyle");
							if(!$.isValidator(object)){
								warning += fieldName + "：" + warn + "\n";
								//object.removeClass().addClass("formValid");
								flag++;
								return false;
							}
						}
					});
				});
			});
			if (warning != "") {
			    var msg = "提交数据时出现以下异常：\n";
			    alert(msg + warning);
			}
			if(flag>0)
				return false;
			else
				return true;
		},
		//获得验证规则xml文档
		getXML : function(validXmlPath){
			var returnXml = "";
           	$.ajax({
                type: "GET",
                url: validXmlPath,
                async: false,
                ifModified: true,
                cache:false,
                dataType: "xml", //大小写敏感
                success: function(validXml) {
                    returnXml = validXml;
                }
            });
            return returnXml;
		},
		//按索引填充字符串
		format : String.prototype.format = function(){
			var args = arguments;
            return this.replace(/\{(\d+)\}/g,
                function(m, i) {
                    return args[i];
                });
		},
		//关系表达式解释
		rela : {
			NotEqual:"不等于",
			GreaterThan:"大于",
			GreaterThanEqual:"大于等于",
			LessThan:"小于",
			LessThanEqual:"小于等于",
			Equal:"等于"
		},
        //验证单个控件
        isValidator : function(object){
            var dataType = $(object).attr("dataType");
            var _require = $(object).attr("require");
	    	if(_require == undefined){_require = "true"}
            var msg = true;
            if(dataType != undefined)
            {
                if(dataType != "Group" && _require != "false" && object.val().length <= 0)
                    return false;//没有内容且不是组验证	

                switch(dataType)
                {
                    case "Require"://必填
                        msg = object.val().length > 0;
                        break;
                    case "Chinese"://中文
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isChinese(object);}
                        }
                        else{msg = $.isChinese(object);}
                        break;
                    case "English"://英文
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isEnglish(object);}
                        }
                        else{msg = $.isEnglish(object);}
                        break;
                    case "Number"://数字（正整数）
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isNumber(object);}
                        }
                        else{msg = $.isNumber(object);}
                        break;
                    case "Integer"://整数（正整数和负整数）
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isInteger(object);}
                        }
                        else{msg = $.isInteger(object);}
                        break;
                    case "Double"://实数（小数）
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isDouble(object);}
                        }
                        else{msg = $.isDouble(object);}
                        break;
                    case "Currency"://货币格式
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isCurrency(object);}
                        }
                        else{msg = $.isCurrency(object);}
                        break;
                    case "QQ"://QQ
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isQQ(object);}
                        }
                        else{msg = $.isQQ(object);}
                        break;
                    case "Email"://邮箱地址
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isEmail(object);}
                        }
                        else{msg = $.isEmail(object);}
                        break;
                    case "Url"://Url地址
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isURL(object);}
                        }
                        else{msg = $.isURL(object);}
                        break;
                    case "IP"://IP地址
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isIpAddress(object);}
                        }
                        else{msg = $.isIpAddress(object);}
                        break;
                    case "Zip"://邮编
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isPostalCode(object);}
                        }
                        else{msg = $.isPostalCode(object);}
                        break;
                    case "IdCard"://身份证
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isIDCard(object);}
                        }
                        else{msg = $.isIDCard(object);}
                        break;
                    case "Phone"://电话号话
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isPhoneCall(object);}
                        }
                        else{msg = $.isPhoneCall(object);}
                        break;
                    case "Mobile"://手机号码
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isMobile(object);}
                        }
                        else{msg = $.isMobile(object);}
                        break;
                    case "UserName"://用户名，长度在6-50之间的，只包含字母，数字和下划线
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isValidUserName(object);}
                        }
                        else{msg = $.isValidUserName(object);}
                        break;
                    case "PassWord"://密码，长度在6-20之间
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isValidPass(object);}
                        }
                        else{msg = $.isValidPass(object);}
                        break;
                   case "Repeat"://重复输入
                    	if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isRepeat(object);}
                        }
                        else{msg = $.isRepeat(object);}
                        break;
                   case "Compare_Value"://关系比较,与值比较
                   		if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isCompareValue(object);}
                        }
                        else{msg = $.isCompareValue(object);}
                        break;
					case "Compare_object"://关系比较，与对象比较
                   		if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isCompareObject(object);}
                        }
                        else{msg = $.isCompareObject(object);}
                        break;
                   case "Range"://输入范围
                   		if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isRange(object);}
                        }
                        else{msg = $.isRange(object);}
                        break;
                   case "Limit"://限制输入长度
                   		if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isLimit(object);}
                        }
                        else{msg = $.isLimit(object);}
                        break;
                   case "LimitB"://限制输入的字节长度
                        if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isLimitB(object);}
                        }
                        else{msg = $.isLimitB(object);}
                        break;
                   case "Group_more"://验证多选按钮组
                   		if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isGroup(object);}
                        }
                        else{msg = $.isGroup(object);}
                        break;
				   case "Group_only"://验证单选按钮组
                   		if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isGroup(object);}
                        }
                        else{msg = $.isGroup(object);}
                        break;
				   case "Custom"://客户自定义验证方式
						if(_require == "false")
                        {
                            if(object.val().length <= 0){msg = true;}
                            else{msg = $.isCustom(object);}
                        }
                        else{msg = $.isCustom(object);}
                        break;
                }
            }
              return msg;
        },
        getWidth : function(object) {
            return object.offsetWidth;
        },
        getLeft : function(object) {
            var go = object;
            var oParent,oLeft = go.offsetLeft;
            while(go.offsetParent!=null) {
                oParent = go.offsetParent;
                oLeft += oParent.offsetLeft;
                go = oParent;
            }
            return oLeft;
        },
        getTop : function(object) {
            var go = object;
            var oParent,oTop = go.offsetTop;
            while(go.offsetParent!=null) {
                oParent = go.offsetParent;
                oTop += oParent.offsetTop;
                go = oParent;
            }
            return oTop + 22;
        },
        //去除左边的空格
        ltrim: function(_str)
        {
            return _str.replace(/(^\s*)/g, "");
        },
        //去除右边的空格
        rtrim: function(_str)
        {
            return _str.replace(/(\s*$)/g, "");
        },
        //因为jquery本身已经有了trim方法,故这里不再重新定义
        //计算字符串长度，一个双字节字符长度计2，ASCII字符计1
        lengthw: function(_str)
        {
           return  _str.replace(/[^\x00-\xff]/g,"rr").length; 
        },
        //转换为大写
        toUpper: function(_str)
        {
            return _str.toUpperCase();
        },
        //转换为小写
        toLower: function(_str)
        {
            return _str.toLowerCase();
        },
        //15位身份证转换为18位,如果参数字符串中有非数字字符,则返回"#"表示参数不正确
        idCardUpdate: function(_str)
        { 
            var idCard18;
            var regIDCard15 = /^(\d){15}$/;
            if(regIDCard15.test(_str))
            {
                var nTemp = 0;
                var ArrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);
                var ArrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2');
                _str = _str.substr(0,6) + '1' + '9' + _str.substr(6,_str.length-6);
                for(var i=0;i<_str.length;i++)
                {
                    nTemp += parseInt(_str.substr(i,1)) * ArrInt[i];
                }
                _str += ArrCh[nTemp % 11];
                idCard18 = _str;        
            }
            else
            {
                idCard18 = "#";
            }
            return idCard18;
        },
        //是否为空字符串
        isEmpty: function(_str)
        {
            if (_str == undefined) {
				return true;
			}else if(_str == null){
				return true;
			}else{
				var tmp_str = jQuery.trim(_str);
            	return tmp_str.length == 0; 
			}
        },
        //是否中文
        isChinese: function(object)
        {
            return /^[\u4E00-\u9FA5]{0,25}$/.test(object.val());
        },
        //是否英文
        isEnglish: function(object)
        {
            return /^[A-Za-z]+$/.test(object.val());
        },
        //数字（正整数）
        isNumber : function(object)
        {
            return /^\d+$/.test(object.val());
        },
        //整数（正整数和负整数）
        isInteger : function(object)
        {
            return /^[-\+]?\d+$/.test(object.val());
        },
        //实数（小数）
        isDouble : function(object)
        {
            return /^[-\+]?\d+(\.\d+)?$/.test(object.val());
        },
        //QQ
        isQQ : function(object)
        {
            return /^[1-9]\d{3,8}$/.test(object.val());
        },
        //是否为合法电子邮件地址
        isEmail: function(object)
        {
           return /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/.test(object.val()); 
        },
        //是否合法url地址
        isURL: function(object)
        {
            var regTextUrl = /^(file|http|https|ftp|mms|telnet|news|wais|mailto):\/\/(.+)$/;
            return regTextUrl.test(object.val());
        },
        //是否为合法ip地址
        isIpAddress: function(object)
        {
            reVal = /^(\d{1}|\d{2}|[0-1]\d{2}|2[0-4]\d|25[0-5])\.(\d{1}|\d{2}|[0-1]\d{2}|2[0-4]\d|25[0-5])\.(\d{1}|\d{2}|[0-1]\d{2}|2[0-4]\d|25[0-5])\.(\d{1}|\d{2}|[0-1]\d{2}|2[0-4]\d|25[0-5])$/;
            return (reVal.test (object.val()));    
        },
        //是否邮政编码(中国)
        isPostalCode: function(object)
        {
            var regTextPost = /^(\d){6}$/;
            return regTextPost.test(object.val());
        },
        //是否是有效中国身份证
        isIDCard: function(object)
        {
            var iSum=0;
            var info="";
            var sId;
            var aCity={11:"北京",12:"天津",13:"河北",14:"山西",15:"内蒙古",21:"辽宁",22:"吉林",23:"黑龙江",31:"上海",32:"江苏",33:"浙江",34:"安徽",35:"福建",36:"江西",37:"山东",41:"河南",42:"湖北",43:"湖南",44:"广东",45:"广西",46:"海南",50:"重庆",51:"四川",52:"贵州",53:"云南",54:"西藏",61:"陕西",62:"甘肃",63:"青海",64:"宁夏",65:"新疆",71:"台湾",81:"香港",82:"澳门",91:"国外"};
            //如果输入的为15位数字,则先转换为18位身份证号
            if(object.val().length == 15)    
                sId = jQuery.idCardUpdate(object.val());    
            else
                sId = object.val();
            
            if(!/^\d{17}(\d|x)$/i.test(sId))
            {
                return false;
            }
            sId=sId.replace(/x$/i,"a");
            //非法地区
            if(aCity[parseInt(sId.substr(0,2))]==null)
            {
                return false;
            }
            var sBirthday=sId.substr(6,4)+"-"+Number(sId.substr(10,2))+"-"+Number(sId.substr(12,2));
            var d=new Date(sBirthday.replace(/-/g,"/"))    
            //非法生日
            if(sBirthday!=(d.getFullYear()+"-"+ (d.getMonth()+1) + "-" + d.getDate()))
            {
                return false;
            }
            for(var i = 17;i>=0;i--) 
            {
                iSum += (Math.pow(2,i) % 11) * parseInt(sId.charAt(17 - i),11);
            }
            if(iSum%11!=1)
            {
                return false;
            }
            return true;    
        },
        //是否有效的电话号码(中国)
        isPhoneCall: function(object)
        {
            return /(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^[0-9]{3,4}[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$)/.test(object.val());
        },
        //是否有效的手机号码(最新的手机号码段可以是15开头的
        isMobile: function(object)
        {
            return /^0{0,1}1(3|5)[0-9]{9}$/.test(object.val());
        },
        //是否有效用户名,长度在6-50之间的，只包含字母，数字和下划线
        isValidUserName: function(object)
        {	
			var mini = $(object).attr("min");
			var maxi = $(object).attr("max");
			var regexp = eval("/^\\w{"+mini+","+maxi+"}$/");
            //return /^\w{6,20}$/.test(object.val());
			return  regexp.test(object.val());
        },
        //货币格式（小数及有正负）
        isCurrency: function(object)
        {
            return /^[-\+]?\d+(\.\d+)?$/.test(object.val());
        },
        //是否有效密码,长度在6-20之间
        isValidPass: function(object)
        {
			var mini = $(object).attr("min");
			var maxi = $(object).attr("max");
			var regexp = eval("/^\\w{"+mini+","+maxi+"}$/");
			//return /^\w{6,20}$/.test(object.val());
			return  regexp.test(object.val());
        },
        //重复输入
        isRepeat: function(object)
        {
            var to_obj = document.getElementsByName($(object).attr('to'))[0];
            if(to_obj == undefined){to_obj = document.getElementsById($(object).attr('to'))[0];}
            if(to_obj == undefined){return true;}
            else
            {
                if(to_obj == undefined){return true;}
                else
                {
                    if(to_obj.value == object.val()){return true;}
                    else{return false;}
                }  
            }
        },
        //关系比较
        isCompareValue : function(object)
        {
             var operator = $(object).attr('operator');
             if(operator == undefined){return true;}
             else{return $.compare(object.val(),operator,$(object).attr('toValue'));}
        },
		isCompareObject : function(object)
        {		
			 var to_obj = document.getElementsByName($(object).attr('toObject'))[0];
			 if(to_obj == undefined){to_obj = document.getElementsById($(object).attr('toObject'))[0];}
             var operator = $(object).attr('operator');
             if(operator == undefined){return true;}
             else{return $.compare(object.val(),operator,$(to_obj).val());}
        },
        //输入范围
        isRange : function(object)
        {
            return $(object).attr('min') <= (object.val()|0) && (object.val()|0) <= $(object).attr('max');
        },
        //限制输入长度
        isLimit : function(object)
        {
            var min = $(object).attr('min');
            var max = $(object).attr('max');
            var len = object.val().length;
            min = min || 0;
            max = max || Number.MAX_VALUE;
            return min <= len && len <= max;
        },
        //限制输入的字节长度
        isLimitB : function(object)
        {
            var min = $(object).attr('min');
            var max = $(object).attr('max');
            var len = $.lengthw(object.val());
            min = min || 0;
            max = max || Number.MAX_VALUE;
            return min <= len && len <= max;
        },
        //自定义正则表达式验证
        isCustom : function(object)
        {
			var regexp = eval($(object).attr('regexp'));
			return regexp.test(object.val());
            //return new RegExp($(object).attr('regexp'),"g").test(object.val());
        },
        //验证单/多选按钮组
        isGroup : function(object)
        {
            var min = $(object).attr('min');
            var max = $(object).attr('max');
            var hasChecked = 0;
            min = min || 1;
            max = max || object.length;
            for(var i=object.length-1;i>=0;i--)
            if(object[i].checked) hasChecked++;
                return min <= hasChecked && hasChecked <= max; 
        },
        
        //比较op1和op2的值，operator为比较类型
        compare : function(op1,operator,op2)
        {
				
            switch (operator)
            {
                case "NotEqual":
                    return (op1 != op2);
                case "GreaterThan":
                    return (op1 > op2);
                case "GreaterThanEqual":
                    return (op1 >= op2);
                case "LessThan":
                    return (op1 < op2);
                case "LessThanEqual":
                    return (op1 <= op2);
                case "Equal":
                    return (op1 == op2);
           }           
        },
		//=================================
		//验证提示信息
		mssg: {
			Require:"必填",
			Chinese:"必须是中文",
			English:"必须是英文",
			Number:"必须是数字",
			Integer:"必须是整数",
			Double:"必须是实数(小数)",
			Currency:"必须是货币格式",
			QQ:"QQ格式不正确",
			Email:"邮箱格式不正确",
			Url:"Url地址格式不正确",
			IP:"IP地址格式不正确",
			Zip:"邮编格式不正确",
			IdCard:"身份证格式不正确",
			Phone:"电话格式不正确",
			Mobile:"手机格式不正确",
			UserName:"长度在{0}-{1}之间的,只包含字母,数字和下划线",
			PassWord:"密码长度在{0}-{1}之间",
			Repeat:"请输入相同的值",
			Compare_Value:"输入不符合规定",
			Compare_object:"输入不符合逻辑",
			Range:"范围必须在{0}-{1}之间",
			Limit:"字符长度必须在{0}-{1}之间",
			LimitB:"字节长度必须在{0}-{1}之间",
			Group_more:"选择{0}-{1}项",
			Group_only:"必须选择1项",
			Custom:"输入不符合规则"
		}
    }); 
})(jQuery)