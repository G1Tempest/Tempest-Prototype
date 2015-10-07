//obstacles.js
function Obstacles ()
{
	var obstacleElements=[[]];
	obstacleElements[0]=[];
	var src = ["mons.png","empty.png","obsMag.png"];//,"tubeTrack2.png","tubeTrack3.png","tubeTrack4.png","tubeTrack5.png"];
	var origin = new vec3();
	origin.set(300,300,0);
	var radius = 7;//175;
	//var tempArray=[[1,1,1,1,0,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0],[0,0,0,0,1,0,0,0,0,0,1,0,0,0,1,0,0,1,0,0]];//[0,1,1,1,1,0,2,1,1,1,0,1,2,1,1,0,1,1,1,1];
	var angle = 0;
	var lastUpdate = Date.now();
	var level=0;
	var loader = PIXI.AssetLoader(src);
	this.init = function (stage) {
		var levelReader;
		 levelReader= new LevelReader();//tempArray;


		//preloading textures

		var start = 0.11;
	
		//console.log (levelReader.length);

		for (var j=0;j<levelReader.length;j++) {
			obstacleElements[j]=[];
			//loads into obstacles each round
			for (var i = 0; i < levelReader[j].length; i++) {
				if (levelReader[j][i] == 0) {
					var texture;
					//var angle =  (18 * i);
					texture = PIXI.Sprite.fromImage(assetFolder + src[1]);
					texture.anchor.x = 0.5;
					texture.anchor.y = 0.5;
					texture.position.x = origin.getX() + Math.sin(rad(angle)) * radius;
					texture.position.y = origin.getY() + Math.cos(rad(angle)) * radius;
					obstacleElements[j][i]=texture;

				}
				if (levelReader[j][i] == 1) {
					var texture;
					var angle = (18 * i) + 9;
					texture = PIXI.Sprite.fromImage(assetFolder + src[0]);
					texture.rotation = rad(360 - angle);
					texture.anchor.x = 0.5;
					texture.anchor.y = 0.5;
					texture.position.x = origin.getX() + Math.sin(rad(angle)) * radius;
					texture.position.y = origin.getY() + Math.cos(rad(angle)) * radius;
					obstacleElements[j][i]=texture;


				}
				if (levelReader[j][i] == 2) {
					var texture;
					var angle = 360 - (18 * i);
					texture = PIXI.Sprite.fromImage(assetFolder + src[2]);
					//texture.rotation=angle;
					texture.anchor.x = 0.5;
					texture.anchor.y = 0.5;
					texture.position.x = origin.getX() + Math.sin(rad(angle)) * radius;
					texture.position.y = origin.getY() + Math.cos(rad(angle)) * radius;

					obstacleElements[j][i]=texture;


				}
			}
			console.log(levelReader[j].length,obstacleElements[j].length);
		}


			for (var i = 0; i < obstacleElements.length; i++) {
				for(var j=0;j<obstacleElements[i].length;j++) {
					obstacleElements[i][j].scale.x = start;
					obstacleElements[i][j].scale.y = start;
					stage.addChild(obstacleElements[i][j]);
				}
		}

		
	};
	function onAssetsLoaded(){

	}
	
	this.update = function () {

		if(level<obstacleElements.length){
			currentUpdate = Date.now();
			for (var j = 0; j < obstacleElements[level].length; j++) {
				obstacleElements[level][j].scale.x *= 1.013;
				obstacleElements[level][j].scale.y *= 1.013;
				radius += 0.02 * (currentUpdate - lastUpdate) * 0.0015;
				obstacleElements[level][j].position.x = origin.getX() + Math.sin(rad((18 * j) + 9)) * radius;
				obstacleElements[level][j].position.y = origin.getY() + Math.cos(rad((18 * j) + 9)) * radius;

				if (obstacleElements[level][j].scale.x > 1.0) {
					obstacleElements[level][j].visible = false;
					level++;
					radius = 7;
					lastUpdate = Date.now();
					break;


				}


			}



		}
	};
	this.draw = function (renderer,stage) {
		renderer.render(stage);
	};
	
	
};