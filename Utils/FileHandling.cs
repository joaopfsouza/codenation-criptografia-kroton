using System.IO;
using Newtonsoft.Json;

namespace Utils
{
   static class FileHandling
    {
       static public bool SaveStringInFileJson(string nameFile, string stringJson)
        {

            string nameFileJson = nameFile + ".json";
            string json = JsonConvert.SerializeObject(stringJson,Formatting.Indented);
            using (Stream file = File.Open(nameFileJson, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(json);
                }

            }
            return File.Exists(nameFileJson);
        }

        static public TObject OpenFileJsonObject<TObject>(string nameFile){
            string nameFileJson = nameFile + ".json";
            return JsonConvert.DeserializeObject<TObject>(File.ReadAllText(nameFileJson));
            
        }

        static public void SaveFileJsonObject<TObject>(string nameFile,TObject objectToSerialize){
            string nameFileJson = nameFile + ".json";
            File.WriteAllText(nameFileJson, JsonConvert.SerializeObject(objectToSerialize,Formatting.Indented));
            
            
        }
    }
}