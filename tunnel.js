//tunnel.js
function Tunnel ()
{
	var tunnelElements;
	var src = ["tubeTrack1.png"]//,"tubeTrack2.png","tubeTrack3.png","tubeTrack4.png","tubeTrack5.png"];
	var alpha;
	var center;
	
	this.init = function (stage) {
		
		tunnelElements = [];
		
		var start = 0.6;
		
		var len = src.length;
		
		var factor = 1.0;
		
		center = new vec3();
		center.set (300,300,0);
		
		for (var i = 0; i< 11; i++) {
			
			tunnelElements.push (new TunnelElement());
			tunnelElements[i].init(center,i,stage);
		}
			
			
		alpha = PIXI.Sprite.fromImage (assetFolder + "alpha.png");
		alpha.position.x = 300;
		alpha.position.y = 300;
		alpha.anchor.x = 0.5;
		alpha.anchor.y = 0.5;
		alpha.scale.x = 1;
		alpha.scale.y = 1;
		stage.addChild(alpha);
		
		
		
	};
	
	this.update = function () {
		var len = tunnelElements.length;
		
		for (var i = 0; i< len; i++) {
			
			tunnelElements[i].update();
		}
		
		
		
		
	};
	
	
};

function TunnelElement ()
{
	var position;
	var scale;
	var elementTexture;
	var factor = 0.2;
	
	this.init = function (center, index, stage)
	{
		position = new vec3();
		
		elementTexture = PIXI.Sprite.fromImage(assetFolder + "tubeBlue2.png");		
		elementTexture.anchor.x = 0.5;
		elementTexture.anchor.y = 0.5;
		elementTexture.position.x = center.getX();
		elementTexture.position.y = center.getY();
		elementTexture.scale.x = Math.pow(0.8,index);        	//index * 0.1;
		elementTexture.scale.y = Math.pow(0.8,index); 		//index * 1;
		console.log(elementTexture.scale);
		position.setX (center.getX());
		position.setY (center.getY());
		position.setZ (Math.pow(0.8,index));
		
		stage.addChild(elementTexture);
	};
	
	this.update = function ()
	{
		//console.log (elementTexture.scale);
	
		position.setZ(position.getZ() * 1.0075);
		
		scale = position.getZ();
		
		elementTexture.scale.x = scale;
		elementTexture.scale.y = scale;
		
		if (scale > 1.1) 
		{
			scale = 0.1;
			position.setZ(0.1);
		}
		
	};
}