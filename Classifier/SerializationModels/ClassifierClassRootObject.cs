using System.Collections.Generic;

namespace ClassifierComponent.SerializationModels
{
    public class ClassifierClassRootObject
    {   
        public string classifier_id { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public string top_class { get; set; }
        public List<ClassifierResultClass> classes { get; set; }
    }
}
