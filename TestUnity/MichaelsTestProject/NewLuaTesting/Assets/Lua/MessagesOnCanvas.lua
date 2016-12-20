if(Hit == triggerDoorLevel1) then
HUD:Message("Try opening the door by typing Door:Open()")
end
if(Hit == triggerWalkedThroughDoorLevel1) then
HUD:Message("Good Job. You used a function for an object. Is that a coin? Free money! Let's pick it up.")
end
if(Hit == TriggLevel1Coin) then
HUD:Message("Tip:Coin.PickUp()")
end
if(Hit == TriggerPickedUpCoin) then
HUD:Message("Nice you have some money now and again you used a function but for another object. Let's continue.")
end
if(Hit == triggerWaterLevel3) then
HUD:Message("The boat is coming our way. Someone is trying to help you. How does the boat operate?")
end
if(Hit == triggerWaterBoatLevel3) then
HUD:Message("Hee, someone programmed the boat that is was going in your direction. Now you need to go the opposite direction.")
end
if(Hit == triggerWaterBoatEndLevel3) then
HUD:Message("Using a function with parameters. Nice! but what did the text and number show you? The text was the direction and the number the amount in meters.")
end
if(Hit == triggerLevel4) then
HUD:Message("Did you see that? I think I saw a coin on the way here. That's unfair you weren't able to get there. Maybe you can go Toward the Coin, but how to get back? You can continue if you want to.")
end
if(Hit == triggerLevelCoin4) then
HUD:Message("So you went for the coin and used the gameobject. But how to get back. If there is forward and backwards. Maybe there is also right and left. Try more then just one line of code.")
end
if(Hit == triggerLevelCoinEnd4) then
HUD:Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.")
end