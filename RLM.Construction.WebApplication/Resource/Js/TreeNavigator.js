var timeout = null;
var Delay = 10;

function TreeNavigator(clientId, plus, minus)
{
	this.Container = document.getElementById(clientId);
    this.plus = plus;
    this.minus = minus;
    var instance = this;
    var uls = this.Container.getElementsByTagName("ul");
    for(var i=0; i < uls.length; i++)
    {
		/* skip the product list (if present) */
		if (uls[i].id && uls[i].id == "categoryList")
			continue;
    }
    var links = this.Container.getElementsByTagName("a");
    for (var i =0; i < links.length; i++)
    {
        if (links[i].nextSibling && links[i].nextSibling.tagName != "IMG")
        {
            links[i].onclick = function (e)
            {
                return instance.Toggle(e);
            }
        }
    }
}


TreeNavigator.prototype.Toggle = function(e)
{
	if (!e)
	{
		e = window.event;
	}

	var src = e.srcElement ? e.srcElement : e.target;
    
    if (!src.tagName)
    {
        src = src.parentNode;
    }
    
    if (src.tagName != "A")
	{
        return false;
	}
    
	var category = src.nextSibling;
	if (!category || category.tagName == "IMG")
	{
		return true;
	}
	if (category.style.display == "block")
	{
		this.Hide(category);
	}
	else
	{
		if (this.SingleExpand)
		{
			var parent = category.parentNode.parentNode;

			for (var i = 0; i < parent.childNodes.length; i++)
			{
                if (parent.childNodes[i].childNodes.length > 2)
				{
                    if (parent.childNodes[i].childNodes[2] != category)
                    {
                        parent.childNodes[i].childNodes[2].style.display = "none";
                        parent.childNodes[i].className = "collapsed";
                    }
                }
			}
		}
		this.Show(category);
	}
	return false;
}

TreeNavigator.prototype.Hide = function(node, img)
{
	if (timeout && this.Showing)
	{
		window.clearTimeout(timeout);
		this.Showing = false;
	}
	this.Hiding = true;
	node.style.overflow = "hidden";
	node.parentNode.className = "collapsed";
	
	window.HideStep = function (height)
	{
		TreeNavigator.HideStep(height, node);
	}
	timeout = window.setTimeout("HideStep(" + node.scrollHeight + ")",5);
}

TreeNavigator.HideStep = function (scroll, node)
{
	var height = node.scrollHeight;
    scroll = scroll - Delay;
	if (scroll > 10 )
	{
		node.style.height = scroll + "px";
		timeout = window.setTimeout("HideStep(" + scroll + ")",5);
	}else
	{
		node.style.oveflow = "";
		node.style.display = "none";
	}
}

TreeNavigator.prototype.Show = function(node, img)
{
	if (timeout && this.Hiding)
	{
		window.clearTimeout(timeout);
		this.Hiding = false;
	}
	this.Showing = true;

	node.style.width = "100%";
	node.style.overflow = "hidden";
	node.style.display = "block";
	node.style.height = "1px";
	node.parentNode.className = "expanded";
    
	window.ShowStep = function(step)
	{
		TreeNavigator.ShowStep(step, node);
	};
	timeout = window.setTimeout("ShowStep(1)", 5);
}

TreeNavigator.ShowStep = function(scroll, node)
{
	var height = node.scrollHeight;
	scroll = scroll + Delay;
	if (scroll <= height)
	{
		node.style.height = scroll + "px";
		timeout= window.setTimeout("ShowStep(" + scroll + ")", 5);
	}else
	{
		node.style.height = "";
		node.style.overflow = "";
	}
}
