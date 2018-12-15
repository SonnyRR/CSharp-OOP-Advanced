namespace _08.Pet_clinics
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Clinic : IEquatable<Clinic>
    {

        public Clinic(string name, int rooms)
        {
            this.Name = name;
            this.Rooms = rooms;
            this.accommodationStartIndex = (int)Math.Round((this.rooms.Length / 2.0), MidpointRounding.AwayFromZero);
            this.leftSearch = true;
            this.releaseDirection = true;
        }

        private Pet[] rooms;
        private int accommodationStartIndex;
        private bool leftSearch;
        private bool releaseDirection;
        public string Name { get; set; }


        public int Rooms
        {
            get { return rooms.Length; }

            private set
            {
                if (value % 2 == 0)
                {
                    throw new InvalidOperationException("Invalid Operation!");
                }

                this.rooms = new Pet[value];
            }
        }

        public bool Add(Pet pet)
        {
            int emptyRoom = this.FindEmptyRoom();

            if (emptyRoom != -1)
            {
                this.rooms[emptyRoom] = pet;
            }

            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return true;
        }

        public Pet Release()
        {
            bool wasAPetReleased = false;
            Pet currentPet = null;

            if (this.releaseDirection)
            {
                for (int i = this.accommodationStartIndex; i < this.rooms.Length; i++)
                {
                    if (this.rooms[i] != null)
                    {
                        wasAPetReleased = true;
                        currentPet = this.rooms[i];
                    }

                    if (i == this.rooms.Length - 1)
                    {
                        this.releaseDirection = false;
                    }

                    if (wasAPetReleased)
                        break;
                }
            }


            else if (this.releaseDirection == false)
            {
                for (int i = 0; i < this.accommodationStartIndex; i++)
                {
                    if (this.rooms[i] != null)
                    {
                        wasAPetReleased = true;
                        currentPet = this.rooms[i];
                    }
                    if (wasAPetReleased)
                        break;
                }
            }

            return currentPet;

        }
        private int FindEmptyRoom()
        {
            int index = -1;

            if (leftSearch == true)
            {
                for (int i = this.accommodationStartIndex; i >= this.rooms.Length; i--)
                {
                    if (this.rooms[i] == null)
                    {
                        index = i;
                        this.leftSearch = false;
                        break;
                    }
                }
            }

            else
            {
                for (int i = this.accommodationStartIndex; i < this.rooms.Length; i++)
                {
                    if (this.rooms[i] == null)
                    {
                        index = i;
                        this.leftSearch = true;
                        break;
                    }
                }
            }

            return index;
        }
        public bool Equals(Clinic other)
        {
            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
