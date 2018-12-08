using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_postcardScript : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		postcardScript data = (postcardScript)obj;
		// Add your writer.Write calls here.
		writer.Write(data.useGUILayout);
		writer.Write(data.runInEditMode);
		writer.Write(data.enabled);
		writer.Write(data.tag);
		writer.Write(data.name);
		writer.Write(data.hideFlags);
		writer.Write(data.holidayWish01);
		writer.Write(data.holidayWish02);
		writer.Write(data.holidayWish03);
		writer.Write(data.beachRequired);
		writer.Write(data.wildernessRequired);
		writer.Write(data.cityRequired);
		writer.Write(data.snowRequired);
		writer.Write(data.woodlandRequired);
		writer.Write(data.cruiseRequired);
		writer.Write(data.funRequired);
		writer.Write(data.excitementRequired);
		writer.Write(data.romanceRequired);
		writer.Write(data.historicalRequired);
		writer.Write(data.relaxingRequired);
		writer.Write(data.cheapRequired);
		writer.Write(data.extravagantRequired);
		writer.Write(data.warmRequired);
		writer.Write(data.chillyRequired);
		writer.Write(data.finalBeachValue);
		writer.Write(data.finalWildernessValue);
		writer.Write(data.finalCityValue);
		writer.Write(data.finalSnowValue);
		writer.Write(data.finalWoodlandValue);
		writer.Write(data.finalCruiseValue);
		writer.Write(data.finalFunValue);
		writer.Write(data.finalExcitementValue);
		writer.Write(data.finalRomanceValue);
		writer.Write(data.finalHistoricalValue);
		writer.Write(data.finalRelaxingValue);
		writer.Write(data.finalCheapValue);
		writer.Write(data.finalExtravagantValue);
		writer.Write(data.finalWarmValue);
		writer.Write(data.finalChillyValue);
		writer.Write(data.holidayScoreTotal);
		writer.Write(data.holidayFeedbackPositive);
		writer.Write(data.holidayFeedbackNegative);
		writer.Write(data.postCardText);
		writer.Write(data.onHolidayImage);
		writer.Write(data.counterTimeLeft);
		writer.Write(data.counterOn);
		writer.Write(data.counterText);
		writer.Write(data.onHoliday);

	}
	
	public override object Read(ES2Reader reader)
	{
		postcardScript data = GetOrCreate<postcardScript>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		postcardScript data = (postcardScript)c;
		// Add your reader.Read calls here to read the data into the object.
		data.useGUILayout = reader.Read<System.Boolean>();
		data.runInEditMode = reader.Read<System.Boolean>();
		data.enabled = reader.Read<System.Boolean>();
		data.tag = reader.Read<System.String>();
		data.name = reader.Read<System.String>();
		data.hideFlags = reader.Read<UnityEngine.HideFlags>();
		data.holidayWish01 = reader.Read<System.Int32>();
		data.holidayWish02 = reader.Read<System.Int32>();
		data.holidayWish03 = reader.Read<System.Int32>();
		data.beachRequired = reader.Read<System.Boolean>();
		data.wildernessRequired = reader.Read<System.Boolean>();
		data.cityRequired = reader.Read<System.Boolean>();
		data.snowRequired = reader.Read<System.Boolean>();
		data.woodlandRequired = reader.Read<System.Boolean>();
		data.cruiseRequired = reader.Read<System.Boolean>();
		data.funRequired = reader.Read<System.Boolean>();
		data.excitementRequired = reader.Read<System.Boolean>();
		data.romanceRequired = reader.Read<System.Boolean>();
		data.historicalRequired = reader.Read<System.Boolean>();
		data.relaxingRequired = reader.Read<System.Boolean>();
		data.cheapRequired = reader.Read<System.Boolean>();
		data.extravagantRequired = reader.Read<System.Boolean>();
		data.warmRequired = reader.Read<System.Boolean>();
		data.chillyRequired = reader.Read<System.Boolean>();
		data.finalBeachValue = reader.Read<System.Int32>();
		data.finalWildernessValue = reader.Read<System.Int32>();
		data.finalCityValue = reader.Read<System.Int32>();
		data.finalSnowValue = reader.Read<System.Int32>();
		data.finalWoodlandValue = reader.Read<System.Int32>();
		data.finalCruiseValue = reader.Read<System.Int32>();
		data.finalFunValue = reader.Read<System.Int32>();
		data.finalExcitementValue = reader.Read<System.Int32>();
		data.finalRomanceValue = reader.Read<System.Int32>();
		data.finalHistoricalValue = reader.Read<System.Int32>();
		data.finalRelaxingValue = reader.Read<System.Int32>();
		data.finalCheapValue = reader.Read<System.Int32>();
		data.finalExtravagantValue = reader.Read<System.Int32>();
		data.finalWarmValue = reader.Read<System.Int32>();
		data.finalChillyValue = reader.Read<System.Int32>();
		data.holidayScoreTotal = reader.Read<System.Int32>();
		data.holidayFeedbackPositive = reader.Read<System.String>();
		data.holidayFeedbackNegative = reader.Read<System.String>();
		data.postCardText = reader.Read<UnityEngine.UI.Text>();
		data.onHolidayImage = reader.Read<UnityEngine.GameObject>();
		data.counterTimeLeft = reader.Read<System.Single>();
		data.counterOn = reader.Read<System.Boolean>();
		data.counterText = reader.Read<UnityEngine.UI.Text>();
		data.onHoliday = reader.Read<System.Boolean>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_postcardScript():base(typeof(postcardScript)){}
}