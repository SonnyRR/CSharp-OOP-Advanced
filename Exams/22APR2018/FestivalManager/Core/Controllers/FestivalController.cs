namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Factories.Contracts;
    using Entities.Factories;
    using Entities.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";

        private ISetFactory setFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;
        private IInstrumentFactory instrumentFactory;

        private readonly IStage stage;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            setFactory = new SetFactory();
            performerFactory = new PerformerFactory();
            songFactory = new SongFactory();
            instrumentFactory = new InstrumentFactory();
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            //"mm\\:ss";
            result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }

        private string FormatTime(TimeSpan totalFestivalLength)
        {
            //return totalFestivalLength.ToString(TimeFormat);
            return $"{(int)totalFestivalLength.TotalMinutes:d2}:{(int)totalFestivalLength.Seconds:d2}";
        }

        public string RegisterSet(string[] args)
        {
            string venueName = args[0];
            string venueType = args[1];

            ISet set = setFactory.CreateSet(venueName, venueType);
            this.stage.AddSet(set);

            return $"Registered {venueType} set";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var intstrumentsNames = args.Skip(2).ToArray();

            var instruments = intstrumentsNames
                .Select(t => this.instrumentFactory.CreateInstrument(t))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            // TODO: scheduled for next month

            var songName = args[0];
            var songDurationAsText = args[1];
            TimeSpan actualDuration = TimeSpan.ParseExact(songDurationAsText, TimeFormat, CultureInfo.InvariantCulture);

            ISong song = this.songFactory.CreateSong(songName, actualDuration);

            this.stage.AddSong(song);

            return $"Registered song {song}";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }

        // Временно!!! Чтобы работало делаем срез на конец месяца
        //public string AddPerformerToSet(string[] args)
        //{
        //    return PerformerRegistration(args);
        //}

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);
            set.AddPerformer(performer);


            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}