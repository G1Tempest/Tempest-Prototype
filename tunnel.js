//tunnel.js

var tnlIndex = 2;

function Tunnel ()
{
	var tunnelElements;
	var src = ["tubeTrack1.png"];
	var alpha;
	var center;
	var loader = new LevelReader();
	var levelMap = [];
	var stage;
	var player;
	
	this.setPlayer = function (plyr)
	{
	
		player = plyr;
	
	};
	
	this.init = function (stg) {
		
		stage = stg;
		
		levelMap = loader.Load(curLevel);
		
		curNdx = 0;
		
		tunnelElements = [];
		
		var start = 0.6;
		
		var len = src.length;
		
		var factor = 1.0;
		
		center = new vec3();
		center.set (300,300,0);
		
		for (var i = 0; i< 11; i++) {
			
			tunnelElements.push (new TunnelElement());
			tunnelElements[i].init(center,i,stage, levelMap);
		}
			
		for (var i = 10; i>= 0; i--) {
			
			//tunnelElements.push (new TunnelElement());
			tunnelElements[i].addObstacles(stage);
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
	
	this.reAddObstacles = function () {
	
		for (var i = 10; i>= 0; i--) {
			
			//tunnelElements.push (new TunnelElement());
			tunnelElements[i].addObstacles(stage);
		}
	
	
	};
	
	this.checkForCollision = function () {
	
		return tunnelElements[tnlIndex].checkForCollision(player.getAngle());
	
	};
	
	this.update = function () {
		var len = tunnelElements.length;
		var readd = false;
		
		for (var i = 0; i< len; i++) {
			
			if (tunnelElements[i].update() == true)
				readd = true;
		}
		
		if (this.checkForCollision() == true)
			gameOver = true;
		
		if (readd == true)
			this.reAddObstacles();
		
		
	};
	
	
};

function TunnelElement ()
{
	var position;
	var scale;
	var elementTexture;
	var ndx;
	var lvlMap; 
	var obstacles = [];
	var center;
	var stage;
	
	this.init = function (ctr, index, stg, levelMap)
	{
		stage = stg;
	
	
		lvlMap = levelMap;
		position = new vec3();
		ndx = index;
		center = ctr;
		elementTexture = PIXI.Sprite.fromImage(assetFolder + "tubeBlue2.png");		
		elementTexture.anchor.x = 0.5;
		elementTexture.anchor.y = 0.5;
		elementTexture.position.x = center.getX();
		elementTexture.position.y = center.getY();
		elementTexture.scale.x = Math.pow(0.8,index);        	//index * 0.1;
		elementTexture.scale.y = Math.pow(0.8,index); 			//index * 1;
		
		position.setX (center.getX());
		position.setY (center.getY());
		position.setZ (Math.pow(0.8,index));
		
		for (var i = 0 ; i < levelMap[index].length; i++) 
		{
			if (levelMap[index][i] != '0') {
				obstacles.push(new ObstacleElement(levelMap[index][i]));
				obstacles[obstacles.length - 1].init(center,i,position.getZ());
			}
		}
		
		stage.addChild(elementTexture);
	};
	
	this.addObstacles = function (stage)
	{
		for (var i = 0; i< obstacles.length; i++)
			stage.addChild(obstacles[i].getTexture());
	};
	
	this.reInit = function (index) 
	{
		if (index == lvlMap.length - 1)
			levelEnd = true;
			
		ndx = index;
		
		// read from level map to create the obstacles
		for (var i = 0; i< obstacles.length; i++)
			stage.removeChild(obstacles[i].getTexture());
		
		obstacles = [];
		
		for (var i = 0 ; i < lvlMap[ndx].length; i++) 
		{
			if (lvlMap[ndx][i] != '0') {
				obstacles.push(new ObstacleElement(lvlMap[ndx][i]));
				obstacles[obstacles.length - 1].init(center,i,0.1);
			}
		}
	
	};
	
	this.checkForCollision = function (playerAngle) 
	{
		for (var i = 0; i < obstacles.length; i++)
			if (obstacles[i].checkForCollision(playerAngle) == true)
				return true;
	
		return false;
		
	};
	
	this.update = function ()
	{
	
		
		position.setZ(position.getZ() * 1.0075);
		
		scale = position.getZ();
		
//		if (ndx == 5)
//			console.log(scale);
	
		if (scale > 0.65 && scale < 0.8) {
			tnlIndex = ndx % 11;
			console.log (tnlIndex);
		}
		
	
		elementTexture.scale.x = scale;
		elementTexture.scale.y = scale;
		
		for (var i = 0; i< obstacles.length; i++)
			obstacles[i].update();
		
		if (scale > 1.1) 
		{
			scale = 0.1;//Math.pow(0.8,10);
			position.setZ(scale);
			this.reInit (ndx + 11);
			return true;
		}
		
		return false;
	};
	
	
}

function ObstacleElement (typ)
{
	var position;
	var scale;
	var elementTexture;
	var angle;
	var radius;
	var type = typ;
	
	this.getTexture = function ()
	{
		return elementTexture;
	};
	
	this.init = function (center, obsNdx, scale)//, stage)
	{
		position = new vec3();
		
		angle = (18 * obsNdx) + 9;
		radius = scale * 240;
		
		elementTexture = PIXI.Sprite.fromImage(assetFolder + type + ".png");		
		elementTexture.anchor.x = 0.5;
		elementTexture.anchor.y = 1;
		elementTexture.position.x = center.getX() + (radius * Math.sin (rad(angle)));
		elementTexture.position.y = center.getY() + (radius * Math.cos(rad(angle)));
		elementTexture.scale.x = scale;        	
		elementTexture.scale.y = scale; 		
		elementTexture.rotation = rad(360-angle);
		
		//console.log(elementTexture.scale);
		position.setX (center.getX());
		position.setY (center.getY());
		position.setZ (scale);
		
		//stage.addChild(elementTexture);
	};
	
	this.checkForCollision = function (playerAngle)
	{
		//var playerMax = playerAngle + 9;
		//var playerMin = playerAngle - 9;
	
		var obsMax = angle + 9;
		var obsMin = angle - 9;
		
		if (playerAngle >= obsMin && playerAngle <= obsMax)
			return true;
			
		return false;
	
	};
	
	this.update = function ()
	{
		
		position.setZ(position.getZ() * 1.0075);
		
		radius = radius * 1.0075;	
		
		elementTexture.position.x = 300 + (radius * Math.sin (rad(angle)));
		elementTexture.position.y = 300 + (radius * Math.cos (rad(angle)));
		
		scale = position.getZ();
		
		elementTexture.scale.x = scale;
		elementTexture.scale.y = scale;
		
		if (scale > 1.1) 
		{
			scale = 0.1;
			position.setZ(0.1);
		}
		
	};
};