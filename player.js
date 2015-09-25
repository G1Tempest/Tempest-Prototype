//player.js

function rad(deg)
{
	return deg * 0.01745;
}


function Player ()
{
	var playerTexture;
	var shadowTexture;
	var position; 
	var angle;
	
	var origin = new vec3();
	origin.set(300,300,0);
	
	var radius = 175;
	
	this.init = function (stage) {
		position = new vec3();
		
		angle = 0;
		
		
		position.set(origin.getX() + Math.sin(rad(angle)) * radius,
					 origin.getY() + Math.cos(rad(angle)) * radius,
					 0);
					 
		playerTexture = PIXI.Sprite.fromImage(assetFolder+"ship.png");
		playerTexture.position.x = position.getX();
		playerTexture.position.y = position.getY();
		playerTexture.anchor.x = 0.5;
		playerTexture.anchor.y = 0.5;
		playerTexture.scale.x = 0.3;
		playerTexture.scale.y = 0.3;
		
		shadowTexture = PIXI.Sprite.fromImage(assetFolder+"shadow.png");
		shadowTexture.position.x = position.getX();
		shadowTexture.position.y = position.getY() + 30;
		shadowTexture.anchor.x = 0.5;
		shadowTexture.anchor.y = 0.5;
		shadowTexture.scale.x = 0.5;
		shadowTexture.scale.y = 0.5;
		
		
		stage.addChild(playerTexture);
		stage.addChild(shadowTexture);
		
	};
	
	this.update = function (e) {
		if (e == null)
			return;
		else {
			console.log (e.keyCode);
	
	
			if (e.keyCode == 39) {//|| e.keyCode == 37) {
				angle += 5;
			
				if(angle >= 360)
					angle = 0;
		
				position.setX(origin.getX() + radius * Math.sin(rad(angle)));
				position.setY(origin.getY() + radius * Math.cos(rad(angle)));
				
				shadowTexture.position.x = (origin.getX() + (radius+30) * Math.sin(rad(angle)));
				shadowTexture.position.y = (origin.getY() + (radius+30) * Math.cos(rad(angle)));
				
				
			} else if (e.keyCode == 37) {//|| e.keyCode == 37) {
				angle -= 5;
		
				if (angle <= 0)
					angle = 360;
		
				position.setX(origin.getX() + radius * Math.sin(rad(angle)));
				position.setY(origin.getY() + radius * Math.cos(rad(angle)));
			
				shadowTexture.position.x = (origin.getX() + (radius+30) * Math.sin(rad(angle)));
				shadowTexture.position.y = (origin.getY() + (radius+30) * Math.cos(rad(angle)));
				
			}
		}
		
		playerTexture.position.x = position.getX();
		playerTexture.position.y = position.getY();
		playerTexture.rotation = rad(360-angle);
		shadowTexture.rotation = rad(360-angle);
	};
	
	//this.draw = funtion () {
		
	//};
	
	return this;
}