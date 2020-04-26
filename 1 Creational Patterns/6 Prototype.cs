Prototype: Specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.

public static T DeepCopy<T>(this T source)
{
	if (Object.ReferenceEquals(source, null))
		return default(T);

	var serializeSettings = new JsonSerializerSettings
	{
		ObjectCreationHandling = ObjectCreationHandling.Replace,
		ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
		TypeNameHandling = TypeNameHandling.All
	};

	return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, serializeSettings), serializeSettings);
}