
message = NewComponent ("Transform")


function NewComponent (name)
	print(name)
	
	if(type(name)=="string")then
		--local comp = Components[name]
		--if(comp~=nil)then
		--	return "component Already exists"
		--else
		--GameObjectC.NewScript (name)
		return "Succes"
		--end
	else
		return "NewComponent expects a string"
	end
end