using ClassifierComponent.SerializationModels;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;


namespace ClassifierComponent.specs
{
    [Binding]
    public class DownloadingSomeDataSteps
    {
        private string _username;
        private string _password;
        private string _sentence;
        private string _classificationRawResult;
  
        private ClassifierClassRootObject _serializedClassificationResult;

        [Given(@"I use the username ""(.*)""")]
        public void GivenIUseTheUsername(string username)
        {
            _username = username;
        }

        [Given(@"I use the password ""(.*)""")]
        public void GivenIUseThePassword(string password)
        {
            _password = password;
        }

        [Given(@"I use the sentence ""(.*)""")]
        public void GivenIUseTheSentence(string sentence)
        {
            _sentence = sentence;
        }

        [When(@"I call the service")]
        public void WhenICallTheService()
        {
            _classificationRawResult = new Classifier()
                .WithUsername(_username)
                .WithPassword(_password)
                .GetClassificationRawData(_sentence);
        }

        [Then(@"I should retrieve some data")]
        public void ThenIShouldRetrieveSomeData()
        {
            Assert.IsFalse(String.IsNullOrWhiteSpace(_classificationRawResult));
        }


        [When(@"I request a classification")]
        public void WhenIRequestAClassification()
        {
            _serializedClassificationResult = new Classifier()
                 .WithUsername(_username)
                 .WithPassword(_password)
                 .GetClassification(_sentence);
        }

        [Then(@"the returned classification will be ""(.*)""")]
        public void ThenTheReturnedClassificationWillBe(string expectedClassification)
        {
            Assert.AreEqual(expectedClassification, _serializedClassificationResult.top_class);
        }

    }
}
