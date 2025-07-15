namespace Jsoon.Tests
{
    public class JsoonTests
    {
        public class Person
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
        }

        [Fact]
        public void Serialize_ShouldReturnJsonString()
        {
            var obj = new Person { Name = "Rodrigo", Age = 35 };
            var json = Jsoon.Serialize(obj);

            Assert.Contains("\"name\"", json);
            Assert.Contains("\"age\"", json);
            Assert.Contains("Rodrigo", json);
        }

        [Fact]
        public void Deserialize_ShouldReturnObject()
        {
            var json = "{\"name\":\"Rodrigo\",\"age\":35}";
            var person = Jsoon.Deserialize<Person>(json);

            Assert.NotNull(person);
            Assert.Equal("Rodrigo", person!.Name);
            Assert.Equal(35, person.Age);
        }

        [Fact]
        public void Serialize_NullObject_ShouldReturnStringNull()
        {
            var result = Jsoon.Serialize<object>(null!);
            Assert.Equal("null", result);
        }

        [Fact]
        public void Deserialize_InvalidJson_ShouldThrowException()
        {
            string invalidJson = "{ invalid json }";
            Assert.Throws<JsonSerializerException>(() => Jsoon.Deserialize<Person>(invalidJson));
        }

        [Fact]
        public void Deserialize_EmptyJson_ShouldThrowException()
        {
            string emptyJson = "";
            Assert.Throws<JsonSerializerException>(() => Jsoon.Deserialize<Person>(emptyJson));
        }

        [Fact]
        public void Deserialize_TypeNull_ShouldThrowException()
        {
            string json = "{\"name\":\"Rodrigo\",\"age\":35}";
            Assert.Throws<JsonSerializerException>(() => Jsoon.Deserialize(json, null!));
        }

        [Fact]
        public void Serialize_UnsupportedType_ShouldThrowException()
        {
            Assert.Throws<JsonSerializerException>(() => Jsoon.Serialize(System.Console.Out));
        }
    }
}