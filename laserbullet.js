//laser bullet.js


function LaserBullet()
{
	var active;
	var position; 
	
	var scale;
	var bullettexture;
	var radius;
	var angle;
	var player;
	var center = new vec3();
	center.set (300,300,0);
	
	this.init = function (stage,playr)
	{
		bullettexture =  PIXI.Sprite.fromImage(assetFolder+"bullet.png");
		bullettexture.anchor.x = 0.5;
		bullettexture.anchor.y = 0.5;
		bullettexture.visible = false;
		active = false;
		stage.addChild (bullettexture);
		
		player = playr;
	};

	
	this.update = function ()
	{
		if (active == true)
		{
			scale = scale * 0.95;
			bullettexture.scale.x = scale;
			bullettexture.scale.y = scale;
			
			radius = radius * 0.97;
			//position.x = 
			//position.y = 
			//position.z = 
			bullettexture.position.x = center.getX() + (radius - 20) * Math.sin(rad(angle));
			bullettexture.position.y = center.getY() + (radius - 20) * Math.cos(rad(angle));
			
			if (scale <= 0.05) {
				active = false;
				bullettexture.visible = false;
				player.addAmmo(this);
			}
				
			
		}
	};
	
	this.fire = function (position, ang, radi)
	{
		active = true;
		radius = radi - 20;
		angle = ang;
		
		bullettexture.scale.x = 0.45;
		bullettexture.scale.y = 0.45;
		scale = 0.45;
		
		bullettexture.visible = true;
		bullettexture.position.x = 300 + (radius - 20) * Math.sin(rad(angle));
		bullettexture.position.y = 300 + (radius - 20) * Math.cos(rad(angle));
		bullettexture.rotation = rad(360-angle);
		
	};
	
	
}