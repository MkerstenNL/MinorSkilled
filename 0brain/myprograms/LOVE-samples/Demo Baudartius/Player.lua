local Player = {} -- new table for the hero
Player.x = 0 -- x,y coordinates of the Player
Player.y = 0
Player.oldx = 0
Player.oldy = 0
--Player.width = 30
--Player.height = 15
Player.sprite = love.graphics.newImage("Hero.png")
Player.width = Player.sprite.getWidth(Player.sprite)
Player.height = Player.sprite.getHeight(Player.sprite)
Player.speed = 250

Player.inventory = {}
Player.inventory.hasKey = false;

function Player.test()
    print("fuck it")
    return "Fuck IT"
end

function Player.update(player, dt)
  if love.keyboard.isDown("left") then
    player.x = player.x - player.speed*dt
  elseif love.keyboard.isDown("right") then
    player.x = player.x + player.speed*dt
  end
  
  if love.keyboard.isDown("up") then
    player.y = player.y - player.speed * dt
  elseif love.keyboard.isDown("down") then
    player.y = player.y + player.speed * dt
  end
end

function Player.hitKey(player)
  player.inventory.hasKey = true;
end

function Player.hasKey(player)
  return player.inventory.hasKey
end

function Player.setPosition(player, x, y)
  player.x = x
  player.y = y
end



return Player