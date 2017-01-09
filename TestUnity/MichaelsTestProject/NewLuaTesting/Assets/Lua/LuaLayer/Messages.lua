----1 hint
----0 message
-- Hit = ""

-- function Update()
-- Hit = "triggerWalkedThroughDoorLevel1	"--RigidBody:LastHit()
-- OnHit()
-- end
function OnHit(Hit)	
	if(Hit == "StartTrigger") then
	Message("Try to escape the prison the door looks unguarded",0)
	end
	if(Hit == "Door") then
	Message("Try opening the door by typing Door:Open()",1)
	end
	if(Hit == "triggerWalkedThroughDoorLevel1") then
	Message("Good Job. You used a function for an object. Is that a coin? Free money! Let's pick it up.",0)
	end
	if(Hit == "TriggLevel1Coin") then
	Message("Tip:Coin.PickUp()",1)
	end
	if(Hit == "TriggerPickedUpCoin") then
	Message("Nice you have some money now and again you used a function but for another object. Let's continue.",0)
	end
	if(Hit == "triggerWaterLevel3") then
	Message("The boat is coming our way. Someone is trying to help you. How does the boat operate?",0)
	end
	if(Hit == "Boat") then
	Message("Hee, someone programmed the boat that is was going in your direction. Now you need to go the opposite direction.",1)
	end
	if(Hit == "triggerWaterBoatEndLevel3") then
	Message("Using a function with parameters. Nice! but what did the text and number show you? The text was the direction and the number the amount in meters.",0)
	end
	if(Hit == "triggerLevel4") then
	Message("Did you see that? I think I saw a coin on the way here. That's unfair you weren't able to get there. Maybe you can go Toward the Coin, but how to get back? You can continue if you want to.",0)
	end
	if(Hit == "TriggerLevel4Coin") then
	Message("So you went for the coin and used the gameobject. But how to get back. If there is forward and backwards. Maybe there is also right and left. Try more then just one line of code.",1)
	end
	if(Hit == "triggerLevelCoinEnd4") then
	Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.",0)
	end
end

