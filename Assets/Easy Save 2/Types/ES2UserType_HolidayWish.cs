using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_HolidayWish : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		HolidayWish data = (HolidayWish)obj;
		// Add your writer.Write calls here.
		writer.Write(data.wishID);
		writer.Write(data.stampName);
		writer.Write(data.type);
		writer.Write(data.beachRequirement);
		writer.Write(data.wildernessRequirement);
		writer.Write(data.cityRequirement);
		writer.Write(data.snowRequirement);
		writer.Write(data.woodlandRequirement);
		writer.Write(data.cruiseRequirement);
		writer.Write(data.funRequirement);
		writer.Write(data.excitementRequirement);
		writer.Write(data.romanceRequirement);
		writer.Write(data.historicalRequirement);
		writer.Write(data.relaxingRequirement);
		writer.Write(data.cheapRequirement);
		writer.Write(data.extravagantRequirement);
		writer.Write(data.warmRequirement);
		writer.Write(data.chillyRequirement);

	}
	
	public override object Read(ES2Reader reader)
	{
		HolidayWish data = new HolidayWish();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		HolidayWish data = (HolidayWish)c;
		// Add your reader.Read calls here to read the data into the object.
		data.wishID = reader.Read<System.String>();
		data.stampName = reader.Read<System.String>();
		data.type = reader.Read<System.String>();
		data.beachRequirement = reader.Read<System.Int32>();
		data.wildernessRequirement = reader.Read<System.Int32>();
		data.cityRequirement = reader.Read<System.Int32>();
		data.snowRequirement = reader.Read<System.Int32>();
		data.woodlandRequirement = reader.Read<System.Int32>();
		data.cruiseRequirement = reader.Read<System.Int32>();
		data.funRequirement = reader.Read<System.Int32>();
		data.excitementRequirement = reader.Read<System.Int32>();
		data.romanceRequirement = reader.Read<System.Int32>();
		data.historicalRequirement = reader.Read<System.Int32>();
		data.relaxingRequirement = reader.Read<System.Int32>();
		data.cheapRequirement = reader.Read<System.Int32>();
		data.extravagantRequirement = reader.Read<System.Int32>();
		data.warmRequirement = reader.Read<System.Int32>();
		data.chillyRequirement = reader.Read<System.Int32>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_HolidayWish():base(typeof(HolidayWish)){}
}