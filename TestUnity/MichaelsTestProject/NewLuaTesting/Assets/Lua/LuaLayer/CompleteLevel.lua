GuardRange = 2
GuardSense = 4
GuardSpeedRunning = 2
GuardSpeedWalking = 1

Player = GameObject.Find("Player")
Car = nil

if(Player.Hit() == "Door") then
Door:Open()
end

if (Player.Hit == "Coin") then
Coin:PickUp()
end

function Start()

end

function Update()
inSense = Guard:Sense(GuardSense)
isMoving = Boat:Move("Back",10)
	if(isMoving == false and Boat.Hit() == "Player") then
		Boat:Move("Towards","Coin",10)
		
	end
StillPatrol = Guard:Patrol(GuardRange, GuardSpeedWalking)
	if(StillPatrol == false or inSense == true) then
		--StillChasing = Guard:Chase(Player,GuardSpeedRunning)
		Guard:Evade(Player,GuardSpeedRunning)
		if(Gaurd.Hit() == "Player") then
			Player:TeleportTo(10,1,10)
		end
	else
		Guard:Patrol(GuardRange,GuardSpeedWalking)
	end
	if(Car =~ nil and Car.Hit() == "Player") then
		Car.Move("MoveTo", 10,1,100)
	end
end

if(Player.Hit() == "Fence") then
Fence::TurnOnCollider(false)
Car = World:CreateObject("Car",10,1,40)
end