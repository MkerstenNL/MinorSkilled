--require "Player"
class = require("middleclass")
Wall= class('Wall')
doorOpen = false
wallpng = love.graphics.newImage("brick.png")
function Wall:initialize(x,y)
    self.x = x
    self.y = y
    self.width = 150
    self.height = 150
    return self
end


walls = {}
function love.load(arg)
  if arg and arg[#arg] == "-debug" then require("mobdebug").start() end
  love.window.setMode(1280,720)
  hero = require("Player")
  key = require("Key")
  for i = 0,9 do
    if i == 4 then
      door = require("Door")
      door.x = i*150
      door.y = 100

    else
      wall = Wall:new(150*i,100)
      print(wall.x)
      table.insert(walls, wall)
      print(i)
      print(table.getn(walls))
    end
    

  end

      hero:setPosition(500,500)

end

function love.update(dt)
  hero:update(dt)
  checkCollisions()
  
end

function checkCollisions()
    --player vs key
    if(CheckCollision(hero.x,hero.y,hero.width,hero.height,key.x,key.y,key.width,key.height)and hero.inventory.hasKey == false)then
        hero.hitKey(hero)
        --hero.inventory.hasKey = true;
    end
    for key, value in pairs(walls)do
      local tempwall = walls[key]
      if(CheckCollision(hero.x,hero.y,hero.width,hero.height,tempwall.x,tempwall.y,tempwall.width,tempwall.height)) then
        resolveCollision(hero,tempwall)
      end
    end
    
    if(CheckCollision(hero.x,hero.y,hero.width,hero.height,door.x,door.y,door.width,door.height))then
      if(hero.inventory.hasKey == true or doorOpen==true)then
        doorOpen = true
      else
        resolveCollision(hero,door)
      end
    end
end

function resolveCollision(hero, wall)
   if(math.abs(hero.x-wall.x)>math.abs(hero.y-wall.y))then
    if(hero.x>wall.x)then--hero.x is right of x2
        hero.x = wall.x + wall.width
    else
        hero.x = wall.x - hero.width
    end
  else
    if(hero.y>wall.y)then
        hero.y = wall.y + wall.width
    else
      hero.y = wall.y - hero.height
    end
  end
  

end


function love.draw()
  -- let's draw a background
  love.graphics.setColor(255,255,255,255)
  love.graphics.rectangle("fill",0,0,1280,720)
  if(hero.inventory.hasKey == false)then
    love.graphics.draw(key.sprite,key.x,key.y)
  end
  if(doorOpen==false)then
  love.graphics.draw(door.sprite,door.x,door.y)  
  end
  for key, value in pairs(walls) do
      local tempWall = walls[key]
      love.graphics.draw(wallpng,tempWall.x,tempWall.y)
  end
  
  -- let's draw our hero
  love.graphics.setColor(255,255,255,255)
  love.graphics.draw(hero.sprite,hero.x,hero.y)
end

-- Collision detection function.
-- Checks if a and b overlap.
-- w and h mean width and height.
function CheckCollision(ax1,ay1,aw,ah, bx1,by1,bw,bh)
  local ax2,ay2,bx2,by2 = ax1 + aw, ay1 + ah, bx1 + bw, by1 + bh
  return ax1 < bx2 and ax2 > bx1 and ay1 < by2 and ay2 > by1
end
