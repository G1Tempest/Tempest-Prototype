
function LevelReader ()
{

	var levelMap = [];

	this.Load  = function (index) {
		var oFrame = document.getElementById(index.toString());
		var strRawContents = oFrame.contentWindow.document.body.childNodes[0].innerHTML;
		
		while (strRawContents.indexOf("\r") >= 0)
			strRawContents = strRawContents.replace("\r", "");
    
		var arrLines = strRawContents.split("\n");
    
		for (var i = 0; i < arrLines.length; i++) {
			  levelMap [i] = arrLines[i].split("");
		}
	
		return levelMap;
	};

    return this;

}