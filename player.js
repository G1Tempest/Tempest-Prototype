//player.js
function rad(deg)
{
	return deg * 0.01745;
}

function Player ()
{
	var playerTexture;
	var position; 
	var angle;
	var inactiveammo;
	var activeammo;
	var score=0;
	
	var scoreOrigin=new vec3();
	scoreOrigin.set(10,10,0);
	var Scoretext;
	var origin = new vec3();
	origin.set(300,300,0);
	
	this.getAngle = function () 
	{
		return angle;
	};
	
	var radius = 175;
	
	this.init = function (stage) {
		position = new vec3();
		
		angle = 0;
		
	 Scoretext= new PIXI.Text("Score: "+score, {font:"50px Arial", fill:"red"});
		
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
		
		inactiveammo = [];
		
		for (var i = 0; i<2; i++)
		{	
			inactiveammo.push(new LaserBullet());
			inactiveammo[i].init(stage,this);
		}
		
		activeammo = [];
		
		stage.addChild(playerTexture);
		stage.addChild(Scoretext);
		
	};
	
	this.checkForCollision = function () 
	{
		
		
		
	};
	
	this.getActiveAmmo = function ()
	{
	
		return activeammo;
	
	};
	
	this.update = function (e) {
		//if (e == null)
			//return;
		//else {
			//console.log (e.keyCode);
	
	
		if (map[39] == true) {
			angle += 2;
		
			if(angle >= 360)
				angle = 0;
	
			position.setX(origin.getX() + radius * Math.sin(rad(angle)));
			position.setY(origin.getY() + radius * Math.cos(rad(angle)));
			
			
		} 
		
		if (map[37] == true) {
			angle -= 2;
	
			if (angle <= 0)
				angle = 360;
	
			position.setX(origin.getX() + radius * Math.sin(rad(angle)));
			position.setY(origin.getY() + radius * Math.cos(rad(angle)));
		
			
			
		}

		if (e != null && e.keyCode == 32) {
			if (map[32] == true) {
				
				var ammolen = inactiveammo.length;
				
				if (ammolen > 0) {
					inactiveammo[0].fire(position,angle,radius);
					
					activeammo.push(inactiveammo[0]);
					
					var index = inactiveammo.indexOf(inactiveammo[0]);
					inactiveammo.splice(0, 1);
					
					
				}
				
			}
		}
		
		for (var i = 0; i < activeammo.length; i++)
		{
			activeammo[i].update();
		
		}
		
		playerTexture.position.x = position.getX();
		playerTexture.position.y = position.getY();
		playerTexture.rotation = rad(360-angle);
		
//console.log(score);
Scoretext.setText("Score: "+score);
		
	};
	
	this.addAmmo = function (ammo)
	{
		var index = activeammo.indexOf(ammo);
	
		activeammo.splice(index,1);
		inactiveammo.push(ammo);
	
	};
	
	
	return this;
}
