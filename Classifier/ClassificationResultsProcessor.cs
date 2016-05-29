using ClassifierComponent.SerializationModels;
using Newtonsoft.Json;

namespace ClassifierComponent
{
    public class ClassificationResultsProcessor : IClassificationResultsProcessor
    {
        public ClassifierClassRootObject Process(string rawData)
        {
            return JsonConvert.DeserializeObject<ClassifierClassRootObject>(rawData);
        }
    }

}
