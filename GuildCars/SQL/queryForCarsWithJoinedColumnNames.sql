use GuildCars

select VehicleId, 
		Make.MakeId,
		Model, 
		[Type].TypeId, 
		BodyStyle.BodyStyle, 
		[Year], 
		Transmission.TransmissionType, 
		Color.Color,
		--interior color,
		Mileage,
		VIN,
		MSRP,
		SalePrice,
		[Description],
		PictureFilePath,
		IsFeature
		 
from Vehicle

join Make
	on Vehicle.MakeId = Make.MakeId
join [Type]
	on Vehicle.TypeId = [Type].TypeId
join BodyStyle
	on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
join Transmission
	on Vehicle.TransmissionId = Transmission.TransmissionId
join Color  
	on Vehicle.ColorId = Color.ColorId
--need to add interior color

select VehicleId, 
		Make.Make,
		Vehicle.MakeId,
		Model, 
		Vehicle.TypeId,
		[Type].NewOrUsed,
		Vehicle.TypeId, 
		BodyStyle.BodyStyle,
		Vehicle.BodyStyleId, 
		[Year], 
		Vehicle.TransmissionId,
		Transmission.TransmissionType,
		Color.Color,
		--Vehicle.ColorId,
		--Vehicle.InteriorId,
		Mileage,
		VIN,
		MSRP,
		SalePrice,
		[Description],
		PictureFilePath,
		IsFeature
		 
from Vehicle

join Make
	on Vehicle.MakeId = make.MakeId
join [Type]
	on Vehicle.TypeId = [Type].TypeId
join BodyStyle
	on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
join Transmission
	on Vehicle.TransmissionId = Transmission.TransmissionId
join Color 
	on Vehicle.ColorId = Color.ColorId
--join Color as Color2
--	on Vehicle.InteriorId = Color2.ColorId
--need to add interior color
	--TO JOIN INTERIOR AND COLOR, BOTH COLOR AND VEHICLE NEED TO SHARE AN INTERIOR ID 


