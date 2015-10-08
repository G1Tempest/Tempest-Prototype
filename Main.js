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
var MainMenuState=true;
var IngameState=false;
var firstEntry=true;
var titleScreen;
var playerScore=0;
var backGroundAudio;// = $("backgroundScore")

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
	this.loadTitleScreen = function () {
		titleScreen=new TitleScreen();


	};
	
	
	this.init = function () {
		
		backGroundAudio = $("backgroundScore");
		backGroundAudio.play();
		
		
		curLevel = 0;
		
		stage = new PIXI.Stage(0x000000, true);	

		renderer = PIXI.autoDetectRenderer(800, 600);	
	
		document.body.appendChild(renderer.view);	
	

		if(MainMenuState) {
			this.loadTitleScreen();
			titleScreen.init(stage);
		}
		else {
		this.loadNextLevel();
			level.init(stage);
		}
		
		
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
		

		if(MainMenuState)
		titleScreen.update(e);
		else{
			if(firstEntry) {
				firstEntry=false;
				this.loadNextLevel();
				level.init(stage);
			}
		level.update(e);
		}

		
		
			
		
		
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

		if(MainMenuState)
		titleScreen.draw(renderer,stage);
		else
		level.draw(renderer,stage);
		renderer.render(stage);
		
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
