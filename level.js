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
		
		background1 = new PIXI.Graphics();
		background1.beginFill(0x000000);  
		background1.drawRect(0, 0, 800, 100);
		stage.addChild(background1);
	
		background2 = new PIXI.Graphics();
		background2.beginFill(0x000000);  
		background2.drawRect(0, 0, 100, 800);
		stage.addChild(background2);
		
		background3 = new PIXI.Graphics();
		background3.beginFill(0x000000);  
		background3.drawRect(0, 500, 800, 125);
		stage.addChild(background3);
			
		background4 = new PIXI.Graphics();
		background4.beginFill(0x000000);  
		background4.drawRect(500, 0, 100, 800);
		stage.addChild(background4);
	
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