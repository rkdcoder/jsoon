using System.Text.Json;

namespace Jsoon
{
    /// <summary>
    /// Provides standardized, opinionated JSON serialization and deserialization for .NET, 
    /// using recommended <see cref="System.Text.Json"/> options: camelCase properties, 
    /// case-insensitive matching, and null value ignore.
    /// </summary>
    public static class Serializer
    {
        private static readonly JsonSerializerOptions _defaultOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        /// <summary>
        /// Serializes an object to a JSON string using Jsoon's standard options.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The JSON string representation of the object.</returns>
        /// <exception cref="JsonSerializerException">
        /// Thrown when the object cannot be serialized for any reason (unsupported types, invalid structure, etc).
        /// </exception>
        public static string Serialize<T>(T obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj, _defaultOptions);
            }
            catch (Exception ex)
            {
                throw new JsonSerializerException("An error occurred during serialization.", ex);
            }
        }

        /// <summary>
        /// Deserializes a JSON string to the specified type using Jsoon's standard options.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized object, or <c>null</c> if the input is null or empty.</returns>
        /// <exception cref="JsonSerializerException">
        /// Thrown when the JSON cannot be deserialized to the specified type.
        /// </exception>
        public static T? Deserialize<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json, _defaultOptions);
            }
            catch (Exception ex)
            {
                throw new JsonSerializerException("An error occurred during deserialization.", ex);
            }
        }

        /// <summary>
        /// Deserializes a JSON string to a specified runtime type using Jsoon's standard options.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <param name="type">The target runtime type.</param>
        /// <returns>The deserialized object, or <c>null</c> if the input is null or empty.</returns>
        /// <exception cref="JsonSerializerException">
        /// Thrown when the JSON cannot be deserialized to the specified type.
        /// </exception>
        public static object? Deserialize(string json, Type type)
        {
            try
            {
                return JsonSerializer.Deserialize(json, type, _defaultOptions);
            }
            catch (Exception ex)
            {
                throw new JsonSerializerException("An error occurred during deserialization.", ex);
            }
        }
    }
}