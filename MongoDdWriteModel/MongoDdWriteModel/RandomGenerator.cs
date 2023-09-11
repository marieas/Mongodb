using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MongoDdWriteModel
{
    internal class RandomGenerator
    {
        Random Rand { get; set; }
        List<string> AvailableMunicipalitys { get; set; }
        public RandomGenerator()
        {
            Rand = new();
            AvailableMunicipalitys = new List<string>() { "Vestfold og Telemark",
                "Oslo", "Møre og Romsdal", "Rogaland", "Viken",
                "Nordland", "Agder", "Vestland", "Trøndelag",
                "Troms og Finnmark", "Innlandet" };
            
        }
        public List<Student> CreateAndReturnRandomStudents()
        {
            var students = new List<Student>();
            for (int i = 0; i < 50; i++)
            {
                students.Add(new Student(CreateNewName(), CreateNewAddress()));
            }
            return students;
        }
        private string CreateNewName()
        {          
            string firstName = GetRandListOfCharacters(5,10);
            string lastName = GetRandListOfCharacters(7, 14); ;
       
            return $"{ firstName} {lastName}";
        }
        private string CreateNewAddress()
        {
            string streetName = GetRandListOfCharacters(10, 20);
            int areaCode = GetRandomAreaCode();
            var munipicipality = GetRandMunicipality();
           
            return $"{streetName},{munipicipality},{areaCode}";
        }
        private string GetRandListOfCharacters(int min, int max)
        {
            int numberOfCharacters = Rand.Next(min, max);
            string randString = "";
            for (int i = 0; i <= numberOfCharacters; i++)
            {               
                if(i == 0)
                {
                    randString += (char)Rand.Next(65, 90);
                }
                randString += (char)Rand.Next(98, 122);
            }            

            return randString;
        }
        private string GetRandMunicipality()
        {
            var rand = Rand.Next(0, AvailableMunicipalitys.Count - 1);
            return AvailableMunicipalitys[rand];
        }
        private int GetRandomAreaCode()
        {
            return Rand.Next(1000, 5097);
        }
    }
}
