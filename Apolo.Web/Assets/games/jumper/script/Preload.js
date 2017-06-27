var loadState = function(game){

};

  loadState.prototype = {
      
      preload: function(){
          console.log(game.state.getCurrentState());

          var Font = "40px Comic Sans MS";
            this.loadText = this.add.text(this.world.centerX,this.world.centerY,'loading ',{font: Font, fill: '#99CC0E', stroke: '#55B50D', strokeThickness: 3});
          this.loadText.anchor.setTo(0.5,0.5);
          
          /*
          this.loadingBg = this.add.sprite(this.world.centerX,this.world.centerY,'loadingbg');
          this.loadingBg.anchor.setTo(0.5,0.5);
          this.loadingBg.scale.setTo(0.5,0.5);
          
          this.loadingBar = this.add.sprite(this.world.centerX,this.world.centerY,'loadingbar');
          this.loadingBar.anchor.setTo(0.5,0.5);
          this.loadingBar.scale.setTo(0.5,1);
          this.load.setPreloadSprite(this.loadingBar);
          this.loadingBar.x = this.world.centerX - this.loadingBar.width/2;
          */
          var baseUrl = '/ApoloWebApp/Assets/games/jumper/';
          // load all objcet 
          this.load.image('background',baseUrl + 'assets/bg.png');
          this.load.image('cactus', baseUrl + 'assets/cactus.png');
          this.load.image('platform', baseUrl + 'assets/platform.png');
          
          //load fruties
          this.load.image('fruit0', baseUrl + 'assets/fruits/banana_01.png');
          this.load.image('fruit1', baseUrl + 'assets/fruits/grape.png');
          this.load.image('fruit2', baseUrl + 'assets/fruits/pineapple.png');
          this.load.image('fruit3', baseUrl + 'assets/fruits/watermelon.png');
          this.load.image('fruit4', baseUrl + 'assets/fruits/cherry.png');
          // load utility
          this.load.spritesheet('gems', baseUrl + 'assets/gems-sprite.png',45,42); // fruit.js && play.js
          // load player
          this.load.spritesheet('jolly', baseUrl + 'assets/player/monkey.png',63,78);
          
          // load GUI
          this.load.image('play', baseUrl + 'assets/GUI/play.png');    
          this.load.image('setting', baseUrl + 'assets/GUI/setting.png');    
          this.load.image('credit', baseUrl + 'assets/GUI/credit.png');    
          this.load.image('howtoplay', baseUrl + 'assets/GUI/howToPlay.png');      
          this.load.spritesheet('sound-sprite', baseUrl + 'assets/GUI/sound.png',70,60); 
          this.load.image('title-bg', baseUrl + 'assets/GUI/title_bg.png');
          this.load.image('menu-title', baseUrl + 'assets/GUI/menu-title.png');
          this.load.image('pauseBtn', baseUrl + 'assets/GUI/pause.png');  // Play.js
          this.load.image('restartBtn', baseUrl + 'assets/GUI/restart.png');  // leaderboard.js
          this.load.image('menuBtn', baseUrl + 'assets/GUI/b_More.png');  // leaderboard.js
          this.load.image('backward', baseUrl + 'assets/GUI/backward.png');// credit.js
          this.load.image('resumeBtn', baseUrl + 'assets/GUI/resume.png'); // Play.js
          this.load.image('life', baseUrl + 'assets/GUI/life.png'); // Play.js
          this.load.image('coconut', baseUrl + 'assets/coconut.png'); // fruit.js
           
          //credit
          //this.load.image('social-link', baseUrl + 'assets/credit/credit-social-link.png');
          //this.load.image('code', baseUrl + 'assets/credit/code.png');
          //this.load.image('devcredit', baseUrl + 'assets/credit/devcredit.png');
          //this.load.image('shohan', baseUrl + 'assets/credit/shohan.png');
          
          //// how to play
          //this.load.image('how-to-play', baseUrl + 'assets/how-to-play.png');
          
          // sounds
          this.load.audio('fruitGulp', [baseUrl + 'sounds/fruitGulp.wav', baseUrl + 'sounds/fruitGulp.ogg', baseUrl + 'sounds/fruitGulp.mp3', baseUrl + 'sounds/fruitGulp.m4a'],true);
          this.load.audio('menuBg', [baseUrl + 'sounds/menuBg.ogg', baseUrl + 'sounds/menuBg.wav', baseUrl + 'sounds/menuBg.mp3', baseUrl + 'sounds/menuBg.m4a'],true);
          
          this.load.audio('jumpSound', [baseUrl + 'sounds/jump.wav', baseUrl + 'sounds/jump.ogg', baseUrl + 'sounds/jump.mp3', baseUrl + 'sounds/jump.m4a'],true);

          this.load.audio('gemSound', [baseUrl + 'sounds/gemSound.mp3', baseUrl + 'sounds/gemSound.wav', baseUrl + 'sounds/gemSound.ogg', baseUrl + 'sounds/gemSound.m4a'],true);
          
          this.load.audio('deadSound', [baseUrl + 'sounds/dead.mp3', baseUrl + 'sounds/dead.wav', baseUrl + 'sounds/dead.ogg', baseUrl + 'sounds/dead.m4a'],true);
          
          this.load.audio('cocoSound', [baseUrl + 'sounds/dap.mp3', baseUrl + 'sounds/dap.wav', baseUrl + 'sounds/dap.ogg', baseUrl + 'sounds/dap.m4a'],true);
          
          
      },
      
      create: function(){
            
          this.sound.setDecodedCallback([ 'gemSound', 'menuBg', 'jumpSound','deadSound' ], function(){
                console.log('sounds are ready');
                this.state.start('Menu');
          }, this);
      },
      
      loadUpdate: function(){
        this.loadText.text = 'Cargando '+this.load.progress+'%';
          //console.log(this.load.progress);
      },
      
      update: function(){
            
      }
      
      
  }