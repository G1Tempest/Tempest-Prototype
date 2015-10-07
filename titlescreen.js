//level.js
var levelEnd = false;
var gameOver = false;

function TitleScreen ()
{
    //var LevelMap = LevelLoader.load(curLevel);

    //create logo
    var background1;
    var FireToStart;
    var movingShip;
    var alpha1,alpha2;

    //player.rotation = 270 * 0.01745;
    this.init = function (stage) {




        background1 = new PIXI.Sprite.fromImage(assetFolder + "titleMain2.png");
        FireToStart=new PIXI.Sprite.fromImage(assetFolder + "titleStart.png");
        movingShip=new PIXI.Sprite.fromImage(assetFolder + "vehicle_start.png");


        background1.position.x=0;
        background1.position.y=0;

        FireToStart.position.x=300;
        FireToStart.position.y=350;
        FireToStart.anchor.x=0.5;
        FireToStart.anchor.y=0.5;
        FireToStart.scale.x=0.5;
        FireToStart.scale.y=0.5;


        movingShip.position.x=450;
        movingShip.position.y=210;
        movingShip.scale.x=0.2;
        movingShip.scale.y=0.2;

        stage.addChild(background1);
        stage.addChild(FireToStart);
        stage.addChild(movingShip);


    };

    this.update = function (e) {
            FireToStart.scale.x *= 1.005;
            FireToStart.scale.y *= 1.005;
        movingShip.position.x+=5;

        if(movingShip.position.x>=500){
            movingShip.position.x=-400;
        }
        if(FireToStart.scale.x>=1.0){
            FireToStart.scale.x*=0.6;
            FireToStart.scale.y*=0.6;
        }
        if(map[32]== true){
            background1.visible=false;
            FireToStart.visible=false;
            movingShip.visible=false;
            MainMenuState=false;
        }


    };

    this.draw = function (renderer,stage) {
        renderer.render(stage);
    };


    return this;
}