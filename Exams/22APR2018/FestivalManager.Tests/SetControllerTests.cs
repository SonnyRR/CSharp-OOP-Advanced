
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void PerformSets_ShouldNotPerformEmptySets()
        {
            IStage stage = new Stage();
            ISetController controller = new SetController(stage);

            ISet set = new Long("Set1");
            stage.AddSet(set);

            string actualResult = controller.PerformSets();
            string expectedResultShouldNotEndWith = "Did not perform";

            Assert.That(actualResult, Is.EqualTo("1. Set1:\r\n-- Did not perform"));
        }

        [Test]
        public void PerformSets_ShouldPerformValidSets()
        {
            IStage stage = new Stage();
            ISetController controller = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

            IPerformer performer = new Performer("Sonny", 22);
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer);

            ISong song = new Song("Song", new TimeSpan(0, 3, 24));
            set.AddSong(song);

            string actualOutput = controller.PerformSets();
            string shouldEndWith = "1. Set1:\r\n-- 1. Song (03:24)\r\n-- Set Successful";

            Assert.That(actualOutput, Is.EqualTo(shouldEndWith));
        }

        [Test]
        public void PerformSets_WearDownTest()
        {
            IStage stage = new Stage();
            ISetController controller = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

            IPerformer performer = new Performer("Sonny", 22);
            IInstrument guitar = new Guitar();
            performer.AddInstrument(guitar);
            set.AddPerformer(performer);

            ISong song = new Song("Song", new TimeSpan(0, 3, 24));
            set.AddSong(song);

            var wearBeforeWearDown = guitar.Wear;
            controller.PerformSets();
            var afterWearDownWear = guitar.Wear;

            Assert.That(wearBeforeWearDown, Is.Not.EqualTo(afterWearDownWear));

        }
    }
}