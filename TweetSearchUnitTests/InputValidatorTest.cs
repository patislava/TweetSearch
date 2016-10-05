using NUnit.Framework;
using TweetSearchWPF;

namespace TweetSearchUnitTests
{
    [TestFixture]
    public class InputValidatorTest
    {
        private IInputValidator _inputValidator;

        [SetUp]
        public void Init()
        {
            _inputValidator = new InputValidator();
        }

        [Test]
        public void ValidateCorrectInput()
        {
            bool shouldBeTrue = _inputValidator.Validate("#test");

            //NUnit.Framework.Assert.IsTrue(shouldBeTrue);
            NUnit.Framework.Assert.That(shouldBeTrue, Is.EqualTo(true));
        }

        [Test]
        public void ValidateInputWithoutHashtag()
        {
            bool shouldBeFalse = _inputValidator.Validate("test");

            //NUnit.Framework.Assert.IsFalse(shouldBeFalse);
            NUnit.Framework.Assert.That(shouldBeFalse, Is.EqualTo(false));
        }

        [Test]
        public void ValidateInputWithSpace()
        {
            bool shouldBeFalse = _inputValidator.Validate("# ");

            //NUnit.Framework.Assert.IsFalse(shouldBeFalse);
            NUnit.Framework.Assert.That(shouldBeFalse, Is.EqualTo(false));
        }


        [Test]
        public void ValidateInputHashtagInTheEnd()
        {
            bool shouldBeFalse = _inputValidator.Validate("test#");

            //NUnit.Framework.Assert.IsFalse(shouldBeFalse);
            NUnit.Framework.Assert.That(shouldBeFalse, Is.EqualTo(false));
        }

        [Test]
        public void ValidateInputSymbols()
        {
            bool shouldBeFalse = _inputValidator.Validate("#test%^&");

            //NUnit.Framework.Assert.IsFalse(shouldBeFalse);
            NUnit.Framework.Assert.That(shouldBeFalse, Is.EqualTo(false));
        }

        [Test]
        public void ValidateInputLength()
        {
            bool shouldBeFalse = _inputValidator.Validate(new string('t', 141));

            //NUnit.Framework.Assert.IsFalse(shouldBeFalse);
            NUnit.Framework.Assert.That(shouldBeFalse, Is.EqualTo(false));
        }


    }
}


