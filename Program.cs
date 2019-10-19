using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using AnswerCodenation;
using Newtonsoft.Json;
using Utils;

namespace codenation_criptografia_kroton
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            AnswerRepository requestCodenation = new AnswerRepository("https://api.codenation.dev/v1/challenge/dev-ps/");
            var generateDataObjectAux = await requestCodenation.GetGenerateDatatAsync<Answer>("5a75c604c522ee723768438b45e9b7b86d8b7145");
            FileHandling.SaveFileJsonObject("answer", generateDataObjectAux);
        
            Answer generateDataObject = FileHandling.OpenFileJsonObject<Answer>("answer");

            int descryptionInterval = generateDataObject.numero_casas;
            string textToDescrypt = generateDataObject.cifrado;
            generateDataObject.decifrado = DescryptCodenation.JulioCesarDescryptionTool(textToDescrypt, descryptionInterval);
            generateDataObject.resumo_criptografico = DescryptCodenation.ConvertSHA1(generateDataObject.decifrado);

            FileHandling.SaveFileJsonObject("answer", generateDataObject);

            System.Console.WriteLine(generateDataObject);
        }
    }
}
