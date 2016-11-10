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

function Player.update(player, dt)
  local newx = player.x
  local newy = player.y
  if love.keyboard.isDown("left") then
    --player.x = player.x - player.speed*dt
    newx = player.x - player.speed*dt
    --player.move(player,player.speed*dt*-1,0)
  elseif love.keyboard.isDown("right") then
    --player.x = player.x + player.speed*dt
    --player.move(player,player.speed*dt,0)
    newx = player.x + player.speed*dt
  end
  
  if love.keyboard.isDown("up") then
    --player.y = player.y - player.speed * dt
    newy = player.y - player.speed * dt
    --player.move(player,0,player.speed*dt*-1)
  elseif love.keyboard.isDown("down") then
    --player.y = player.y + player.speed * dt
    newy = player.y + player.speed * dt
    --player.move(player,0,player.speed*dt)
  end
  player.setPosition(player,newx,newy)
  
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

function Player.move(player, speedx,speedy)
    player.x = player.x+speedx
    player.y = player.y+speedy
end



return Player