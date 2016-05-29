using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using ClassifierComponent.SerializationModels;

namespace ClassifierComponent
{
    public class Classifier
    {
        public string Password { get; private set; }
        public string Username { get; private set; }

        public string GetClassificationRawData(string sentence)
        {
            var returnValue = "";
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(@"http://localhost:50665/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var byteArray = Encoding.ASCII.GetBytes("b4949ffd-0f75-433a-8cda-3e1aaa75b91d:rLVfGY4ttyeh");
                var header = new AuthenticationHeaderValue(
                           "Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = header;

                var sentenceEncode = HttpUtility.UrlEncode(sentence);
                HttpResponseMessage response = client.GetAsync(String.Concat("https://gateway.watsonplatform.net/natural-language-classifier/api/v1/classifiers/3a84dfx64-nlc-18018/classify?text=", sentenceEncode)).Result;
                response.EnsureSuccessStatusCode();
                returnValue = ((HttpResponseMessage)response).Content.ReadAsStringAsync().Result;
            }
            return returnValue;

        }

        public Classifier WithPassword(string password)
        {
            Classifier result = (Classifier)MemberwiseClone();
            result.Password = password;
            return result;
        }

        public Classifier WithUsername(string username)
        {
            Classifier result = (Classifier)MemberwiseClone();
            result.Username = username;

            return result;  
        }


        public ClassifierClassRootObject GetClassification(string _sentence)
        {
            var result = new ClassificationResultsProcessor()
                .Process(GetClassificationRawData(_sentence));

            return result;
        }
    }











    //public class ClassificationsResult
    //{
    //    public IOrderedEnumerable<ClassificationDetails> RankedClassifications { get; internal set; }

    //    public ClassificationsResult FromRawData(string rawData, IClassificationResultsProcessor processor)
    //    {
    //        ClassificationsResult result = (ClassificationsResult)MemberwiseClone();
    //        result.RankedClassifications = processor.Process(rawData)
    //            .OrderBy(item => item.Confidence);

    //        return result;
    //    }
    //}

    //public class ClassificationDetails
    //{
    //    public float Confidence { get; set; }
    //    public string Name { get; set; }
    //}


}
