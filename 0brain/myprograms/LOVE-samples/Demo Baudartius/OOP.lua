local OOP = {}
local classMetatables = {}

local function class_new(self, ...)
	return self:__init(...)
end

local DefaultBase = {}
function DefaultBase:__init(t) return setmetatable(t or {},self) end

--- Creates a new class.
function OOP:Class(base)
	-- Default to the default base class
	base = base or DefaultBase
	
	-- Retrieve the class' metatable from the cache, or make a new one
	local mt
	if classMetatables[base] then
		mt = classMetatables[base]
	else
		mt = {}
		mt.__index = base
		mt.__call = class_new
		classMetatables[base] = mt
	end
	
	-- Make the actual class
	local cls = setmetatable({}, mt)
	
	if not base.__index or base.__index == base then
		-- __index unmodified, set __index to class
		cls.__index = cls
	else
		-- __index modified, inherit it
		cls.__index = base.__index
	end
	
	return cls, base
end

--- Returns the class of object v
function OOP:ClassOf(v)
	return getmetatable(v)
end

--- Returns the superclass of class c.
-- Note: This returns nil if the object's super class is the default super class
-- (i.e. nothing was passed to Class())
function OOP:SuperClass(c)
	local super = getmetatable(c).__index
	if super == DefaultBase then
		return nil
	else
		return super
	end
end
return OOP