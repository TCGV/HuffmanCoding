using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tcgv.HuffmanCoding.UnitTest
{
    [TestClass]
    public class HuffmanEncoderTest
    {
        [TestMethod]
        public void EncodeAndDecodeTest()
        {
            var huff = new HuffmanEncoder();
            var output = huff.Encode(text);
            var decoded = huff.Decode(output);
            Assert.AreEqual(9744, output.Length);
            Assert.AreEqual(text, decoded);
        }

        private readonly string text = @"Bacon ipsum dolor amet shankle spare ribs bresaola, jowl ground round ham turkey capicola. Ground round andouille ham filet mignon beef pork loin pancetta porchetta picanha. Shank rump porchetta turkey leberkas, alcatra biltong burgdoggen fatback pork chop corned beef sirloin shankle. Shankle beef meatball bresaola buffalo biltong ham. Kevin spare ribs shoulder landjaeger sausage meatloaf turkey flank beef ribs biltong chuck cupim pancetta.

Meatloaf andouille pork cupim. Hamburger beef ribs meatloaf buffalo t-bone brisket chuck alcatra boudin prosciutto ball tip shankle filet mignon corned beef. Boudin andouille tongue spare ribs. Pork pig fatback, ham hock meatloaf pancetta chicken beef kevin. Filet mignon shankle kielbasa, tail ham beef ribs tenderloin sausage buffalo spare ribs prosciutto rump cow sirloin tongue. Swine pastrami ham hock, andouille fatback landjaeger buffalo leberkas. Bacon turkey leberkas tongue, meatloaf kielbasa jerky capicola cow alcatra fatback.

Salami turkey short loin, bacon doner pork belly beef ribs hamburger burgdoggen prosciutto cow meatball. Salami doner beef sirloin capicola ribeye. Sausage doner shoulder spare ribs drumstick sirloin ribeye. Sausage t-bone pork chop strip steak cow ham pork loin flank drumstick swine beef ribs doner brisket tri-tip. Filet mignon alcatra ball tip prosciutto.

Meatloaf filet mignon turducken tenderloin picanha leberkas ham hock meatball jerky biltong strip steak fatback flank bresaola. Meatball turducken ribeye prosciutto. Pig andouille t-bone boudin sirloin, fatback shank cow venison alcatra buffalo sausage prosciutto. Meatball buffalo pork loin tongue, shoulder ground round porchetta capicola. Burgdoggen sirloin shoulder kielbasa, capicola kevin tail pork chop andouille.

Boudin pastrami landjaeger frankfurter, shank tri-tip rump jerky. Pig alcatra tail ham, capicola sausage filet mignon. Tongue turducken biltong jerky hamburger bacon leberkas beef ribs. Sirloin drumstick pork chop biltong tail picanha bresaola.";
    }
}
