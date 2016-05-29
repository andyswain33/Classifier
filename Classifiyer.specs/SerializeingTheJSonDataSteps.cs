using ClassifierComponent;
using TechTalk.SpecFlow;
using NUnit.Framework;
using ClassifierComponent.SerializationModels;

namespace ClassifierComponentIntegration.specs
{
    [Binding]
    public class SerializeingTheJSonDataSteps
    {
        private string _jsonString;
        private ClassifierClassRootObject _classificationResult;

        [Given(@"I have a example Json string")]
        public void GivenIHaveAValidJsonString()
        {
            _jsonString = "{ \"classifier_id\" : \"3a84dfx64-nlc-18018\", \"url\" : \"https://gateway.watsonplatform.net/natural-language-classifier/api/v1/classifiers/3a84dfx64-nlc-18018\", \"text\" : \"Is it going to rain today?\", \"top_class\" : \"conditions\", \"classes\" : [ { \"class_name\" : \"conditions\", \"confidence\" : 0.9935744855576073 }, { \"class_name\" : \"temperature\", \"confidence\" : 0.006425514442392742 } ] }";
        }

        [Given(@"I have a real Json string")]
        public void GivenIHaveARealJsonString()
        {
            // really this data should come from config. I'm aware that hard coded strings are bad practice.
            _jsonString = new Classifier()
                 .WithUsername("b4949ffd-0f75-433a-8cda-3e1aaa75b91d")
                 .WithPassword("rLVfGY4ttyeh")
                 .GetClassificationRawData("will it rain today?");
        }


        [When(@"I process the data")]
        public void WhenIProcessTheData()
        {
            _classificationResult = new ClassificationResultsProcessor().Process(_jsonString);
        }

        [Then(@"A sertialized result model will be created")]
        public void ThenASertializedResultModelWillBeCreated()
        {
            Assert.IsNotNull(_classificationResult, "It seems that model was not created from the JSon Data.");
        }

        [Then(@"the model will have some content")]
        public void ThenTheModelWillHaveSomeContent()
        {
            Assert.Greater(_classificationResult.classes.Count, 0, "Processor results appear to be empty");
        }

    }
}
