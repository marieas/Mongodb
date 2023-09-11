namespace MongoDdWriteModel
{
    using MongoDB.Driver;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using System.Collections;

    internal class MongoConnection
    {
        MongoClient DbClient { get; set; }
        RandomGenerator RandomGenerator { get; set; }

        public MongoConnection()
        {
            RandomGenerator = new();
            MongoUrl url = new MongoUrl("mongodb://localhost:27017");
            DbClient = new MongoClient(url);
            //BsonClassMap.RegisterClassMap<Student>(classMap =>
            //{
            //    classMap.AutoMap();               
            //});
            //BsonClassMap.RegisterClassMap<Address>(classMap =>
            //{
            //    classMap.AutoMap();                
            //});
            PrintAvailableDbs();
            //UpdatePhoneNums();
            ReadDocuments();
            //InsertDataToCollection("Students");
        }

        private void ReadDocuments()
        {
            var database = DbClient.GetDatabase("GetAcademy");
            var collection = database.GetCollection<Student>("Students");
            var filter = Builders<Student>.Filter.Eq(student => student.Address.Municipality, "Vestfold og Telemark");
            var doc = collection.Find(filter);
            var elements = doc.ToList();
            elements.ForEach((elem) =>
            {
                Console.Write($"{elem.Name} \n");
            });
        }
        private void UpdatePhoneNums()
        {
            var database = DbClient.GetDatabase("GetAcademy");
            var collection = database.GetCollection<Student>("Students");

            var filter = Builders<Student>.Filter.Eq(student => student.Address.Municipality, "Nordland");
            var update = Builders<Student>.Update.Set(student => student.PhoneNr, "43789523");

            collection.UpdateMany(filter, update);

        }
        private void PrintAvailableDbs()
        {
            var databases = DbClient.ListDatabaseNames().ToList();
            databases.ForEach((db)=> {
                Console.WriteLine($"Database: {db}");
                });
        }

        private async Task InsertDataToCollection(string collectionName)
        {
            var database = DbClient.GetDatabase("GetAcademy");
            var collection = database.GetCollection<Student>(collectionName);
            var students = RandomGenerator.CreateAndReturnRandomStudents();
            collection.InsertMany(students);
            //students.ForEach(async (student) =>
            //{  
            //        await collection.InsertOneAsync(student);
            //        var json = student.ToJson();
            //        //Console.WriteLine("Dok insert" + json);             
            //});            
        }
       
    }
}
