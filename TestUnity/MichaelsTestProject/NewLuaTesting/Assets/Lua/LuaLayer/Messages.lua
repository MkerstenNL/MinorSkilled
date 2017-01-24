function OnHit (Hit)
	if(Hit == "StartTrigger") then
	M.Message("Why do you need to be in the holding cell. You did nothing, they tricked you. Let's try to escape the door looks unguarded. Maybe you can open it.",0)
	end
	if(Hit == "Door") then
	M.Message("Hint - Door opens on command. Use the field on the left to program. Try typing Door:Interact() to open the door.",1)
	end
	if(Hit == "triggerWalkedThroughDoorLevel1") then
	M.Message("Good Job. You used the function interact for the door object.",0)
	end
	if(Hit == "triggerSeeCoin") then
	M.Message("Is that a coin? Free money! Let's pick it up. You can use as much as possible if you want to survive outside.",0)
	end
	if(Hit == "TriggerLevel1Coin") then
	M.Message("Hint - To pickup we can use the same function Coin.Interact(). Use the same field to program",1)
	end
	if(Hit == "TriggerPickedUpCoin") then
	M.Message("Nice you have some money now and again you used the same function but for another object that does something else. Let's continue.",0)
	end
	if(Hit == "triggerWaterLevel3") then
	M.Message("The boat is coming our way. Someone is trying to help you.",0)
	end
	if(Hit == "Boat") then
	M.Message("Hint - Move the boat forward with a speed of 5. Boat:Move('Forward',5) in the field on the left. Don't go harder you need to get your balance.",1)
	end
	if(Hit == "triggerWaterBoatEndLevel3") then
	M.Message("We are going to the other side, we moved the boat using speed.",0)
	end
	-- if(Hit == "triggerLevel4") then
	-- M.Message("Did you see that? I think I saw a coin on the way here. That's unfair you weren't able to get there. Maybe you can use other directions, but how to get back? You can continue if you want to.",1)
	-- end
	-- if(Hit == "TriggerLevel4Coin") then
	-- M.Message("So you went for the coin and used the more directions. But how to get back. Try more then just one line of code. To go faster.",1)
	-- end
	-- if(Hit == "triggerLevelCoinEnd4") then
	-- M.Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.",1)
	-- end
	if(Hit == "TriggerDirtySign") then
	M.Message("There is a messageboard. Maybe we there is a hint how to get pass the guards?",0)
	end
	if(Hit == "TriggerMessage") then
	M.Message("Hint - The sign is dirty and wouldn't show the text. If the status is clean. It will clean itself.",1)
	end
	--triggered after sign completed
	if(Hit == "TriggerMessageComplete") then
	M.Message("Good job. Maybe this can help you slip by the guards. They start in patrol and doing that till thy see you, but will chase you if you are in range.",0)
	end
	if(Hit == "BeforeGuardTrigger") then
	M.Message("I hope you read the sign. There might be a usefull hint.",0)
	end
	
	--Triggered when guard caught you.
	if(Hit == "Guard") then
	M.Message("Hint - You got caught. Remember the hint. They will chase you because of the Update function. Make from Chase -> Evade and see what happens when you are close to them.",1)
	end
	if(Hit == "BigGuard") then
	M.Message("Hint - She didn't run away from you and set you back to the boat to tell you to get back, but she didn't took your money. Try to Bribe her with the 3 coins you've found.It only needs to happens once. We can use Start function for that. bribed = GuardGirl:Bribe(3).",1)
	end
	--Not perfect explained
	if(Hit == "BigGuardTrigger") then
	M.Message("A policewoman! I don't think she will evade you. Some say that women have better eye sight. You better watch out.",0)
	end
	if(Hit == "FenceTrigger") then
	M.Message("Freedom is on the other side of the fence!",0)
	end
	if(Hit == "FenceHitTrigger") then
	M.Message("Hint - Only have to open the fence. Try interact with it.",1)
	end
	-- if(Hit == "FenceHitScriptTrigger") then
	-- M.Message("You found the weak spot. real life can be a bitch sometimes, Luckily this is a game. Why not trying to get through? TurnOnCollider(TrueOrFalse)?",1)
	-- end
	if(Hit == "FreedomTrigger") then
	M.Message("YOU DID IT! Now get out fast! Get to the road",0)
	end
	if(Hit == "CreateObjectTrigger") then
	M.Message("Hint - Call the car! World:Call('car',x,y,z) X,Y,Z is the position in the world. I already did that for you.",1)
	end
	if(Hit == "InteractCarTrigger") then
	M.Message("Hint - You should be able to do this now! Interact with the car to escape",1)
	end
	if(Hit == "EndAlphaGame") then
	M.Message("Congratz! You have finished the Alpha. We changed a lot but hoped that you learned anything. Might be not much, but if you liked? Try real programming.",0)
	end
	
	if(Hit == "TriggerLevel2Coin") then
	M.Message("Hint - Pick up the coin you need how to do it.",1)
	end
	if(Hit == "TriggerLevel3Coin") then
	M.Message("Hint - You're still reading this? Expect to something to change?",1)
	end
	if(Hit == "TriggerLevel5Coin") then
	M.Message("Hint - Collect the coin.",1)
	end
	if(Hit == "TriggerLevel6Coin") then
	M.Message("Hint - Collect the coin.",1)
	end
end