gotha = false
function Start()
end

function Update()
--chase to evade
gotha = Guard:Chase(Player)
if(gotha) then
Player:TeleportTo(0,0,0)
Guard:TeleportTo(10,0,10)
end
end
