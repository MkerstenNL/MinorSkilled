--TransformComponent = this:AddCompoment("Transform")
--Assert(TransformComponent!=nil)
--AttachedComponents{}
--CsharpFile = nil
x = 0
y = 0
z = 0
GameObject = nil

--Gets Called From Engine on start of script
function Start()
	--x, y, z = cSharp:GetPosition ()
	pos = cSharp:GetPosition ()
	x,y,z = table.unpack(pos)
	cSharp:Log(cSharp:GetPosition())
	--x,y,z = table.unpack(pos)
	cSharp:Log (x)
	cSharp:Log (y)
	cSharp:Log (z)


--start call

end

--gets called once per fram
function Update()
--object logic
end

function OntriggerEnter()
--Gets Called when it hits a trigger
end