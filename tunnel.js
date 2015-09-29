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
		
		//center = new Vec3();
		//center.set (300,300,0);
		
		for (var i = 0; i< 8; i++) {
			
			
			tunnelElements.push (new TunnelElement());
			tunnelElements[i].init(center,i,stage);
			
			/*tunnelElements.push(PIXI.Sprite.fromImage(assetFolder + src[0]));
			tunnelElements[i].position.x = 300;
			tunnelElements[i].position.y = 300;
			tunnelElements[i].anchor.x = 0.5;
			tunnelElements[i].anchor.y = 0.5;
			
			tunnelElements[i].scale.x = start - (0.12 * i * factor);//- (0.005 * i);
			tunnelElements[i].scale.y = start - (0.12 * i * factor);//- (0.005 * i);
			
			factor -= 0.05;*/
			
			//stage.addChild(tunnelElements[i]);
		}
			
			
		alpha = PIXI.Sprite.fromImage (assetFolder + "alpha.png");
		alpha.position.x = 300;
		alpha.position.y = 300;
		alpha.anchor.x = 0.5;
		alpha.anchor.y = 0.5;
		alpha.scale.x = 0.5;
		alpha.scale.y = 0.5;
		stage.addChild(alpha);
		
		
		/*logo = PIXI.Sprite.fromImage(assetFolder+"tunnel.jpg");    
		logo.position.x = 300;
		logo.position.y = 300;
		logo.anchor.x = 0.5;
		logo.anchor.y = 0.5;*/
		
	};
	
	this.update = function () {
		var len = tunnelElements.length;
		
		for (var i = 0; i< len; i++) {
			tunnelElements[i].scale.x *= 1.01;
			tunnelElements[i].scale.y *= 1.01;
		
			//tunnelElements[i].position.x += i*1;
		
			//tunnelElements[i].position += i*10;
		
			if (tunnelElements[i].scale.x > 0.8) {
				tunnelElements[i].scale.x = 0.1;
				tunnelElements[i].scale.y = 0.1;
			}
		}
		
		
		
		
	};
	
	
};

function TunnelElement ()
{
	var position;
	var scale;
	var elementTexture;
	
	this.init = function (center, index)
	{
		position = new Vec3();
		
		elementTexture = PIXI.Sprite.fromImage(assetFolder + "tubeTrack1.png");		
		position.setX (center.getX());
		position.setY (center.getY());
		position.setZ (index);
	};
	
	this.update = function ()
	{
		position.setZ(position.getZ() + 0.5);
		
		scale = position.getZ();
		
		elementTexture.scale.x = scale;
		elementTexture.scale.y = scale;
		
		if (scale > 0.8) 
			scale = 0.1;
		
	};
}