Coin = {}
Coin.PickedUp = false
Coin.Score = 0
function Coin:Start()
	------GameObjectC.Log("Coinsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")
	GameObject:NewScript ("Transform")
	GameObject:NewScript("HUD")
--World:Start()
end

function Coin:Update()
end

function Coin:Interactive()
	if(Coin.PickedUp == false) then
	------GameObjectC.Log("Picking Up Coin")
	Coin.PickedUp = true
	Transform:Teleport("Right",100)
	--HUD:Score(Score+1)
	------GameObjectC.Log("Coin PickedUp")
	Coin:AddScore();
	Coin:AddInventory();
	end
end

function Coin:AddScore()
	GameObjectC.Log("Coin Score")
	Coin.Score = Coin.Score+1
	Coin.Score = HUD:Score(Coin.Score)
	--Score = HUDC:Score(Score+1)
end
function Coin:AddInventory()--?Todo
	------GameObjectC.Log("Coin Score")
	Inventory = HUD:Inventory(Score+1)
	--Inventory = HUDC:Inventory(Score+1)
end

return Coin