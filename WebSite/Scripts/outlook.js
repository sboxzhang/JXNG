//菜单上按钮操作
var bMenuState = true;
function setMenuHide()
{
    //打开或隐藏菜单
    if (bMenuState) {
        bMenuState = false;
        if (getBrowser()!=6) {
            $("#navigation").css({ width: "0%"});
            $("#content").css({ width: "98%"}); 
        }
        else
        {
            $("#navigation").css({ width: "0px"});
            var w = ($("#content").width()+180)+"px";
            $("#content").css({ width: w}); 
        }
        document.getElementById("htmlSubHeader").style.display = "none";
        document.getElementById("htmlMenuPanel").style.display = "none";
        document.getElementById("htmlMenuSelect").style.display = "none";
        document.getElementById("htmlMenuHide").innerHTML = "<img src=\"App_Themes/Default/images/application_windows_right.png\" alt=\"\" />打开菜单</a>";
    }
    else {
        //隐藏菜单
        //width:20%;
        bMenuState = true;
        if (getBrowser()!=6) {
            $("#navigation").css({ width: "15%"});
            $("#content").css({ width: "83%"}); 
        }
        else
        {
            $("#navigation").css({ width: "180px"});
            var w = ($("#PageForm").width()-200)+"px";
            $("#content").css({ width: w}); 
        }
        
        document.getElementById("htmlSubHeader").style.display = "";
        document.getElementById("htmlMenuPanel").style.display = "";
        document.getElementById("htmlMenuSelect").style.display = "";
        document.getElementById("htmlMenuHide").innerHTML = "<img src=\"App_Themes/Default/images/application_windows_left.png\" alt=\"\" />隐藏菜单</a>";
    }
}

function resizeWindow() 
{
    var windowHeight = getWindowHeight();
    
    if (document.getElementById("content")!=null) {
        document.getElementById("content").style.height = (windowHeight - 68) + "px";
        if (getBrowser()==6) {
            var w = ($("#PageForm").width()-220)+"px";
                    $("#content").css({ width: w}); 
        }
    }
    
    if (document.getElementById("contentPanel")!=null) {
        document.getElementById("contentPanel").style.height = (windowHeight - 108) + "px";
    }
    
    if (document.getElementById("navigation")!=null) {
        document.getElementById("navigation").style.height = (windowHeight - 68) + "px";
    }
}


function getWindowHeight() 
{
	var windowHeight=0;
	if (typeof(window.innerHeight)=='number') 
	{
		windowHeight = window.innerHeight;
	}
	else {
		if (document.documentElement && document.documentElement.clientHeight) 
		{
			windowHeight = document.documentElement.clientHeight;
		}
		else 
		{
			if (document.body && document.body.clientHeight) 
			{
				windowHeight = document.body.clientHeight;
			}
		}
	}
	return windowHeight;
}


function getBrowser()
{
    var agt = navigator.userAgent.toLowerCase();
    var appVer = navigator.appVersion.toLowerCase();
   
   //*** Browser Version ***
   var is_minor = parseFloat(appVer);
   var is_major = parseInt(is_minor);
   
  // alert(agt.toString());
   //alert(appVer.toString());
   
   var iePos = appVer.indexOf("msie");
   if(iePos!=-1)
   {
       is_minor = parseFloat(appVer.substring(iePos + 5,appVer.indexOf(";",iePos)));
       is_major = parseInt(is_minor);
       
   }
   return is_major;
}