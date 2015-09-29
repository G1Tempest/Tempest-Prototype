//obstacles.js
function Obstacles ()
{
	var obstacleElements;
	var src = ["mons.png"]//,"tubeTrack2.png","tubeTrack3.png","tubeTrack4.png","tubeTrack5.png"];

	this.init = function (stage) {
		
		var start = 0.6;
		var len = src.length;
		var factor = 1.0;

		obstacleElements=PIXI.Sprite.fromImage(assetFolder + src[0]);
		obstacleElements.position.x = 300;
		obstacleElements.position.y = 350;
		obstacleElements.anchor.x = 0.5;
		obstacleElements.anchor.y = 0.5;
		obstacleElements.scale.x = start - (0.15  * factor);//- (0.005 * i);
		obstacleElements.scale.y = start - (0.15  * factor);//- (0.005 * i);
			
			factor -= 0.05;
			stage.addChild(obstacleElements);


		
		/*logo = PIXI.Sprite.fromImage(assetFolder+"tunnel.jpg");    
		logo.position.x = 300;
		logo.position.y = 300;
		logo.anchor.x = 0.5;
		logo.anchor.y = 0.5;*/
		
	};
	
	this.update = function () {
		

			obstacleElements.scale.x *= 1.01;
			obstacleElements.scale.y *= 1.011;
		
			//tunnelElements[i].position.x += i*1;
		
		//tunnelElements[i].position += i*10;
		if (obstacleElements.scale.x > 0.8) {
			obstacleElements.scale.x = 0.1;
			obstacleElements.scale.y = 0.1;
		}


		
		
		//console.log(tunnelElements[0].scale.x);
		//console.log(tunnelElements[0].scale.y);
	};
	this.draw = function (renderer,stage) {
		renderer.render(stage);
	};
	
	
};