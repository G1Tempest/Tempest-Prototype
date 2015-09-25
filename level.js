//level.js

function Level ()
{
	//var LevelMap = LevelLoader.load(curLevel);
	
	//create logo
    var logo;
	var background1;
	var background2;
	var background3;
	var background4;
	var player;
	var tunnel;
	
	//player.rotation = 270 * 0.01745;
	this.init = function (stage) {
		
		tunnel = new Tunnel ();
		
		tunnel.init (stage);
		
		player = new Player();

		player.init(stage);
			
	};
	
	this.update = function (e) {
		
		if (e == null ){
			tunnel.update(e);
		} else {
			player.update(e);
			
			
		}
		
	};
	
	this.draw = function (renderer,stage) {
		renderer.render(stage);
	};
	
	
	return this;
}