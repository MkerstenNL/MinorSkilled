Coin = {}
Coin.PickedUp = false
function Coin:Start()
	GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("Transform")
	--World:Start()
end

function Coin:Update()
end

function Coin:PickUp()
	if(Coin.PickedUp == false) then
	GameObjectC.Log("Picking Up Coin")
	Coin.PickedUp = true
	Transform:Teleport("Right",100)
	--HUD:Score(Score+1)
	GameObjectC.Log("Coin PickedUp")
	end
end

return Coin