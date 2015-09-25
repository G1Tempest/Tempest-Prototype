//tunnel.js
function Tunnel ()
{
	var tunnelElements;
	var src = ["tubeTrack1.png"]//,"tubeTrack2.png","tubeTrack3.png","tubeTrack4.png","tubeTrack5.png"];
	
	
	this.init = function (stage) {
		
		tunnelElements = [];
		
		var start = 0.6;
		
		var len = src.length;
		
		var factor = 1.0;
		
		for (var i = 0; i< 8; i++) {
			tunnelElements.push(PIXI.Sprite.fromImage(assetFolder + src[0]));
			tunnelElements[i].position.x = 300;
			tunnelElements[i].position.y = 300;
			tunnelElements[i].anchor.x = 0.5;
			tunnelElements[i].anchor.y = 0.5;
			
			tunnelElements[i].scale.x = start - (0.12 * i * factor);//- (0.005 * i);
			tunnelElements[i].scale.y = start - (0.12 * i * factor);//- (0.005 * i);
			
			factor -= 0.05;
			
			stage.addChild(tunnelElements[i]);
		}
			
		
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
		
		
		//console.log(tunnelElements[0].scale.x);
		//console.log(tunnelElements[0].scale.y);
	};
	
	
};