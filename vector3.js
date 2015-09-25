function vec3 ()
{
	var x,y,z;

	this.getX = function () {
		return x;
	};
	
	this.getY = function () {
		return y;
	};
	
	this.getZ = function () {
		return z;
	};
	
	this.set = function (ix,iy,iz) {
		x = ix;
		y = iy;
		z = iz;
	};
	
	this.setX = function (ix) {
		x = ix;
	};
	
	this.setY = function (iy) {
		y = iy;
	};
	
	this.setZ = function (iz) {
		z = iz;
	};
	
	return this;
} 