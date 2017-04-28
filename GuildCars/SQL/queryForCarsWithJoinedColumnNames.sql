select VehicleId, 
		Make.MakeName,
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
	on Vehicle.MakeId = make.MakeId
join [Type]
	on Vehicle.TypeId = [Type].TypeId
join BodyStyle
	on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
join Transmission
	on Vehicle.TransmissionId = Transmission.TransmissionId
join Color  
	on Vehicle.ColorId = Color.ColorId
--need to add interior color

