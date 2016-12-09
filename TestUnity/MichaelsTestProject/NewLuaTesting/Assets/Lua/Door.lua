Door = {}
 Door.Open = false
function Door:Start()

end

function Door:Update()

end

function Door:Open()
	if(Door.Open)then return"Door Already open."end
	Door.Open = true
	Transform:Rotate(90)
end

function Door:Close()
	if(Door.Open==false)then return"Door Already Closed."end
	Door.Open = false
	Transform:Rotate(-90)
end

return Door