using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using TechTalk.SpecFlow;

namespace DeadPixels.Tests.Steps
{
    [Binding]
    public class DeadPixelsSteps
    {
        private readonly DeadPixels _deadPixels = new DeadPixels();
        private char[][] _pixels;

        [Given(@"the monitor pixels are (.*)")]
        public void GivenTheMonitorPixelsAre(char[][] pixels)
        {
            _pixels = pixels;
        }

        [Then(@"the group count should be (.*)")]
        public void ThenTheGroupCountShouldBe(int count)
        {
            Assert.AreEqual(count, _deadPixels.CountGroups(_pixels));
        }

        [Given(@"there is no monitor")]
        public void GivenThereIsNoMonitor()
        {
            _pixels = null;
        }

        [Given(@"the pixel count of the monitor is 0")]
        public void GivenThePixelCountOfTheMonitorIs()
        {
            _pixels = new char[1][] { new char[0] };
        }


        [Then(@"an ArgumentNullException should be thrown")]
        public void ThenAnArgumentNullExceptionShouldBeThrown()
        {
            bool thrown = false;
            try
            {
                _deadPixels.CountGroups(_pixels);
            }
            catch (ArgumentNullException)
            {
                thrown = true;
            }
            catch
            {
                // Ignores
            }

            Assert.IsTrue(thrown);
        }

        [Then(@"an ArgumentException should be thrown")]
        public void ThenAnArgumentExceptionShouldBeThrown()
        {
            bool thrown = false;
            try
            {
                _deadPixels.CountGroups(_pixels);
            }
            catch (ArgumentException)
            {
                thrown = true;
            }
            catch
            {
                // Ignores
            }

            Assert.IsTrue(thrown);
        }

        [StepArgumentTransformation]
        public char[][] TransformToCharMatrix(string pixels)
        {
            return JsonConvert.DeserializeObject<char[][]>($"[{pixels}]");
        }
    }
}
