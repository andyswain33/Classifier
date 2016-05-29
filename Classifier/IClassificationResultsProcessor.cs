using ClassifierComponent.SerializationModels;

namespace ClassifierComponent
{
    public interface IClassificationResultsProcessor
    {
        ClassifierClassRootObject Process(string rawData);
    }
}