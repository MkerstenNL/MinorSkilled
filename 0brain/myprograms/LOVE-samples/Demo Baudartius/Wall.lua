[[--Class = require("middleClass")
Wall = Class("Wall")
function Wall:initialize(x,y)
   wall = Wall:new(x,y)
   --local this = super._init(self)
   wall.x = x
   wall.y = y
   wall.sprite =  love.graphics.newImage("brick.png")
   wall.width = 150
   wall.height = 150
   --self.width = self.sprite.getWidth(self.sprite)
   --self.height = self.sprite.getHeight(self.sprite)
   --wall = {}
   -- setmetatable(wall, self)
    --self.__index = self;
    --Wall:create()
    --return wall
    return wall
end



function Wall:create()
  self.x = 0
  self.y = 100
  self.sprite = love.graphics.newImage("brick.png")
  self.width = wall.sprite.getWidth(wall.sprite)
  self.height = wall.sprite.getHeight(wall.sprite)
end--]]