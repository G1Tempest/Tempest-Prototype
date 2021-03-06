//level.js
var levelEnd = false;
var gameOver = false;

function Level ()
{
	//var LevelMap = LevelLoader.load(curLevel);
	
	//create logo
    var background1;
	var background2;
	var background3;
	var background4;
	var player;
	var tunnel;
	var score;
	
	//player.rotation = 270 * 0.01745;
	this.init = function (stage) {
		
		

		score= new PIXI.Text("Score:0", {font:"20px Arial", fill:"red"})
		score.position.x=50;
		score.position.y=50;

		tunnel = new Tunnel ();
		
		tunnel.init (stage);
		
		player = new Player();

		player.init(stage);
		
		tunnel.setPlayer (player);
		
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
		background4.drawRect(500, 0, 200, 800);
		stage.addChild(background4);
		stage.addChild(score);
	};
	
	this.update = function (e) {
		
		//if (e == null ){
		playerScore++;
		score.setText("Score:" + playerScore/100);
			
		player.update(e);
		tunnel.update(e);
		//} else {
			
		//}
		
	};
	
	this.draw = function (renderer,stage) {
		renderer.render(stage);
	};
	
	
	return this;
}
