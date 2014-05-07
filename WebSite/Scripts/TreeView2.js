/***************************************************************************************
Name: Client Javascript for ASP.NET 2.0 TreeView 
Description: ASP.NET 2.0 TreeView lack for client operation. This set of functions provide
    some supports. Includes:
    * get node
    * change checkbox status of parent and child nodes

Author: Zhangtao, zhangtao.it@gmail.com
Date:   2006-03-30
Commonts:
***************************************************************************************/

//set child nodes checkbox status
function TV2_SetChildNodesCheckStatus(node,isChecked)
{
    var childNodes = TV2i_GetChildNodesDiv(node);
    if(childNodes == null)
        return;
        
    var inputs = WebForm_GetElementsByTagName(childNodes,"INPUT");
    if(inputs == null || inputs.length == 0)
        return;

    for(var i = 0; i < inputs.length; i++)
    {
        if(IsCheckBox(inputs[i]))
            inputs[i].checked = isChecked;  
    } 
}   

//change parent node checkbox status after child node changed
function TV2_NodeOnChildNodeCheckedChanged(tree,node,isChecked)
{
    if(node == null)
        return;
             
    var childNodes = TV2_GetChildNodes(tree,node);
    
    if(childNodes == null || childNodes.length == 0)
        return;    
    
    var isAllSame = true;

    for(var i = 0; i < childNodes.length; i++)
    {
        var item = childNodes[i];
        var value = TV2_NodeGetChecked(item);
        if(isChecked != value)
        {
            isAllSame = false;
            break;
        }
    }

    var parent = TV2_GetParentNode(tree,node);
    if(isChecked)
    {
        TV2_NodeSetChecked(node,isChecked);        
        TV2_NodeOnChildNodeCheckedChanged(tree,parent,isChecked);
    }    
    else
    {    
        if(isAllSame)
        {
            TV2_NodeSetChecked(node,false);  
            TV2_NodeOnChildNodeCheckedChanged(tree,parent,false); 
        }
    }
}

//get node relative element(etc. checkbox)
function TV2_GetNode(tree,element)
{
    var id = element.id.replace(tree.id,"");   
    id = id.toLowerCase().replace(element.type,"");    
    id = tree.id + id;
    
    var node = document.getElementById(id);
    if(node == null) //leaf node, no "A" node
        return element;
    return node;
}

//get parent node
function TV2_GetParentNode(tree,node)
{
    var div = WebForm_GetParentByTagName(node,"DIV");
    
    //The structure of node: <table>information of node</table><div>child nodes</div>
    var table = div.previousSibling; 
    if(table == null)
        return null;   
   
    return TV2i_GetNodeInElement(tree,table);
}

//get child nodes array
function TV2_GetChildNodes(tree,node)
{
    if(TV2_NodeIsLeaf(node))
        return null;
    
    var children = new Array();
    var div = TV2i_GetChildNodesDiv(node);
    var index = 0;
    
    for(var i = 0; i < div.childNodes.length; i++)
    {
        var element = div.childNodes[i];        
        if(element.tagName != "TABLE")
            continue; 
        
        var child = TV2i_GetNodeInElement(tree,element);
        if(child != null)
            children[index++] = child;
    }
    return children;
}

function TV2_NodeIsLeaf(node)
{
    return !(node.tagName == "A"); //Todo
}

function TV2_NodeGetChecked(node)
{
    var checkbox = TV2i_NodeGetCheckBox(node);   
    return checkbox.checked;
}

function TV2_NodeSetChecked(node,isChecked)
{
    var checkbox = TV2i_NodeGetCheckBox(node);
    if(checkbox != null)
     checkbox.checked = isChecked;
}

function IsCheckBox(element)
{   
    if(element == null)
        return false;
    return (element.tagName == "INPUT" && element.type.toLowerCase() == "checkbox");
}

//get tree
function TV2_GetTreeById(id)
{
    return document.getElementById(id);
}

//////////////////////////////////////////////////////////////////////////////////////////////
//private mothods, with TV2i_ prefix
//////////////////////////////////////////////////////////////////////////////////////////////

//get div contains child nodes
function TV2i_GetChildNodesDiv(node)
{
    if(TV2_NodeIsLeaf(node))
        return null;
        
    var childNodsDivId = node.id + "Nodes";
    return document.getElementById( childNodsDivId );
}

//find node in element
function TV2i_GetNodeInElement(tree,element)
{
    var node = TV2i_GetNodeInElementA(tree,element);
    if(node == null)
    {
        node = TV2i_GetNodeInElementInput(tree,element);
    }
    return node;
}

//find "A" node 
function TV2i_GetNodeInElementA(tree,element)
{
    var as = WebForm_GetElementsByTagName(element,"A");
    if(as== null || as.length == 0)
        return null;

    var regexp = new RegExp("^" + tree.id + "n\\d+$");

    for(var i = 0; i < as.length; i++)
    {
        if(as[i].id.match(regexp))
        {
            return as[i];
        }
    }      
    return null; 
}

//find "INPUT" node
function TV2i_GetNodeInElementInput(tree,element)
{
    var as = WebForm_GetElementsByTagName(element,"INPUT");
    if(as== null || as.length == 0)
        return null;
        
    var regexp = new RegExp("^" + tree.id + "n\\d+");

    for(var i = 0; i < as.length; i++)
    {
        if(as[i].id.match(regexp))
        {
            return as[i];
        }
    }      
    return null; 
}

//get checkbox of node
function TV2i_NodeGetCheckBox(node)
{
    if(IsCheckBox(node))
        return node;
        
    var id = node.id + "CheckBox";
    return document.getElementById(id);   
}