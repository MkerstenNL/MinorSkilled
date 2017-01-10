----1 hint
----0 message
-- Hit = ""

-- function Update()
-- Hit = "triggerWalkedThroughDoorLevel1	"--RigidBody:LastHit()
-- OnHit()
-- end
function OnHit (Hit)
	if(Hit == "StartTrigger") then
	M.Message("Try to escape the prison the door looks unguarded",0)
	end
	if(Hit == "Door") then
	M.Message("Try opening the door by typing Door:Interactive()",1)
	end
	if(Hit == "triggerWalkedThroughDoorLevel1") then
	M.Message("Good Job. You used a function for an object. Is that a coin? Free money! Let's pick it up.",0)
	end
	if(Hit == "TriggerLevel1Coin") then
	M.Message("Tip:Coin.Interactive()",1)
	end
	if(Hit == "TriggerPickedUpCoin") then
	M.Message("Nice you have some money now and again you used the same function but for another object that does something else. Let's continue.",0)
	end
	if(Hit == "triggerWaterLevel3") then
	M.Message("The boat is coming our way. Someone is trying to help you. How does the boat operate?",0)
	end
	if(Hit == "Boat") then
	M.Message("Hee, someone programmed the boat that is was going in your direction. Now you need to go the opposite direction.",1)
	end
	if(Hit == "triggerWaterBoatEndLevel3") then
	M.Message("Using a function with parameters. Nice! but what did the text and number show you? The text was the direction and the number the amount in meters.",0)
	end
	if(Hit == "triggerLevel4") then
	M.Message("Did you see that? I think I saw a coin on the way here. That's unfair you weren't able to get there. Maybe you can go Toward the Coin, but how to get back? You can continue if you want to.",0)
	end
	if(Hit == "TriggerLevel4Coin") then
	M.Message("So you went for the coin and used the gameobject. But how to get back. If there is forward and backwards. Maybe there is also right and left. Try more then just one line of code.",1)
	end
	if(Hit == "triggerLevelCoinEnd4") then
	M.Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.",0)
	end
	if(Hit == "triggerLevelCoinEnd4") then
	M.Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.",0)
	end
	if(Hit == "TriggerDirtySign") then
	M.Message("There is a dirty sign what does it say?",0)
	end
	if(Hit == "TriggerMessage") then
	M.Message("It looks like a that if the sign is dirty it wouldn't show the text.",1)
	end
	--triggered after sign completed
	if(Hit == "TriggerMessageComplete") then
	M.Message("You did it! You changed a variable to change the if. Now there is more if and variables.",1)
	end
	
	if(Hit == "BeforeGuardTrigger") then
	M.Message("I hope you read the sign. There might me a usefull tip.",0)
	end
	
	--Triggered when guard caught you.
	if(Hit == "HitByGuard") then
	M.Message("Well they found you. Now we can say that the guards don't have to chase you.",1)
	end
	
	if(Hit == "BigGuardTrigger") then
	M.Message("Wow he is big!. Let's see what changed. Not everything is changed when facing another guard.",0)
	end
	
	
end

