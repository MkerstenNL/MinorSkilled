GuardRange = 4
GuardSense = 6
GuardSpeedRunning = 3
GuardSpeedWalking = 0


function Start()

end

function Update()
IsSense = Guard:Sense(GuardSense)
StillPatrol = Guard:Patrol(GuardRange, GuardSpeedWalking)
	if(StillPatrol == false or IsSense == true) then
		StillChasing = Guard:Chase("Player",GuardSpeedRunning)
		if(Guard.Hit() == "Player") then
			Player:TeleportTo(10,1,10)
		end
	else
		Guard:Patrol(GuardRange,GuardSpeedWalking)
	end
end