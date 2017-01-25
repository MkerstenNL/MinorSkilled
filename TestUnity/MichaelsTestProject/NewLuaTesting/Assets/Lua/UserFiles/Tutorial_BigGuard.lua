Range = 4
SeePerson = 15
SpeedRunning = 5
SpeedWalking = 1
inRange = false
bribed = "false"

function Start()
	GuardGirl:Patrol (Range, SpeedWalking)
	GuardGirl:Sense (SeePerson)
GuardGirl:Bribe(3)
end

function Update ()
	inRange = GuardGirl:CheckRangeTarget ("Player")
	if(inRange and bribed == "false") then
		GuardGirl:Chase ("Player", SpeedRunning)
	else
		GuardGirl:Patrol (Range, SpeedWalking)
	end
end	