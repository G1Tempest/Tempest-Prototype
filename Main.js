$ = function(_) {
    return document.getElementById(_);
};

var map = []; 
onkeydown = onkeyup = function(e){
    e = e || event; 
    map[e.keyCode] = e.type == 'keydown';
    /*insert conditional here*/
}

var assetFolder = "textures/";
var curLevel;   

function Tempest(){
	
	
	var level;
	var levelLoader;
	var stage;
	var renderer;
	var obstacle;
	
	this.loadNextLevel = function () {
		curLevel ++;
		
		level = new Level ();
		
		
	};
	
	
	this.init = function () {
		curLevel = 0;
		
		stage = new PIXI.Stage(0x000000, true);	

		renderer = PIXI.autoDetectRenderer(800, 600);	
	
		document.body.appendChild(renderer.view);	
	
		this.loadNextLevel();
		
		level.init(stage);
		
	};
	
	
	this.update = function (e)
	{
		if (gameOver == true)
			return;
			
		if (e)
		{	
			e = e || event; 
			map[e.keyCode] = e.type == 'keydown';
		}
		
		level.update(e);
		
		
			
		
		
		if (levelEnd == true) {
			
			for (var i = stage.children.length - 1; i >= 0; i--) {
				stage.removeChild(stage.children[i]);
			};
		
			this.loadNextLevel();
			
			level.init(stage);
		
			levelEnd = false;
		}
	};
	
	this.draw = function ()
	{
		level.draw(renderer,stage);
		
	};
	
	
	
	return this;
};


   
var game = new Tempest();


   
   

   
window.addEventListener('keydown',game.update,false);
window.addEventListener('keyup',game.update,false);

function init(){

	game.init();

	requestAnimFrame( tick );	
}

function tick() {
		
	game.update(null);
	game.draw();
	requestAnimFrame( tick );	   
	
}

function tile_clicked(){
   				
	var clicked = this ;//where 'this' is the Box we just have clicked. Weird Javascript!!! :P


}


function onTick(event){

	nCount--;
	
	
}
